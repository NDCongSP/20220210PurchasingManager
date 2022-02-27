using ComponentFactory.Krypton.Toolkit;
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
    public partial class ucThuMua : UserControl
    {
      

        public ucThuMua()
        {
            InitializeComponent();
            Load += UcThuMua_Load;
            gvPurchaseList.DoubleClick += GvPurchaseList_DoubleClick;
            gvPurchaseList.CellBeginEdit += GvPurchaseList_CellBeginEdit;
        }

        private void GvPurchaseList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //KryptonDataGridView gv = sender as KryptonDataGridView;
            var activeColumn = gvPurchaseList.Columns[e.ColumnIndex];
            if (activeColumn.Name == "Degree")
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void UcThuMua_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
          List<PurchaseModel> purchaseModels =  GlobalVariable.ConnectionDb.Query<PurchaseModel>("spPurchaseSelectAll", null, commandType: CommandType.StoredProcedure).ToList();
            gvPurchaseList.DataSource = purchaseModels;
            gvPurchaseList.Columns["CustomerId"].Visible = false;
            gvPurchaseList.Columns["PriceId"].Visible = false;
        }
        private void GvPurchaseList_DoubleClick(object sender, EventArgs e)
        {
            KryptonDataGridView gv = sender as KryptonDataGridView;
            
            
        }
    }
}
