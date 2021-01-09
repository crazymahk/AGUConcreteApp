using CapstoneProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capstoneProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void click_methodology(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.tempMethod();
            ACI aci = new ACI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Controls.Clear();
            this.Controls.Add(aci);
            aci.Show();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Design des = new Design() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.Controls.Clear();
            this.Controls.Add(des);
            des.Show();
        }
    }
}
