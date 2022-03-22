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
    public partial class ucAccount : UserControl
    {
        public ucAccount()
        {
            InitializeComponent();

            txtUserName.Focus();

            txtUserName.Text = GlobalVariable.UserInfo.UserName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn cập nhật lại thông tin?","CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtPassNew.Text) && !string.IsNullOrEmpty(txtPassNewReEnter.Text)&& !string.IsNullOrEmpty(txtPassOld.Text) && !string.IsNullOrEmpty(txtUserName.Text))
                {
                    if (EncodeMD5.EncryptString(txtPassOld.Text,"PhucTh!nhMD%")==GlobalVariable.UserInfo.Password)
                    {
                        if (txtPassNew.Text == txtPassNewReEnter.Text)
                        {
                            var _res = GlobalVariable.ConnectionDb.Execute($"update useraccount set UserName = '{txtUserName.Text}', Password = '{EncodeMD5.EncryptString(txtPassNew.Text,"PhucTh!nhMD%")}' where Id = {GlobalVariable.UserInfo.Id}");
                            if (_res>0)
                            {
                                MessageBox.Show("Cập nhật thành công.");

                                GlobalVariable.UserInfo.UserName = txtUserName.Text;
                                GlobalVariable.UserInfo.Password = EncodeMD5.EncryptString(txtPassNew.Text, "PhucTh!nhMD%");
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật thất bại.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu mới không trùng nhau. Mời nhập lại.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu hiện tại. Mời nhập lại");
                    }
                }
                else
                {
                    MessageBox.Show("Không được để trống các trường. Mời nhập lại");
                }
            }
        }
    }
}
