namespace QuanLyThuMua
{
    partial class ucDonGia
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
            this.kryGridGia = new  ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column5 = new  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column2 = new  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.Column3 = new  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column4 = new  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryGridGia)).BeginInit();
            this.SuspendLayout();
            // 
            // kryGridGia
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.kryGridGia.ColumnHeadersHeight = 50;
            this.kryGridGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            this.kryGridGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryGridGia.Location = new System.Drawing.Point(0, 0);
            this.kryGridGia.Name = "kryGridGia";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridGia.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.kryGridGia.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridGia.RowTemplate.Height = 50;
            this.kryGridGia.Size = new System.Drawing.Size(933, 530);
            this.kryGridGia.StateCommon.BackStyle =  ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.kryGridGia.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridGia.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.kryGridGia.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryGridGia.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 50;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Type";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Loại Giá";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.Width = 150;
            // 
            // Column2
            // 
            this.Column2.Checked = false;
            this.Column2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.Column2.DataPropertyName = "CreatedDate";
            this.Column2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Column2.HeaderText = "Ngày tạo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Price";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Giá";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Note";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Ghi chú";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.Width = 500;
            // 
            // ucDonGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryGridGia);
            this.Name = "ucDonGia";
            this.Size = new System.Drawing.Size(933, 530);
            ((System.ComponentModel.ISupportInitialize)(this.kryGridGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private  ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryGridGia;
        private  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column1;
        private  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column5;
        private  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn Column2;
        private  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column3;
        private  ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column4;
    }
}
