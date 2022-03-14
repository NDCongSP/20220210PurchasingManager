using Krypton.Toolkit;
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
using ComponentFactory.Krypton.Toolkit;

namespace QuanLyThuMua
{
    public partial class ucThuMua : UserControl
    {

        public int GridHeight { get; set; }
        bool isUpdate;
        int CurrentValue;
        public ucThuMua()
        {
            InitializeComponent();
            Load += UcThuMua_Load;
            gvPurchaseList.DoubleClick += GvPurchaseList_DoubleClick;
            gvPurchaseList.CellBeginEdit += GvPurchaseList_CellBeginEdit;
            gvPurchaseList.CellValueChanged += GvPurchaseList_CellValueChanged;
            //gvPurchaseList.CellValidating += GvPurchaseList_CellValidating;
            gvPurchaseList.CellEndEdit += GvPurchaseList_CellEndEdit;

            gvPurchaseList.AutoGenerateColumns = true;
        }


        private void GvPurchaseList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            KryptonDataGridView gv = sender as KryptonDataGridView;
            var row = gv.Rows[e.RowIndex];
            int currentValue = Convert.ToInt32(row.Cells[e.ColumnIndex].Value);
            if (CurrentValue != currentValue)
            {
                isUpdate = true;
            }
            else
            {
                isUpdate = false;
            }
        }

        private void GvPurchaseList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }

        private void GvPurchaseList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            KryptonDataGridView gv = sender as KryptonDataGridView;
            var row = gv.Rows[e.RowIndex];
            //string textValue = row.Cells[e.ColumnIndex].Value.ToString();
            //if ((!System.Text.RegularExpressions.Regex.IsMatch(textValue, "\\d+") || !float.TryParse(textValue, out float res)) && !string.IsNullOrEmpty(textValue))
            //{
            //    MessageBox.Show("Vui lòng nhập đúng định dạng?");
            //}
            //else
            //{
            //    MessageBox.Show("Cập nhật lại số độ?");
            //}
            long Id = Convert.ToInt64(row.Cells["Id"].Value);
            int Sodo = Convert.ToInt32(row.Cells["Degree"].Value);
            if (Sodo > GlobalVariable.SoDoMax || Sodo < GlobalVariable.SoDoMin)
            {
                MessageBox.Show($"Số độ nằm trong khoảng giá trị từ  {GlobalVariable.SoDoMin} đến  {GlobalVariable.SoDoMax} ", "Cảnh báo", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                row.Cells["Degree"].Value = CurrentValue;
                return;
            }
            if (isUpdate && MessageBox.Show("Cập nhật lại số độ?","Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (UpdatePurchase(Id, Sodo) >0)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông tin", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    // GetData();

                }
                else
                {
                    row.Cells["Degree"].Value = CurrentValue;
                }
            }
        }
        private void GvPurchaseList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //KryptonDataGridView gv = sender as KryptonDataGridView;
            var activeColumn = gvPurchaseList.Columns[e.ColumnIndex];
            var row = gvPurchaseList.Rows[e.RowIndex];
            var _type = row.Cells["type"].Value.ToString();
            string _mutype = row.Cells["mutypename"].Value.ToString();
            if (activeColumn.Name == "Degree" && _type == "Cao su" && _mutype != "Mủ chén")
            {
                CurrentValue = Convert.ToInt32(row.Cells["Degree"].Value);
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
            Console.WriteLine(this.Height);
            gvPurchaseList.Height = GridHeight - 50;

            gvPurchaseList.Focus();
        }

        public void GetData()
        {
            List<PurchaseModel> purchaseModels = GlobalVariable.ConnectionDb.Query<PurchaseModel>("spPurchaseSelectAll", null, commandType: CommandType.StoredProcedure).ToList();
            gvPurchaseList.DataSource = purchaseModels;
            gvPurchaseList.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            gvPurchaseList.Columns["Weight"].DefaultCellStyle.Format = "#,###.##";
            gvPurchaseList.Columns["Price"].DefaultCellStyle.Format = "#,###";
            gvPurchaseList.Columns["Money"].DefaultCellStyle.Format = "#,###";
            //gvPurchaseList.Columns["CustomerId"].Visible = false;
            //gvPurchaseList.Columns["PriceId"].Visible = false;
        }
        private int UpdatePurchase(long Id, int Sodo)
        {
            var param = new DynamicParameters();
            param.Add("@_id",Id);
            param.Add("@_sodo",Sodo);
            return GlobalVariable.ConnectionDb.Execute("spPurchaseUpdate", param, commandType: CommandType.StoredProcedure);
        }
        private void GvPurchaseList_DoubleClick(object sender, EventArgs e)
        {
            KryptonDataGridView gv = sender as KryptonDataGridView;
        }
    }
}
