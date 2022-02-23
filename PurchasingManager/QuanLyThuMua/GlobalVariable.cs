using System.Data;

namespace QuanLyThuMua
{
    public static class GlobalVariable
    {
        public static IDbConnection ConnectionDb { get; set; } = new MySqlConnection("Data Source=localhost;Database=dulieuthumua;UID=root;Password=100100" +
                 "; Min Pool Size=0;Max Pool Size=1000;Pooling=true; Connect Timeout=65535;");
    }
}
