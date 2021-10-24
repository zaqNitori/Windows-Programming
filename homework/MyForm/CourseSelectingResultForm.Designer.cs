
namespace homework.MyForm
{
    partial class CourseSelectingResultForm
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
            this._courseSelectResultDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectResultDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // _courseSelectResultDataGrid
            // 
            this._courseSelectResultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseSelectResultDataGrid.Location = new System.Drawing.Point(12, 12);
            this._courseSelectResultDataGrid.Name = "_courseSelectResultDataGrid";
            this._courseSelectResultDataGrid.RowHeadersWidth = 51;
            this._courseSelectResultDataGrid.RowTemplate.Height = 27;
            this._courseSelectResultDataGrid.Size = new System.Drawing.Size(776, 400);
            this._courseSelectResultDataGrid.TabIndex = 0;
            // 
            // CourseSelectingResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._courseSelectResultDataGrid);
            this.Name = "CourseSelectingResultForm";
            this.Text = "CourseSelectingResultForm";
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectResultDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _courseSelectResultDataGrid;
    }
}