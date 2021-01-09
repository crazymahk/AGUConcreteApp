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
    public partial class HelpPage : Form
    {
        string curDir = System.IO.Directory.GetCurrentDirectory();
        public HelpPage()
        {
            InitializeComponent();
            this.webBrowserHelp.Url = new Uri(String.Format("file:///{0}/help.pdf", curDir));
        }
    }
}
