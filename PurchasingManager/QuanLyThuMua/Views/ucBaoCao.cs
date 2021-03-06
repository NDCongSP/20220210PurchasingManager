using ClosedXML.Excel;
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
using QuanLyThuMua.Utils;
using System.IO;

namespace QuanLyThuMua
{
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

            kryptonNavigator1.SelectedIndex = 0;

            _chart1.Series = new SeriesCollection();
            _chart1.LegendLocation = LegendLocation.Right;

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
            _chart1.Series.Add(new ColumnSeries()
            {
                Title = "Tổng",
                Values = new ChartValues<double> { }
            });
            _chart1.AxisX.Add(new Axis
            {
                Title = "Thời Gian",
                Labels = new string[] { },
                LabelsRotation = 45,
                Foreground = System.Windows.Media.Brushes.Red
            });

            _chart1.AxisY.Add(new Axis
            {
                Title = "Kg",
                LabelFormatter = value => value.ToString("N"),
                Foreground = System.Windows.Media.Brushes.Red
            });

            // .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromHours(1).Ticks)
            var dayConfig = Mappers.Xy<DataModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks)
                .Y(dayModel => dayModel.Value);

            //_chart2.LegendLocation = LegendLocation.Right;
            //_chart2.Series = new SeriesCollection(dayConfig);
            //_chart2.Series.Add(new LineSeries()
            //{
            //    Title = "Cao su",
            //    Values = new ChartValues<DateModel>()
            //});
            //_chart2.Series.Add(new LineSeries()
            //{
            //    Title = "Điều",
            //    Values = new ChartValues<DateModel>()
            //});
            //_chart2.Series.Add(new LineSeries()
            //{
            //    Title = "Tạm Ứng",
            //    Values = new ChartValues<DateModel>()
            //});

            //_chart2.AxisX.Add(new Axis()
            //{
            //    Title = "Thời gian",
            //    LabelFormatter = value => new System.DateTime((long)(value)).ToString("yyyy-MM-dd"),  
            //    // LabelFormatter = value => new System.DateTime((long)(value * TimeSpan.FromHours(1).Ticks)).ToString("yyyy-MM-dd HH:mm"),
            //    LabelsRotation = 45
            //});

            _chart2.LegendLocation = LegendLocation.Right;
            _chart2.Series = new SeriesCollection();
            _chart2.Series.Add(new LineSeries()
            {
                Title = "Cao su",
                Values = new ChartValues<double>()
            });
            _chart2.Series.Add(new LineSeries()
            {
                Title = "Điều",
                Values = new ChartValues<double>()
            });
            _chart2.Series.Add(new LineSeries()
            {
                Title = "Tổng",
                Values = new ChartValues<double>()
            });

            _chart2.AxisX.Add(new Axis()
            {
                Title = "Thời gian",
                LabelFormatter = value => new System.DateTime((long)(value)).ToString("yyyy-MM-dd"),
                Labels = new string[] { },
                LabelsRotation = 45,
                Foreground = System.Windows.Media.Brushes.Red
            });
            _chart2.AxisY.Add(new Axis
            {
                Title = "VNĐ",
                LabelFormatter = value => value.ToString("N"),
                Foreground = System.Windows.Media.Brushes.Red
            });

        }

        public void CapNhat(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow, List<CustomerModel> customerInfo)
        {
            try
            {
                _fromTime = fromTime;
                _toTime = toTime;

                labFromDate.Text = _fromTime.ToString("HH:mm:ss dd/MM/yyyy");
                labToDate.Text = _toTime.ToString("HH:mm:ss dd/MM/yyyy");

                //get đơn hàng thu mua
                _purchaseModels = GetPurchaseModels(fromTime, toTime, customerId, kieu, payNow, customerInfo);

                CapNhatChartThuMua();

                _dgBaoCao.DataSource = _purchaseModels;
                _dgBaoCao.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                //get tạm ứng
                CapNhatTamUng(fromTime, toTime, customerId, payNow, customerInfo);

                CapNhatThongKe();

                CapNhatChartLine();
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
            _chart1.Series[2].Values.Clear();

            List<string> labels = new List<string>();

            var groups = _purchaseModels.GroupBy(x => x.CreatedDate.ToString("yyyy-MM-dd")).OrderBy(x => x.Key);
            foreach (var group in groups)
            {
                double caosu = 0;
                double dieu = 0;

                foreach (var item in group)
                {
                    if (item.Type == "Cao su")
                    {
                        caosu += item.Weight;
                    }
                    else
                    {
                        dieu += item.Weight;
                    }
                }

                _chart1.Series[0].Values.Add(caosu);
                _chart1.Series[1].Values.Add(dieu);
                _chart1.Series[2].Values.Add(dieu + caosu);
                labels.Add(group.Key);
            }
            _chart1.AxisX[0].Labels = labels;
            _chart1.Update(true, true);
        }

        private void CapNhatChartLine()
        {
            _chart2.Series[0].Values.Clear();
            _chart2.Series[1].Values.Clear();
            _chart2.Series[2].Values.Clear();

            //foreach (var item in _purchaseModels.OrderBy(x => x.CreatedDate))
            //{
            //    DateModel model = new DateModel();
            //    model.Value = item.Money;
            //    model.DateTime = item.CreatedDate;

            //    if (item.Type == "Cao su")
            //    {
            //        _chart2.Series[0].Values.Add(model);
            //    }
            //    else
            //    {
            //        _chart2.Series[1].Values.Add(model);
            //    }
            //}

            //foreach (var item in _tamUngModels.OrderBy(x => x.CreatedDate))
            //{
            //    DateModel model = new DateModel();
            //    model.Value = item.Money;
            //    model.DateTime = item.CreatedDate;
            //    _chart2.Series[2].Values.Add(model);
            //}

            List<string> labels = new List<string>();

            var groups = _purchaseModels.GroupBy(x => x.CreatedDate.ToString("yyyy-MM-dd")).OrderBy(x => x.Key);

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

                _chart2.Series[0].Values.Add(caosu);
                _chart2.Series[1].Values.Add(dieu);
                _chart2.Series[2].Values.Add(dieu + caosu);
                labels.Add(group.Key);
            }
            _chart2.AxisX[0].Labels = labels;

            _chart2.Update(true, true);
        }

        private void CapNhatTamUng(DateTime fromTime, DateTime toTime, int? customerId, int payNow, List<CustomerModel> customerList)
        {
            try
            {

                _tamUngModels = GetTamUngs(fromTime, toTime, customerId, payNow, customerList);
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

            double klMuNuoc = _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 0).Sum(x => x.Weight);
            double klMuChen = _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 1).Sum(x => x.Weight);
            double klMuDay = _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 2).Sum(x => x.Weight);

            double klCaoSu = klMuNuoc + klMuChen + klMuDay; // _purchaseModels.Where(x => x.Type == "Cao su").Sum(x => x.Weight);

            double klDieu = _purchaseModels.Where(x => x.Type == "Điều").Sum(x => x.Weight);
            labKlMuNuoc.Text = $"{klMuNuoc:#,##0.00} Kg";
            labKlMuChen.Text = $"{klMuChen:#,##0.00} Kg";
            labKlMuDay.Text = $"{klMuDay:#,##0.00} Kg";
            _lbKLCaoSu.Text = $"{klCaoSu:#,##0.00} Kg";
            _lbKLDieu.Text = $"{klDieu:#,##0.00} Kg";

            double tongTienMuNuoc = _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 0).Sum(x => x.Money);
            double tongTienMuChen = _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 1).Sum(x => x.Money);
            double tongTienMuDay = _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 2).Sum(x => x.Money);

            double tongTienCaoSu = tongTienMuNuoc + tongTienMuChen + tongTienMuDay;
            //double tongTienCaoSu = _purchaseModels.Where(x => x.Type == "Cao su").Sum(x => x.Money);

            double tongTienDieu = _purchaseModels.Where(x => x.Type == "Điều").Sum(x => x.Money);
            double tongTienThuMua = _purchaseModels.Sum(x => x.Money);
            double tienThuMuaDaThanhToan = _purchaseModels.Where(x => x.PayNow == 1).Sum(x => x.Money);
            double tienThuMuaConLai = tongTienThuMua - tienThuMuaDaThanhToan;
            _lbTongTienThuMua.Text = $"{tongTienThuMua:#,##0} VND";
            _lbThuMuaDaThanhToan.Text = $"{tienThuMuaDaThanhToan:#,##0} VND";
            _lbTienThuMuaConLai.Text = $"{tienThuMuaConLai:#,##0} VND";
            labTienCaoSu.Text = $"{tongTienCaoSu:#,##0} VND";
            labTienDieu.Text = $"{tongTienDieu:#,##0} VND";
            labTienMuNuoc.Text = $"{tongTienMuNuoc:#,##0} VND";
            labTienMuChen.Text = $"{tongTienMuChen:#,##0} VND";
            labTienMuDay.Text = $"{tongTienMuDay:#,##0} VND";

            double tongTienTamUng = _tamUngModels.Sum(x => x.Money);
            double tienTamUngDaTra = _tamUngModels.Where(x => x.Payed == 1).Sum(X => X.Money);
            double tienTamUngConNo = tongTienTamUng - tienTamUngDaTra;
            _lbTongTienTamUng.Text = $"{tongTienTamUng:#,##0} VND";
            _lbTienTamUngDaTra.Text = $"{tienTamUngDaTra:#,##0} VND";
            _lbConNo.Text = $"{tienTamUngConNo:#,##0} VND";

            double tongTienPhaiTra = tienThuMuaConLai - tienTamUngConNo;
            _lbTongTienPhaiTra.Text = $"{tienThuMuaConLai:#,##0} - {tienTamUngConNo:#,##0} = {tongTienPhaiTra:#,##0} VND";

            //update thêm tính trung bình số độ, chỉ làm với mủ nước
            //lấy tổng số kg: A
            //tổng tích: số độ x số ký (B). (Từng record riêng)
            //Trung binh độ = B/A
            double sumWeight = _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 0).Sum(x => x.Weight);
            double sumTongTich = 0;
            foreach (var item in _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 0))
            {
                sumTongTich = sumTongTich + (item.Degree * item.Weight);
            }
            //double avgSoDo = _purchaseModels.Where(x => x.Type == "Cao su" && x.MuType == 0).Average(x => x.Degree);
            double avgSoDo = sumTongTich / sumWeight;
            labAvgDegree.Text = $"{avgSoDo:#,##0.##}";
        }

        public void XuatExcelThanhToan(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow, List<CustomerModel> customerInfo)
        {
            try
            {
                //SaveFileDialog sfd = new SaveFileDialog();
                //sfd.Filter = "Excel File |*.xlsx";
                //sfd.FileName = "BaoCao";

                //if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var dsThuMua = GetPurchaseModels(fromTime, toTime, customerId, kieu, payNow, customerInfo);
                    var dsTamUng = GetTamUngs(fromTime, toTime, customerId, payNow, customerInfo);

                    //using (var wb = new XLWorkbook())
                    //{
                    //    var wsThongKe = wb.Worksheets.Add("ThongKe");
                    //    var wsThuMua = wb.Worksheets.Add("ThuMua");
                    //    var wsTamUng = wb.Worksheets.Add("TamUng");

                    if (customerInfo != null)//&& customerInfo.Count == 1)
                    {
                        foreach (var itemCustomer in customerInfo)//xuat thanh toan cho nhieu khach hang cung luc
                        {
                            using (var wb = new XLWorkbook())
                            {
                                var wsThongKe = wb.Worksheets.Add("ThongKe");
                                var wsThuMua = wb.Worksheets.Add("ThuMua");
                                var wsTamUng = wb.Worksheets.Add("TamUng");

                                #region Tạo sheet thống kê
                                CustomerModel _customerInfo = new CustomerModel();

                                #region cập nhật trạng thái đã thanh toán, và xóa các tạm ứng
                                var listUpdateThanhtoan = dsThuMua.Where(x => x.PayNow == 0 && x.CustomerId == itemCustomer.Id).ToList();
                                var listUpdateTamUngThanhToan = dsTamUng.Where(x => x.Payed == 0 && x.CustomerId == itemCustomer.Id).ToList();
                                var paidDate = DateTime.Now;

                                foreach (var item in listUpdateThanhtoan)
                                {
                                    item.PaidDate = paidDate;
                                    //item.PayNow = 1;
                                }
                                foreach (var item in listUpdateTamUngThanhToan)
                                {
                                    item.PaidDate = paidDate;
                                    //item.Payed = 1;
                                }

                                GlobalVariable.ConnectionDb.Execute(@"Update purchaseinfo set PaidDate = @PaidDate, PayNow = 1 where Id = @Id", listUpdateThanhtoan);
                                GlobalVariable.ConnectionDb.Execute(@"Update tamung set PaidDate = @PaidDate, Payed = 1 where Id = @Id", listUpdateTamUngThanhToan);
                                #endregion

                                _customerInfo = GlobalVariable.ConnectionDb.Query<CustomerModel>($"select * from customerinfo where Id = {itemCustomer.Id}").First();
                                double klCaoSu = dsThuMua.Where(x => x.Type == "Cao su" && x.CustomerId == itemCustomer.Id).Sum(x => x.Weight);
                                double klDieu = dsThuMua.Where(x => x.Type == "Điều" && x.CustomerId == itemCustomer.Id).Sum(x => x.Weight);

                                double tongTienThuMua = dsThuMua.Where(x => x.CustomerId == itemCustomer.Id).Sum(x => x.Money);
                                double tienThuMuaDaThanhToan = dsThuMua.Where(x => x.PayNow == 1 && x.CustomerId == itemCustomer.Id).Sum(x => x.Money);
                                double tienThuMuaConLai = tongTienThuMua - tienThuMuaDaThanhToan;

                                double tongTienTamUng = dsTamUng.Where(x => x.CustomerId == itemCustomer.Id).Sum(x => x.Money);
                                double tienTamUngDaTra = dsTamUng.Where(x => x.Payed == 1 && x.CustomerId == itemCustomer.Id).Sum(X => X.Money);
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
                                    .Alignment.SetShrinkToFit(true)
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
                                    .Alignment.SetShrinkToFit(true)
                                    .NumberFormat.Format = "#,##0";
                                wsThongKe.Range("D14:D16").DataType = XLDataType.Number;

                                wsThongKe.Range("A13:D18").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
                                       .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                                       .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                                       .Font.FontSize = 14;

                                wsThongKe.Cell("A20").Value = "SỐ TIỀN CẦN THANH THOÁN (a - b)";
                                //wsThongKe.Cell("A16").Style.Alignment.WrapText = true;
                                wsThongKe.Range("A20:D20").Merge();
                                wsThongKe.Range("A21:D21").Merge().Value = $"{tienThuMuaConLai:#,##0} - {tienTamUngConNo:#,##0} = {tongTienPhaiTra:#,##0}";
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

                                wsThongKe.Cell("E23").Value = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                                wsThongKe.Cell("E24").Value = "Xác nhận bên thu mua";
                                wsThongKe.Range("E24").Style
                                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left)
                                        .Font.FontSize = 14;

                                wsThongKe.Columns().AdjustToContents();
                                #endregion

                                #region Tạo sheet thu mua
                                DataTable dtThuMua = new DataTable();
                                dtThuMua.Columns.Add("Ngày Mua", typeof(DateTime));
                                dtThuMua.Columns.Add("Kiểu", typeof(string));
                                dtThuMua.Columns.Add("Khách Hàng", typeof(string));
                                dtThuMua.Columns.Add("Kiểu Mủ", typeof(string));
                                dtThuMua.Columns.Add("Khối Lượng", typeof(double));
                                dtThuMua.Columns.Add("Độ", typeof(double));
                                dtThuMua.Columns.Add("Đơn Giá", typeof(double));
                                dtThuMua.Columns.Add("Thành Tiền", typeof(double));
                                dtThuMua.Columns.Add("Thanh Toán", typeof(string));
                                dtThuMua.Columns.Add("Ghi Chú", typeof(string));

                                foreach (var item in dsThuMua.Where(x => x.CustomerId == itemCustomer.Id))
                                {
                                    dtThuMua.Rows.Add(item.CreatedDate, item.Type, item.Name, item.MuTypeName, item.Weight, item.Degree, 
                                        item.Price, item.Money, item.PayNow == 1 ? "Đã thanh toán" : "", item.Note);
                                }
                                wsThuMua.Cell("A1").Value = "DANH SÁCH THU MUA";
                                wsThuMua.Range(1, 1, 1, dtThuMua.Columns.Count).Merge().AddToNamed("Titles");

                                wsThuMua.Range(2, 1, 2, dtThuMua.Columns.Count).Merge().Value = $"Từ ngày: {fromTime} - Đến ngày: {toTime}";
                                wsThuMua.Range(2, 1, 2, dtThuMua.Columns.Count).Style
                                   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                                   .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                                   .Font.FontSize = 12;

                                wsThuMua.Cell("A3").InsertTable(dtThuMua.AsEnumerable());

                                wsThuMua.Columns().AdjustToContents();
                                #endregion

                                #region tạo sheet tạm ứng
                                DataTable dtTamUng = new DataTable();
                                dtTamUng.Columns.Add("Ngày Ứng", typeof(DateTime));
                                dtTamUng.Columns.Add("Khách Hàng", typeof(string));
                                dtTamUng.Columns.Add("Số Tiền", typeof(double));
                                dtTamUng.Columns.Add("Ghi Chú", typeof(string));

                                foreach (var item in dsTamUng.Where(x => x.CustomerId == itemCustomer.Id))
                                {
                                    dtTamUng.Rows.Add(item.CreatedDate, item.TenKhachHang, item.Money, item.Note);
                                }
                                wsTamUng.Cell(1, 1).Value = "DANH SÁCH TẠM ỨNG";
                                wsTamUng.Range(1, 1, 1, dtTamUng.Columns.Count).Merge().AddToNamed("Titles");

                                wsTamUng.Range(2, 1, 2, dtTamUng.Columns.Count).Merge().Value = $"Từ ngày: {fromTime} - Đến ngày: {toTime}";
                                wsTamUng.Range(2, 1, 2, dtTamUng.Columns.Count).Style
                                   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                                   .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                                   .Font.FontSize = 10;

                                wsTamUng.Cell(3, 1).InsertTable(dtTamUng.AsEnumerable());
                                wsTamUng.Columns().AdjustToContents();
                                #endregion

                                // Prepare the style for the titles
                                var titlesStyle = wb.Style;
                                titlesStyle.Font.Bold = true;
                                titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                titlesStyle.Fill.BackgroundColor = XLColor.BlueGreen;

                                // Format all titles in one shot
                                wb.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;

                                string _pathOpen = Path.Combine(GlobalVariable.PathFile, $"ThanhToan");
                                if (Directory.Exists($"{_pathOpen}"))
                                {
                                    _pathOpen = Path.Combine(_pathOpen, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_ThanhToan_{_customerInfo.Name}.xlsx");
                                    wb.SaveAs(_pathOpen);
                                }
                                else
                                {
                                    Directory.CreateDirectory(_pathOpen);
                                    _pathOpen = Path.Combine(_pathOpen, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_ThanhToan_{_customerInfo.Name}.xlsx");
                                    wb.SaveAs(_pathOpen);
                                }

                                //wb.SaveAs(sfd.FileName);
                                if (customerInfo.Count() == 1)
                                {
                                    SUtils.OpenFile(_pathOpen);
                                }
                            }
                        }

                        #region Tạo báo cáo thanh toán
                        //#region Tạo sheet thống kê
                        //CustomerModel _customerInfo = new CustomerModel();

                        //#region cập nhật trạng thái đã thanh toán, và xóa các tạm ứng
                        //var listUpdateThanhtoan = dsThuMua.Where(x => x.PayNow == 0).ToList();
                        //var listUpdateTamUngThanhToan = dsTamUng.Where(x => x.Payed == 0).ToList();
                        //var paidDate = DateTime.Now;

                        //foreach (var item in listUpdateThanhtoan)
                        //{
                        //    item.PaidDate = paidDate;
                        //    //item.PayNow = 1;
                        //}
                        //foreach (var item in listUpdateTamUngThanhToan)
                        //{
                        //    item.PaidDate = paidDate;
                        //    //item.Payed = 1;
                        //}

                        //GlobalVariable.ConnectionDb.Execute(@"Update purchaseinfo set PaidDate = @PaidDate, PayNow = 1 where Id = @Id", listUpdateThanhtoan);
                        //GlobalVariable.ConnectionDb.Execute(@"Update tamung set PaidDate = @PaidDate, Payed = 1 where Id = @Id", listUpdateTamUngThanhToan);
                        //#endregion

                        //_customerInfo = GlobalVariable.ConnectionDb.Query<CustomerModel>($"select * from customerinfo where Id = {customerInfo[0].Id}").First();
                        //double klCaoSu = dsThuMua.Where(x => x.Type == "Cao su").Sum(x => x.Weight);
                        //double klDieu = dsThuMua.Where(x => x.Type == "Điều").Sum(x => x.Weight);

                        //double tongTienThuMua = dsThuMua.Sum(x => x.Money);
                        //double tienThuMuaDaThanhToan = dsThuMua.Where(x => x.PayNow == 1).Sum(x => x.Money);
                        //double tienThuMuaConLai = tongTienThuMua - tienThuMuaDaThanhToan;

                        //double tongTienTamUng = dsTamUng.Sum(x => x.Money);
                        //double tienTamUngDaTra = dsTamUng.Where(x => x.Payed == 1).Sum(X => X.Money);
                        //double tienTamUngConNo = tongTienTamUng - tienTamUngDaTra;

                        //double tongTienPhaiTra = tienThuMuaConLai - tienTamUngConNo;

                        //wsThongKe.Range("A1:E25").Style.Font.FontName = "Times New Roman";

                        //wsThongKe.Cell("A1").Value = "ĐẠI LÝ THU MUA NÔNG SẢN HAI HỔ";
                        //wsThongKe.Range("A1:E1").Merge();//.AddToNamed("Titles");
                        //wsThongKe.Range("A1:E1").Style.Font.FontSize = 20;

                        //wsThongKe.Cell("A2").Value = "Chuyên thu mua: CAO SU - ĐIỀU - CÀ PHÊ";
                        //wsThongKe.Range("A2:E2").Merge();//.AddToNamed("Titles");
                        //wsThongKe.Cell("A3").Value = "ĐC: Ấp Sắc Di - Xã Tân Phước - Đồng Phú - Bình Phước";
                        //wsThongKe.Range("A3:E3").Merge();//.AddToNamed("Titles");
                        //wsThongKe.Cell("A4").Value = "ĐT: 0918 88 00 24";
                        //wsThongKe.Range("A4:E4").Merge();//.AddToNamed("Titles");
                        //wsThongKe.Range("A2:E4").Style.Font.FontSize = 16;

                        //wsThongKe.Cell("A6").Value = "BIÊN LAI THANH TOÁN";
                        //wsThongKe.Range("A6:E6").Merge();
                        //wsThongKe.Range("A6:E6").Style.Font.FontSize = 20;

                        //wsThongKe.Range("A1:E6").Style
                        //    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        //    .Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                        //wsThongKe.Range("A7:E7").Merge().Value = $"Từ ngày: {fromTime} - Đến ngày: {toTime}";
                        //wsThongKe.Range("A7:E7").Merge();
                        //wsThongKe.Range("A7:E7").Style
                        //   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                        //   .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        //   .Font.FontSize = 12;

                        //wsThongKe.Range("A1:E7").Style.Font.Bold = true;

                        //wsThongKe.Cell("A9").Value = "Tên khách hàng:";
                        //wsThongKe.Cell("B9").Value = _customerInfo.Name;
                        //wsThongKe.Range("B9:E9").Merge();//.AddToNamed("Titles");

                        //wsThongKe.Cell("A10").Value = "Số điện thoại:";
                        //wsThongKe.Cell("B10").Value = $"'{_customerInfo.Phone}";
                        //wsThongKe.Range("B10:E10").Merge();//.AddToNamed("Titles");

                        //wsThongKe.Cell("A11").Value = "Địa chỉ:";
                        //wsThongKe.Cell("B11").Value = _customerInfo.Address;
                        //wsThongKe.Range("B11:E11").Merge();//.AddToNamed("Titles");
                        //wsThongKe.Range("A9:E11").Style.Font.FontSize = 14;
                        //wsThongKe.Range("B9:E11").Style.Font.Bold = true;

                        //wsThongKe.Range("A13:B13").Merge().Value = "THU MUA";
                        //wsThongKe.Range("C13:D13").Merge().Value = "TẠM ỨNG";
                        //wsThongKe.Range("A13:D13").Style
                        //    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                        //    .Font.Bold = true;

                        //wsThongKe.Cell("A14").Value = "Khối lượng cao su";
                        //wsThongKe.Cell("A15").Value = "Khối lượng điều";
                        //wsThongKe.Cell("A16").Value = "Tống tiền";
                        //wsThongKe.Cell("A17").Value = "Đã thanh toán";
                        //wsThongKe.Cell("A18").Value = "Còn lại (a)";
                        //wsThongKe.Cell("B14").Value = $"{klCaoSu}";
                        //wsThongKe.Cell("B15").Value = $"{klDieu}";
                        //wsThongKe.Range("B14:B15").Style
                        //    .Font.SetBold(true)
                        //    .Alignment.SetShrinkToFit(true)
                        //    .NumberFormat.Format = "#,##0.00";
                        //wsThongKe.Range("B14:B15").DataType = XLDataType.Number;

                        //wsThongKe.Cell("B16").Value = $"{tongTienThuMua}";
                        //wsThongKe.Cell("B17").Value = $"{tienThuMuaDaThanhToan}";
                        //wsThongKe.Cell("B18").Value = $"{tienThuMuaConLai}";
                        //wsThongKe.Range("B16:B18").Style
                        //    .Font.SetBold(true)
                        //    .Alignment.SetShrinkToFit(true)
                        //    .NumberFormat.Format = "#,##0";
                        //wsThongKe.Range("B16:B18").DataType = XLDataType.Number;

                        //wsThongKe.Cell("C14").Value = "Tổng tiền";
                        //wsThongKe.Cell("C15").Value = "Đã trả";
                        //wsThongKe.Cell("C16").Value = "Còn nợ (b)";

                        //wsThongKe.Cell("D14").Value = tongTienTamUng;
                        //wsThongKe.Cell("D15").Value = tienTamUngDaTra;
                        //wsThongKe.Cell("D16").Value = tienTamUngConNo;
                        //wsThongKe.Range("D14:D16").Style
                        //    .Font.SetBold(true)
                        //    .Alignment.SetShrinkToFit(true)
                        //    .NumberFormat.Format = "#,##0";
                        //wsThongKe.Range("D14:D16").DataType = XLDataType.Number;

                        //wsThongKe.Range("A13:D18").Style.Border.SetInsideBorder(XLBorderStyleValues.Thin)
                        //       .Border.SetOutsideBorder(XLBorderStyleValues.Thin)
                        //       .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        //       .Font.FontSize = 14;

                        //wsThongKe.Cell("A20").Value = "SỐ TIỀN CẦN THANH THOÁN (a - b)";
                        ////wsThongKe.Cell("A16").Style.Alignment.WrapText = true;
                        //wsThongKe.Range("A20:D20").Merge();
                        //wsThongKe.Range("A21:D21").Merge().Value = $"{tienThuMuaConLai:#,##0} - {tienTamUngConNo:#,##0} = {tongTienPhaiTra:#,##0}";
                        ////wsThongKe.Range("A21:D21").Merge();
                        //wsThongKe.Range("A20:A21").Style
                        //        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        //        .Font.FontSize = 14;
                        //wsThongKe.Range("A20:A21").Style.Font.Bold = true;

                        //wsThongKe.Cell("A24").Value = "Xác nhận bên bán";
                        //wsThongKe.Range("A24").Style
                        //        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        //        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left)
                        //        .Font.FontSize = 14;

                        //wsThongKe.Cell("E23").Value = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                        //wsThongKe.Cell("E24").Value = "Xác nhận bên thu mua";
                        //wsThongKe.Range("E24").Style
                        //        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        //        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left)
                        //        .Font.FontSize = 14;

                        //wsThongKe.Columns().AdjustToContents();
                        //#endregion

                        //#region Tạo sheet thu mua
                        //DataTable dtThuMua = new DataTable();
                        //dtThuMua.Columns.Add("Ngày Mua", typeof(DateTime));
                        //dtThuMua.Columns.Add("Kiểu", typeof(string));
                        //dtThuMua.Columns.Add("Khách Hàng", typeof(string));
                        //dtThuMua.Columns.Add("Khối Lượng", typeof(double));
                        //dtThuMua.Columns.Add("Đơn Giá", typeof(double));
                        //dtThuMua.Columns.Add("Thành Tiền", typeof(double));
                        //dtThuMua.Columns.Add("Thanh Toán", typeof(string));
                        //dtThuMua.Columns.Add("Kiểu Mủ", typeof(string));
                        //dtThuMua.Columns.Add("Độ", typeof(double));
                        //dtThuMua.Columns.Add("Ghi Chú", typeof(string));

                        //foreach (var item in dsThuMua)
                        //{
                        //    dtThuMua.Rows.Add(item.CreatedDate, item.Type, item.Name, item.Weight, item.Price, item.Money, item.PayNow == 1 ? "Đã thanh toán" : "",
                        //        item.MuTypeName, item.Degree, item.Note);
                        //}
                        //wsThuMua.Cell("A1").Value = "DANH SÁCH THU MUA";
                        //wsThuMua.Range(1, 1, 1, dtThuMua.Columns.Count).Merge().AddToNamed("Titles");

                        //wsThuMua.Range(2, 1, 2, dtThuMua.Columns.Count).Merge().Value = $"Từ ngày: {fromTime} - Đến ngày: {toTime}";
                        //wsThuMua.Range(2, 1, 2, dtThuMua.Columns.Count).Style
                        //   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                        //   .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        //   .Font.FontSize = 12;

                        //wsThuMua.Cell("A3").InsertTable(dtThuMua.AsEnumerable());

                        //wsThuMua.Columns().AdjustToContents();
                        //#endregion

                        //#region tạo sheet tạm ứng
                        //DataTable dtTamUng = new DataTable();
                        //dtTamUng.Columns.Add("Ngày Ứng", typeof(DateTime));
                        //dtTamUng.Columns.Add("Khách Hàng", typeof(string));
                        //dtTamUng.Columns.Add("Số Tiền", typeof(double));
                        //dtTamUng.Columns.Add("Ghi Chú", typeof(string));

                        //foreach (var item in dsTamUng)
                        //{
                        //    dtTamUng.Rows.Add(item.CreatedDate, item.TenKhachHang, item.Money, item.Note);
                        //}
                        //wsTamUng.Cell(1, 1).Value = "DANH SÁCH TẠM ỨNG";
                        //wsTamUng.Range(1, 1, 1, dtTamUng.Columns.Count).Merge().AddToNamed("Titles");

                        //wsTamUng.Range(2, 1, 2, dtTamUng.Columns.Count).Merge().Value = $"Từ ngày: {fromTime} - Đến ngày: {toTime}";
                        //wsTamUng.Range(2, 1, 2, dtTamUng.Columns.Count).Style
                        //   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                        //   .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        //   .Font.FontSize = 10;

                        //wsTamUng.Cell(3, 1).InsertTable(dtTamUng.AsEnumerable());
                        //wsTamUng.Columns().AdjustToContents();
                        //#endregion

                        //// Prepare the style for the titles
                        //var titlesStyle = wb.Style;
                        //titlesStyle.Font.Bold = true;
                        //titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        //titlesStyle.Fill.BackgroundColor = XLColor.BlueGreen;

                        //// Format all titles in one shot
                        //wb.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;

                        //string _pathOpen = Path.Combine(GlobalVariable.PathFile, $"ThanhToan");
                        //if (Directory.Exists($"{_pathOpen}"))
                        //{
                        //    _pathOpen = Path.Combine(_pathOpen, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_ThanhToan_{_customerInfo.Name}.xlsx");
                        //    wb.SaveAs(_pathOpen);
                        //}
                        //else
                        //{
                        //    Directory.CreateDirectory(_pathOpen);
                        //    _pathOpen = Path.Combine(_pathOpen, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_ThanhToan_{_customerInfo.Name}.xlsx");
                        //    wb.SaveAs(_pathOpen);
                        //}

                        ////wb.SaveAs(sfd.FileName);
                        //SUtils.OpenFile(_pathOpen);
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn tên khách hàng, hoặc chọn nhiều hơn 1 khách hàng (chỉ được chọn duy nhất 1 khách hàng để thanh toán). Mời chọn lại.", "CẢNH BÁO", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi: {ex}");
            }
        }

        public void XuatExcel(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow, List<CustomerModel> customerInfo)
        {
            try
            {
                //SaveFileDialog sfd = new SaveFileDialog();
                //sfd.Filter = "Excel File |*.xlsx";
                //sfd.FileName = "BaoCao";

                //if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var dsThuMua = GetPurchaseModels(fromTime, toTime, customerId, kieu, payNow, customerInfo);

                    using (var wb = new XLWorkbook())
                    {
                        var wsThuMua = wb.Worksheets.Add("ThuMua");
                        var wsTamUng = wb.Worksheets.Add("TamUng");

                        DataTable dtThuMua = new DataTable();
                        dtThuMua.Columns.Add("Ngày Mua", typeof(DateTime));
                        dtThuMua.Columns.Add("Kiểu", typeof(string));
                        dtThuMua.Columns.Add("Khách Hàng", typeof(string));
                        dtThuMua.Columns.Add("Kiểu Mủ", typeof(string));
                        dtThuMua.Columns.Add("Khối Lượng", typeof(double));
                        dtThuMua.Columns.Add("Độ", typeof(double));
                        dtThuMua.Columns.Add("Đơn Giá", typeof(double));
                        dtThuMua.Columns.Add("Thành Tiền", typeof(double));
                        dtThuMua.Columns.Add("Thanh Toán", typeof(string));
                        dtThuMua.Columns.Add("Ghi Chú", typeof(string));

                        foreach (var item in dsThuMua)
                        {
                            dtThuMua.Rows.Add(item.CreatedDate, item.Type, item.Name, item.MuTypeName, item.Weight, item.Degree,
                                item.Price, item.Money, item.PayNow == 1 ? "Đã thanh toán" : "", item.Note);
                        }
                        wsThuMua.Cell("A1").Value = "DANH SÁCH THU MUA";
                        wsThuMua.Range(1, 1, 1, dtThuMua.Columns.Count).Merge().AddToNamed("Titles");

                        wsThuMua.Range(2, 1, 2, dtThuMua.Columns.Count).Merge().Value = $"Từ ngày: {fromTime} - Đến ngày: {toTime}";
                        wsThuMua.Range(2, 1, 2, dtThuMua.Columns.Count).Style
                           .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                           .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                           .Font.FontSize = 12;

                        wsThuMua.Cell("A3").InsertTable(dtThuMua.AsEnumerable());

                        wsThuMua.Columns().AdjustToContents();
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        var dsTamUng = GetTamUngs(fromTime, toTime, customerId, payNow, customerInfo);
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

                        wsTamUng.Range(2, 1, 2, dtTamUng.Columns.Count).Merge().Value = $"Từ ngày: {fromTime} - Đến ngày: {toTime}";
                        wsTamUng.Range(2, 1, 2, dtTamUng.Columns.Count).Style
                           .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                           .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                           .Font.FontSize = 10;

                        wsTamUng.Cell(3, 1).InsertTable(dtTamUng.AsEnumerable());
                        wsTamUng.Columns().AdjustToContents();

                        // Prepare the style for the titles
                        var titlesStyle = wb.Style;
                        titlesStyle.Font.Bold = true;
                        titlesStyle.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        titlesStyle.Fill.BackgroundColor = XLColor.BlueGreen;

                        // Format all titles in one shot
                        wb.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;

                        string _pathOpen = Path.Combine(GlobalVariable.PathFile, $"BaoCao");
                        if (Directory.Exists($"{_pathOpen}"))
                        {
                            _pathOpen = Path.Combine(_pathOpen, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx");
                            wb.SaveAs(_pathOpen);
                        }
                        else
                        {
                            Directory.CreateDirectory(_pathOpen);
                            _pathOpen = Path.Combine(_pathOpen, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx");
                            wb.SaveAs(_pathOpen);
                        }

                        //wb.SaveAs(sfd.FileName);
                        if (MessageBox.Show($"Xuất báo cáo thành công! Bạn có muốn mở file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            SUtils.OpenFile(_pathOpen);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi: {ex}");
            }
        }

        public List<PurchaseModel> GetPurchaseModels(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow, List<CustomerModel> customerList)
        {
            string query = $"select purchaseinfo.*, customerinfo.Name as Name, " +
                $"case when purchaseinfo.MuType = 1 then 'Mủ chén' " +
                $"when purchaseinfo.MuType = 0 then 'Mủ nước' " +
                $"when purchaseinfo.MuType = 2 then 'Mủ dây' " +
                $"else '' end MuTypeName" +
                $" from purchaseinfo inner JOIN customerinfo ON customerinfo.Id = purchaseinfo.CustomerId" +
                $" where purchaseinfo.CreatedDate > '{fromTime:yyyy-MM-dd HH:mm:ss}' and purchaseinfo.CreatedDate < '{toTime:yyyy-MM-dd HH:mm:ss}' and Actived = 1";

            //if (customerId != null && customerId != 0)
            //{
            //    query = query + $" and purchaseinfo.CustomerId = {customerId.Value}";
            //}

            if (!string.IsNullOrWhiteSpace(kieu) && kieu != "Tất Cả")
            {
                query = query + $" and purchaseinfo.Type = '{kieu}'";
            }

            if (payNow == 1 || payNow == 0)
            {
                query = query + $" and purchaseinfo.PayNow = {payNow}";
            }

            if (customerList != null && customerList.Count > 0)
            {
                string _where = null;
                foreach (var item in customerList)
                {
                    if (_where == null)
                    {
                        _where = _where + $"{item.Id}";
                    }
                    else
                    {
                        _where = _where + $",{item.Id}";
                    }
                }

                query = query + $" and purchaseinfo.CustomerId in ( {_where} )";
            }

            var result = GlobalVariable.ConnectionDb.Query<PurchaseModel>(query + " order by Id desc").AsList();
            return result;
        }

        public List<TamUngModel> GetTamUngs(DateTime fromTime, DateTime toTime, int? customerId, int payNow, List<CustomerModel> customerList)
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

            if (customerList != null && customerList.Count > 0)
            {
                string _where = null;
                foreach (var item in customerList)
                {
                    if (_where == null)
                    {
                        _where = _where + $"{item.Id}";
                    }
                    else
                    {
                        _where = _where + $",{item.Id}";
                    }
                }

                query = query + $" and tamung.CustomerId in ( {_where} )";
            }
            var result = GlobalVariable.ConnectionDb.Query<TamUngModel>(query).AsList();
            return result;
        }

        public void ThanhToan(DateTime fromTime, DateTime toTime, int? customerId, string kieu, int payNow, List<CustomerModel> customerInfo)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn thanh toán?", "CẢNH BẢO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                XuatExcelThanhToan(fromTime, toTime, customerId, kieu, payNow, customerInfo);
            }
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

    public class DataModel
    {
        public System.DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}
