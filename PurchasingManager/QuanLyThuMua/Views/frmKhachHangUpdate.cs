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
    public partial class frmKhachHangUpdate : KryptonForm
    {
        private int customerId;
        private CustomerModel customerInfo = new CustomerModel();
        private bool isActived = false;
        public event EventHandler OnCustomerChanged;
        public frmKhachHangUpdate()
        {
            InitializeComponent();

            Load += FrmKhachHangUpdate_Load;
        }

        private void FrmKhachHangUpdate_Load(object sender, EventArgs e)
        {
            var _res = GlobalVariable.ConnectionDb.Query<CustomerModel>("call spCustomerSelectAll").ToList();

            krpCboCustomer.DataSource = _res;
            krpCboCustomer.ValueMember = "Id";
            krpCboCustomer.DisplayMember = "Name";

            customerInfo = _res[0];

            txtName.BeginInvoke(new Action(() =>
            {
                txtName.Text = customerInfo.Name;
            }));
            txtPhoneNum.BeginInvoke(new Action(() =>
            {
                txtPhoneNum.Text = customerInfo.Phone;
            }));
            txtAdd.BeginInvoke(new Action(() =>
            {
                txtAdd.Text = customerInfo.Address;
            }));

            if (customerInfo.IsActived == 1)
            {
                ckbStatus.Checked = true;
                isActived = true;
            }
            else
            {
                ckbStatus.Checked = false;
                isActived = false;
            }

            krpCboCustomer.SelectedValueChanged += KrpCboCustomer_SelectedValueChanged;
            ckbStatus.CheckedChanged += CkbStatus_CheckedChanged;
        }

        private void CkbStatus_CheckedChanged(object sender, EventArgs e)
        {
            var sen = sender as KryptonCheckBox;
            isActived = sen.Checked;
        }

        private void KrpCboCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            var sen = (KryptonComboBox)sender;

            customerInfo = (CustomerModel)sen.SelectedItem;

            txtName.BeginInvoke(new Action(() =>
            {
                txtName.Text = customerInfo.Name;
            }));
            txtPhoneNum.BeginInvoke(new Action(() =>
            {
                txtPhoneNum.Text = customerInfo.Phone;
            }));
            txtAdd.BeginInvoke(new Action(() =>
            {
                txtAdd.Text = customerInfo.Address;
            }));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPhoneNum.Text) && !string.IsNullOrEmpty(txtAdd.Text))
            {
                if (GlobalVariable.ConnectionDb.Execute($"call spCustomerUpdate ({customerInfo.Id},'{txtName.Text}','{txtPhoneNum.Text}','{txtAdd.Text}',{isActived});") > 0)
                {
                    OnCustomerChanged?.Invoke(this, e);
                    MessageBox.Show("Cập nhật thành công.");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
                }
            }

            this.Close();
        }
    }
}
