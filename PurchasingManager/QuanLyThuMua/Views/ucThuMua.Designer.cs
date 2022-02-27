
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
            this.gvPurchaseList = new Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPurchaseList
            // 
            this.gvPurchaseList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPurchaseList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvPurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPurchaseList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gvPurchaseList.Location = new System.Drawing.Point(8, 8);
            this.gvPurchaseList.MultiSelect = false;
            this.gvPurchaseList.Name = "gvPurchaseList";
            this.gvPurchaseList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gvPurchaseList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPurchaseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPurchaseList.Size = new System.Drawing.Size(1060, 660);
            this.gvPurchaseList.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.gvPurchaseList.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvPurchaseList.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvPurchaseList.TabIndex = 2;
            // 
            // ucThuMua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gvPurchaseList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucThuMua";
            this.Size = new System.Drawing.Size(1060, 660);
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchaseList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView gvPurchaseList;
    }
}
