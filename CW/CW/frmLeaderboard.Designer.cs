
namespace Petkunas__Lukas___Byte_size_Quiz
{
    partial class frmLeaderboard
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
            this.btnTopPerformers = new System.Windows.Forms.Button();
            this.lblAverages = new System.Windows.Forms.Label();
            this.lblSortInstructions = new System.Windows.Forms.Label();
            this.lblScores = new System.Windows.Forms.Label();
            this.dgvAverageScores = new System.Windows.Forms.DataGridView();
            this.dgvTeamTotalScores = new System.Windows.Forms.DataGridView();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnStaffMenu = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAverageScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamTotalScores)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTopPerformers
            // 
            this.btnTopPerformers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTopPerformers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopPerformers.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnTopPerformers.Location = new System.Drawing.Point(720, 180);
            this.btnTopPerformers.Name = "btnTopPerformers";
            this.btnTopPerformers.Size = new System.Drawing.Size(315, 87);
            this.btnTopPerformers.TabIndex = 14;
            this.btnTopPerformers.Text = "Reveal top performers";
            this.btnTopPerformers.UseVisualStyleBackColor = false;
            this.btnTopPerformers.Click += new System.EventHandler(this.btnTopPerformers_Click);
            // 
            // lblAverages
            // 
            this.lblAverages.AutoSize = true;
            this.lblAverages.BackColor = System.Drawing.Color.Transparent;
            this.lblAverages.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold);
            this.lblAverages.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblAverages.Location = new System.Drawing.Point(779, 288);
            this.lblAverages.Name = "lblAverages";
            this.lblAverages.Size = new System.Drawing.Size(208, 23);
            this.lblAverages.TabIndex = 13;
            this.lblAverages.Text = "Challenge averages";
            // 
            // lblSortInstructions
            // 
            this.lblSortInstructions.AutoSize = true;
            this.lblSortInstructions.BackColor = System.Drawing.Color.Transparent;
            this.lblSortInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSortInstructions.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSortInstructions.Location = new System.Drawing.Point(21, 79);
            this.lblSortInstructions.Name = "lblSortInstructions";
            this.lblSortInstructions.Size = new System.Drawing.Size(406, 17);
            this.lblSortInstructions.TabIndex = 12;
            this.lblSortInstructions.Text = "You can change any column\'s sorting by clicking on its heading";
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.BackColor = System.Drawing.Color.Transparent;
            this.lblScores.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold);
            this.lblScores.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblScores.Location = new System.Drawing.Point(197, 51);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(340, 23);
            this.lblScores.TabIndex = 11;
            this.lblScores.Text = "Total Team Scores and Rankings";
            // 
            // dgvAverageScores
            // 
            this.dgvAverageScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAverageScores.Location = new System.Drawing.Point(720, 314);
            this.dgvAverageScores.Name = "dgvAverageScores";
            this.dgvAverageScores.Size = new System.Drawing.Size(315, 185);
            this.dgvAverageScores.TabIndex = 9;
            // 
            // dgvTeamTotalScores
            // 
            this.dgvTeamTotalScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamTotalScores.Location = new System.Drawing.Point(24, 99);
            this.dgvTeamTotalScores.Name = "dgvTeamTotalScores";
            this.dgvTeamTotalScores.ReadOnly = true;
            this.dgvTeamTotalScores.Size = new System.Drawing.Size(686, 400);
            this.dgvTeamTotalScores.TabIndex = 8;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnLogOut.Location = new System.Drawing.Point(853, 123);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(182, 30);
            this.btnLogOut.TabIndex = 45;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnMainMenu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnMainMenu.Location = new System.Drawing.Point(853, 87);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(182, 30);
            this.btnMainMenu.TabIndex = 44;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnStaffMenu
            // 
            this.btnStaffMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnStaffMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffMenu.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnStaffMenu.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnStaffMenu.Location = new System.Drawing.Point(853, 51);
            this.btnStaffMenu.Name = "btnStaffMenu";
            this.btnStaffMenu.Size = new System.Drawing.Size(182, 30);
            this.btnStaffMenu.TabIndex = 43;
            this.btnStaffMenu.Text = "Staff Menu";
            this.btnStaffMenu.UseVisualStyleBackColor = false;
            this.btnStaffMenu.Click += new System.EventHandler(this.btnStaffMenu_Click);
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.pnlToolbar.Controls.Add(this.btnClose);
            this.pnlToolbar.Controls.Add(this.lblTitle);
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1049, 42);
            this.pnlToolbar.TabIndex = 48;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnClose.Location = new System.Drawing.Point(1007, 8);
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
            this.lblTitle.Location = new System.Drawing.Point(425, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(219, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Leaderboard - ~\\Downloads";
            // 
            // frmLeaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(1047, 511);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnStaffMenu);
            this.Controls.Add(this.btnTopPerformers);
            this.Controls.Add(this.lblAverages);
            this.Controls.Add(this.lblSortInstructions);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.dgvAverageScores);
            this.Controls.Add(this.dgvTeamTotalScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLeaderboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.frmLeaderboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAverageScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamTotalScores)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTopPerformers;
        private System.Windows.Forms.Label lblAverages;
        private System.Windows.Forms.Label lblSortInstructions;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.DataGridView dgvAverageScores;
        private System.Windows.Forms.DataGridView dgvTeamTotalScores;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnStaffMenu;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
    }
}