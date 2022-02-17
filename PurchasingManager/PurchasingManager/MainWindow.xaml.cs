using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        System.Timers.Timer _timer = new System.Timers.Timer();

        public MainWindow()
        {
            InitializeComponent();

            _timer.Interval = 100;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Enabled = false;

            Dispatcher.BeginInvoke(new Action(
                       () =>
                       {
                           labTime.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                       }));
            _timer.Enabled = true;
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
