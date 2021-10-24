
namespace homework.MyController
{
    partial class CourseDataGridViewComponent
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._courseDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._courseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _courseDataGridView
            // 
            this._courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseDataGridView.Location = new System.Drawing.Point(3, 3);
            this._courseDataGridView.Name = "_courseDataGridView";
            this._courseDataGridView.RowHeadersWidth = 51;
            this._courseDataGridView.RowTemplate.Height = 27;
            this._courseDataGridView.Size = new System.Drawing.Size(994, 364);
            this._courseDataGridView.TabIndex = 0;
            // 
            // CourseDataGridViewComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._courseDataGridView);
            this.Name = "CourseDataGridViewComponent";
            this.Size = new System.Drawing.Size(1000, 400);
            ((System.ComponentModel.ISupportInitialize)(this._courseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _courseDataGridView;
    }
}
