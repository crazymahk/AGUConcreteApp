using capstoneProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneProject
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            SidePanel.Top = btnHome.Top;
            SidePanel.Height = btnHome.Height;
            Home aboutPanel = new Home() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dvContent.Controls.Clear();
            dvContent.Controls.Add(aboutPanel);
            aboutPanel.Show();

        }
        bool isDesigning = false;
        public bool checkCurrentEvent()
        {
            if (isDesigning)
            {
                if (DialogResult.Yes == MessageBox.Show("Design in progress, if you continue you will lose progress. \n"
                      + "Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    isDesigning = false;
                    btnDesign.Enabled = true;
                    return true;
                }
                else return false;
            }
            else
            {
                return true;
            }

        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (checkCurrentEvent())
            {
                SidePanel.Height = btnHome.Height;
                SidePanel.Top = btnHome.Top;

                Home aboutPanel = new Home() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                dvContent.Controls.Clear();
                dvContent.Controls.Add(aboutPanel);
                aboutPanel.Show();
            }
        }

        private void btnACI_Click(object sender, EventArgs e)
        {
            if (checkCurrentEvent())
            {
                SidePanel.Height = btnACI.Height;
                SidePanel.Top = btnACI.Top;
                ACI aboutPanel = new ACI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                dvContent.Controls.Clear();
                dvContent.Controls.Add(aboutPanel);
                aboutPanel.Show();
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            isDesigning = true;
            SidePanel.Height = btnDesign.Height;
            SidePanel.Top = btnDesign.Top;

            Design designPanel = new Design() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dvContent.Controls.Clear();
            dvContent.Controls.Add(designPanel);
            designPanel.Show();
            btnDesign.Enabled = false;
        }


        private void btnTaratMe_Click(object sender, EventArgs e)
        {
            if (checkCurrentEvent())
            {
                SidePanel.Height = btnTaratMe.Height;
                SidePanel.Top = btnTaratMe.Top;

                Cost aboutPanel = new Cost() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                dvContent.Controls.Clear();
                dvContent.Controls.Add(aboutPanel);
                aboutPanel.Show();
            }
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (checkCurrentEvent())
            {
                SidePanel.Height = btnAbout.Height;
                SidePanel.Top = btnAbout.Top;

                About aboutPanel = new About("www.google.com.tr") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                dvContent.Controls.Clear();
                dvContent.Controls.Add(aboutPanel);
                aboutPanel.Show();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!checkCurrentEvent())
                return;
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
             if (checkCurrentEvent())
            {
                Settings st = new Settings();
                st.Show();
                dvContent.Controls.Clear();
            }
        }

        private void btnYouTube_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do not forget to subscribe our University Channel", "YouTube");
            System.Diagnostics.Process.Start("explorer.exe", "https://www.youtube.com/user/abdullahguluniAGU");
        }

        private void btnTwit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do not forget to follow our Department Account", "Twitter");
            System.Diagnostics.Process.Start("explorer.exe", "https://twitter.com/agucivileng");
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do not forget to follow our Department Account", "Instagram");
            System.Diagnostics.Process.Start("explorer.exe", "https://www.instagram.com/aguinsaatmuhendisligi/");
        }

        private void btnSite_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do not forget to check my website", "Personal Website");
            System.Diagnostics.Process.Start("explorer.exe", "http://www.blogyilmaz.blogspot.com ");
        }



        private void me_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The software was designed by Yılmaz Uçar, Senior Student of the Civil Engineering Department at Abdullah Gül University");

        }

        public void tempMethod()
        {
            ACI aci = new ACI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dvContent.Controls.Clear();
            dvContent.Controls.Add(aci);
            aci.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (checkCurrentEvent())
            {
              
                HelpPage aboutPanel = new HelpPage () { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                dvContent.Controls.Clear();
                dvContent.Controls.Add(aboutPanel);
                aboutPanel.Show();
            }
        }
    }
}
