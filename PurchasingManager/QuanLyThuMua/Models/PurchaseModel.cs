using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuMua
{
    public class PurchaseModel
    {
        CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
        [Browsable(true)]
        public int Id { get; set; }
        [DesignOnly(true)]
        [Browsable(false)]
        public int CustomerId { get; set; }
        [Browsable(false)]
        public string  Phone { get; set; }
        [Browsable(false)]
        public string Address { get; set; }
        [Browsable(false)]
        public string PathFileExcelOpen { get; set; }
        [Browsable(false)]
        public int MuType { get; set; }

        [DisplayName("Tên khách hàng")]
        public string  Name { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Loại")]
        public string Type { get; set; }
        [DisplayName("Trọng lượng")]
        public double Weight { get; set; }
        [Browsable(false)]
        public int PriceId { get; set; }
        [DisplayName("Đơn giá")]
        public double Price { get; set; }
        [DisplayName("Thanh toán ngay")]
        public int PayNow { get; set; }
      
        [DisplayName("Loại mủ")]
        public string MuTypeName { get; set; }
        [DisplayName("Số độ")]
        public double Degree { get; set; } 
    
        private double _money;
        [DisplayName("Thành tiền")]
        public double Money
        {
            get { return  Price * (Degree == 0?1: Degree) * Weight ; }
            set { _money = value; }
        }

        [DisplayName("Lưu ý")]
        public string Note { get; set; }

        public string TenKhachHang { get; set; }
        public string ThanhTien { get; set; }
    }
}
