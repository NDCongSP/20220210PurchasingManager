using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuMua
{
    public static class GlobalVariable
    {
        public static IDbConnection ConnectionDb { get; set; } = new MySqlConnection("Data Source=localhost;Database=dulieuthumua;UID=root;Password=100100" +
                 "; Min Pool Size=0;Max Pool Size=1000;Pooling=true; Connect Timeout=65535;");
    }
}
