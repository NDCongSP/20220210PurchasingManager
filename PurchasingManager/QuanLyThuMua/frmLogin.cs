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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string _pass = EncodeMD5.EncryptString(txtPass.Text, "PhucTh!nhMD%");
            string _query = $"Select * from useraccount where UserName = '{txtUseName.Text}' and Password = '{_pass}'";
            GlobalVariable.UserInfo = GlobalVariable.ConnectionDb.Query<AcountModel>($"{_query}", null).FirstOrDefault();

            if (GlobalVariable.UserInfo != null)
            {
                Form1 nF = new Form1();

                if (nF.ShowDialog(this) == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác.","CẢNH BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
