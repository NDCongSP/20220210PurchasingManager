using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PurchasingManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);

            DataProvider.Instance.connectionStr = EncodeMD5.DecryptString(ConfigurationManager.AppSettings["ConString"], "PhucTh!nhMD%");

           // DataProvider.Instance.ExecuteNonQuery("call spCustomerInsert ('Nguyễn Văn D','0909123459','Bình Phước');");

            GlobalVariable.DonGiaCaoSu.Add(0, 900);
            GlobalVariable.DonGiaCaoSu.Add(10, 1000);
            GlobalVariable.DonGiaCaoSu.Add(20, 1000);
            GlobalVariable.DonGiaCaoSu.Add(30, 1000);
            GlobalVariable.DonGiaCaoSu.Add(40, 1000);
            GlobalVariable.DonGiaCaoSu.Add(50, 1000);
            GlobalVariable.DonGiaCaoSu.Add(60, 1000);
            GlobalVariable.DonGiaCaoSu.Add(70, 1000);
            GlobalVariable.DonGiaCaoSu.Add(80, 1000);
            GlobalVariable.DonGiaCaoSu.Add(90, 1000);
            GlobalVariable.DonGiaCaoSu.Add(100, 1000);

            GlobalVariable.ExampleData.Add(new DataModel()
            {
                TenKhach = "Nguyễn Văn A",
                SDT = "0909123456",
                NgayMua = "2022-02-10 10:00:00",
                MuChen = false,
                KhoiLuong = 5000,
                SoDo = 70
            });
            GlobalVariable.ExampleData.Add(new DataModel()
            {
                TenKhach = "Nguyễn Văn A",
                SDT = "0909123456",
                NgayMua = "2022-02-10 10:00:00",
                MuChen = true,
                KhoiLuong = 700,
                SoDo = 0
            });
            GlobalVariable.ExampleData.Add(new DataModel()
            {
                TenKhach = "Nguyễn Văn A",
                SDT = "0909123456",
                NgayMua = "2022-02-10 15:00:00",
                MuChen = false,
                KhoiLuong = 1000,
                SoDo = 90
            });
            GlobalVariable.ExampleData.Add(new DataModel()
            {
                TenKhach = "Nguyễn Văn A",
                SDT = "0909123456",
                NgayMua = "2022-02-17 11:00:00",
                MuChen = false,
                KhoiLuong = 2000,
                SoDo = 80
            });
            GlobalVariable.ExampleData.Add(new DataModel()
            {
                TenKhach = "Nguyễn Văn B",
                SDT = "0978123456",
                NgayMua = "2022-02-11 13:00:00",
                MuChen = false,
                KhoiLuong = 3000,
                SoDo = 100
            });
            GlobalVariable.ExampleData.Add(new DataModel()
            {
                TenKhach = "Nguyễn Văn B",
                SDT = "0978123456",
                NgayMua = "2022-02-13 09:00:00",
                MuChen = false,
                KhoiLuong = 5000,
                SoDo = 70
            });

            foreach (var item in GlobalVariable.ExampleData)
            {
                if (item.MuChen == false)
                {
                    item.DonGia = GlobalVariable.DonGiaCaoSu[item.SoDo];
                    item.ThanhTien = item.KhoiLuong * item.SoDo * item.DonGia;
                }
                else
                {
                    item.DonGia = GlobalVariable.DonGiaCaoSu[item.SoDo];
                    item.ThanhTien = item.KhoiLuong * item.DonGia;
                }
            }
        }
    }
}
