using ClosedXML.Excel;
using ComponentFactory.Krypton.Toolkit;
using Dapper;
using Krypton.Toolkit;
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
    public partial class frmThuMua : KryptonForm
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
        bool LoaiCaoSu = true;//True:ko phải mủ chén; flase: mủ chén
        CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        public frmThuMua()
        {
            InitializeComponent();
            Load += FrmThuMua_Load;
            cbbKH.SelectedValueChanged += CbbKH_SelectedValueChanged;
            //txtKL.Validating += TxtKL_Validating;
            //txtKL.Validated += TxtKL_Validated;
            txtKL.TextChanged += TxtKL_TextChanged;
            txtKL.KeyPress += TxtKL_KeyPress; 

            cbbLoaimu.SelectedValueChanged += CbbLoaimu_SelectedValueChanged;
            btnSave.Click += BtnLuu_Click;
            txtDongia.Validating += TxtDongia_Validating;
            txtDongia.Validated += TxtDongia_Validated;
            txtDongia.TextChanged += TxtDongia_TextChanged;
            btnExit.Click += BtnExit_Click;
            ckbPayNow.CheckedChanged += CkbPayNow_CheckedChanged;

            txtSodo.Validating += TxtSodo_Validating;
            txtSodo.Validated += TxtSodo_Validated;
            txtSodo.TextChanged += TxtSodo_TextChanged;

        }
        private void TxtKL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
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
        private void GetLastestPrice(string type,int mutype)
        {
            var param = new DynamicParameters();
            param.Add("@_type", type);
            param.Add("@_mutype", mutype);
            LastestPrice = GlobalVariable.ConnectionDb.Query<PriceModel>("spPriceGetLatestPrice", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            txtDongia.Text = LastestPrice?.Price.ToString("#,###", culture.NumberFormat);
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

            if (purchaseModel.Type=="Cao su")
            {
                param.Add("@note", purchaseModel.MuType == 0 ? $"[Mủ nước] {purchaseModel.Note}" : purchaseModel.MuType == 1 ? $"[Mủ chén] {purchaseModel.Note}" : $"[Mủ dây] {purchaseModel.Note}");
            }
            else
            {
                param.Add("@note", purchaseModel.Note);
            }
            
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
                if (cbbLoaimu.Text == "Mủ nước")
                {
                    ws.Cell("C10").Value = $"Cao su ({cbbLoaimu.Text.ToLower()})";
                    ws.Cell("G15").Value = $"{purchaseModel.Degree}";
                }
                else
                {
                    ws.Cell("C10").Value = $"Cao su ({cbbLoaimu.Text.ToLower()})";
                    ws.Cell("G15").Value = $"";
                    ws.Cell("F15").Value = $"";
                }
                //if (LoaiCaoSu)//không phải mủ chens
                //{
                //    ws.Cell("C10").Value = $"Cao su ({cbbLoaimu.Text.ToLower()})";
                //    ws.Cell("G15").Value = $"{purchaseModel.Degree}";
                //}
                //else//mủ chén
                //{
                //    ws.Cell("C10").Value = $"Cao su ({cbbLoaimu.Text.ToLower()})";
                //    ws.Cell("G15").Value = $"";
                //    ws.Cell("F15").Value = $"";
                //}
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

            ws.Cell("C16").Value = $"{purchaseModel.Price.ToString("#,###", culture.NumberFormat)} VNĐ";

            var degree = purchaseModel.Degree != 0 ? purchaseModel.Degree / 10 : 1;
            double tongTien = purchaseModel.Price * Convert.ToDouble(degree) * purchaseModel.Weight;

            ws.Cell("C18").Value = $"{tongTien.ToString("#,###", culture.NumberFormat)} VNĐ";
            string value = cell.GetValue<string>();
            Debug.WriteLine(value);
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
            txtThanhtien.Text = ((Double.TryParse(txtDongia.Text, out double res) ? res : LastestPrice.Price) * (Double.TryParse(txtSodo.Text, out double res1) ? res1 / 10 : 1) * (Double.TryParse(txtKL.Text, out double res2) ? res2 : 0)).ToString("#,###", culture.NumberFormat);
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

        private void HandleKL_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (float.TryParse(tb.Text, out float res) && !string.IsNullOrEmpty(tb.Text))
            {
                culture = CultureInfo.GetCultureInfo("en-US");   // try with "en-US"
                tb.Text = float.Parse(tb.Text).ToString("#,###",culture.NumberFormat);
                //tb.Text = $"{float.Parse(tb.Text).ToString():#,###}";
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
            GetLastestPrice(Type,0);
            //txtDongia.Text = LastestPrice.Price.ToString("#,###", culture.NumberFormat);
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
            if (!float.TryParse(tb.Text, out float res) && !string.IsNullOrEmpty(tb.Text))
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
            HandleKL_TextChanged(sender, e);
        }
        private void CbbLoaimu_SelectedValueChanged(object sender, EventArgs e)
        {
            KryptonComboBox cbb = sender as KryptonComboBox;
            if (cbb.Text == "Mủ dây")
            {
                GetLastestPrice(Type, 2);
            }
            else if (cbb.Text == "Mủ chén")
            {
                GetLastestPrice(Type, 1);
            }
            else
            {
                GetLastestPrice(Type, 0);
            }
      
            if (cbb.Text == "Mủ chén" || cbb.Text == "Mủ dây")
            {
                lblSodo.Visible = false;
                txtSodo.Visible = false;
                LoaiCaoSu = false;
            }
            else
            {
                LoaiCaoSu = true;
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

            if (string.IsNullOrEmpty(txtSodo.Text) && cbbLoaimu.Text == "Mủ nước" && Type == "Cao su")
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
            purchaseModel = new PurchaseModel();
            purchaseModel.CustomerId = Convert.ToInt32(cbbKH.SelectedValue);
            purchaseModel.Type = Type;
            purchaseModel.Weight = Convert.ToDouble(txtKL.Text);
            purchaseModel.PriceId = ckbPayNow.Checked ? 0 : LastestPrice.Id;
            purchaseModel.Price = ckbPayNow.Checked ? Convert.ToDouble(txtDongia.Text) : LastestPrice.Price;
            purchaseModel.PayNow = Convert.ToInt32(ckbPayNow.Checked);
            int? muType = null;
            switch (cbbLoaimu.Text)
            {
                case "Mủ nước":
                    muType = 0;
                    break;
                case "Mủ chén":
                    muType = 1;
                    break;
                case "Mủ dây":
                    muType = 2;
                    break;
                default:
                    break;
            }
            //if (cbbLoaimu.Text == "Mủ chén")
            //{
            //    muType = 1;
            //}
            //else
            //{
            //    muType = 0;
            //};

            purchaseModel.MuType = muType;
            purchaseModel.Degree = Double.TryParse(txtSodo.Text, out double res) ? res : 0;
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
                OnPurchaseInserted(this, e);
            }
            Close();

            //    customerId,_type, weight, priceId, price, payNow, muType, degree,note
        }
        private void TxtKL_TextChanged(object sender, EventArgs e)
        {
            //HandleKL_TextChanged(sender, e);

            TextBox tb = sender as TextBox;

            if (float.TryParse(tb.Text, out float res) && !string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = Puntos(tb.Text, 1);
                tb.Select(tb.TextLength, 0);

                UpdateTotalMoney();
            }
        }

        /// <summary>
        /// Method dùng để format lại cho textbox, phân cách theo đơn vị, và số thập phân.
        /// </summary>
        /// <param name="strValor">Nội dung.</param>
        /// <param name="intNumDecimales">Chọn phần số lẻ cần hiển thị</param>
        /// <returns></returns>
        public string Puntos(string strValor, int intNumDecimales)
        {
            string strAux = null;
            string strComas = null;
            string strPuntos = null;
            int intX = 0;
            bool bolMenos = false;

            strComas = "";
            if (strValor.Length == 0) return "";
            strValor = strValor.Replace(Application.CurrentCulture.NumberFormat.NumberGroupSeparator, "");
            if (strValor.Contains(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                strAux = strValor.Substring(0, strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                strComas = strValor.Substring(strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator) + 1);
            }
            else
            {
                strAux = strValor;
            }

            if (strAux.Substring(0, 1) == Application.CurrentCulture.NumberFormat.NegativeSign)
            {
                bolMenos = true;
                strAux = strAux.Substring(1);
            }

            strPuntos = strAux;
            strAux = "";
            while (strPuntos.Length > 3)
            {
                strAux = Application.CurrentCulture.NumberFormat.NumberGroupSeparator + strPuntos.Substring(strPuntos.Length - 3, 3) + strAux;
                strPuntos = strPuntos.Substring(0, strPuntos.Length - 3);
            }
            if (intNumDecimales > 0)
            {
                if (strValor.Contains(Application.CurrentCulture.NumberFormat.PercentDecimalSeparator))
                {
                    strComas = Application.CurrentCulture.NumberFormat.PercentDecimalSeparator + strValor.Substring(strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.PercentDecimalSeparator) + 1);
                    if (strComas.Length > intNumDecimales)
                    {
                        strComas = strComas.Substring(0, intNumDecimales + 1);
                    }

                }
            }
            strAux = strPuntos + strAux + strComas;


            return strAux;
        }

        private void RdType_CheckedChanged(object sender, EventArgs e)
        {
            KryptonRadioButton rd = sender as KryptonRadioButton;

            if (rd.Name == "rdDieu")
            {
                Type = "Điều";
                GetLastestPrice(Type,0);
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
                GetLastestPrice(Type,2);
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
            txtDongia.Text = LastestPrice.Price.ToString("#,###", culture.NumberFormat);
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
