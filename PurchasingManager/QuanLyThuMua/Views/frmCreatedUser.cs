using Dapper;
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
    public partial class frmCreatedUser : Form
    {
        public frmCreatedUser()
        {
            InitializeComponent();

            txtUserName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn tạo tài khoản này?","CẢNH BÁO",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    var _res = GlobalVariable.ConnectionDb.Execute($"insert into useraccount (UserName,Password,Role) values ('{txtUserName.Text}','{EncodeMD5.EncryptString("1@345","PhucTh!nhMD%")}','2')");
                    if (_res>0)
                    {
                        MessageBox.Show("Tạo tài khoản thành công.");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tạo tài khoản thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập tên tài khoản.");
            }
        }
    }
}
