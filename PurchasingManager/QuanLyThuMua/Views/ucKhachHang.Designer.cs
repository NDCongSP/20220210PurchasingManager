
namespace QuanLyThuMua
{
    partial class ucKhachHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryGridCustomer = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column3 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column4 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column5 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryGridCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // kryGridCustomer
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.kryGridCustomer.ColumnHeadersHeight = 50;
            this.kryGridCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.kryGridCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryGridCustomer.Location = new System.Drawing.Point(0, 0);
            this.kryGridCustomer.Name = "kryGridCustomer";
            this.kryGridCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridCustomer.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.kryGridCustomer.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridCustomer.RowTemplate.Height = 50;
            this.kryGridCustomer.Size = new System.Drawing.Size(1205, 723);
            this.kryGridCustomer.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.kryGridCustomer.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridCustomer.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.kryGridCustomer.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridCustomer.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Tên khách hàng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Phone";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Số điện thoại";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Address";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Địa chỉ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 500;
            // 
            // Column5
            // 
            this.Column5.Checked = false;
            this.Column5.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.Column5.DataPropertyName = "CreatedDate";
            this.Column5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Column5.HeaderText = "Ngày tạo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // ucKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.kryGridCustomer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucKhachHang";
            this.Size = new System.Drawing.Size(1205, 723);
            ((System.ComponentModel.ISupportInitialize)(this.kryGridCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryGridCustomer;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn Column5;
    }
}
