using Dapper;
using System;
using System.Windows.Forms;

namespace QuanLyThuMua
{
    public partial class ucBaoCao : UserControl
    {
        public ucBaoCao()
        {
            InitializeComponent();
            _dgBaoCao.AutoGenerateColumns = false;
            _dgTamUng.AutoGenerateColumns = false;
        }


        public void CapNhat(DateTime fromTime, DateTime toTime, int? customerId, string kieu)
        {
            try
            {
                string query = $"select purchaseinfo.*, customerinfo.Name as TenKhachHang, purchaseinfo.Weight * purchaseinfo.price as ThanhTien" +
                $" from purchaseinfo inner JOIN customerinfo ON customerinfo.Id = purchaseinfo.CustomerId" +
                $" where purchaseinfo.CreatedDate > '{fromTime:yyyy-MM-dd HH:mm:ss}' and purchaseinfo.CreatedDate < '{toTime:yyyy-MM-dd HH:mm:ss}'";

                if (customerId != null)
                {
                    query = query + $" and purchaseinfo.CustomerId = {customerId.Value}";
                }

                if (!string.IsNullOrWhiteSpace(kieu))
                {
                    query = query + $" and purchaseinfo.Type = '{kieu}'";
                }

                var result = GlobalVariable.ConnectionDb.Query<PurchaseModel>(query).AsList();

                _dgBaoCao.DataSource = result;
                _dgBaoCao.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                CapNhatTamUng(fromTime, toTime, customerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi: {ex}");
            }
        }

        private void CapNhatTamUng(DateTime fromTime, DateTime toTime, int? customerId)
        {
            try
            {
                string query = $"select tamung.*, customerinfo.Name as TenKhachHang" +
                $" from tamung inner JOIN customerinfo ON customerinfo.Id = tamung.CustomerId" +
                $" where tamung.CreatedDate > '{fromTime:yyyy-MM-dd HH:mm:ss}' and tamung.CreatedDate < '{toTime:yyyy-MM-dd HH:mm:ss}'";

                if (customerId != null)
                {
                    query = query + $" and tamung.CustomerId = {customerId.Value}";
                }

                var result = GlobalVariable.ConnectionDb.Query<PurchaseModel>(query).AsList();

                _dgTamUng.DataSource = result;
                _dgTamUng.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi: {ex}");
            }
        }
    }
}
