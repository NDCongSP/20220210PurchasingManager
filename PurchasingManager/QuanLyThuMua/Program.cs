using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuMua
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Lấy thông tin chuỗi kết Db
            GlobalVariable.ConnectionDb.ConnectionString = EncodeMD5.DecryptString(ConfigurationManager.AppSettings["ConString"], "PhucTh!nhMD%");
            GlobalVariable.PathFile = ConfigurationManager.AppSettings["PathFile"];
            GlobalVariable.SoDoMin =Convert.ToInt32( ConfigurationManager.AppSettings["SoDoMin"]);
            GlobalVariable.SoDoMax = Convert.ToInt32(ConfigurationManager.AppSettings["SoDoMax"]);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
