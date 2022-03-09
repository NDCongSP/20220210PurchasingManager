using ClosedXML.Excel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace QuanLyThuMua
{
    public partial class ucBaoCao : UserControl
    {
        private List<PurchaseModel> _purchaseModels;
        private List<TamUngModel> _tamUngModels;
        DateTime _fromTime;
        DateTime _toTime;

        public ucBaoCao()
        {
            InitializeComponent();
            _dgTamUng.MultiSelect = true;
            _dgBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgBaoCao.MultiSelect = true;
            _dgTamUng.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _dgBaoCao.AutoGenerateColumns = false;
            _dgTamUng.AutoGenerateColumns = false;
        }

        public void CapNhat(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow)
        {
            try
            {
                _fromTime = fromTime;
                _toTime = toTime;

                _purchaseModels = GetPurchaseModels(fromTime, toTime, customerId, kieu, payNow);

                _dgBaoCao.DataSource = _purchaseModels;
                _dgBaoCao.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                CapNhatTamUng(fromTime, toTime, customerId, payNow);

                CapNhatThongKe();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi: {ex}");
            }
        }

        private void CapNhatTamUng(DateTime fromTime, DateTime toTime, int? customerId, int payNow)
        {
            try
            {

                _tamUngModels = GetTamUngs(fromTime, toTime, customerId, payNow);
                _dgTamUng.DataSource = _tamUngModels;
                _dgTamUng.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi: {ex}");
            }
        }

        private void CapNhatThongKe()
        {
            _lbTuNgay.Text = $"{_fromTime:dd/MM/yyyy HH:mm:ss}";
            _lbDenNgay.Text = $"{_toTime:dd/MM/yyyy HH:mm:ss}";

            double klCaoSu = _purchaseModels.Where(x => x.Type == "Cao Su").Sum(x => x.Weight);
            double klDieu = _purchaseModels.Where(x => x.Type == "Điều").Sum(x => x.Weight);
            _lbKLCaoSu.Text = $"{klCaoSu} Kg";
            _lbKLDieu.Text = $"{klDieu} Kg";

            double tongTienThuMua = _purchaseModels.Sum(x => x.Money);
            double tienThuMuaDaThanhToan = _purchaseModels.Where(x => x.PayNow == 1).Sum(x => x.Money);
            double tienThuMuaConLai = tongTienThuMua - tienThuMuaDaThanhToan;
            _lbTongTienThuMua.Text = $"{tongTienThuMua:#,###} VND";
            _lbThuMuaDaThanhToan.Text = $"{tienThuMuaDaThanhToan:#,###} VND";
            _lbTienThuMuaConLai.Text = $"{tienThuMuaConLai:#,###} VND";

            double tongTienTamUng = _tamUngModels.Sum(x => x.Money);
            double tienTamUngDaTra = _tamUngModels.Where(x => x.Payed == 1).Sum(X => X.Money);
            double tienTamUngConNo = tongTienTamUng - tienTamUngDaTra;
            _lbTongTienTamUng.Text = $"{tongTienTamUng:#,###} VND";
            _lbTienTamUngDaTra.Text = $"{tienTamUngDaTra:#,###} VND";
            _lbConNo.Text = $"{tienTamUngConNo:#,###} VND";

            double tongTienPhaiTra = tienThuMuaConLai - tienTamUngConNo;
            _lbTongTienPhaiTra.Text = $"{tienThuMuaConLai:#,###} - {tienTamUngConNo:#,###} = {tongTienPhaiTra:#,###} VND";
        }

        public void XuatExcel(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel File |*.xlsx";
                sfd.FileName = "BaoCao";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var dsThuMua = GetPurchaseModels(fromTime, toTime, customerId, kieu, payNow);

                    using (var wb = new XLWorkbook())
                    {
                        var wsThuMua = wb.Worksheets.Add("ThuMua");
                        var wsTamUng = wb.Worksheets.Add("TamUng");
                        var wsThongKe = wb.Worksheets.Add("ThongKe");

                        DataTable dtThuMua = new DataTable();
                        dtThuMua.Columns.Add("Ngày Mua", typeof(DateTime));
                        dtThuMua.Columns.Add("Kiểu", typeof(string));
                        dtThuMua.Columns.Add("Khách Hàng", typeof(string));
                        dtThuMua.Columns.Add("Khối Lượng", typeof(double));
                        dtThuMua.Columns.Add("Đơn Giá", typeof(double));
                        dtThuMua.Columns.Add("Thành Tiền", typeof(double));
                        dtThuMua.Columns.Add("Thanh Toán", typeof(string));
                        dtThuMua.Columns.Add("Kiểu Mủ", typeof(string));
                        dtThuMua.Columns.Add("Độ", typeof(double));
                        dtThuMua.Columns.Add("Ghi Chú", typeof(string));

                        foreach (var item in dsThuMua)
                        {
                            dtThuMua.Rows.Add(item.CreatedDate, item.Type, item.TenKhachHang, item.Weight, item.Price, item.Money, item.PayNow == 1 ? "Đã thanh toán" : "",
                                item.MuTypeName, item.Degree, item.Note);
                        }
                        wsThuMua.Cell(1, 1).Value = "DANH SÁCH THU MUA";
                        wsThuMua.Range(1, 1, 1, dtThuMua.Columns.Count).Merge().AddToNamed("Titles");
                        wsThuMua.Cell(2, 1).InsertTable(dtThuMua.AsEnumerable());
                        wsThuMua.Columns().AdjustToContents();

                        var dsTamUng = GetTamUngs(fromTime, toTime, customerId, payNow);
                        DataTable dtTamUng = new DataTable();
                        dtTamUng.Columns.Add("Ngày Ứng", typeof(DateTime));
                        dtTamUng.Columns.Add("Khách Hàng", typeof(string));
                        dtTamUng.Columns.Add("Số Tiền", typeof(double));
                        dtTamUng.Columns.Add("Ghi Chú", typeof(string));

                        foreach (var item in dsTamUng)
                        {
                            dtTamUng.Rows.Add(item.CreatedDate, item.TenKhachHang, item.Money, item.Note);
                        }
                        wsTamUng.Cell(1, 1).Value = "DANH SÁCH TẠM ỨNG";
                        wsTamUng.Range(1, 1, 1, dtTamUng.Columns.Count).Merge().AddToNamed("Titles");
                        wsTamUng.Cell(2, 1).InsertTable(dtTamUng.AsEnumerable());
                        wsTamUng.Columns().AdjustToContents();

                        double klCaoSu = dsThuMua.Where(x => x.Type == "Cao Su").Sum(x => x.Weight);
                        double klDieu = dsThuMua.Where(x => x.Type == "Điều").Sum(x => x.Weight);

                        double tongTienThuMua = dsThuMua.Sum(x => x.Money);
                        double tienThuMuaDaThanhToan = dsThuMua.Where(x => x.PayNow == 1).Sum(x => x.Money);
                        double tienThuMuaConLai = tongTienThuMua - tienThuMuaDaThanhToan;

                        double tongTienTamUng = dsTamUng.Sum(x => x.Money);
                        double tienTamUngDaTra = dsTamUng.Where(x => x.Payed == 1).Sum(X => X.Money);
                        double tienTamUngConNo = tongTienTamUng - tienTamUngDaTra;

                        double tongTienPhaiTra = tienThuMuaConLai - tienTamUngConNo;

                        wsThongKe.Cell(1, 1).Value = "THỐNG KÊ";
                        wsThongKe.Range(1, 1, 1, 4).Merge().AddToNamed("Titles");
                        wsThongKe.Range(2, 1, 2, 4).Merge().Value = "Từ ngày: - Đến Ngày: ";

                        wsThongKe.Range(3, 1, 3, 2).Merge().Value = "THU MUA";
                        wsThongKe.Range(3, 3, 3, 4).Merge().Value = "TẠM ỨNG";

                        wsThongKe.Cell(4, 1).Value = "Khối lượng cao su";
                        wsThongKe.Cell(5, 1).Value = "Khối lượng điều";
                        wsThongKe.Cell(6, 1).Value = "Tống tiền";
                        wsThongKe.Cell(7, 1).Value = "Đã thanh toán";
                        wsThongKe.Cell(8, 1).Value = "Còn lại";
                        wsThongKe.Cell(4, 2).Value = klCaoSu;
                        wsThongKe.Cell(5, 2).Value = klDieu;
                        wsThongKe.Cell(6, 2).Value = tongTienThuMua;
                        wsThongKe.Cell(7, 2).Value = tienThuMuaDaThanhToan;
                        wsThongKe.Cell(8, 2).Value = tienThuMuaConLai;

                        wsThongKe.Cell(4, 3).Value = "Tổng tiền";
                        wsThongKe.Cell(5, 3).Value = "Đã trả";
                        wsThongKe.Cell(6, 3).Value = "Còn nợ";

                        wsThongKe.Cell(4, 4).Value = tongTienTamUng;
                        wsThongKe.Cell(5, 4).Value = tienTamUngDaTra;
                        wsThongKe.Cell(6, 4).Value = tienTamUngConNo;

                        wsThongKe.Range(8,1, 8, 4).Merge().Value = $"{tienThuMuaConLai:#,###} - {tienTamUngConNo:#,###} = {tongTienPhaiTra:#,###} VND";

                        wsThongKe.CellsUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Hair);
                        wsThongKe.Columns().AdjustToContents();

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

        public List<PurchaseModel> GetPurchaseModels(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow)
        {
            string query = $"select purchaseinfo.*, customerinfo.Name as TenKhachHang" +
                $" from purchaseinfo inner JOIN customerinfo ON customerinfo.Id = purchaseinfo.CustomerId" +
                $" where purchaseinfo.CreatedDate > '{fromTime:yyyy-MM-dd HH:mm:ss}' and purchaseinfo.CreatedDate < '{toTime:yyyy-MM-dd HH:mm:ss}'";

            if (customerId != null && customerId != 0)
            {
                query = query + $" and purchaseinfo.CustomerId = {customerId.Value}";
            }

            if (!string.IsNullOrWhiteSpace(kieu) && kieu != "Tất Cả")
            {
                query = query + $" and purchaseinfo.Type = '{kieu}'";
            }

            if (payNow == 1 || payNow == 0)
            {
                query = query + $" and purchaseinfo.PayNow = '{kieu}'";
            }

            var result = GlobalVariable.ConnectionDb.Query<PurchaseModel>(query).AsList();
            return result;
        }

        public List<TamUngModel> GetTamUngs(DateTime fromTime, DateTime toTime, int? customerId, int payNow)
        {
            string query = $"select tamung.*, customerinfo.Name as TenKhachHang" +
                $" from tamung inner JOIN customerinfo ON customerinfo.Id = tamung.CustomerId" +
                $" where tamung.CreatedDate > '{fromTime:yyyy-MM-dd HH:mm:ss}' and tamung.CreatedDate < '{toTime:yyyy-MM-dd HH:mm:ss}'";

            if (customerId != null && customerId != 0)
            {
                query = query + $" and tamung.CustomerId = {customerId.Value}";
            }

            if (payNow == 1 || payNow == 0)
            {
                query = query + $" and tamung.Payed = {payNow}";
            }

            var result = GlobalVariable.ConnectionDb.Query<TamUngModel>(query).AsList();
            return result;
        }

        public void ThanhToan()
        {

        }

        private void thanhToanDonDaChonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dgBaoCao.SelectedRows != null && _dgBaoCao.SelectedRows.Count > 0)
            {
                List<PurchaseModel> purchaseModels = new List<PurchaseModel>();
                foreach (DataGridViewRow item in _dgBaoCao.SelectedRows)
                {
                    if (item.DataBoundItem is PurchaseModel model)
                    {
                        if (model.PayNow != 1)
                        {
                            model.Handle = item;
                            purchaseModels.Add(model);
                        }
                    }
                }

                if (purchaseModels.Count > 0)
                {
                    var mbr = MessageBox.Show($"Bạn có muốn thanh thanh toán các đơn đã chọn ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (mbr == DialogResult.Yes)
                    {

                    }
                }
            }
        }

        private void xacNhanDaThuHoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dgTamUng.SelectedRows != null && _dgTamUng.SelectedRows.Count > 0)
            {
                List<TamUngModel> tamUngModels = new List<TamUngModel>();
                foreach (DataGridViewRow item in _dgTamUng.SelectedRows)
                {
                    if (item.DataBoundItem is TamUngModel model)
                    {
                        if (model.Payed != 1)
                        {
                            model.Handle = item;
                            tamUngModels.Add(model);
                        }
                    }
                }

                if (tamUngModels.Count > 0)
                {
                    var mbr = MessageBox.Show($"Bạn có muốn xác nhận đã thu hồi tạm ứng ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (mbr == DialogResult.Yes)
                    {

                    }
                }
            }
        }
    }
}
