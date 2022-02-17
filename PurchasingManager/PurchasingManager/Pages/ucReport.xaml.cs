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
    /// Interaction logic for ucReport.xaml
    /// </summary>
    public partial class ucReport : UserControl
    {
        double totalMoney = 0;


        public ucReport()
        {
            InitializeComponent();

            Loaded += UcReport_Loaded;
        }

        private void UcReport_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = GlobalVariable.ExampleData;

            foreach (var item in GlobalVariable.ExampleData)
            {
                totalMoney = totalMoney + item.ThanhTien;
            }

            labTotalMoney.Dispatcher.BeginInvoke(new Action(() =>
            {
                labTotalMoney.Content = totalMoney.ToString();
            }));

            dtFrom.SelectedDate = DateTime.Now;
            dtTo.SelectedDate = DateTime.Now;

            dataGrid1.MouseDoubleClick += DataGrid1_MouseDoubleClick;
        }

        private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            //if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            //{
            //    //This is the code which helps to show the data when the row is double clicked.
            //    DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;


            //}
            var _rowDetail = grid.SelectedItem as DataModel;

            if (_rowDetail.MuChen==false)
            {
                frmNhapSoDo nf = new frmNhapSoDo() { CusTomerName = _rowDetail.TenKhach };
                nf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chỉ nhập số độ cho mủ không phải mủ chén.","CẢNH BÁO",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTruyVan_Click(object sender, RoutedEventArgs e)
        {
            //List<DataModel> _data = new List<DataModel>();
            totalMoney = 0;

            var _cusName = cboCustomer.Text;

            if (_cusName != "TẤT CẢ")
            {
                var _data = from item in GlobalVariable.ExampleData where item.TenKhach == _cusName select item;

                if (_data != null)
                {
                    dataGrid1.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        dataGrid1.ItemsSource = _data;
                    }));

                    foreach (var item in _data)
                    {
                        totalMoney = totalMoney + item.ThanhTien;
                    }
                }
            }
            else
            {
                dataGrid1.ItemsSource = GlobalVariable.ExampleData;

                foreach (var item in GlobalVariable.ExampleData)
                {
                    totalMoney = totalMoney + item.ThanhTien;
                }
            }

            labTotalMoney.Dispatcher.BeginInvoke(new Action(() =>
            {
                labTotalMoney.Content = totalMoney.ToString();
            }));
        }

        private void cboCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
