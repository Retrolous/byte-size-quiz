
namespace Petkunas__Lukas___Byte_size_Quiz
{
    partial class frmMainMenu
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
            this.btnTask1 = new System.Windows.Forms.Button();
            this.btnTask2 = new System.Windows.Forms.Button();
            this.btnTask3 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnStaffMenu = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblToolbarTitle = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblScore1 = new System.Windows.Forms.Label();
            this.lblScore2 = new System.Windows.Forms.Label();
            this.lblScore3 = new System.Windows.Forms.Label();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTask1
            // 
            this.btnTask1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnTask1.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnTask1.ForeColor = System.Drawing.Color.SkyBlue;
            this.btnTask1.Location = new System.Drawing.Point(12, 70);
            this.btnTask1.Name = "btnTask1";
            this.btnTask1.Size = new System.Drawing.Size(165, 263);
            this.btnTask1.TabIndex = 0;
            this.btnTask1.Text = "Compile and Conquer";
            this.btnTask1.UseVisualStyleBackColor = false;
            this.btnTask1.Click += new System.EventHandler(this.btnTask1_Click);
            // 
            // btnTask2
            // 
            this.btnTask2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnTask2.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnTask2.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnTask2.Location = new System.Drawing.Point(193, 70);
            this.btnTask2.Name = "btnTask2";
            this.btnTask2.Size = new System.Drawing.Size(165, 263);
            this.btnTask2.TabIndex = 1;
            this.btnTask2.Text = "Bit-wise up";
            this.btnTask2.UseVisualStyleBackColor = false;
            this.btnTask2.Click += new System.EventHandler(this.btnTask2_Click);
            // 
            // btnTask3
            // 
            this.btnTask3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnTask3.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnTask3.ForeColor = System.Drawing.Color.Red;
            this.btnTask3.Location = new System.Drawing.Point(375, 70);
            this.btnTask3.Name = "btnTask3";
            this.btnTask3.Size = new System.Drawing.Size(165, 263);
            this.btnTask3.TabIndex = 2;
            this.btnTask3.Text = "Swap N\' Drop";
            this.btnTask3.UseVisualStyleBackColor = false;
            this.btnTask3.Click += new System.EventHandler(this.btnTask3_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(557, 70);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 18);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Welcome.";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogOut.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogOut.Location = new System.Drawing.Point(560, 271);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(144, 62);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnStaffMenu
            // 
            this.btnStaffMenu.BackColor = System.Drawing.Color.Goldenrod;
            this.btnStaffMenu.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnStaffMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStaffMenu.Location = new System.Drawing.Point(560, 91);
            this.btnStaffMenu.Name = "btnStaffMenu";
            this.btnStaffMenu.Size = new System.Drawing.Size(144, 102);
            this.btnStaffMenu.TabIndex = 6;
            this.btnStaffMenu.Text = "Staff Menu";
            this.btnStaffMenu.UseVisualStyleBackColor = false;
            this.btnStaffMenu.Visible = false;
            this.btnStaffMenu.Click += new System.EventHandler(this.btnStaffMenu_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.pnlToolbar.Controls.Add(this.btnClose);
            this.pnlToolbar.Controls.Add(this.lblToolbarTitle);
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(725, 42);
            this.pnlToolbar.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnClose.Location = new System.Drawing.Point(685, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblToolbarTitle
            // 
            this.lblToolbarTitle.AutoSize = true;
            this.lblToolbarTitle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolbarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lblToolbarTitle.Location = new System.Drawing.Point(258, 9);
            this.lblToolbarTitle.Name = "lblToolbarTitle";
            this.lblToolbarTitle.Size = new System.Drawing.Size(202, 22);
            this.lblToolbarTitle.TabIndex = 0;
            this.lblToolbarTitle.Text = "Main Menu - ~\\Downloads";
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Salmon;
            this.btnHelp.Font = new System.Drawing.Font("Consolas", 17.5F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.Color.Red;
            this.btnHelp.Location = new System.Drawing.Point(560, 199);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(144, 66);
            this.btnHelp.TabIndex = 22;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblScore1
            // 
            this.lblScore1.AutoSize = true;
            this.lblScore1.BackColor = System.Drawing.Color.Transparent;
            this.lblScore1.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblScore1.ForeColor = System.Drawing.Color.White;
            this.lblScore1.Location = new System.Drawing.Point(12, 49);
            this.lblScore1.Name = "lblScore1";
            this.lblScore1.Size = new System.Drawing.Size(64, 18);
            this.lblScore1.TabIndex = 24;
            this.lblScore1.Text = "Score: ";
            // 
            // lblScore2
            // 
            this.lblScore2.AutoSize = true;
            this.lblScore2.BackColor = System.Drawing.Color.Transparent;
            this.lblScore2.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblScore2.ForeColor = System.Drawing.Color.White;
            this.lblScore2.Location = new System.Drawing.Point(190, 49);
            this.lblScore2.Name = "lblScore2";
            this.lblScore2.Size = new System.Drawing.Size(64, 18);
            this.lblScore2.TabIndex = 25;
            this.lblScore2.Text = "Score: ";
            // 
            // lblScore3
            // 
            this.lblScore3.AutoSize = true;
            this.lblScore3.BackColor = System.Drawing.Color.Transparent;
            this.lblScore3.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblScore3.ForeColor = System.Drawing.Color.White;
            this.lblScore3.Location = new System.Drawing.Point(372, 49);
            this.lblScore3.Name = "lblScore3";
            this.lblScore3.Size = new System.Drawing.Size(64, 18);
            this.lblScore3.TabIndex = 26;
            this.lblScore3.Text = "Score: ";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(725, 348);
            this.Controls.Add(this.lblScore3);
            this.Controls.Add(this.lblScore2);
            this.Controls.Add(this.lblScore1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.btnStaffMenu);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnTask3);
            this.Controls.Add(this.btnTask2);
            this.Controls.Add(this.btnTask1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTask1;
        private System.Windows.Forms.Button btnTask2;
        private System.Windows.Forms.Button btnTask3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnStaffMenu;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblToolbarTitle;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblScore1;
        private System.Windows.Forms.Label lblScore2;
        private System.Windows.Forms.Label lblScore3;
    }
}

