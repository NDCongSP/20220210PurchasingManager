
namespace QuanLyThuMua
{
    partial class ucThuMua
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column3 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column4 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column5 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.Size = new System.Drawing.Size(1060, 660);
            this.kryptonDataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 100;
            // 
            // Column2
            // 
            this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 100;
            // 
            // Column3
            // 
            this.Column3.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 100;
            // 
            // Column4
            // 
            this.Column4.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 100;
            // 
            // Column5
            // 
            this.Column5.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 100;
            // 
            // ucThuMua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.kryptonDataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucThuMua";
            this.Size = new System.Drawing.Size(1060, 660);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column5;
    }
}
