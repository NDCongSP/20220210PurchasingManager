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
        public string TitleForm = null;
        public string PriceType = "Cao su";
        public int MuType { get; set; } = 0;//0- mủ nước và mủ chén; 2- mủ dây

        CultureInfo culture;
        private bool dieu = false;
        private List<PriceModel> priceInfo = new List<PriceModel>();

        public frmDonGia()
        {
            InitializeComponent();

            Load += FrmDonGia_Load;
            txtPriceCaoSu.Validating += TxtPrice_Validating;
            txtPriceCaoSu.TextChanged += TxtPric_TextChanged;

        }

        private void Rad_CheckedChanged(object sender, EventArgs e)
        {
            KryptonRadioButton rd = sender as KryptonRadioButton;

            if (rd.Name == "radCaoSu")
            {
                PriceType = "Cao su";

                GetPriceInfo();
            }
            else
            {
                PriceType = "Điều";

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
            labTitle.Text = TitleForm;

            GetPriceInfo();

            dtpCaoSu.Value = DateTime.Now;
        }

        private void GetPriceInfo()
        {
            priceInfo = GlobalVariable.ConnectionDb.Query<PriceModel>("call spPriceSelectAll").AsList<PriceModel>();

            if (priceInfo != null)
            {
                var lastestPrice = priceInfo.Where(x => x.Type == PriceType && x.MuType == MuType).OrderByDescending(x => x.Id);

                if (lastestPrice.Count() > 0)
                {
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

                //if (MuType == 0)//mủ nước (có số độ)
                //{
                //    var lastestPrice = priceInfo.Where(x => x.Type == PriceType).OrderByDescending(x => x.Id);

                //    var _first = lastestPrice.First();

                //    if (txtPriceCaoSu.InvokeRequired)
                //    {
                //        txtPriceCaoSu.Invoke(new Action(() =>
                //        {
                //            txtPriceCaoSu.Text = _first.Price.ToString();
                //        }));
                //    }
                //    else
                //    {
                //        txtPriceCaoSu.Text = _first.Price.ToString();
                //    }
                //}
                //else if (MuType ==1)//mủ chén
                //{
                //    var lastestPrice = priceInfo.Where(x => x.Type == PriceType).OrderByDescending(x => x.Id);

                //    var _first = lastestPrice.First();

                //    if (txtPriceCaoSu.InvokeRequired)
                //    {
                //        txtPriceCaoSu.Invoke(new Action(() =>
                //        {
                //            txtPriceCaoSu.Text = _first.Price.ToString();
                //        }));
                //    }
                //    else
                //    {
                //        txtPriceCaoSu.Text = _first.Price.ToString();
                //    }
                //}
                //else// if (MuType == 2)//mủ dây
                //{
                //    var lastestPrice = priceInfo.Where(x => x.Type == PriceType && x.MuType == MuType).OrderByDescending(x => x.Id);

                //    if (lastestPrice.Count() > 0)
                //    {
                //        var _first = lastestPrice.First();

                //        if (txtPriceCaoSu.InvokeRequired)
                //        {
                //            txtPriceCaoSu.Invoke(new Action(() =>
                //            {
                //                txtPriceCaoSu.Text = _first.Price.ToString();
                //            }));
                //        }
                //        else
                //        {
                //            txtPriceCaoSu.Text = _first.Price.ToString();
                //        }
                //    }
                //}
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPriceCaoSu.Text))
                {
                    var p = new DynamicParameters();
                    p.Add("_createdDate", dtpCaoSu.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    p.Add("_type", PriceType);
                    p.Add("_price", double.TryParse(txtPriceCaoSu.Text, out double res) ? res : 0);
                    if (PriceType == "Cao su")
                    {
                        if (MuType == 0)
                        {
                            p.Add("_note", $"[Mủ nước] {txtNoteCaosu.Text}");
                        }
                        else if (MuType == 1)
                        {
                            p.Add("_note", $"[Mủ chén] {txtNoteCaosu.Text}");
                        }
                        else
                        {
                            p.Add("_note", $"[Mủ dây] {txtNoteCaosu.Text}");
                        }
                    }
                    else
                    {
                        p.Add("_note", $"{txtNoteCaosu.Text}");
                    }
                    p.Add("_muType", MuType);

                    if (GlobalVariable.ConnectionDb.Execute("spPriceInsert", p, commandType: System.Data.CommandType.StoredProcedure) > 0)
                    {
                        OnPriceChanged?.Invoke(this, e);
                        MessageBox.Show("Lưu thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại.");
                    }

                    //if (PriceType == "Cao su")
                    //{
                    //    if (GlobalVariable.ConnectionDb.Execute($"call spPriceInsert ('{dtpCaoSu.Value.ToString("yyyy-MM-dd HH:mm:ss")}','{PriceType}','{txtPriceCaoSu.Text}','{txtNoteCaosu.Text}')") > 0)
                    //    {
                    //        _res += 1;
                    //    }
                    //}
                    //else
                    //{
                    //    if (GlobalVariable.ConnectionDb.Execute($"call spPriceInsert ('{dtpCaoSu.Value.ToString("yyyy-MM-dd HH:mm:ss")}','{PriceType}','{txtPriceCaoSu.Text}','{txtNoteCaosu.Text}')") > 0)
                    //    {
                    //        _res += 1;
                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show($"Bạn chưa nhập giá.", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
            finally
            {
                this.Close();
            }
        }
    }
}
