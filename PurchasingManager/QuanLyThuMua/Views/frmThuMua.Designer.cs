
namespace QuanLyThuMua
{
    partial class frmThuMua
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.cbbKH = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.cbbLoaimu = new System.Windows.Forms.ComboBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.kryptonCheckBox1 = new Krypton.Toolkit.KryptonCheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtKL = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbKH)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonCheckBox1);
            this.kryptonPanel1.Controls.Add(this.textBox6);
            this.kryptonPanel1.Controls.Add(this.textBox7);
            this.kryptonPanel1.Controls.Add(this.textBox5);
            this.kryptonPanel1.Controls.Add(this.textBox4);
            this.kryptonPanel1.Controls.Add(this.textBox3);
            this.kryptonPanel1.Controls.Add(this.txtKL);
            this.kryptonPanel1.Controls.Add(this.txtSdt);
            this.kryptonPanel1.Controls.Add(this.txtDiachi);
            this.kryptonPanel1.Controls.Add(this.cbbKH);
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.cbbLoaimu);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1240, 794);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cbbKH
            // 
            this.cbbKH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbbKH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbKH.DropDownWidth = 955;
            this.cbbKH.IntegralHeight = false;
            this.cbbKH.Items.AddRange(new object[] {
            "Nguyen Van A",
            "Tran Van B",
            "Nguyen Thi C",
            "Cao Van D",
            "Le Van E"});
            this.cbbKH.Location = new System.Drawing.Point(232, 44);
            this.cbbKH.Name = "cbbKH";
            this.cbbKH.Size = new System.Drawing.Size(926, 37);
            this.cbbKH.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.cbbKH.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(8);
            this.cbbKH.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cbbKH.TabIndex = 8;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(1023, 729);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(205, 53);
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.kryptonButton2.TabIndex = 7;
            this.kryptonButton2.Values.Text = "Luu";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(700, 729);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(290, 53);
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 7;
            this.kryptonButton1.Values.Text = "Thanh toan ngay va Luu";
            // 
            // cbbLoaimu
            // 
            this.cbbLoaimu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoaimu.FormattingEnabled = true;
            this.cbbLoaimu.Location = new System.Drawing.Point(232, 270);
            this.cbbLoaimu.Name = "cbbLoaimu";
            this.cbbLoaimu.Size = new System.Drawing.Size(420, 33);
            this.cbbLoaimu.TabIndex = 6;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Enabled = false;
            this.txtDiachi.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiachi.Location = new System.Drawing.Point(232, 122);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.ReadOnly = true;
            this.txtDiachi.Size = new System.Drawing.Size(926, 33);
            this.txtDiachi.TabIndex = 9;
            // 
            // txtSdt
            // 
            this.txtSdt.Enabled = false;
            this.txtSdt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSdt.Location = new System.Drawing.Point(232, 196);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.ReadOnly = true;
            this.txtSdt.Size = new System.Drawing.Size(926, 33);
            this.txtSdt.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(77, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(138, 33);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = "Khach hang";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(77, 122);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(138, 33);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "Dia chi";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(77, 270);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(138, 33);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "Loai mu";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(77, 196);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(138, 33);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "SDT";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonCheckBox1
            // 
            this.kryptonCheckBox1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonCheckBox1.Location = new System.Drawing.Point(689, 273);
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Size = new System.Drawing.Size(101, 30);
            this.kryptonCheckBox1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.kryptonCheckBox1.StateCommon.ShortText.Color1 = System.Drawing.Color.Navy;
            this.kryptonCheckBox1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.kryptonCheckBox1.TabIndex = 11;
            this.kryptonCheckBox1.Values.Text = "Mu chen";
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(77, 342);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(138, 33);
            this.textBox7.TabIndex = 10;
            this.textBox7.Text = "Khoi luong (Kg)";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKL
            // 
            this.txtKL.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKL.Location = new System.Drawing.Point(232, 342);
            this.txtKL.Name = "txtKL";
            this.txtKL.Size = new System.Drawing.Size(926, 33);
            this.txtKL.TabIndex = 9;
            // 
            // frmThuMua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 794);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmThuMua";
            this.Text = "frmThuMua";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.ComboBox cbbLoaimu;
        private Krypton.Toolkit.KryptonComboBox cbbKH;
        private System.Windows.Forms.TextBox txtDiachi;
        private Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtKL;
        private System.Windows.Forms.TextBox txtSdt;
    }
}