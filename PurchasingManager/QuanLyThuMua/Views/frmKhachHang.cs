using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuMua
{
    public partial class frmKhachHang : KryptonForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhoneNum.Text) && !string.IsNullOrEmpty(txtAdd.Text))
            {

            }
            else
            {
                MessageBox.Show($"Không được để trống TÊN, SỐ ĐIỆN THOẠI và ĐỊA CHỈ.", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
