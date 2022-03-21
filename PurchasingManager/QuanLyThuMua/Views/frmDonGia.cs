using ComponentFactory.Krypton.Toolkit;
using Dapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuMua
{
    public partial class frmDonGia : KryptonForm
    {
        public event EventHandler OnPriceChanged;
        CultureInfo culture;
        private string priceType = "Cao su";
        private bool dieu = false;
        private List<PriceModel> priceInfo = new List<PriceModel>();

        public frmDonGia()
        {
            InitializeComponent();

            Load += FrmDonGia_Load;
            txtPriceCaoSu.Validating += TxtPrice_Validating;
            txtPriceCaoSu.TextChanged += TxtPric_TextChanged;
            radCaoSu.CheckedChanged += Rad_CheckedChanged;
            radDieu.CheckedChanged += Rad_CheckedChanged;
        }

        private void Rad_CheckedChanged(object sender, EventArgs e)
        {
            KryptonRadioButton rd = sender as KryptonRadioButton;

            if (rd.Name == "radCaoSu")
            {
                priceType = "Cao su";

                GetPriceInfo();
            }
            else
            {
                priceType = "Điều";

                GetPriceInfo();
            }
        }

        private void TxtPric_TextChanged(object sender, EventArgs e)
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
        }

        private void TxtPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void FrmDonGia_Load(object sender, EventArgs e)
        {
            GetPriceInfo();

            dtpCaoSu.Value = DateTime.Now;
        }

        private void GetPriceInfo()
        {
            priceInfo = GlobalVariable.ConnectionDb.Query<PriceModel>("call spPriceSelectAll").AsList<PriceModel>();

            if (priceInfo != null)
            {
                var lastestPrice = priceInfo.Where(x => x.Type == priceType).OrderByDescending(x => x.Id);
                var _first = lastestPrice.First();

                if (txtPriceCaoSu.InvokeRequired)
                {
                    txtPriceCaoSu.Invoke(new Action(() =>
                    {
                        txtPriceCaoSu.Text = _first.Price.ToString();
                    }));
                }
                else
                {
                    txtPriceCaoSu.Text = _first.Price.ToString();
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPriceCaoSu.Text))
            {
                var p = new DynamicParameters();
                p.Add("_createdDate", dtpCaoSu.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                p.Add("_type", priceType);
                p.Add("_price",  double.TryParse(txtPriceCaoSu.Text,out double res)?res:0);
                p.Add("_note", txtNoteCaosu.Text);

                if (GlobalVariable.ConnectionDb.Execute("spPriceInsert", p, commandType: System.Data.CommandType.StoredProcedure) > 0)
                {
                    OnPriceChanged?.Invoke(this, e);
                    MessageBox.Show("Lưu thành công.");
                }
                else
                {
                    MessageBox.Show("Lưu thất bại.");
                }

                //if (priceType == "Cao su")
                //{
                //    if (GlobalVariable.ConnectionDb.Execute($"call spPriceInsert ('{dtpCaoSu.Value.ToString("yyyy-MM-dd HH:mm:ss")}','{priceType}','{txtPriceCaoSu.Text}','{txtNoteCaosu.Text}')") > 0)
                //    {
                //        _res += 1;
                //    }
                //}
                //else
                //{
                //    if (GlobalVariable.ConnectionDb.Execute($"call spPriceInsert ('{dtpCaoSu.Value.ToString("yyyy-MM-dd HH:mm:ss")}','{priceType}','{txtPriceCaoSu.Text}','{txtNoteCaosu.Text}')") > 0)
                //    {
                //        _res += 1;
                //    }
                //}
            }
            else
            {
                MessageBox.Show($"Bạn chưa nhập giá.", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Close();
        }
    }
}
