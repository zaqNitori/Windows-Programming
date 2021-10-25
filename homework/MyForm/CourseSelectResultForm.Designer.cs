
namespace homework
{
    partial class CourseSelectResultForm
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
            this._courseSelectResultDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectResultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _courseSelectResultDataGridView
            // 
            this._courseSelectResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseSelectResultDataGridView.Location = new System.Drawing.Point(12, 12);
            this._courseSelectResultDataGridView.Name = "_courseSelectResultDataGridView";
            this._courseSelectResultDataGridView.RowHeadersWidth = 51;
            this._courseSelectResultDataGridView.RowTemplate.Height = 27;
            this._courseSelectResultDataGridView.Size = new System.Drawing.Size(810, 420);
            this._courseSelectResultDataGridView.TabIndex = 0;
            // 
            // CourseSelectResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 487);
            this.Controls.Add(this._courseSelectResultDataGridView);
            this.Name = "CourseSelectResultForm";
            this.Text = "CourseSelectResultForm";
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectResultDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _courseSelectResultDataGridView;
    }
}