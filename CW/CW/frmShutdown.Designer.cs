
namespace Petkunas__Lukas___Byte_size_Quiz
{
    partial class frmShutdown
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
            this.lblShutdown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblShutdown
            // 
            this.lblShutdown.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShutdown.ForeColor = System.Drawing.Color.Lime;
            this.lblShutdown.Location = new System.Drawing.Point(20, 20);
            this.lblShutdown.Name = "lblShutdown";
            this.lblShutdown.Size = new System.Drawing.Size(460, 250);
            this.lblShutdown.TabIndex = 0;
            // 
            // frmShutdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.lblShutdown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShutdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shutdown in progress...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblShutdown;
    }
}