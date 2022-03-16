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
            var _useInfo = GlobalVariable.ConnectionDb.Query<AcountModel>($"{_query}", null).FirstOrDefault();

            if (_useInfo != null)
            {
                Form1 nF = new Form1();

                if (nF.ShowDialog(this) == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }
    }
}
