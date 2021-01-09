namespace CapstoneProject
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.rdTurkish = new XanderUI.XUIRadio();
            this.rdEnglish = new XanderUI.XUIRadio();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Label();
            this.labelSettings = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sensType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sieveType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdTurkish
            // 
            this.rdTurkish.Checked = false;
            this.rdTurkish.Font = new System.Drawing.Font("Sitka Small", 10.25F, System.Drawing.FontStyle.Bold);
            this.rdTurkish.ForeColor = System.Drawing.Color.Black;
            this.rdTurkish.Location = new System.Drawing.Point(32, 142);
            this.rdTurkish.Name = "rdTurkish";
            this.rdTurkish.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.rdTurkish.RadioHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.rdTurkish.RadioStyle = XanderUI.XUIRadio.Style.iOS;
            this.rdTurkish.Size = new System.Drawing.Size(98, 33);
            this.rdTurkish.TabIndex = 1;
            this.rdTurkish.Text = "Türkçe";
            this.rdTurkish.Click += new System.EventHandler(this.rdTurkish_Click);
            // 
            // rdEnglish
            // 
            this.rdEnglish.Checked = false;
            this.rdEnglish.Font = new System.Drawing.Font("Sitka Small", 10.25F, System.Drawing.FontStyle.Bold);
            this.rdEnglish.ForeColor = System.Drawing.Color.Black;
            this.rdEnglish.Location = new System.Drawing.Point(281, 142);
            this.rdEnglish.Name = "rdEnglish";
            this.rdEnglish.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.rdEnglish.RadioHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.rdEnglish.RadioStyle = XanderUI.XUIRadio.Style.iOS;
            this.rdEnglish.Size = new System.Drawing.Size(98, 33);
            this.rdEnglish.TabIndex = 2;
            this.rdEnglish.Text = "English";
            this.rdEnglish.Click += new System.EventHandler(this.rdEnglish_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 10.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lütfen arayüz dilini seçiniz.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 9.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(42, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Please choose the UI language.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel2.Location = new System.Drawing.Point(12, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(520, 10);
            this.panel2.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnStart.Font = new System.Drawing.Font("Sitka Small", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.Image = global::capstoneProject.Properties.Resources.start_32;
            this.btnStart.Location = new System.Drawing.Point(230, 398);
            this.btnStart.MaximumSize = new System.Drawing.Size(40, 40);
            this.btnStart.MinimumSize = new System.Drawing.Size(40, 40);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(40, 40);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = " ";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold);
            this.labelSettings.Location = new System.Drawing.Point(155, 9);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(170, 26);
            this.labelSettings.TabIndex = 8;
            this.labelSettings.Text = "Settings / Ayarlar ";
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.leftPanel.Location = new System.Drawing.Point(12, 12);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(10, 426);
            this.leftPanel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 10.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(28, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kombinasyon Hassasiyeti";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 9.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(42, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Combination Sensitivity";
            // 
            // sensType
            // 
            this.sensType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sensType.FormattingEnabled = true;
            this.sensType.Items.AddRange(new object[] {
            "1% High Sens ",
            "2% (recommended)",
            "4%",
            "5% Low Sens"});
            this.sensType.Location = new System.Drawing.Point(32, 243);
            this.sensType.Name = "sensType";
            this.sensType.Size = new System.Drawing.Size(121, 21);
            this.sensType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Small", 9.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(42, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Sieve Standards";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Small", 10.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(31, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Elek Standartı";
            // 
            // sieveType
            // 
            this.sieveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sieveType.FormattingEnabled = true;
            this.sieveType.Items.AddRange(new object[] {
            "ASTM Test Sieves ",
            "TS EN 933-1"});
            this.sieveType.Location = new System.Drawing.Point(32, 334);
            this.sieveType.Name = "sieveType";
            this.sieveType.Size = new System.Drawing.Size(121, 21);
            this.sieveType.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Location = new System.Drawing.Point(522, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 426);
            this.panel1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Update Software";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(542, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sieveType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sensType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.labelSettings);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdEnglish);
            this.Controls.Add(this.rdTurkish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private XanderUI.XUIRadio rdTurkish;
        private XanderUI.XUIRadio rdEnglish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label btnStart;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox sensType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox sieveType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}