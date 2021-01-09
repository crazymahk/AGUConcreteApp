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
    public partial class ACI : Form
    {

        string curDir = System.IO.Directory.GetCurrentDirectory();
        public ACI()
        {
            InitializeComponent();
            
            this.webBrowserAci.Url = new Uri(String.Format("file:///{0}/aci.pdf", curDir));
           
            //webBrowserAci.Url = new Uri(@".\Documents/yilmaz.html");
          // webBrowserAci.Navigate(@".\Documents\yilmaz.pdf");
        }
    }
}
