using ClosedXML.Excel;
using ComponentFactory.Krypton.Toolkit;
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
    public partial class frmTamUng : KryptonForm
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
        public frmTamUng()
        {
            InitializeComponent();
            Load += FrmThuMua_Load;
            cbbKH.SelectedValueChanged += CbbKH_SelectedValueChanged;
            btnSave.Click += BtnLuu_Click;
            txtSotien.Validating += TxtSoTien_Validating;
            txtSotien.Validated += TxtSoTien_Validated;
            txtSotien.TextChanged += TxtSotien_TextChanged;
            btnExit.Click += BtnExit_Click;
        }

        private void TxtSotien_TextChanged(object sender, EventArgs e)
        {
            Handle_TextChanged(sender,e);
        }

        #region Props
        public string Type { get; set; } = "Cao su";
        #endregion
        #region Methods
        private void GetListCustomer()
        {
            ls_CustomerInfo = GlobalVariable.ConnectionDb.Query<CustomerModel>("call spCustomerSelectAll").ToList();
            cbbKH.DataSource = ls_CustomerInfo;
            cbbKH.ValueMember = "Id";
            cbbKH.DisplayMember = "Name";
        }
        private void GetLastestPrice(string type, int muType)
        {
            var param = new DynamicParameters();
            param.Add("@_type", type);
            param.Add("@_mutype", muType);
            LastestPrice = GlobalVariable.ConnectionDb.QueryFirst<PriceModel>("spPriceGetLatestPrice", param, commandType: CommandType.StoredProcedure);
        }
        private int InsertTamUng(TamUngModel tamUng)
        {
            var param = new DynamicParameters();
            param.Add("@_customerId", tamUng.CustomerId);
            param.Add("@_money", tamUng.Money);
            param.Add("@_note", tamUng.Note);
            return GlobalVariable.ConnectionDb.Execute("spTamUngInsert", param, commandType: CommandType.StoredProcedure);
        }
        private void Handle_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (float.TryParse(tb.Text, out float res) && !string.IsNullOrEmpty(tb.Text))
            {
                //CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                culture = CultureInfo.GetCultureInfo("en-US");   // try with "en-US"
                //tb.Text = double.Parse(tb.Text).ToString("#,##0", culture.NumberFormat);
                tb.Text = $"{ double.Parse(tb.Text):#,###}";
                tb.Select(tb.TextLength, 0);
            }
        }
        #endregion
        #region Events

        private void FrmThuMua_Load(object sender, EventArgs e)
        {
            //Initial Data
            GetListCustomer();
            //GetLastestPrice(Type,0);
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
            //CurrentCustomer
        }
     
        private void TxtSoTien_Validating(object sender, CancelEventArgs e)
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
        private void TxtSoTien_Validated(object sender, EventArgs e)
        {
            Handle_TextChanged(sender, e);
        }
  

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // LoadTemplate();
            if (string.IsNullOrEmpty(txtSotien.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền cần tạm ứng", "Cảnh báo", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }
            TamUngModel tamUng = new TamUngModel();
            tamUng.CustomerId = Convert.ToInt32(cbbKH.SelectedValue);
            tamUng.Money = Convert.ToDouble(txtSotien.Text);
            tamUng.Note = rtbNote.Text;
            if (InsertTamUng(tamUng) > 0)
            {
                MessageBox.Show("Thêm thành công", "Thông tin", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            }
            Close();
            //    customerId,_type, weight, priceId, price, payNow, muType, degree,note
        }
        #endregion


    }
}
