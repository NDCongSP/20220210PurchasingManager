
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdDieu = new Krypton.Toolkit.KryptonRadioButton();
            this.rdCaosu = new Krypton.Toolkit.KryptonRadioButton();
            this.ckbPayNow = new Krypton.Toolkit.KryptonCheckBox();
            this.txtThanhtien = new System.Windows.Forms.TextBox();
            this.txtDongia = new System.Windows.Forms.TextBox();
            this.txtSodo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.txtKL = new System.Windows.Forms.TextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.cbbLoaimu = new Krypton.Toolkit.KryptonComboBox();
            this.cbbKH = new Krypton.Toolkit.KryptonComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDongia = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSodo = new System.Windows.Forms.Label();
            this.lblLoaimu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbLoaimu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbKH)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdDieu);
            this.groupBox1.Controls.Add(this.rdCaosu);
            this.groupBox1.Controls.Add(this.ckbPayNow);
            this.groupBox1.Controls.Add(this.txtThanhtien);
            this.groupBox1.Controls.Add(this.txtDongia);
            this.groupBox1.Controls.Add(this.txtSodo);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.rtbNote);
            this.groupBox1.Controls.Add(this.txtKL);
            this.groupBox1.Controls.Add(this.txtDiachi);
            this.groupBox1.Controls.Add(this.txtSdt);
            this.groupBox1.Controls.Add(this.cbbLoaimu);
            this.groupBox1.Controls.Add(this.cbbKH);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDongia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblSodo);
            this.groupBox1.Controls.Add(this.lblLoaimu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1110, 713);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rdDieu
            // 
            this.rdDieu.AutoSize = false;
            this.rdDieu.Location = new System.Drawing.Point(396, 36);
            this.rdDieu.Name = "rdDieu";
            this.rdDieu.Size = new System.Drawing.Size(159, 25);
            this.rdDieu.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDieu.TabIndex = 11;
            this.rdDieu.Values.Text = "Điều";
            // 
            // rdCaosu
            // 
            this.rdCaosu.AutoSize = false;
            this.rdCaosu.Checked = true;
            this.rdCaosu.Location = new System.Drawing.Point(208, 36);
            this.rdCaosu.Name = "rdCaosu";
            this.rdCaosu.Size = new System.Drawing.Size(159, 25);
            this.rdCaosu.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCaosu.TabIndex = 11;
            this.rdCaosu.Values.Text = "Cao su";
            // 
            // ckbPayNow
            // 
            this.ckbPayNow.AutoSize = false;
            this.ckbPayNow.Location = new System.Drawing.Point(420, 327);
            this.ckbPayNow.Name = "ckbPayNow";
            this.ckbPayNow.Size = new System.Drawing.Size(183, 25);
            this.ckbPayNow.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbPayNow.TabIndex = 4;
            this.ckbPayNow.Values.Text = "Thanh toán ngay";
            // 
            // txtThanhtien
            // 
            this.txtThanhtien.BackColor = System.Drawing.Color.White;
            this.txtThanhtien.Enabled = false;
            this.txtThanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.txtThanhtien.Location = new System.Drawing.Point(208, 383);
            this.txtThanhtien.Name = "txtThanhtien";
            this.txtThanhtien.ReadOnly = true;
            this.txtThanhtien.Size = new System.Drawing.Size(395, 53);
            this.txtThanhtien.TabIndex = 9;
            this.txtThanhtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDongia
            // 
            this.txtDongia.BackColor = System.Drawing.Color.White;
            this.txtDongia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtDongia.Location = new System.Drawing.Point(743, 323);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.Size = new System.Drawing.Size(327, 29);
            this.txtDongia.TabIndex = 5;
            this.txtDongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDongia.Visible = false;
            // 
            // txtSodo
            // 
            this.txtSodo.BackColor = System.Drawing.Color.White;
            this.txtSodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtSodo.Location = new System.Drawing.Point(743, 263);
            this.txtSodo.Name = "txtSodo";
            this.txtSodo.Size = new System.Drawing.Size(327, 29);
            this.txtSodo.TabIndex = 2;
            this.txtSodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold);
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(648, 587);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(422, 112);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // rtbNote
            // 
            this.rtbNote.AutoWordSelection = true;
            this.rtbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.rtbNote.Location = new System.Drawing.Point(208, 449);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(862, 96);
            this.rtbNote.TabIndex = 6;
            this.rtbNote.Text = "";
            // 
            // txtKL
            // 
            this.txtKL.BackColor = System.Drawing.Color.White;
            this.txtKL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtKL.Location = new System.Drawing.Point(208, 323);
            this.txtKL.Name = "txtKL";
            this.txtKL.Size = new System.Drawing.Size(184, 29);
            this.txtKL.TabIndex = 3;
            this.txtKL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Enabled = false;
            this.txtDiachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtDiachi.ForeColor = System.Drawing.Color.Black;
            this.txtDiachi.Location = new System.Drawing.Point(208, 206);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.ReadOnly = true;
            this.txtDiachi.Size = new System.Drawing.Size(862, 29);
            this.txtDiachi.TabIndex = 2;
            // 
            // txtSdt
            // 
            this.txtSdt.Enabled = false;
            this.txtSdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtSdt.ForeColor = System.Drawing.Color.Black;
            this.txtSdt.Location = new System.Drawing.Point(208, 146);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.ReadOnly = true;
            this.txtSdt.Size = new System.Drawing.Size(862, 29);
            this.txtSdt.TabIndex = 2;
            // 
            // cbbLoaimu
            // 
            this.cbbLoaimu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbLoaimu.DropDownWidth = 862;
            this.cbbLoaimu.IntegralHeight = false;
            this.cbbLoaimu.Items.AddRange(new object[] {
            "Không phải mủ chén",
            "Mủ chén"});
            this.cbbLoaimu.Location = new System.Drawing.Point(208, 265);
            this.cbbLoaimu.Name = "cbbLoaimu";
            this.cbbLoaimu.Size = new System.Drawing.Size(395, 27);
            this.cbbLoaimu.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoaimu.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cbbLoaimu.TabIndex = 1;
            this.cbbLoaimu.Text = "Không phải mủ chén";
            // 
            // cbbKH
            // 
            this.cbbKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbKH.DropDownWidth = 862;
            this.cbbKH.IntegralHeight = false;
            this.cbbKH.Location = new System.Drawing.Point(208, 88);
            this.cbbKH.Name = "cbbKH";
            this.cbbKH.Size = new System.Drawing.Size(862, 27);
            this.cbbKH.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbKH.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cbbKH.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(27, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Khối lượng (Kg)";
            // 
            // lblDongia
            // 
            this.lblDongia.AutoSize = true;
            this.lblDongia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblDongia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDongia.Location = new System.Drawing.Point(644, 328);
            this.lblDongia.Name = "lblDongia";
            this.lblDongia.Size = new System.Drawing.Size(75, 24);
            this.lblDongia.TabIndex = 0;
            this.lblDongia.Text = "Đơn giá";
            this.lblDongia.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(27, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Thành tiền (VNĐ)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(27, 449);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ghi chú";
            // 
            // lblSodo
            // 
            this.lblSodo.AutoSize = true;
            this.lblSodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblSodo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSodo.Location = new System.Drawing.Point(644, 268);
            this.lblSodo.Name = "lblSodo";
            this.lblSodo.Size = new System.Drawing.Size(61, 24);
            this.lblSodo.TabIndex = 0;
            this.lblSodo.Text = "Số độ";
            // 
            // lblLoaimu
            // 
            this.lblLoaimu.AutoSize = true;
            this.lblLoaimu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblLoaimu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLoaimu.Location = new System.Drawing.Point(27, 268);
            this.lblLoaimu.Name = "lblLoaimu";
            this.lblLoaimu.Size = new System.Drawing.Size(77, 24);
            this.lblLoaimu.TabIndex = 0;
            this.lblLoaimu.Text = "Loại mủ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(27, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(27, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(27, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại thu mua";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(27, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khách hàng";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.OrangeRed;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(721, 644);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 55);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // frmThuMua
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1110, 713);
            this.Controls.Add(this.groupBox1);
            this.CornerRoundingRadius = 5F;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "frmThuMua";
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 5F;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbLoaimu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.TextBox txtSdt;
        private Krypton.Toolkit.KryptonComboBox cbbKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLoaimu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSodo;
        private System.Windows.Forms.TextBox txtKL;
        private Krypton.Toolkit.KryptonComboBox cbbLoaimu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSodo;
        private Krypton.Toolkit.KryptonCheckBox ckbPayNow;
        private Krypton.Toolkit.KryptonRadioButton rdDieu;
        private Krypton.Toolkit.KryptonRadioButton rdCaosu;
        private System.Windows.Forms.TextBox txtDongia;
        private System.Windows.Forms.Label lblDongia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThanhtien;
        private System.Windows.Forms.Label label7;
    }
}