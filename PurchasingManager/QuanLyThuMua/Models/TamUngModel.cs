using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuMua
{
   public class TamUngModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
        public double Money { get; set; }
        public string Note { get; set; }
        public int Payed { get; set; }

        public string TenKhachHang { get; set; }

        public object Handle { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}
