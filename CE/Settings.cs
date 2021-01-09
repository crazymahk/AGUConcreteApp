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
    public partial class Settings : Form
    {
        depo dp = new depo();
        public Settings()
        {
            InitializeComponent();

        }

        private void rdTurkish_Click(object sender, EventArgs e)
        {
        }

        private void rdEnglish_Click(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            global::capstoneProject.User.Default.sens = Convert.ToInt32(sensType.SelectedItem.ToString().Substring(0, 1));
            MessageBox.Show("Saved.");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the latest version");
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
           
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            switch (capstoneProject.User.Default.sens)
            {
                case 1:
                    sensType.SelectedIndex = 0;
                    break;
                case 2:
                    sensType.SelectedIndex = 1;
                    break;
                case 4:
                    sensType.SelectedIndex = 2;
                    break;
                case 5:
                    sensType.SelectedIndex = 3;
                    break;
                default:
                    sensType.SelectedIndex = 1;
                    break;
            }
        }
    }
}
