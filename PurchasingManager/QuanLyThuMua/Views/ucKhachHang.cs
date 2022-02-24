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
    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();

            RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var _res = GlobalVariable.ConnectionDb.Query<CustomerModel>("call spCustomerSelectAll").ToList();

            if (_res != null)
            {
                kryGridCustomer.BeginInvoke(new Action(() =>
                {
                    kryGridCustomer.DataSource = _res;
                }));
            }
        }
    }
}
