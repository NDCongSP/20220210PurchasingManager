using ComponentFactory.Krypton.Toolkit;
using Dapper;
using System;
using System.Windows.Forms;

namespace QuanLyThuMua
{
    public partial class frmDonGia : KryptonForm
    {
        public frmDonGia()
        {
            InitializeComponent();

            Load += FrmDonGia_Load;
        }

        private void FrmDonGia_Load(object sender, EventArgs e)
        {
            var _res = GlobalVariable.ConnectionDb.Query<PriceModel>("call spPriceGetLatestPrice('Cao su')");

            if (_res != null)
            {
                //if (txtPriceCaoSu.InvokeRequired)
                //{

                //}
                foreach (var item in _res)
                {
                    txtPriceCaoSu.BeginInvoke(new Action(() =>
                    {
                        txtPriceCaoSu.Text = item.Price.ToString(); ;
                    }));

                    dtpCaoSu.Value = DateTime.Now;
                }
            }

            _res = GlobalVariable.ConnectionDb.Query<PriceModel>("call spPriceGetLatestPrice('Dieu')");

            if (_res != null)
            {
                //if (txtPriceCaoSu.InvokeRequired)
                //{

                //}
                foreach (var item in _res)
                {
                    txtPriceDieu.BeginInvoke(new Action(() =>
                    {
                        txtPriceDieu.Text = item.Price.ToString(); ;
                    }));

                    dtpDieu.Value = DateTime.Now;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _res = 0;

            if (!string.IsNullOrEmpty(txtPriceCaoSu.Text))
            {
               if( GlobalVariable.ConnectionDb.Execute($"call spPriceInsert ('{dtpCaoSu.Value.ToString("yyyy-MM-dd HH:mm:ss")}','Cao su','{txtPriceCaoSu.Text}','{txtNoteCaosu.Text}')")>0)
                {
                    _res += 1;
                }
            }
            else
            {
                MessageBox.Show($"Bạn chưa nhập giá.","CẢNH BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            if (!string.IsNullOrEmpty(txtPriceDieu.Text))
            {
                if(GlobalVariable.ConnectionDb.Execute($"call spPriceInsert ('{dtpDieu.Value.ToString("yyyy-MM-dd HH:mm:ss")}','Dieu','{txtPriceDieu.Text}','{txtNoteDieu.Text}')") > 0)
                {
                    _res += 1;
                }
            }
            else
            {
                MessageBox.Show($"Bạn chưa nhập giá.", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (_res==2)
            {
                MessageBox.Show("Lưu thành công.");
            }
            else
            {
                MessageBox.Show("Lưu thất bại.");
            }
        }
    }
}
