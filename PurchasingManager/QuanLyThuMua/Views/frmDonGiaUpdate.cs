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
    public partial class frmDonGiaUpdate : Form
    {
        private PriceModel dongiaInfo = new PriceModel();
       public  event EventHandler OnPriceChanged;
        public frmDonGiaUpdate()
        {
            InitializeComponent();

            Load += FrmDonGiaUpdate_Load;
        }

        private void FrmDonGiaUpdate_Load(object sender, EventArgs e)
        {
            var _res = GlobalVariable.ConnectionDb.Query<PriceModel>("call spCustomerSelectAll").ToList();

            krpCboGiaCaoSu.DataSource = _res;
            //krpCboGiaCaoSu.ValueMember = "Id";
            //krpCboGiaCaoSu.DisplayMember = "Name";

            dongiaInfo = _res[0];

            txtPriceCaoSu.BeginInvoke(new Action(() =>
            {
                txtPriceCaoSu.Text = dongiaInfo.Price.ToString();
            }));
            txtNoteCaosu.BeginInvoke(new Action(() =>
            {
                txtNoteCaosu.Text = dongiaInfo.Note;
            }));

            _res = GlobalVariable.ConnectionDb.Query<PriceModel>("call spCustomerSelectAll").ToList();

            krpCboGiaCaoSu.DataSource = _res;
            //krpCboGiaCaoSu.ValueMember = "Id";
            //krpCboGiaCaoSu.DisplayMember = "Name";

            dongiaInfo = _res[0];

            txtPriceDieu.BeginInvoke(new Action(() =>
            {
                txtPriceDieu.Text = dongiaInfo.Price.ToString();
            }));
            txtNoteDieu.BeginInvoke(new Action(() =>
            {
                txtNoteDieu.Text = dongiaInfo.Note;
            }));

            krpCboGiaCaoSu.SelectedValueChanged += KrpCboGiaCaoSu_SelectedValueChanged;
            krpCboGiaDieu.SelectedIndexChanged += KrpCboGiaDieu_SelectedIndexChanged;
        }

        private void KrpCboGiaDieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void KrpCboGiaCaoSu_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
