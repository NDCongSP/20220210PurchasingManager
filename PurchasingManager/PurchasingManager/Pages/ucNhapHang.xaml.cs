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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PurchasingManager
{
    /// <summary>
    /// Interaction logic for ucNhapHang.xaml
    /// </summary>
    public partial class ucNhapHang : UserControl
    {
        public ucNhapHang()
        {
            InitializeComponent();

            Loaded += UcNhapHang_Loaded;
        }

        private void UcNhapHang_Loaded(object sender, RoutedEventArgs e)
        {
            cboCustomer.SelectionChanged += CboCustomer_SelectionChanged;
        }

        private void CboCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox _cbo = sender as ComboBox;

            var _res = GlobalVariable.ExampleData.FirstOrDefault(x => x.TenKhach == _cbo.Text);

            if (_res != null)
            {
                labSDT.Dispatcher.BeginInvoke(new Action(() =>
                {
                    labSDT.Content = _res.SDT;
                }));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cboCustomer_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
