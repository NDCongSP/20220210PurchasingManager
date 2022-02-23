using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuMua
{
    public class PriceModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
    }
}
