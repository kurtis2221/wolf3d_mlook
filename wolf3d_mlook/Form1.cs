using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace wolf3d_mlook
{
    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public Int32 X;
            public Int32 Y;
        }

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT point);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private string dosbox_exe = "DOSBox";
        private Process proc;

        private MemoryEdit.Memory mem;
        private GlobalLowLevelHooks.MouseHook gmh;
        private KeyHook.GlobalKeyboardHook gkh;
        private int old_x;
        private bool lock_mouse;
        private bool focused;

        //Memory addresses, offsets
        private uint dosbox_baseaddr = 0x01D3C370;
        private uint[] wolf3d_offsets =
        {
            0x44264, //Wolf3d v1.1
            0x46836, //Wolf3d v1.4
            0x441D4, //Spear v1.4
            0x45E42, //SpearRes
            0x3C3F8, //SpearEoD
            0x4AB31  //T3D
        };
        private uint wolf3d_offset;

        private string[] game_names =
        {
            "Wolfenstein 3D v1.1",
            "Wolfenstein 3D v1.4",
            "Spear of Destinity v1.4",
            "Spear Resurrection",
            "Spear End of Destinity",
            "Tristania 3D"
        };

        public Form1()
        {
            InitializeComponent();
            cb_game.Items.AddRange(game_names);
            cb_game.SelectedIndex = 0;
            //Memory manipulation
            mem = new MemoryEdit.Memory();
            //
            gkh = new KeyHook.GlobalKeyboardHook();
            gkh.Hook();
            gkh.KeyDown += gkh_KeyDown;
            gkh.KeyUp += gkh_KeyUp;
            //
            gmh = new GlobalLowLevelHooks.MouseHook();
            gmh.Install();
            gmh.LeftButtonDown += gmh_LeftButtonDown;
            gmh.LeftButtonUp += gmh_LeftButtonUp;
            gmh.MouseMove += gmh_MouseMove;
        }

        //Mouse events

        //Mouse left click
        private void gmh_LeftButtonUp(GlobalLowLevelHooks.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (!lock_mouse || !focused) return;
            //CTRL release
            keybd_event((byte)0xA2, 0x0, 2, 0);
        }

        private void gmh_LeftButtonDown(GlobalLowLevelHooks.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (!lock_mouse || !focused) return;
            //CTRL hold
            keybd_event((byte)0xA2, 0x0, 0, 0);
        }

        //Mouse movement
        private void gmh_MouseMove(GlobalLowLevelHooks.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (!lock_mouse || !focused) return;
            int x = mouseStruct.pt.x;
            int delta = old_x - x;
            uint ptr = (uint)mem.Read(dosbox_baseaddr) + wolf3d_offset;
            int angle = mem.Read(ptr);
            angle += delta;
            angle %= 360;
            if (angle < 0) angle += 360;
            byte[] buffer = BitConverter.GetBytes(angle);
            mem.WriteBytes(ptr, buffer, 4);
        }

        //Keyboard events

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (!focused) return;
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.B)
            {
                POINT pt;
                GetCursorPos(out pt);
                old_x = pt.X;
                lock_mouse = !lock_mouse;
            }
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            if (!focused && lock_mouse) return;
            if (e.Modifiers == Keys.Alt)
            {
                //ALT hold
                keybd_event((byte)0xA4, 0x0, 0, 0);
            }
        }

        private void tmr_game_Tick(object sender, EventArgs e)
        {
            focused = mem.IsFocused();
            if (proc != null && !proc.HasExited) return;
            mem.Detach();
            Process[] tmp = Process.GetProcessesByName(dosbox_exe);
            if (tmp.Length == 0) return;
            proc = tmp[0];
            mem.Attach((uint)proc.Id, MemoryEdit.Memory.ProcessAccessFlags.All);
        }

        private void cb_game_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cb_game.SelectedIndex;
            if (idx < 0 || idx > wolf3d_offsets.Length) return;
            wolf3d_offset = wolf3d_offsets[idx];
        }

        private void bt_dosbox_base_Click(object sender, EventArgs e)
        {
            if (tb_dosbox_base.Text.Length > 0)
                dosbox_baseaddr = uint.Parse(tb_dosbox_base.Text, System.Globalization.NumberStyles.HexNumber);
            if (tb_dosbox_exe.Text.Length > 0)
                dosbox_exe = tb_dosbox_exe.Text;
        }
    }
}