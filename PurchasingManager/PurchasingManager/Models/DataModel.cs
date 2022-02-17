using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchasingManager
{
   public  class DataModel
    {
        public string TenKhach { get; set; }
        public string SDT { get; set; }
        public string NgayMua { get; set; }
        public double KhoiLuong { get; set; }
        public double SoDo { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
        public bool MuChen { get; set; } = false;//False-ko phải mủ chen (Có cập nhật số độ); true- mủ chén (ko cập nhật số độ)
    }
}
