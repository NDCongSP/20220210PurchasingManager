using ClosedXML.Excel;
using ComponentFactory.Krypton.Toolkit;
using Dapper;
using QuanLyThuMua.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuMua
{
    public partial class frmThuMuaDieu : Form
    {
        PurchaseModel purchaseModel = new PurchaseModel();
        List<CustomerModel> ls_CustomerInfo = new List<CustomerModel>();
        CustomerModel CurrentCustomer = new CustomerModel();
        PriceModel LastestPrice = new PriceModel();
        string strExeFilePath;
        //This will strip just the working path name:
        //C:\Program Files\MyApplication
        string strWorkPath;
        string fileName;
        bool LoaiCaoSu = true;//True:mủ nước; flase: mủ chén
        CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        public frmThuMuaDieu()
        {
            InitializeComponent();
            Load += FrmThuMua_Load;
            cbbKH.SelectedValueChanged += CbbKH_SelectedValueChanged;
            txtKL.Validating += TxtKL_Validating;
            txtKL.Validated += TxtKL_Validated;
            txtKL.TextChanged += TxtKL_TextChanged;
         
            btnSave.Click += BtnLuu_Click;
            txtDongia.Validating += TxtDongia_Validating;
            txtDongia.Validated += TxtDongia_Validated;
            txtDongia.TextChanged += TxtDongia_TextChanged;
            btnExit.Click += BtnExit_Click;
            ckbPayNow.CheckedChanged += CkbPayNow_CheckedChanged;
        }
        #region Props
        public string Type { get; set; } = "Điều";
        public event EventHandler OnPurchaseInserted;

        #endregion
        #region Methods
        private void GetListCustomer()
        {
            ls_CustomerInfo = GlobalVariable.ConnectionDb.Query<CustomerModel>("call spCustomerSelectAll").ToList();
            cbbKH.DataSource = ls_CustomerInfo;
            cbbKH.ValueMember = "Id";
            cbbKH.DisplayMember = "Name";
        }
        private void GetLastestPrice(string type)
        {
            var param = new DynamicParameters();
            param.Add("@_type", type);
            LastestPrice = GlobalVariable.ConnectionDb.Query<PriceModel>("spPriceGetLatestPrice", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        private int InsertPurchase(PurchaseModel purchaseModel)
        {
            var param = new DynamicParameters();
            param.Add("@customerId", purchaseModel.CustomerId);
            param.Add("@_type", purchaseModel.Type);
            param.Add("@weight", purchaseModel.Weight);
            param.Add("@priceId", purchaseModel.PriceId);
            param.Add("@price", purchaseModel.Price);
            param.Add("@payNow", purchaseModel.PayNow);
            param.Add("@muType", purchaseModel.MuType);
            param.Add("@degree", purchaseModel.Degree);
            param.Add("@note", purchaseModel.Note);
            return GlobalVariable.ConnectionDb.Execute("spPurchaseInsert", param, commandType: CommandType.StoredProcedure);
        }
        private void LoadTemplate()
        {

            var workbook = new XLWorkbook(fileName);
            var ws = workbook.Worksheet(1);
            var row = ws.Row(10);
            var cell = row.Cell(1);
            string loaiHang = "";

            if (Type == "Cao su")
            {
                loaiHang = "CaoSu";

                if (LoaiCaoSu)//Mủ nước
                {
                    ws.Cell("C10").Value = $"Cao su (mủ nước)";
                }
                else//mủ chén
                {
                    ws.Cell("C10").Value = $"Cao su (mủ chén)";
                }
                //cell.Value = $"Tên hàng: Cao su";
            }
            else
            {
                loaiHang = "Dieu";

                ws.Cell("C10").Value = $"Điều";
                //cell.Value = $"Tên hàng: Điều";
            }
            ws.Cell("A8").Value = $"'{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
            ws.Cell("C11").Value = $"{purchaseModel.Name}";
            ws.Cell("C12").Value = $"'{purchaseModel.Phone}";
            ws.Cell("C13").Value = $"{purchaseModel.Address}";
            ws.Cell("C15").Value = $"{purchaseModel.Weight.ToString("#,###.##", culture.NumberFormat)}";
            ws.Cell("F15").Value = $"";
            ws.Cell("G15").Value = $"";
            ws.Cell("C16").Value = $"{purchaseModel.Price.ToString("#,###", culture.NumberFormat)} VNĐ";

            var degree = purchaseModel.Degree != 0 ? purchaseModel.Degree : 1;
            double tongTien = purchaseModel.Price * Convert.ToDouble(degree) * purchaseModel.Weight;

            ws.Cell("C18").Value = $"{tongTien.ToString("#,###", culture.NumberFormat)} VNĐ";
            string value = cell.GetValue<string>();
        
            //workbook.Save();

            //lay ten file de su dung  cho metho open file khi xuat excel xong
            purchaseModel.PathFileExcelOpen = Path.Combine(GlobalVariable.PathFile, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{loaiHang}_{purchaseModel.Name}.xlsx");
            if (Directory.Exists($"{GlobalVariable.PathFile}"))
            {
                workbook.SaveAs(purchaseModel.PathFileExcelOpen);
            }
            else
            {
                Directory.CreateDirectory(GlobalVariable.PathFile);
                workbook.SaveAs(purchaseModel.PathFileExcelOpen);
            }
        }
        private void SendToPrinter(string fileName)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = fileName;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process p = new Process();
            p.StartInfo = info;
            p.Start();
            p?.WaitForInputIdle();
            System.Threading.Thread.Sleep(5000);
            if (false == p?.CloseMainWindow())
                if (!p.HasExited)
                {
                    p.Kill();
                }
        }

        void UpdateTotalMoney()
        {
            txtThanhtien.Text = ((Double.TryParse(txtDongia.Text, out double res) ? res : LastestPrice.Price) * (Double.TryParse(txtKL.Text, out double res2) ? res2 : 0)).ToString("#,###", culture.NumberFormat);
        }
        private void Handle_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (float.TryParse(tb.Text, out float res) && !string.IsNullOrEmpty(tb.Text))
            {
                culture = CultureInfo.GetCultureInfo("en-US");   // try with "en-US"
                tb.Text = double.Parse(tb.Text).ToString("#,###", culture.NumberFormat);
                tb.Select(tb.TextLength, 0);
                UpdateTotalMoney();
            }
        }
        #endregion
        #region Events

        private void FrmThuMua_Load(object sender, EventArgs e)
        {
            //Initial Data
            GetListCustomer();
            GetLastestPrice(Type);
            txtDongia.Text = LastestPrice.Price.ToString("#,###", culture.NumberFormat);
            strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //This will strip just the working path name:
            //C:\Program Files\MyApplication
            strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            fileName = System.IO.Path.Combine(strWorkPath, "Templates", "TemplateBill.xlsx");
            txtSdt.DataBindings.Add("Text", ls_CustomerInfo, "Phone");
            txtDiachi.DataBindings.Add("Text", ls_CustomerInfo, "Address");
        }
        private void CbbKH_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void TxtKL_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if ((!System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "\\d+") || !float.TryParse(tb.Text, out float res)) && !string.IsNullOrEmpty(tb.Text))
            {

                tb.Text = "";
                e.Cancel = true;
            }

            //if (!float.TryParse(tb.Text,out float res))
            //{
            //    tb.Text = "";
            //    e.Cancel = true;
            //}
        }
        private void TxtKL_Validated(object sender, EventArgs e)
        {
            Handle_TextChanged(sender, e);
        }
 

        private void TxtDongia_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string value;
            NumberStyles style;
            decimal currency;

            value = tb.Text;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            //culture = CultureInfo.CreateSpecificCulture("vi-VN");
            culture = CultureInfo.CreateSpecificCulture("en-US");
            if (!Decimal.TryParse(value, style, culture, out currency) && !string.IsNullOrEmpty(value))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // prevent the textbox from losing focus
                tb.Text = "";
                e.Cancel = true;
            }
        }
        private void TxtDongia_Validated(object sender, EventArgs e)
        {
            Handle_TextChanged(sender, e);
        }
        private void CkbPayNow_CheckedChanged(object sender, EventArgs e)
        {
            KryptonCheckBox cb = sender as KryptonCheckBox;
            if (cb.Checked)
            {

                txtDongia.Enabled = true;
                lblDongia.Enabled = true;
                txtDongia.Focus();
            }
            else
            {
                txtDongia.Enabled = false;
                lblDongia.Enabled = false;
            }
            txtDongia.Text = LastestPrice.Price.ToString("#,###", culture.NumberFormat);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // LoadTemplate();

            if (string.IsNullOrEmpty(txtDongia.Text) && ckbPayNow.Checked)
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Cảnh báo", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtKL.Text))
            {
                MessageBox.Show("Vui lòng nhập khối lượng", "Cảnh báo", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            purchaseModel = new PurchaseModel();
            purchaseModel.CustomerId = Convert.ToInt32(cbbKH.SelectedValue);
            purchaseModel.Type = Type;
            purchaseModel.Weight = Convert.ToDouble(txtKL.Text);
            purchaseModel.PriceId = ckbPayNow.Checked ? 0 : LastestPrice.Id;
            purchaseModel.Price = ckbPayNow.Checked ? Convert.ToDouble(txtDongia.Text) : LastestPrice.Price;
            purchaseModel.PayNow = Convert.ToInt32(ckbPayNow.Checked);
            int? muType = null;
           
            purchaseModel.MuType = muType;
            purchaseModel.Degree = 0;
            purchaseModel.Note = rtbNote.Text;
            CustomerModel selectedCus = ls_CustomerInfo.FirstOrDefault(c => c.Id == purchaseModel.CustomerId);
            if (selectedCus != null)
            {
                purchaseModel.Name = selectedCus.Name;
                purchaseModel.Phone = selectedCus.Phone;
                purchaseModel.Address = selectedCus.Address;
            };

            if (InsertPurchase(purchaseModel) > 0)
            {
                MessageBox.Show("Thêm thành công", "Thông tin", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                if (ckbPayNow.Checked)    //In bill neu thanh toan ngay
                {
                    LoadTemplate();
                    //SendToPrinter(fileName);
                    SUtils.OpenFile(purchaseModel.PathFileExcelOpen);
                }
                OnPurchaseInserted?.Invoke(this, e);
            }
            Close();

            //    customerId,_type, weight, priceId, price, payNow, muType, degree,note
        }
        private void TxtKL_TextChanged(object sender, EventArgs e)
        {
            Handle_TextChanged(sender, e);
        }

        private void TxtSodo_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            float Sodo = 0;
            if (string.IsNullOrEmpty(tb.Text))
            {
                return;
            }
            if (Type == "Cao su")
            {
                if ((!System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "\\d+") || !float.TryParse(tb.Text, out Sodo)) && !string.IsNullOrEmpty(tb.Text))
                {
                    tb.Text = "";
                    e.Cancel = true;
                }
                else
                {
                    //int Sodo = Convert.ToInt32(tb.Text);
                    if (Sodo > GlobalVariable.SoDoMax || Sodo < GlobalVariable.SoDoMin)
                    {
                        tb.Text = "";
                        e.Cancel = true;
                        MessageBox.Show($"Số độ nằm trong khoảng giá trị từ  {GlobalVariable.SoDoMin} đến  {GlobalVariable.SoDoMax} ", "Cảnh báo", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                    }

                }
            }
        }
        private void TxtSodo_Validated(object sender, EventArgs e)
        {
            Handle_TextChanged(sender, e);
        }
        private void TxtSodo_TextChanged(object sender, EventArgs e)
        {
            Handle_TextChanged(sender, e);
        }

        private void TxtDongia_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string value;
            NumberStyles style;
            decimal currency;
            value = tb.Text;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            //culture = CultureInfo.CreateSpecificCulture("vi-VN");
            culture = CultureInfo.CreateSpecificCulture("en-US");
            if (Decimal.TryParse(value, style, culture, out currency) && !string.IsNullOrEmpty(value))
            {
                tb.Text = currency.ToString("#,###", culture.NumberFormat);
                tb.Select(tb.TextLength, 0);
            }

            UpdateTotalMoney();
        }

        #endregion
    }
}
