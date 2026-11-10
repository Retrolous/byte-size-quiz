
namespace Petkunas__Lukas___Byte_size_Quiz
{
    partial class frmChallenge1
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
            this.wbvwEditor = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.prgrsCompiling = new System.Windows.Forms.ProgressBar();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTimeTaken = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.tmrChallenge1 = new System.Windows.Forms.Timer(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wbvwEditor)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbvwEditor
            // 
            this.wbvwEditor.AllowExternalDrop = true;
            this.wbvwEditor.BackColor = System.Drawing.Color.White;
            this.wbvwEditor.CreationProperties = null;
            this.wbvwEditor.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wbvwEditor.Location = new System.Drawing.Point(10, 255);
            this.wbvwEditor.Name = "wbvwEditor";
            this.wbvwEditor.Size = new System.Drawing.Size(962, 608);
            this.wbvwEditor.TabIndex = 0;
            this.wbvwEditor.ZoomFactor = 1D;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnMainMenu.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnMainMenu.Location = new System.Drawing.Point(979, 69);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(216, 36);
            this.btnMainMenu.TabIndex = 1;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightBlue;
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(10, 255);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(961, 608);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start the challenge";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.LightBlue;
            this.btnExecute.Enabled = false;
            this.btnExecute.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnExecute.Location = new System.Drawing.Point(979, 158);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(448, 64);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // prgrsCompiling
            // 
            this.prgrsCompiling.BackColor = System.Drawing.Color.PowderBlue;
            this.prgrsCompiling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.prgrsCompiling.Location = new System.Drawing.Point(977, 299);
            this.prgrsCompiling.Name = "prgrsCompiling";
            this.prgrsCompiling.Size = new System.Drawing.Size(447, 36);
            this.prgrsCompiling.TabIndex = 4;
            // 
            // txtQuestion
            // 
            this.txtQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestion.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtQuestion.Location = new System.Drawing.Point(10, 48);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ReadOnly = true;
            this.txtQuestion.Size = new System.Drawing.Size(962, 201);
            this.txtQuestion.TabIndex = 5;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 13F);
            this.txtConsole.ForeColor = System.Drawing.Color.Green;
            this.txtConsole.Location = new System.Drawing.Point(977, 341);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(447, 522);
            this.txtConsole.TabIndex = 6;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.pnlToolbar.Controls.Add(this.btnClose);
            this.pnlToolbar.Controls.Add(this.lblTitle);
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1439, 42);
            this.pnlToolbar.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.btnClose.Location = new System.Drawing.Point(1398, 10);
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
            this.lblTitle.Location = new System.Drawing.Point(578, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(283, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Compile and Conquer - ~\\Challenge1";
            // 
            // lblTimeTaken
            // 
            this.lblTimeTaken.AutoSize = true;
            this.lblTimeTaken.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeTaken.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblTimeTaken.ForeColor = System.Drawing.Color.Green;
            this.lblTimeTaken.Location = new System.Drawing.Point(1201, 69);
            this.lblTimeTaken.Name = "lblTimeTaken";
            this.lblTimeTaken.Size = new System.Drawing.Size(160, 22);
            this.lblTimeTaken.TabIndex = 15;
            this.lblTimeTaken.Text = "Time Taken: 0.0";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.Green;
            this.lblScore.Location = new System.Drawing.Point(1201, 91);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(90, 22);
            this.lblScore.TabIndex = 16;
            this.lblScore.Tag = "";
            this.lblScore.Text = "Score: 0";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogOut.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.Location = new System.Drawing.Point(977, 118);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(216, 34);
            this.btnLogOut.TabIndex = 17;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // tmrChallenge1
            // 
            this.tmrChallenge1.Tick += new System.EventHandler(this.tmrChallenge1_Tick);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Salmon;
            this.btnHelp.Font = new System.Drawing.Font("Consolas", 17.5F, System.Drawing.FontStyle.Bold);
            this.btnHelp.ForeColor = System.Drawing.Color.Red;
            this.btnHelp.Location = new System.Drawing.Point(1199, 118);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(225, 34);
            this.btnHelp.TabIndex = 18;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.LightBlue;
            this.btnSkip.Enabled = false;
            this.btnSkip.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnSkip.Location = new System.Drawing.Point(1199, 228);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(225, 64);
            this.btnSkip.TabIndex = 19;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.LightBlue;
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(979, 228);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(216, 64);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmChallenge1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1438, 875);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblTimeTaken);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.prgrsCompiling);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.wbvwEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChallenge1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compile and Conquer";
            this.Load += new System.EventHandler(this.frmChallenge1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wbvwEditor)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wbvwEditor;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ProgressBar prgrsCompiling;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTimeTaken;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Timer tmrChallenge1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnReset;
    }
}