using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuMua
{
    public class PurchaseModel
    {
        [Browsable(true)]
        public int Id { get; set; }
        [DesignOnly(true)]
        [Browsable(false)]
        public int CustomerId { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Loại")]
        public string Type { get; set; }
        [DisplayName("Trọng lượng")]
        public double Weight { get; set; }
        [DesignOnly(true)]
        [Browsable(true)]
        public int PriceId { get; set; }
        [DisplayName("Đơn giá")]
        public double Price { get; set; }
        [DisplayName("Thanh toán ngay")]
        public int PayNow { get; set; }
        [DisplayName("Loại mủ")]
        public int MuType { get; set; }
        [DisplayName("Số độ")]
        public double? Degree { get; set; }
        [DisplayName("Lưu ý")]
        public string Note { get; set; }
    }
}
