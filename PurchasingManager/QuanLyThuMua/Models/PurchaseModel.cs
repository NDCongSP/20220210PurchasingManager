using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuMua
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public int PriceId { get; set; }
        public double Price { get; set; }
        public int PayNow { get; set; }
        public int MuType { get; set; }
        public double Degree { get; set; }
        public string Note { get; set; }
    }
}
