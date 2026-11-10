
namespace Petkunas__Lukas___Byte_size_Quiz
{
    partial class frmModifyUsers
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
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.lblCursor = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.lblScores = new System.Windows.Forms.Label();
            this.numScore1 = new System.Windows.Forms.NumericUpDown();
            this.numScore2 = new System.Windows.Forms.NumericUpDown();
            this.numScore3 = new System.Windows.Forms.NumericUpDown();
            this.lblScore1 = new System.Windows.Forms.Label();
            this.lblScore2 = new System.Windows.Forms.Label();
            this.lblScore3 = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tmrCursor = new System.Windows.Forms.Timer(this.components);
            this.btnStaffMenu = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblAlert = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScore3)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboUsers
            // 
            this.comboUsers.BackColor = System.Drawing.Color.Honeydew;
            this.comboUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(588, 57);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(182, 21);
            this.comboUsers.TabIndex = 20;
            this.comboUsers.SelectedIndexChanged += new System.EventHandler(this.comboUsers_SelectedIndexChanged);
            // 
            // lblCursor
            // 
            this.lblCursor.BackColor = System.Drawing.Color.White;
            this.lblCursor.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblCursor.Location = new System.Drawing.Point(141, 55);
            this.lblCursor.Name = "lblCursor";
            this.lblCursor.Size = new System.Drawing.Size(12, 21);
            this.lblCursor.TabIndex = 26;
            this.lblCursor.Visible = false;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.txtLastName.ForeColor = System.Drawing.Color.White;
            this.txtLastName.Location = new System.Drawing.Point(140, 125);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(397, 21);
            this.txtLastName.TabIndex = 29;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.txtFirstName.ForeColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(140, 90);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(397, 21);
            this.txtFirstName.TabIndex = 28;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Black;
            this.lblLastName.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblLastName.ForeColor = System.Drawing.Color.Green;
            this.lblLastName.Location = new System.Drawing.Point(14, 125);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(110, 22);
            this.lblLastName.TabIndex = 27;
            this.lblLastName.Text = "Last name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Black;
            this.lblFirstName.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.Green;
            this.lblFirstName.Location = new System.Drawing.Point(14, 90);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(120, 22);
            this.lblFirstName.TabIndex = 25;
            this.lblFirstName.Text = "First name:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(140, 160);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(397, 21);
            this.txtPassword.TabIndex = 24;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.Location = new System.Drawing.Point(140, 55);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(397, 21);
            this.txtUsername.TabIndex = 23;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Black;
            this.lblPassword.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblPassword.Location = new System.Drawing.Point(14, 160);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 22);
            this.lblPassword.TabIndex = 22;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Black;
            this.lblUsername.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.Green;
            this.lblUsername.Location = new System.Drawing.Point(14, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 22);
            this.lblUsername.TabIndex = 21;
            this.lblUsername.Text = "Username:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Black;
            this.lblAge.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblAge.ForeColor = System.Drawing.Color.Green;
            this.lblAge.Location = new System.Drawing.Point(19, 198);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(50, 22);
            this.lblAge.TabIndex = 31;
            this.lblAge.Text = "Age:";
            // 
            // numAge
            // 
            this.numAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.numAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numAge.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.numAge.ForeColor = System.Drawing.Color.White;
            this.numAge.Location = new System.Drawing.Point(75, 198);
            this.numAge.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(114, 24);
            this.numAge.TabIndex = 30;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.BackColor = System.Drawing.Color.Black;
            this.chkAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAdmin.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.chkAdmin.ForeColor = System.Drawing.Color.Green;
            this.chkAdmin.Location = new System.Drawing.Point(303, 199);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(76, 26);
            this.chkAdmin.TabIndex = 27;
            this.chkAdmin.Text = "Admin";
            this.chkAdmin.UseVisualStyleBackColor = false;
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUser.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnSaveUser.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSaveUser.Location = new System.Drawing.Point(23, 274);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(514, 30);
            this.btnSaveUser.TabIndex = 27;
            this.btnSaveUser.Text = "Save user";
            this.btnSaveUser.UseVisualStyleBackColor = false;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.BackColor = System.Drawing.Color.Black;
            this.lblScores.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblScores.ForeColor = System.Drawing.Color.Green;
            this.lblScores.Location = new System.Drawing.Point(14, 233);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(80, 22);
            this.lblScores.TabIndex = 32;
            this.lblScores.Text = "Scores:";
            // 
            // numScore1
            // 
            this.numScore1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.numScore1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numScore1.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.numScore1.ForeColor = System.Drawing.Color.White;
            this.numScore1.Location = new System.Drawing.Point(130, 235);
            this.numScore1.Name = "numScore1";
            this.numScore1.Size = new System.Drawing.Size(94, 24);
            this.numScore1.TabIndex = 33;
            // 
            // numScore2
            // 
            this.numScore2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.numScore2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numScore2.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.numScore2.ForeColor = System.Drawing.Color.White;
            this.numScore2.Location = new System.Drawing.Point(277, 234);
            this.numScore2.Name = "numScore2";
            this.numScore2.Size = new System.Drawing.Size(102, 24);
            this.numScore2.TabIndex = 34;
            // 
            // numScore3
            // 
            this.numScore3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.numScore3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numScore3.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.numScore3.ForeColor = System.Drawing.Color.White;
            this.numScore3.Location = new System.Drawing.Point(435, 233);
            this.numScore3.Name = "numScore3";
            this.numScore3.Size = new System.Drawing.Size(102, 24);
            this.numScore3.TabIndex = 35;
            // 
            // lblScore1
            // 
            this.lblScore1.AutoSize = true;
            this.lblScore1.BackColor = System.Drawing.Color.Black;
            this.lblScore1.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblScore1.ForeColor = System.Drawing.Color.Green;
            this.lblScore1.Location = new System.Drawing.Point(94, 235);
            this.lblScore1.Name = "lblScore1";
            this.lblScore1.Size = new System.Drawing.Size(30, 22);
            this.lblScore1.TabIndex = 36;
            this.lblScore1.Text = "1.";
            // 
            // lblScore2
            // 
            this.lblScore2.AutoSize = true;
            this.lblScore2.BackColor = System.Drawing.Color.Black;
            this.lblScore2.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblScore2.ForeColor = System.Drawing.Color.Green;
            this.lblScore2.Location = new System.Drawing.Point(241, 235);
            this.lblScore2.Name = "lblScore2";
            this.lblScore2.Size = new System.Drawing.Size(30, 22);
            this.lblScore2.TabIndex = 37;
            this.lblScore2.Text = "2.";
            // 
            // lblScore3
            // 
            this.lblScore3.AutoSize = true;
            this.lblScore3.BackColor = System.Drawing.Color.Black;
            this.lblScore3.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblScore3.ForeColor = System.Drawing.Color.Green;
            this.lblScore3.Location = new System.Drawing.Point(399, 234);
            this.lblScore3.Name = "lblScore3";
            this.lblScore3.Size = new System.Drawing.Size(30, 22);
            this.lblScore3.TabIndex = 38;
            this.lblScore3.Text = "3.";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.pnlToolbar.Controls.Add(this.btnClose);
            this.pnlToolbar.Controls.Add(this.lblTitle);
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(799, 42);
            this.pnlToolbar.TabIndex = 39;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnClose.Location = new System.Drawing.Point(760, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(299, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(219, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Modify Users - ~\\Downloads";
            // 
            // tmrCursor
            // 
            this.tmrCursor.Interval = 500;
            this.tmrCursor.Tick += new System.EventHandler(this.tmrCursor_Tick);
            // 
            // btnStaffMenu
            // 
            this.btnStaffMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnStaffMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffMenu.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnStaffMenu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnStaffMenu.Location = new System.Drawing.Point(588, 202);
            this.btnStaffMenu.Name = "btnStaffMenu";
            this.btnStaffMenu.Size = new System.Drawing.Size(182, 30);
            this.btnStaffMenu.TabIndex = 40;
            this.btnStaffMenu.Text = "Staff Menu";
            this.btnStaffMenu.UseVisualStyleBackColor = false;
            this.btnStaffMenu.Click += new System.EventHandler(this.btnStaffMenu_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnMainMenu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnMainMenu.Location = new System.Drawing.Point(588, 238);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(182, 30);
            this.btnMainMenu.TabIndex = 41;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnLogOut.Location = new System.Drawing.Point(588, 274);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(182, 30);
            this.btnLogOut.TabIndex = 42;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblAlert
            // 
            this.lblAlert.AutoSize = true;
            this.lblAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblAlert.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAlert.Location = new System.Drawing.Point(27, 320);
            this.lblAlert.MaximumSize = new System.Drawing.Size(442, 0);
            this.lblAlert.MinimumSize = new System.Drawing.Size(510, 0);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(510, 19);
            this.lblAlert.TabIndex = 43;
            this.lblAlert.Text = "Unknown error";
            this.lblAlert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlert.Visible = false;
            // 
            // frmModifyUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(800, 315);
            this.Controls.Add(this.lblAlert);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnStaffMenu);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.lblScore3);
            this.Controls.Add(this.lblScore2);
            this.Controls.Add(this.lblScore1);
            this.Controls.Add(this.numScore3);
            this.Controls.Add(this.numScore2);
            this.Controls.Add(this.numScore1);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.lblCursor);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.comboUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmModifyUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Users";
            this.Load += new System.EventHandler(this.frmModifyUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScore3)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboUsers;
        private System.Windows.Forms.Label lblCursor;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.NumericUpDown numScore1;
        private System.Windows.Forms.NumericUpDown numScore2;
        private System.Windows.Forms.NumericUpDown numScore3;
        private System.Windows.Forms.Label lblScore1;
        private System.Windows.Forms.Label lblScore2;
        private System.Windows.Forms.Label lblScore3;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer tmrCursor;
        private System.Windows.Forms.Button btnStaffMenu;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblAlert;
    }
}