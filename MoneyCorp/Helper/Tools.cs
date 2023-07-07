using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCorp.Helper
{
    public class Tools
    {
        public static void KillProcess(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            foreach(Process process in processes)
            {
                if(process.ProcessName == name || process.ProcessName == $"{name}.exe")
                {
                    try { process.Kill(); process.WaitForExit(); } catch { }
                }
            }
        }
    }
}
