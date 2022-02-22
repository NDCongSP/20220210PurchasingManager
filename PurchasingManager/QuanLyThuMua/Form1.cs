﻿using Krypton.Toolkit;
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
    public partial class Form1 : KryptonForm
    {
        UserControl _activePage;
        string _activePageText;

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
                    }

                    panelContainer.Controls.Add(_activePage);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            kryptonRibbon1_SelectedTabChanged(null, null);
        }

        private void OnActivePageTextChanged()
        {
            UserControl page = null;
            if (_activePageText == "Thu Mua")
            {
                page = new ucThuMua();
            }
            else if (_activePageText == "Khách Hàng")
            {
                page = new ucKhachHang();
            }
            else if (_activePageText == "Báo Cáo")
            {
                page = new ucBaoCao();
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

        }

        private void _btnTaoTamUng_Click(object sender, EventArgs e)
        {

        }

        private void _btnThemKH_Click(object sender, EventArgs e)
        {
            frmKhachHang form = new frmKhachHang();
            form.ShowDialog();
        }

        private void _btnSuaKH_Click(object sender, EventArgs e)
        {

        }

        private void _btnXoaKH_Click(object sender, EventArgs e)
        {

        }

        private void _btnCaiDatDonGia_Click(object sender, EventArgs e)
        {
            frmDonGia form = new frmDonGia();
            form.ShowDialog();
        }
    }
}