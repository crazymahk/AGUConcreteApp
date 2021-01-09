using capstoneProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Design());

            depo dp = new CapstoneProject.depo();
            if (dp.checkConfig() == "")
            {
                Application.Run(new Form1());
            }
            {
                Application.Run(new Form1());
            }
        }
    }
}
