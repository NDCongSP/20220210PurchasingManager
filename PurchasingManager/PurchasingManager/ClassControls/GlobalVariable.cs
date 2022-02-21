using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchasingManager
{
    public static class GlobalVariable
    {
        public static Dictionary<double, double> DonGiaCaoSu { get; set; } = new Dictionary<double, double>();

        public static List<DataModel> ExampleData = new List<DataModel>();
        public static DataModel BillInfo = new DataModel();
    }
}
