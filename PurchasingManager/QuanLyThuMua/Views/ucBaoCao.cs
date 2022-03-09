using ClosedXML.Excel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
                var result = GetPurchaseModels(fromTime, toTime, customerId, kieu);

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

                var result = GetTamUngs(fromTime, toTime, customerId);
                _dgTamUng.DataSource = result;
                _dgTamUng.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi: {ex}");
            }
        }

        public void XuatExcel(DateTime fromTime, DateTime toTime, int? customerId, string kieu)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel File |*.xlsx";
                sfd.FileName = "BaoCao";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var dsThuMua = GetPurchaseModels(fromTime, toTime, customerId, kieu);

                    using (var wb = new XLWorkbook())
                    {
                        var wsThuMua = wb.Worksheets.Add("ThuMua");
                        var wsTamUng = wb.Worksheets.Add("TamUng");

                        DataTable dtThuMua = new DataTable();
                        dtThuMua.Columns.Add("Ngày Mua", typeof(DateTime));
                        dtThuMua.Columns.Add("Kiểu", typeof(string));
                        dtThuMua.Columns.Add("Khách Hàng", typeof(string));
                        dtThuMua.Columns.Add("Khối Lượng", typeof(double));
                        dtThuMua.Columns.Add("Đơn Giá", typeof(double));
                        dtThuMua.Columns.Add("Thành Tiền", typeof(string));
                        dtThuMua.Columns.Add("Thanh Toán", typeof(string));
                        dtThuMua.Columns.Add("Kiểu Mủ", typeof(string));
                        dtThuMua.Columns.Add("Độ", typeof(double));
                        dtThuMua.Columns.Add("Ghi Chú", typeof(string));

                        foreach (var item in dsThuMua)
                        {
                            dtThuMua.Rows.Add(item.CreatedDate, item.Type, item.TenKhachHang, item.Weight, item.Price, item.ThanhTien, item.PayNow == 1 ? "Đã thanh toán" : "",
                                item.MuTypeName, item.Degree, item.Note);
                        }
                        wsThuMua.Cell(1, 1).Value = "DANH SÁCH THU MUA";
                        wsThuMua.Range(1, 1, 1, dtThuMua.Columns.Count).Merge().AddToNamed("Titles");
                        wsThuMua.Cell(2, 1).InsertTable(dtThuMua.AsEnumerable());
                        wsThuMua.Columns().AdjustToContents();

                        var dsTamUng = GetTamUngs(fromTime, toTime, customerId);
                        DataTable dtTamUng = new DataTable();
                        dtTamUng.Columns.Add("Ngày Ứng", typeof(DateTime));
                        dtTamUng.Columns.Add("Khách Hàng", typeof(string));
                        dtTamUng.Columns.Add("Số Tiền", typeof(double));
                        dtTamUng.Columns.Add("Ghi Chú", typeof(string));

                        foreach (var item in dsTamUng)
                        {
                            dtThuMua.Rows.Add(item.CreatedDate, item.TenKhachHang, item.Money, item.Note);
                        }
                        wsTamUng.Cell(1, 1).Value = "DANH SÁCH TẠM ỨNG";
                        wsTamUng.Range(1, 1, 1, dtTamUng.Columns.Count).Merge().AddToNamed("Titles");
                        wsTamUng.Cell(2, 1).InsertTable(dtTamUng.AsEnumerable());
                        wsTamUng.Columns().AdjustToContents();

                        // Prepare the style for the titles
                        var titlesStyle = wb.Style;
                        titlesStyle.Font.Bold = true;
                        titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titlesStyle.Fill.BackgroundColor = XLColor.BlueGreen;

                        // Format all titles in one shot
                        wb.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show($"Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi: {ex}");
            }
        }

        public List<PurchaseModel> GetPurchaseModels(DateTime fromTime, DateTime toTime, int? customerId, string kieu)
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
            return result;
        }

        public List<TamUngModel> GetTamUngs(DateTime fromTime, DateTime toTime, int? customerId)
        {
            string query = $"select tamung.*, customerinfo.Name as TenKhachHang" +
                $" from tamung inner JOIN customerinfo ON customerinfo.Id = tamung.CustomerId" +
                $" where tamung.CreatedDate > '{fromTime:yyyy-MM-dd HH:mm:ss}' and tamung.CreatedDate < '{toTime:yyyy-MM-dd HH:mm:ss}'";

            if (customerId != null)
            {
                query = query + $" and tamung.CustomerId = {customerId.Value}";
            }

            var result = GlobalVariable.ConnectionDb.Query<TamUngModel>(query).AsList();
            return result;
        }

        public void ThanhToan()
        {

        }
    }
}
