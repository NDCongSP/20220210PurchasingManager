
namespace QuanLyThuMua
{
    partial class frmDonGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonGia));
            this.txtPriceCaoSu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoteCaosu = new System.Windows.Forms.TextBox();
            this.dtpCaoSu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPriceCaoSu
            // 
            this.txtPriceCaoSu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriceCaoSu.Location = new System.Drawing.Point(320, 124);
            this.txtPriceCaoSu.Name = "txtPriceCaoSu";
            this.txtPriceCaoSu.Size = new System.Drawing.Size(234, 29);
            this.txtPriceCaoSu.TabIndex = 4;
            this.txtPriceCaoSu.Text = "0";
            this.txtPriceCaoSu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.labTitle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNoteCaosu);
            this.groupBox1.Controls.Add(this.dtpCaoSu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPriceCaoSu);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 311);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ghi chú";
            // 
            // txtNoteCaosu
            // 
            this.txtNoteCaosu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoteCaosu.Location = new System.Drawing.Point(21, 203);
            this.txtNoteCaosu.Multiline = true;
            this.txtNoteCaosu.Name = "txtNoteCaosu";
            this.txtNoteCaosu.Size = new System.Drawing.Size(533, 90);
            this.txtNoteCaosu.TabIndex = 5;
            // 
            // dtpCaoSu
            // 
            this.dtpCaoSu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpCaoSu.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpCaoSu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCaoSu.Location = new System.Drawing.Point(21, 124);
            this.dtpCaoSu.Name = "dtpCaoSu";
            this.dtpCaoSu.Size = new System.Drawing.Size(227, 29);
            this.dtpCaoSu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Giá (VNĐ)";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thời gian cập nhật";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(12, 343);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(579, 99);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(458, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // labTitle
            // 
            this.labTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(25, 25);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(529, 54);
            this.labTitle.TabIndex = 12;
            this.labTitle.Text = "THÊM ĐƠN GIÁ";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDonGia
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(610, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDonGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm đơn giá";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPriceCaoSu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpCaoSu;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoteCaosu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labTitle;
    }
}