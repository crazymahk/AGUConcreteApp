using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace capstoneProject
{
    public partial class About : Form
    {
        public About(string url)
        {
            InitializeComponent();
            webBrowser1.AllowWebBrowserDrop = false;
         
            webBrowser1.Navigate("ce.agu.edu.tr");
            

            webBrowser2.Navigate("https://drive.google.com/file/d/1RZSGcR8skvWaPPuF7lgdiEMmU8D7gi5G/view?usp=sharing");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }
    }
}