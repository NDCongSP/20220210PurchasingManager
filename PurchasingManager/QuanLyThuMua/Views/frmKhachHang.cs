using ComponentFactory.Krypton.Toolkit;
using Dapper;
using System;
using System.Windows.Forms;

namespace QuanLyThuMua
{
    public partial class frmKhachHang : KryptonForm
    {
        public event EventHandler OnCustomerChanged;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhoneNum.Text) && !string.IsNullOrEmpty(txtAdd.Text))
            {
                if (GlobalVariable.ConnectionDb.Execute($"call spCustomerInsert ('{txtName.Text}','{txtPhoneNum.Text}','{txtAdd.Text}');") > 0)
                {
                    OnCustomerChanged?.Invoke(this, e);
                    MessageBox.Show("Lưu thành công.");
                }
                else
                {
                    MessageBox.Show("Lưu thất bại.");
                }
            }
            else
            {
                MessageBox.Show($"Không được để trống TÊN, SỐ ĐIỆN THOẠI và ĐỊA CHỈ.", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Close();
        }
    }
}
