
namespace Petkunas__Lukas___Byte_size_Quiz
{
    partial class frmChallenge2
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
            this.pnlBoundary = new System.Windows.Forms.Panel();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnSignal = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblAttempts = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblConnections = new System.Windows.Forms.Label();
            this.lblDesiredOutput = new System.Windows.Forms.Label();
            this.btnDesiredOutput = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlBoundary.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoundary
            // 
            this.pnlBoundary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            this.pnlBoundary.Controls.Add(this.btnOutput);
            this.pnlBoundary.Controls.Add(this.btnSignal);
            this.pnlBoundary.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlBoundary.Location = new System.Drawing.Point(12, 48);
            this.pnlBoundary.Name = "pnlBoundary";
            this.pnlBoundary.Size = new System.Drawing.Size(796, 485);
            this.pnlBoundary.TabIndex = 0;
            this.pnlBoundary.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoundary_Paint);
            // 
            // btnOutput
            // 
            this.btnOutput.BackColor = System.Drawing.Color.Red;
            this.btnOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutput.Location = new System.Drawing.Point(688, 206);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(95, 95);
            this.btnOutput.TabIndex = 1;
            this.btnOutput.UseVisualStyleBackColor = false;
            this.btnOutput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnOutput_MouseClick);
            // 
            // btnSignal
            // 
            this.btnSignal.BackColor = System.Drawing.Color.White;
            this.btnSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignal.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignal.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnSignal.Location = new System.Drawing.Point(12, 206);
            this.btnSignal.Name = "btnSignal";
            this.btnSignal.Size = new System.Drawing.Size(95, 95);
            this.btnSignal.TabIndex = 0;
            this.btnSignal.Text = "Signal generator";
            this.btnSignal.UseVisualStyleBackColor = false;
            this.btnSignal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSignal_MouseClick);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogOut.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.Location = new System.Drawing.Point(814, 89);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(235, 34);
            this.btnLogOut.TabIndex = 19;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnMainMenu.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnMainMenu.Location = new System.Drawing.Point(814, 48);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(235, 36);
            this.btnMainMenu.TabIndex = 18;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSkip.Enabled = false;
            this.btnSkip.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnSkip.Location = new System.Drawing.Point(814, 129);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(235, 34);
            this.btnSkip.TabIndex = 21;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(814, 187);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(235, 206);
            this.txtQuestion.TabIndex = 22;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(815, 166);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 17);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "Title";
            this.lblTitle.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnStart.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(818, 499);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(231, 34);
            this.btnStart.TabIndex = 24;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.Green;
            this.lblScore.Location = new System.Drawing.Point(814, 396);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(90, 22);
            this.lblScore.TabIndex = 25;
            this.lblScore.Tag = "";
            this.lblScore.Text = "Score: 0";
            // 
            // lblAttempts
            // 
            this.lblAttempts.AutoSize = true;
            this.lblAttempts.BackColor = System.Drawing.Color.Transparent;
            this.lblAttempts.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblAttempts.ForeColor = System.Drawing.Color.Green;
            this.lblAttempts.Location = new System.Drawing.Point(929, 396);
            this.lblAttempts.Name = "lblAttempts";
            this.lblAttempts.Size = new System.Drawing.Size(120, 22);
            this.lblAttempts.TabIndex = 26;
            this.lblAttempts.Tag = "";
            this.lblAttempts.Text = "Attempts: 0";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.BackColor = System.Drawing.SystemColors.Control;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulty.ForeColor = System.Drawing.Color.Black;
            this.lblDifficulty.Location = new System.Drawing.Point(896, 316);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(63, 18);
            this.lblDifficulty.TabIndex = 27;
            this.lblDifficulty.Text = "Difficulty";
            this.lblDifficulty.Visible = false;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.pnlToolbar.Controls.Add(this.btnClose);
            this.pnlToolbar.Controls.Add(this.lblFormTitle);
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1061, 42);
            this.pnlToolbar.TabIndex = 28;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnClose.Location = new System.Drawing.Point(1021, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lblFormTitle.Location = new System.Drawing.Point(427, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(209, 22);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Bit-wise Up - ~\\Challenge2";
            // 
            // lblConnections
            // 
            this.lblConnections.AutoSize = true;
            this.lblConnections.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblConnections.ForeColor = System.Drawing.Color.White;
            this.lblConnections.Location = new System.Drawing.Point(859, 434);
            this.lblConnections.Name = "lblConnections";
            this.lblConnections.Size = new System.Drawing.Size(150, 22);
            this.lblConnections.TabIndex = 29;
            this.lblConnections.Text = "Connections: 0";
            // 
            // lblDesiredOutput
            // 
            this.lblDesiredOutput.AutoSize = true;
            this.lblDesiredOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDesiredOutput.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblDesiredOutput.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblDesiredOutput.Location = new System.Drawing.Point(849, 343);
            this.lblDesiredOutput.Name = "lblDesiredOutput";
            this.lblDesiredOutput.Size = new System.Drawing.Size(160, 22);
            this.lblDesiredOutput.TabIndex = 30;
            this.lblDesiredOutput.Tag = "";
            this.lblDesiredOutput.Text = "Desired result:";
            // 
            // btnDesiredOutput
            // 
            this.btnDesiredOutput.BackColor = System.Drawing.Color.Gray;
            this.btnDesiredOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesiredOutput.Location = new System.Drawing.Point(814, 368);
            this.btnDesiredOutput.Name = "btnDesiredOutput";
            this.btnDesiredOutput.Size = new System.Drawing.Size(235, 25);
            this.btnDesiredOutput.TabIndex = 2;
            this.btnDesiredOutput.UseVisualStyleBackColor = false;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Salmon;
            this.btnHelp.Font = new System.Drawing.Font("Consolas", 17.5F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.Color.Red;
            this.btnHelp.Location = new System.Drawing.Point(818, 459);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(231, 34);
            this.btnHelp.TabIndex = 31;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmChallenge2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(1061, 639);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnDesiredOutput);
            this.Controls.Add(this.lblDesiredOutput);
            this.Controls.Add(this.lblConnections);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblAttempts);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.pnlBoundary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChallenge2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bit-wise Up";
            this.Load += new System.EventHandler(this.frmChallenge2_Load);
            this.pnlBoundary.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoundary;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnSignal;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblAttempts;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblConnections;
        private System.Windows.Forms.Label lblDesiredOutput;
        private System.Windows.Forms.Button btnDesiredOutput;
        private System.Windows.Forms.Button btnHelp;
    }
}