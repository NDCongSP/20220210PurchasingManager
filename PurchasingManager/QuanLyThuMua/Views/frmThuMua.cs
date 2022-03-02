using ClosedXML.Excel;
using Dapper;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuMua
{
    public partial class frmThuMua : KryptonForm
    {
        List<CustomerModel> ls_CustomerInfo = new List<CustomerModel>();
        CustomerModel CurrentCustomer = new CustomerModel();
        PriceModel LastestPrice = new PriceModel();
        string strExeFilePath;
        //This will strip just the working path name:
        //C:\Program Files\MyApplication
        string strWorkPath;
        string fileName;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
        public frmThuMua()
        {
            InitializeComponent();
            Load += FrmThuMua_Load;
            cbbKH.SelectedValueChanged += CbbKH_SelectedValueChanged;
            txtKL.Validating += TxtKL_Validating;
            txtKL.Validated += TxtKL_Validated;
            cbbLoaimu.SelectedValueChanged += CbbLoaimu_SelectedValueChanged;
            btnSave.Click += BtnLuu_Click;
            txtDongia.Validating += TxtDongia_Validating;
            txtDongia.Validated += TxtDongia_Validated;
            btnExit.Click += BtnExit_Click;
            ckbPayNow.CheckedChanged += CkbPayNow_CheckedChanged;
            rdCaosu.CheckedChanged += RdType_CheckedChanged;
            rdDieu.CheckedChanged += RdType_CheckedChanged;
            txtSodo.Validated += TxtSodo_Validated;
        }

  

        private void RdType_CheckedChanged(object sender, EventArgs e)
        {
            KryptonRadioButton rd = sender as KryptonRadioButton;

            if (rd.Name == "rdDieu")
            {
                Type = "Dieu";
                GetLastestPrice(Type);
                //lblLoaimu.Visible = false;
                //cbbLoaimu.Visible = false;
                //lblSodo.Visible = false;
                //txtSodo.Visible = false;

                lblSodo.Enabled = false;
                txtSodo.Enabled = false;
                lblLoaimu.Enabled = false;
                cbbLoaimu.Enabled = false;
            }
            else
            {
                Type = "Cao su";
                GetLastestPrice(Type);
                //lblLoaimu.Visible = true;
                //cbbLoaimu.Visible = true;
                //lblSodo.Visible = true;
                //txtSodo.Visible = true;

                lblSodo.Enabled = true;
                txtSodo.Enabled = true;
                lblLoaimu.Enabled = true;
                cbbLoaimu.Enabled = true;
                //lblLoaimu.Location = lblKL.Location;
                //cbbLoaimu.Location = txtKL.Location;
                //lblSodo.Location = lblDongia.Location;
                //txtSodo.Location = txtDongia.Location;
            }
        }



        #region Props
        public string Type { get; set; } = "Cao su";
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
            LastestPrice = GlobalVariable.ConnectionDb.QueryFirst<PriceModel>("spPriceGetLatestPrice", param, commandType: CommandType.StoredProcedure);
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
            if (Type == "Cao su")
            {
                ws.Cell("A10").Value = $"Tên hàng: Cao su ({cbbLoaimu.Text})";
                //cell.Value = $"Tên hàng: Cao su";
            }
            else
            {
                ws.Cell("A10").Value = $"Tên hàng: Điều";
                //cell.Value = $"Tên hàng: Điều";
            }
            ws.Cell("A8").Value = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
            ws.Cell("A11").Value = $"Tên khách hàng: {cbbKH.Text}";
            ws.Cell("F11").Value = $"SĐT: {txtSdt.Text}";
            ws.Cell("A12").Value = $"Địa chỉ: {txtDiachi.Text}";
            ws.Cell("A14").Value = $"Khối lượng (Kg): {Convert.ToDouble(txtKL.Text)}";
            ws.Cell("F14").Value = $"Số độ: {txtSodo.Text}";
            ws.Cell("A15").Value = $"Đơn giá: {txtDongia.Text} VNĐ";
            double TongTien = Convert.ToDouble(txtDongia.Text) * (Double.TryParse(txtSodo.Text,out double res)?res:1) * Convert.ToDouble(txtKL.Text);
            ws.Cell("A17").Value = $"Tổng tiền: {TongTien.ToString("#,###",culture.NumberFormat)} VNĐ";
            string value = cell.GetValue<string>();
            Debug.WriteLine(value);
            workbook.Save();
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
        private void OpenFile(string fileName)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = fileName;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process p = new Process();
            p.StartInfo = info;
            p.Start();
        }
        #endregion
        #region Events

        private void FrmThuMua_Load(object sender, EventArgs e)
        {
            //Initial Data
            GetListCustomer();
            GetLastestPrice(Type);
            strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //This will strip just the working path name:
            //C:\Program Files\MyApplication
            strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            fileName = System.IO.Path.Combine(strWorkPath, "Templates","TemplateBill.xlsx");
            txtSdt.DataBindings.Add("Text", ls_CustomerInfo, "Phone");
            txtDiachi.DataBindings.Add("Text", ls_CustomerInfo, "Address");
        }
        private void CbbKH_SelectedValueChanged(object sender, EventArgs e)
        {
            //CurrentCustomer
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
            txtThanhtien.Text = ((Double.TryParse(txtDongia.Text, out double res) ? res : LastestPrice.Price) * (Double.TryParse(txtSodo.Text, out double res1) ? res1 : 1) * (Double.TryParse(txtKL.Text, out double res2) ? res2 : 1)).ToString("#,###", culture.NumberFormat);
        }
        private void CbbLoaimu_SelectedValueChanged(object sender, EventArgs e)
        {
            KryptonComboBox cbb = sender as KryptonComboBox;
            if (cbb.Text == "Mủ chén")
            {
                lblSodo.Visible = false;
                txtSodo.Visible = false;
            }
            else
            {
                lblSodo.Visible = true;
                txtSodo.Visible = true;
                txtSodo.Focus();
            }
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
            TextBox tb = sender as TextBox;
            if (!string.IsNullOrEmpty(tb.Text))
            {
                //CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                culture = CultureInfo.GetCultureInfo("en-US");   // try with "en-US"
                tb.Text = double.Parse(tb.Text).ToString("#,###", culture.NumberFormat);
                txtThanhtien.Text = ((Double.TryParse(txtDongia.Text, out double res) ? res : LastestPrice.Price) * (Double.TryParse(txtSodo.Text, out double res1) ? res1 : 1) * (Double.TryParse(txtKL.Text, out double res2) ? res2 : 1)).ToString("#,###", culture.NumberFormat);
                //tb.Text = double.Parse(tb.Text).ToString("C", cul.NumberFormat);
                //tb.Text = String.Format("{0:C}", tb.Text).ToString("C",cul.NumberFormat);
            }
        }
        private void CkbPayNow_CheckedChanged(object sender, EventArgs e)
        {
            KryptonCheckBox cb = sender as KryptonCheckBox;
            if (cb.Checked)
            {
                txtDongia.Text = LastestPrice.Price.ToString("#,###",culture.NumberFormat);
                txtDongia.Visible = true;
                lblDongia.Visible = true;
                txtDongia.Focus();
            }
            else
            {
                txtDongia.Visible = false;
                lblDongia.Visible = false;
            }
        }
        private void TxtSodo_Validated(object sender, EventArgs e)
        {
            txtThanhtien.Text = ((Double.TryParse(txtDongia.Text, out double res) ? res : LastestPrice.Price) * (Double.TryParse(txtSodo.Text, out double res1) ? res1 : 1) * (Double.TryParse(txtKL.Text, out double res2) ? res2 : 1)).ToString("#,###", culture.NumberFormat);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // LoadTemplate();

            if (string.IsNullOrEmpty(txtSodo.Text) && cbbLoaimu.Text != "Mủ chén")
            {
                MessageBox.Show("Vui lòng nhập số độ", "Cảnh báo", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
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
            PurchaseModel purchaseModel = new PurchaseModel();
            purchaseModel.CustomerId = Convert.ToInt32(cbbKH.SelectedValue);
            purchaseModel.Type = Type;
            purchaseModel.Weight = Convert.ToDouble(txtKL.Text);
            purchaseModel.PriceId = ckbPayNow.Checked ? 0 : LastestPrice.Id;
            purchaseModel.Price = ckbPayNow.Checked ? Convert.ToDouble(txtDongia.Text) : LastestPrice.Price;
            purchaseModel.PayNow = Convert.ToInt32(ckbPayNow.Checked);
            purchaseModel.MuType = cbbLoaimu.Text == "Mủ chén" ? 1 : 0;
            purchaseModel.Degree = Double.TryParse(txtSodo.Text, out double res) ? res : 0;
            purchaseModel.Note = rtbNote.Text;
            if (InsertPurchase(purchaseModel) > 0)
            {
                MessageBox.Show("Thêm thành công", "Thông tin", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                if (ckbPayNow.Checked)    //In bill neu thanh toan ngay
                {
                    LoadTemplate();
                    //SendToPrinter(fileName);
                    OpenFile(fileName);
                }
                OnPurchaseInserted(this, e);
            }

            //    customerId,_type, weight, priceId, price, payNow, muType, degree,note
        }
        #endregion


    }
}
