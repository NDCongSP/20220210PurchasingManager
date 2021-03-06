using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using Dapper;
using System.Collections.Generic;

namespace QuanLyThuMua
{
    public partial class Form1 : KryptonForm
    {
        UserControl _activePage;
        CheckedComboBox checkedListBox;
        List<CustomerModel> lFilterCus = new List<CustomerModel>();
        string _activePageText;

        private System.Timers.Timer nTimer = new System.Timers.Timer();

        public string ActivePageText
        {
            get => _activePageText;
            set
            {
                if (_activePageText != value)
                {
                    _activePageText = value;
                    OnActivePageTextChanged();
                }
            }
        }

        public UserControl ActivePage
        {
            get => _activePage;
            set
            {
                if (_activePage != value)
                {
                    panelContainer.Controls.Clear();

                    _activePage = value;

                    if (_activePage != null)
                    {
                        _activePage.Dock = DockStyle.Fill;
                        panelContainer.Controls.Add(_activePage);
                        _activePage?.Focus();
                    }

                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            nTimer.Interval = 100;
            nTimer.Elapsed += NTimer_Elapsed;
            nTimer.Enabled = true;

            kryptonRibbon1_SelectedTabChanged(null, null);
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += Form1_FormClosing;

            kryptonRibbon1.SelectedTab = kryptonRibbonTab1;

            if (GlobalVariable.UserInfo.Role == "1")
            {
                _btnCreatedUser.Visible = true;
            }
            else
            {
                _btnCreatedUser.Visible = false;
            }

            _dtpFromDay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _dtpToDay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            #region ribbon custom control
            //KryptonCheckedListBox _ck = new CheckedComboBox();
            //_ck.Items.Add("1");
            //_ck.Items.Add("2");
            //_ck.Items.Add("3");
            //_ck.Items.Add("4");
            //_ck.Items.Add("5");
            //_ck.Items.Add("6");
            //_ck.Items.Add("7");
            //_ck.Items.Add("8");
            //_ck.Items.Add("9");
            //_ck.Items.Add("10");

            //kryptonRibbonGroupCustomControl1.CustomControl = _ck;


            checkedListBox = new CheckedComboBox();
            checkedListBox.ItemCheck += CheckedListBox_ItemCheck;

            var result = GlobalVariable.ConnectionDb.Query<CustomerModel>("select * from customerinfo");
            checkedListBox.Items.Clear();

            //checkedListBox.Items.Add(new CustomerModel()
            //{
            //    Name = "Tất Cả"
            //});

            foreach (var item in result)
            {
                checkedListBox.Items.Add(item);
            }

            //if (checkedListBox.SelectedIndex == -1)
            //    checkedListBox.SelectedIndex = 0;

            //checkedListBox.MaxDropDownItems = 5;
            // Make the "Name" property the one to display, rather than the ToString() representation.
            checkedListBox.DisplayMember = "Name";
            checkedListBox.ValueSeparator = ", ";

            kryptonRibbonGroupCustomControl1.CustomControl = checkedListBox;

            
            #endregion
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CustomerModel item = checkedListBox.Items[e.Index] as CustomerModel;
            if (e.NewValue == CheckState.Checked)
            {
                if (!lFilterCus.Contains(item))
                {
                    lFilterCus.Add(item);
                }
            }
            else
            {
                if (lFilterCus.Contains(item))
                {
                    lFilterCus.Remove(item);
                }
            }
        }

        private void NTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            nTimer.Enabled = false;
            if (GlobalVariable.IsActivedApp)
            {
                #region nếu app chưa active, thì check ngày tháng để khóa
                if (GlobalVariable.ActivedApp != "Actived")
                {
                    if (DateTime.Now >= Convert.ToDateTime(GlobalVariable.ActivedApp))
                    {
                        GlobalVariable.IsActivedApp = false;
                    }
                }
                #endregion
            }
            else
            {
                if (kryptonRibbon1.InvokeRequired)
                {
                    kryptonRibbon1.Invoke(new Action(() =>
                    {
                        kryptonRibbon1.Enabled = false;
                    }));
                }
                else
                {
                    kryptonRibbon1.Enabled = false;
                }

                MessageBox.Show("Bạn đã hết thời gian dùng thử, vui lòng liên hệ để lấy license.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            nTimer.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void OnActivePageTextChanged()
        {
            UserControl page = null;

            if (_activePageText == "Thu Mua")
            {
                page = new ucThuMua() { GridHeight = panelContainer.Height };
            }
            else if (_activePageText == "Khách Hàng")
            {
                page = new ucKhachHang();
            }
            else if (_activePageText == "Đơn Giá")
            {
                page = new ucDonGia();
            }
            else if (_activePageText == "Báo Cáo")
            {
                page = new ucBaoCao();
            }
            else if (_activePageText == "Tài Khoản")
            {
                page = new ucAccount();
            }
            ActivePage = page;
        }

        private void kryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {
            string text = null;
            if (kryptonRibbon1.SelectedTab != null)
            {
                text = kryptonRibbon1.SelectedTab.Text;
            }
            ActivePageText = text;
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonPage1_Click(object sender, EventArgs e)
        {

        }

        private void _btnTaoThuMua_Click(object sender, EventArgs e)
        {
            frmThuMua form = new frmThuMua();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.OnPurchaseInserted += Form_OnPurchaseInserted;
            form.ShowDialog();
        }

        private void _btnTaoThuMuaDieu_Click(object sender, EventArgs e)
        {
            frmThuMuaDieu form = new frmThuMuaDieu();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.OnPurchaseInserted += Form_OnPurchaseInserted;
            form.ShowDialog();
        }

        private void Form_OnPurchaseInserted(object sender, EventArgs e)
        {
            if (ActivePage is ucThuMua thuMua)
            {
                thuMua.GetData();
            }
        }

        private void _btnTaoTamUng_Click(object sender, EventArgs e)
        {
            frmTamUng form = new frmTamUng();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.ShowDialog();
        }

        private void _btnThemKH_Click(object sender, EventArgs e)
        {
            frmKhachHang form = new frmKhachHang();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.OnCustomerChanged += Form_OnCustomerChanged; ;
            form.ShowDialog();
        }

        private void Form_OnCustomerChanged(object sender, EventArgs e)
        {
            if (_activePage is ucKhachHang uc)
            {
                uc.RefreshData();
            }
        }

        private void _btnSuaKH_Click(object sender, EventArgs e)
        {
            frmKhachHangUpdate form = new frmKhachHangUpdate();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.OnCustomerChanged += Form_OnCustomerChanged;
            form.ShowDialog();
        }

        private void _btnXoaKH_Click(object sender, EventArgs e)
        {

        }

        private void _btnThemDonGiaCaoSu_Click(object sender, EventArgs e)
        {
            //CÓ SỐ ĐỘ
            frmDonGia form = new frmDonGia();
            form.TitleForm = "THÊM ĐƠN GIÁ CAO SU MỦ NƯỚC";
            form.PriceType = "Cao su";
            form.MuType = 0;
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.OnPriceChanged += Form_OnPriceChanged;
            form.ShowDialog();
        }

        private void Form_OnPriceChanged(object sender, EventArgs e)
        {
            if (_activePage is ucDonGia uc)
            {
                uc.RefreshData();
            }
        }

        private void _btnThemDonGiaDieu_Click(object sender, EventArgs e)
        {
            frmDonGia form = new frmDonGia();
            form.TitleForm = "THÊM ĐƠN GIÁ ĐIỀU";
            form.PriceType = "Điều";
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.OnPriceChanged += Form_OnPriceChanged;
            form.ShowDialog();
        }

        private void _btnRefreshKH_Click(object sender, EventArgs e)
        {
            if (_activePage is ucKhachHang uc)
            {
                uc.RefreshData();
            }
        }

        private void _btnRefreshGia_Click(object sender, EventArgs e)
        {
            if (_activePage is ucDonGia uc)
            {
                uc.RefreshData();
            }
        }

        private void _btnCapNhatBaoCao_Click(object sender, EventArgs e)
        {
            if (_dtpFromDay.Value > _dtpToDay.Value)
            {
                MessageBox.Show("Thời giàn 'Từ Ngày' phải nhỏ hơn 'Đến Ngày'.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ActivePage is ucBaoCao uc)
            {
                //string Customers = checkedListBox.GetItemChecked();
                
                var a = lFilterCus;
                int payNow = -1;
                if (_radioNotPayed.Checked)
                {
                    payNow = 0;
                }
                else if (_radioPayed.Checked)
                {
                    payNow = 1;
                }
                uc.CapNhat(_dtpFromDay.Value, _dtpToDay.Value, 0, _cobKieuBaoCao.Text, payNow,a);
            }
        }

        private void _btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (ActivePage is ucBaoCao uc)
            {
                int payNow = -1;
                if (_radioNotPayed.Checked)
                {
                    payNow = 0;
                }
                else if (_radioPayed.Checked)
                {
                    payNow = 1;
                }
                uc.XuatExcel(_dtpFromDay.Value, _dtpToDay.Value, 0, _cobKieuBaoCao.Text, payNow, lFilterCus);
            }
        }

        private void _cobBaoCaoKH_DropDown(object sender, EventArgs e)
        {
            try
            {
                //var result = GlobalVariable.ConnectionDb.Query<CustomerModel>("select * from customerinfo");
                //_cobBaoCaoKH.Items.Clear();

                //_cobBaoCaoKH.Items.Add(new CustomerModel()
                //{
                //    Name = "Tất Cả"
                //});

                //foreach (var item in result)
                //{
                //    _cobBaoCaoKH.Items.Add(item);
                //}

                //if (_cobBaoCaoKH.SelectedIndex == -1)
                //    _cobBaoCaoKH.SelectedIndex = 0;
            }
            catch { }
        }

        private void _btnThanhToan_Click(object sender, EventArgs e)
        {
            if (ActivePage is ucBaoCao uc)
            {
                //CustomerModel customer = _cobBaoCaoKH.SelectedItem as CustomerModel;
                int payNow = -1;
                if (_radioNotPayed.Checked)
                {
                    payNow = 0;
                }
                else if (_radioPayed.Checked)
                {
                    payNow = 1;
                }

                //uc.ThanhToan(_dtpFromDay.Value, _dtpToDay.Value, customer?.Id, _cobKieuBaoCao.Text, payNow);
                uc.ThanhToan(_dtpFromDay.Value, _dtpToDay.Value, 0, _cobKieuBaoCao.Text, payNow, lFilterCus);
            }
        }

        private void _btnRefresh_Click(object sender, EventArgs e)
        {
            if (ActivePage is ucDonGia uc)
            {
                uc.RefreshData();
            }
        }

        private void _btnRefreshThumua_Click(object sender, EventArgs e)
        {
            if (ActivePage is ucThuMua uc)
            {
                uc.GetData();
            }
        }

        private void _btnCreatedUser_Click(object sender, EventArgs e)
        {
            frmCreatedUser form = new frmCreatedUser();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.ShowDialog();
        }

        private void _btnThemDonGiaMuDay_Click(object sender, EventArgs e)
        {
            frmDonGia form = new frmDonGia();
            form.TitleForm = "THÊM ĐƠN GIÁ CAO SU MỦ DÂY";
            form.PriceType = "Cao su";
            form.MuType = 2;//tạo đơn giá cho mủ dây
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.OnPriceChanged += Form_OnPriceChanged;
            form.ShowDialog();
        }

        private void _btnXoaThuMua_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn của khách hàng tên '{GlobalVariable.PurchaseInfo.Name}'" +
                $", tạo ngày '{GlobalVariable.PurchaseInfo.CreatedDate}'" +
                  $", tổng tiền '{GlobalVariable.PurchaseInfo.Money:#,##0}'?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.Yes)
            {
                GlobalVariable.ConnectionDb.Execute($"update purchaseinfo set Actived = 0 where Id ={GlobalVariable.PurchaseInfo.Id}");

                if (ActivePage is ucThuMua uc)
                {
                    uc.GetData();
                }
            }
        }

        private void _btnThemDonGiaMuChen_Click(object sender, EventArgs e)
        {
            frmDonGia form = new frmDonGia();
            form.TitleForm = "THÊM ĐƠN GIÁ CAO SU MỦ CHÉN";
            form.PriceType = "Cao su";
            form.MuType = 1;
            form.StartPosition = FormStartPosition.CenterParent;
            form.Owner = this;
            form.OnPriceChanged += Form_OnPriceChanged;
            form.ShowDialog();
        }
    }
}
