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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        #region Events
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            labTittle.Content = "NHẬP HÀNG";
            frmInput.Visibility = Visibility.Visible;
            frmReport.Visibility = Visibility.Hidden;
            frmSettings.Visibility = Visibility.Hidden;
        }

        private void btnFrmSettings_Click(object sender, RoutedEventArgs e)
        {
            labTittle.Content = "CÀI ĐẶT";
            frmInput.Visibility = Visibility.Hidden;
            frmReport.Visibility = Visibility.Hidden;
            frmSettings.Visibility = Visibility.Visible;
        }

        private void btnFrmReport_Click(object sender, RoutedEventArgs e)
        {
            labTittle.Content = "BÁO CÁO";
            frmInput.Visibility = Visibility.Hidden;
            frmReport.Visibility = Visibility.Visible;
            frmSettings.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
