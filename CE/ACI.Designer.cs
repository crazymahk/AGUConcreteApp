namespace capstoneProject
{
    partial class ACI
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
            this.webBrowserAci = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserAci
            // 
            this.webBrowserAci.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserAci.Location = new System.Drawing.Point(0, 0);
            this.webBrowserAci.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAci.Name = "webBrowserAci";
            this.webBrowserAci.ScriptErrorsSuppressed = true;
            this.webBrowserAci.Size = new System.Drawing.Size(800, 450);
            this.webBrowserAci.TabIndex = 0;
            // 
            // ACI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webBrowserAci);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ACI";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowserAci;
    }
}