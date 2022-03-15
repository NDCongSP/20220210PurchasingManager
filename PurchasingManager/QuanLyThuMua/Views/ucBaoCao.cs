﻿using ClosedXML.Excel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;

namespace QuanLyThuMua
{
    public class DateModel
    {
        public System.DateTime DateTime { get; set; }
        public double Value { get; set; }
    }

    public partial class ucBaoCao : UserControl
    {
        private List<PurchaseModel> _purchaseModels;
        private List<TamUngModel> _tamUngModels;
        DateTime _fromTime;
        DateTime _toTime;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        public ucBaoCao()
        {
            InitializeComponent();
            _dgTamUng.MultiSelect = true;
            _dgBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgBaoCao.MultiSelect = true;
            _dgTamUng.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _dgBaoCao.AutoGenerateColumns = false;
            _dgTamUng.AutoGenerateColumns = false;

            _dgBaoCao.Focus();

            kryptonNavigator1.SelectedIndex = 2;

            _chart1.Series = new SeriesCollection();
            _chart1.Series.Add(new ColumnSeries()
            {
                Title = "Cao su",
                Values = new ChartValues<double> { }
            });
            _chart1.Series.Add(new ColumnSeries()
            {
                Title = "Điều",
                Values = new ChartValues<double> { }
            });
            _chart1.AxisX.Add(new Axis
            {
                Title = "Thời Gian",
                Labels = new string[] { },
                LabelsRotation = 45
            });

            _chart1.AxisY.Add(new Axis
            {
                Title = "",
                LabelFormatter = value => value.ToString("N")
            });

            // .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromHours(1).Ticks)
            var dayConfig = Mappers.Xy<DateModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks)
                .Y(dayModel => dayModel.Value);

            _chart2.Series = new SeriesCollection();
            _chart2.Series.Add(new LineSeries()
            {
                Title = "Cao su",
                Values = new ChartValues<DateModel>()
            });
            _chart2.Series.Add(new LineSeries()
            {
                Title = "Điều",
                Values = new ChartValues<DateModel>()
            });
            _chart2.Series.Add(new LineSeries()
            {
                Title = "Tạm Ứng",
                Values = new ChartValues<DateModel>()
            });

            _chart2.AxisX.Add(new Axis()
            {
                Title = "Thời gian",
                LabelFormatter = value => new System.DateTime((long)(value)).ToString("yyyy-MM-dd HH:mm"),
                // LabelFormatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("yyyy-MM-dd HH:mm"),
                LabelsRotation = 45
            });
        }

