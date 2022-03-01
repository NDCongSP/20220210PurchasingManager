
namespace QuanLyThuMua
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kryptonRibbon1 = new Krypton.Ribbon.KryptonRibbon();
            this.kryptonRibbonTab1 = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup1 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple1 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this._btnTaoThuMua = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this._btnTaoTamUng = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonTab2 = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup2 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple4 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this._btnRefreshKH = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupTriple2 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this._btnThemKH = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this._btnSuaKH = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonTab3 = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup3 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple3 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this._btnRefreshGia = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this._btnThemDonGia = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this._btnSuaDonGia = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonTab4 = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.panelContainer = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonRibbon1
            // 
            this.kryptonRibbon1.InDesignHelperMode = true;
            this.kryptonRibbon1.Name = "kryptonRibbon1";
            this.kryptonRibbon1.RibbonAppButton.AppButtonVisible = false;
            this.kryptonRibbon1.RibbonTabs.AddRange(new Krypton.Ribbon.KryptonRibbonTab[] {
            this.kryptonRibbonTab1,
            this.kryptonRibbonTab2,
            this.kryptonRibbonTab3,
            this.kryptonRibbonTab4});
            this.kryptonRibbon1.SelectedTab = this.kryptonRibbonTab2;
            this.kryptonRibbon1.Size = new System.Drawing.Size(1924, 145);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRibbon1.TabIndex = 0;
            this.kryptonRibbon1.SelectedTabChanged += new System.EventHandler(this.kryptonRibbon1_SelectedTabChanged);
            // 
            // kryptonRibbonTab1
            // 
            this.kryptonRibbonTab1.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup1});
            this.kryptonRibbonTab1.Text = "Thu Mua";
            // 
            // kryptonRibbonGroup1
            // 
            this.kryptonRibbonGroup1.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1});
            this.kryptonRibbonGroup1.TextLine1 = "Thu Mua";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this._btnTaoThuMua,
            this._btnTaoTamUng});
            // 
            // _btnTaoThuMua
            // 
            this._btnTaoThuMua.TextLine1 = "Tạo Thu Mua";
            this._btnTaoThuMua.Click += new System.EventHandler(this._btnTaoThuMua_Click);
            // 
            // _btnTaoTamUng
            // 
            this._btnTaoTamUng.TextLine1 = "Tạm Ứng";
            this._btnTaoTamUng.Click += new System.EventHandler(this._btnTaoTamUng_Click);
            // 
            // kryptonRibbonTab2
            // 
            this.kryptonRibbonTab2.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup2});
            this.kryptonRibbonTab2.Text = "Khách Hàng";
            // 
            // kryptonRibbonGroup2
            // 
            this.kryptonRibbonGroup2.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple4,
            this.kryptonRibbonGroupTriple2});
            this.kryptonRibbonGroup2.TextLine1 = "Khách Hàng";
            // 
            // kryptonRibbonGroupTriple4
            // 
            this.kryptonRibbonGroupTriple4.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this._btnRefreshKH});
            // 
            // _btnRefreshKH
            // 
            this._btnRefreshKH.ImageLarge = ((System.Drawing.Image)(resources.GetObject("_btnRefreshKH.ImageLarge")));
            this._btnRefreshKH.TextLine1 = "Tải lại";
            this._btnRefreshKH.Click += new System.EventHandler(this._btnRefreshKH_Click);
            // 
            // kryptonRibbonGroupTriple2
            // 
            this.kryptonRibbonGroupTriple2.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this._btnThemKH,
            this._btnSuaKH});
            // 
            // _btnThemKH
            // 
            this._btnThemKH.TextLine1 = "Thêm";
            this._btnThemKH.Click += new System.EventHandler(this._btnThemKH_Click);
            // 
            // _btnSuaKH
            // 
            this._btnSuaKH.TextLine1 = "Sửa";
            this._btnSuaKH.Click += new System.EventHandler(this._btnSuaKH_Click);
            // 
            // kryptonRibbonTab3
            // 
            this.kryptonRibbonTab3.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup3});
            this.kryptonRibbonTab3.Text = "Đơn Giá";
            // 
            // kryptonRibbonGroup3
            // 
            this.kryptonRibbonGroup3.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple3});
            this.kryptonRibbonGroup3.TextLine1 = "Đơn Giá";
            // 
            // kryptonRibbonGroupTriple3
            // 
            this.kryptonRibbonGroupTriple3.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this._btnRefreshGia,
            this._btnThemDonGia,
            this._btnSuaDonGia});
            // 
            // _btnRefreshGia
            // 
            this._btnRefreshGia.ImageLarge = ((System.Drawing.Image)(resources.GetObject("_btnRefreshGia.ImageLarge")));
            this._btnRefreshGia.TextLine1 = "Tải lại";
            this._btnRefreshGia.Click += new System.EventHandler(this._btnRefreshGia_Click);
            // 
            // _btnThemDonGia
            // 
            this._btnThemDonGia.TextLine1 = "Thêm";
            this._btnThemDonGia.Click += new System.EventHandler(this._btnThemDonGia_Click);
            // 
            // _btnSuaDonGia
            // 
            this._btnSuaDonGia.TextLine1 = "Sửa";
            this._btnSuaDonGia.Click += new System.EventHandler(this._btnSuaDonGia_Click);
            // 
            // kryptonRibbonTab4
            // 
            this.kryptonRibbonTab4.Text = "Báo Cáo";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Office2010BlueLightMode;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 145);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Padding = new System.Windows.Forms.Padding(12);
            this.panelContainer.Size = new System.Drawing.Size(1924, 916);
            this.panelContainer.TabIndex = 1;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.kryptonRibbon1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Ribbon.KryptonRibbon kryptonRibbon1;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab1;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab2;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private Krypton.Ribbon.KryptonRibbonGroupButton _btnTaoThuMua;
        private Krypton.Ribbon.KryptonRibbonGroupButton _btnTaoTamUng;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup2;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
        private Krypton.Ribbon.KryptonRibbonGroupButton _btnThemKH;
        private Krypton.Ribbon.KryptonRibbonGroupButton _btnSuaKH;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab3;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab4;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup3;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple3;
        private Krypton.Ribbon.KryptonRibbonGroupButton _btnThemDonGia;
        private Krypton.Ribbon.KryptonRibbonGroupButton _btnSuaDonGia;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple4;
        private Krypton.Ribbon.KryptonRibbonGroupButton _btnRefreshKH;
        private Krypton.Toolkit.KryptonPanel panelContainer;
        private Krypton.Ribbon.KryptonRibbonGroupButton _btnRefreshGia;
    }
}

