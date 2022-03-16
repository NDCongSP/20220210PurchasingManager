
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

namespace QuanLyThuMua
{
    public static class GlobalVariable
    {
        public static IDbConnection ConnectionDb { get; set; } = new MySqlConnection("Data Source=localhost;Database=dulieuthumua;UID=root;Password=100100" +
                 "; Min Pool Size=0;Max Pool Size=1000;Pooling=true; Connect Timeout=65535;");

        public static string PathFile { get; set; }
        public static float SoDoMin { get; set; }
        public static float SoDoMax { get; set; }

        public static string ActivedApp { get; set; }

        public static bool IsActivedApp { get; set; }

    }
}