        public void CapNhat(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow)
        {
            try
            {
                _fromTime = fromTime;
                _toTime = toTime;

                labFromDate.Text = _fromTime.ToString("HH:mm:ss dd/MM/yyyy");
                labToDate.Text = _toTime.ToString("HH:mm:ss dd/MM/yyyy");

                _purchaseModels = GetPurchaseModels(fromTime, toTime, customerId, kieu, payNow);
                CapNhatChartThuMua();

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

        private void CapNhatChartThuMua()
        {
            _chart1.Series[0].Values.Clear();
            _chart1.Series[1].Values.Clear();
            _chart1.AxisX[0].Labels.Clear();

            var groups = _purchaseModels.GroupBy(x => x.CreatedDate.ToString("yyyy-MM-dd"));
            foreach (var group in groups)
            {
                double caosu = 0;
                double dieu = 0;

                foreach (var item in group)
                {
                    if (item.Type == "Cao su")
                    {
                        caosu += item.Money;
                    }
                    else
                    {
                        dieu += item.Money;
                    }
                }

                _chart1.Series[0].Values.Add(dieu);
                _chart1.Series[1].Values.Add(caosu);
                _chart1.AxisX[0].Labels.Add(group.Key);
            }

            _chart1.Update(true, true);
        }

        private void CapNhatChartLine()
        {
            _chart2.Series[0].Values.Clear();
            _chart2.Series[1].Values.Clear();

            foreach (var item in _purchaseModels)
            {
                DateModel model = new DateModel();
                model.Value = item.Money;
                model.DateTime = item.CreatedDate;

                if (item.Type == "Cao su")
                {
                    _chart2.Series[0].Values.Add(model);
                }
                else
                {
                    _chart2.Series[1].Values.Add(model);
                }
            }

            foreach (var item in _tamUngModels)
            {
                DateModel model = new DateModel();
                model.Value = item.Money;
                model.DateTime = item.CreatedDate;
                _chart2.Series[2].Values.Add(model);
            }

            _chart2.Update(true, true);
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
            labFromDate.Text = $"{_fromTime:dd/MM/yyyy HH:mm:ss}";
            labToDate.Text = $"{_toTime:dd/MM/yyyy HH:mm:ss}";

            double klCaoSu = _purchaseModels.Where(x => x.Type == "Cao su").Sum(x => x.Weight);
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
                        var wsThongKe = wb.Worksheets.Add("ThongKe");
                        var wsThuMua = wb.Worksheets.Add("ThuMua");
                        var wsTamUng = wb.Worksheets.Add("TamUng");

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
                            dtThuMua.Rows.Add(item.CreatedDate, item.Type, item.Name, item.Weight, item.Price, item.Money, item.PayNow == 1 ? "Đã thanh toán" : "",
                                item.MuTypeName, item.Degree, item.Note);
                        }
                        wsThuMua.Cell("A1").Value = "DANH SÁCH THU MUA";
                        wsThuMua.Range(1, 1, 1, dtThuMua.Columns.Count).Merge().AddToNamed("Titles");
                        wsThuMua.Cell("A2").InsertTable(dtThuMua.AsEnumerable());

                        wsThuMua.Columns().AdjustToContents();
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        if (customerId != null && customerId != 0)
                        {
                            CustomerModel _customerInfo = GlobalVariable.ConnectionDb.Query<CustomerModel>($"select * from customerinfo where Id = {customerId}").First();
                            double klCaoSu = dsThuMua.Where(x => x.Type == "Cao su").Sum(x => x.Weight);
                            double klDieu = dsThuMua.Where(x => x.Type == "Điều").Sum(x => x.Weight);

                            double tongTienThuMua = dsThuMua.Sum(x => x.Money);
                            double tienThuMuaDaThanhToan = dsThuMua.Where(x => x.PayNow == 1).Sum(x => x.Money);
                            double tienThuMuaConLai = tongTienThuMua - tienThuMuaDaThanhToan;

                            double tongTienTamUng = dsTamUng.Sum(x => x.Money);
                            double tienTamUngDaTra = dsTamUng.Where(x => x.Payed == 1).Sum(X => X.Money);
                            double tienTamUngConNo = tongTienTamUng - tienTamUngDaTra;

                            double tongTienPhaiTra = tienThuMuaConLai - tienTamUngConNo;

                            wsThongKe.Range("A1:E25").Style.Font.FontName = "Times New Roman";

                            wsThongKe.Cell("A1").Value = "ĐẠI LÝ THU MUA NÔNG SẢN HAI HỔ";
                            wsThongKe.Range("A1:E1").Merge();//.AddToNamed("Titles");
                            wsThongKe.Range("A1:E1").Style.Font.FontSize = 20;

                            wsThongKe.Cell("A2").Value = "Chuyên thu mua: CAO SU - ĐIỀU - CÀ PHÊ";
                            wsThongKe.Range("A2:E2").Merge();//.AddToNamed("Titles");
                            wsThongKe.Cell("A3").Value = "ĐC: Ấp Sắc Di - Xã Tân Phước - Đồng Phú - Bình Phước";
                            wsThongKe.Range("A3:E3").Merge();//.AddToNamed("Titles");
                            wsThongKe.Cell("A4").Value = "ĐT: 0918 88 00 24";
                            wsThongKe.Range("A4:E4").Merge();//.AddToNamed("Titles");
                            wsThongKe.Range("A2:E4").Style.Font.FontSize = 16;

                            wsThongKe.Cell("A6").Value = "BIÊN LAI THANH TOÁN";
                            wsThongKe.Range("A6:E6").Merge();
                            wsThongKe.Range("A6:E6").Style.Font.FontSize = 20;

                            wsThongKe.Range("A1:E6").Style
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                            wsThongKe.Range("A7:E7").Merge().Value = $"Từ ngày: {fromTime} - Đến ngày: {toTime}";
                            wsThongKe.Range("A7:E7").Merge();
                            wsThongKe.Range("A7:E7").Style
                               .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                               .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                               .Font.FontSize = 12;

                            wsThongKe.Range("A1:E7").Style.Font.Bold = true;

                            wsThongKe.Cell("A9").Value = "Tên khách hàng:";
                            wsThongKe.Cell("B9").Value = _customerInfo.Name;
                            wsThongKe.Range("B9:E9").Merge();//.AddToNamed("Titles");

                            wsThongKe.Cell("A10").Value = "Số điện thoại:";
                            wsThongKe.Cell("B10").Value = $"'{_customerInfo.Phone}";
                            wsThongKe.Range("B10:E10").Merge();//.AddToNamed("Titles");

                            wsThongKe.Cell("A11").Value = "Địa chỉ:";
                            wsThongKe.Cell("B11").Value = _customerInfo.Address;
                            wsThongKe.Range("B11:E11").Merge();//.AddToNamed("Titles");
                            wsThongKe.Range("A9:E11").Style.Font.FontSize = 14;
                            wsThongKe.Range("B9:E11").Style.Font.Bold = true;

                            wsThongKe.Range("A13:B13").Merge().Value = "THU MUA";
                            wsThongKe.Range("C13:D13").Merge().Value = "TẠM ỨNG";
                            wsThongKe.Range("A13:D13").Style
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                .Font.Bold = true;

                            wsThongKe.Cell("A14").Value = "Khối lượng cao su";
                            wsThongKe.Cell("A15").Value = "Khối lượng điều";
                            wsThongKe.Cell("A16").Value = "Tống tiền";
                            wsThongKe.Cell("A17").Value = "Đã thanh toán";
                            wsThongKe.Cell("A18").Value = "Còn lại (a)";
                            wsThongKe.Cell("B14").Value = $"{klCaoSu}";
                            wsThongKe.Cell("B15").Value = $"{klDieu}";
                            wsThongKe.Range("B14:B15").Style
                                .Font.SetBold(true)
                                .NumberFormat.Format = "#,##0.00";
                            wsThongKe.Range("B14:B15").DataType = XLDataType.Number;

                            wsThongKe.Cell("B16").Value = $"{tongTienThuMua}";
                            wsThongKe.Cell("B17").Value = $"{tienThuMuaDaThanhToan}";
                            wsThongKe.Cell("B18").Value = $"{tienThuMuaConLai}";
                            wsThongKe.Range("B16:B18").Style
                                .Font.SetBold(true)
                                .Alignment.SetShrinkToFit(true)
                                .NumberFormat.Format = "#,##0";
                            wsThongKe.Range("B16:B18").DataType = XLDataType.Number;

                            wsThongKe.Cell("C14").Value = "Tổng tiền";
                            wsThongKe.Cell("C15").Value = "Đã trả";
                            wsThongKe.Cell("C16").Value = "Còn nợ (b)";

                            wsThongKe.Cell("D14").Value = tongTienTamUng;
                            wsThongKe.Cell("D15").Value = tienTamUngDaTra;
                            wsThongKe.Cell("D16").Value = tienTamUngConNo;
                            wsThongKe.Range("D14:D16").Style
                                .Font.SetBold(true)
                                .NumberFormat.Format = "#,##0";
                            wsThongKe.Range("D14:D16").DataType = XLDataType.Number;

                            wsThongKe.Range("A13:D18").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
                                   .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                                   .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                                   .Font.FontSize = 14;

                            wsThongKe.Cell("A20").Value = "SỐ TIỀN CẦN THANH THOÁN (a - b)";
                            //wsThongKe.Cell("A16").Style.Alignment.WrapText = true;
                            wsThongKe.Range("A20:D20").Merge();
                            wsThongKe.Range("A21:D21").Merge().Value = $"{tienThuMuaConLai:#,###} - {tienTamUngConNo:#,###} = {tongTienPhaiTra:#,###}";
                            //wsThongKe.Range("A21:D21").Merge();
                            wsThongKe.Range("A20:A21").Style
                                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                                    .Font.FontSize = 14;
                            wsThongKe.Range("A20:A21").Style.Font.Bold = true;

                            wsThongKe.Cell("A24").Value = "Xác nhận bên bán";
                            wsThongKe.Range("A24").Style
                                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left)
                                    .Font.FontSize = 14;

                            wsThongKe.Cell("E24").Value = "Xác nhận bên thu mua";
                            wsThongKe.Range("E24").Style
                                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left)
                                    .Font.FontSize = 14;

                            

                            wsThongKe.Columns().AdjustToContents();
                        }

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
            string query = $"select purchaseinfo.*, customerinfo.Name as Name" +
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
                query = query + $" and purchaseinfo.PayNow = {payNow}";
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
