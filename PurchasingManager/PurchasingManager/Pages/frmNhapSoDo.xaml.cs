using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PurchasingManager
{
    /// <summary>
    /// Interaction logic for frmNhapSoDo.xaml
    /// </summary>
    public partial class frmNhapSoDo : Window
    {
        public string CusTomerName { get; set; }
        public frmNhapSoDo()
        {
            InitializeComponent();

            Loaded += FrmNhapSoDo_Loaded;
        }

        private void FrmNhapSoDo_Loaded(object sender, RoutedEventArgs e)
        {
            var _res = GlobalVariable.ExampleData.First(x => x.TenKhach == CusTomerName);

            if (_res != null)
            {
                txtSoDo.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txtSoDo.Text = _res.SoDo.ToString();
                }));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            double _soDo = double.TryParse(txtSoDo.Text, out double value) ? value : 0;

            if (_soDo >= 10 && _soDo <= 100)
            {
                var _res = GlobalVariable.ExampleData.FirstOrDefault(x => x.TenKhach == CusTomerName);
                if (_res != null)
                {
                    _res.SoDo = _soDo;
                    _res.DonGia = GlobalVariable.DonGiaCaoSu[_res.SoDo];
                    _res.ThanhTien = _res.KhoiLuong * _res.SoDo * _res.DonGia;
                }
            }
            else
            {
                MessageBox.Show($"Số độ phải nằm trong khoangt [10 ~ 100].", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
