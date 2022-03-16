using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuMua.Utils
{
   public class SUtils
    {
        public static void OpenFile(string fileName)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = fileName;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process p = new Process();
            p.StartInfo = info;
            p.Start();
        }
    }
}
