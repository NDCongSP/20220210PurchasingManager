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
    public partial class ucDonGia : UserControl
    {
        public ucDonGia()
        {
            InitializeComponent();
            Load += UcDonGia_Load;
        }

        private void UcDonGia_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var _res = GlobalVariable.ConnectionDb.Query<PriceModel>("call spPriceSelectAll").ToList();

            if (_res != null)
            {
                kryGridGia.BeginInvoke(new Action(() =>
                {
                    kryGridGia.DataSource = _res;
                }));
            }
        }
    }
}
