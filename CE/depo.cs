using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CapstoneProject
{
    public class depo
    {
        public void createConfig(string lang)
        {

            if (!File.Exists("capstone.cnfg"))
            {
                File.Create("capstone.cnfg").Close();
                using (StreamWriter sw2 = File.AppendText("capstone.cnfg"))
                {
                    sw2.WriteLine(lang);
                }
            }
            else
            {
                File.WriteAllText("capstone.cnfg", String.Empty);
                using (StreamWriter sw2 = File.AppendText("capstone.cnfg"))
                {
                    sw2.WriteLine(lang);
                }
            }
        }

        public string checkConfig()
        {
            if (!File.Exists("capstone.cnfg"))
            {
                return "";
            }
            else
            {

                FileStream fs = new FileStream("capstone.cnfg", FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string input = sw.ReadLine(), lang = "";
                while (input != null)
                {
                    lang = input;
                    input = sw.ReadLine();
                }
                sw.Close();
                fs.Close();
                return lang;
            }
        }
    }
}
