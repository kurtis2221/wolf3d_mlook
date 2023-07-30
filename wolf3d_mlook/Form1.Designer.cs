namespace wolf3d_mlook
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_game = new System.Windows.Forms.ComboBox();
            this.tmr_game = new System.Windows.Forms.Timer(this.components);
            this.tb_dosbox_base = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_dosbox_base = new System.Windows.Forms.Button();
            this.tb_dosbox_exe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game/Mod:";
            // 
            // cb_game
            // 
            this.cb_game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_game.FormattingEnabled = true;
            this.cb_game.Location = new System.Drawing.Point(110, 12);
            this.cb_game.Name = "cb_game";
            this.cb_game.Size = new System.Drawing.Size(268, 28);
            this.cb_game.TabIndex = 1;
            this.cb_game.SelectedIndexChanged += new System.EventHandler(this.cb_game_SelectedIndexChanged);
            // 
            // tmr_game
            // 
            this.tmr_game.Enabled = true;
            this.tmr_game.Tick += new System.EventHandler(this.tmr_game_Tick);
            // 
            // tb_dosbox_base
            // 
            this.tb_dosbox_base.Location = new System.Drawing.Point(181, 100);
            this.tb_dosbox_base.Name = "tb_dosbox_base";
            this.tb_dosbox_base.Size = new System.Drawing.Size(197, 26);
            this.tb_dosbox_base.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "DOSBox base pointer";
            // 
            // bt_dosbox_base
            // 
            this.bt_dosbox_base.Location = new System.Drawing.Point(181, 164);
            this.bt_dosbox_base.Name = "bt_dosbox_base";
            this.bt_dosbox_base.Size = new System.Drawing.Size(197, 31);
            this.bt_dosbox_base.TabIndex = 4;
            this.bt_dosbox_base.Text = "Apply";
            this.bt_dosbox_base.UseVisualStyleBackColor = true;
            this.bt_dosbox_base.Click += new System.EventHandler(this.bt_dosbox_base_Click);
            // 
            // tb_dosbox_exe
            // 
            this.tb_dosbox_exe.Location = new System.Drawing.Point(181, 132);
            this.tb_dosbox_exe.Name = "tb_dosbox_exe";
            this.tb_dosbox_exe.Size = new System.Drawing.Size(197, 26);
            this.tb_dosbox_exe.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "DOSBox exe name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Leave these empty if it works:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 207);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_dosbox_base);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_dosbox_exe);
            this.Controls.Add(this.tb_dosbox_base);
            this.Controls.Add(this.cb_game);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wolfenstein 3D Mouselook for DOSBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_game;
        private System.Windows.Forms.Timer tmr_game;
        private System.Windows.Forms.TextBox tb_dosbox_base;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_dosbox_base;
        private System.Windows.Forms.TextBox tb_dosbox_exe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;






    }
}

