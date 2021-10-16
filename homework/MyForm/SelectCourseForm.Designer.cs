
namespace homework
{
    partial class SelectCourseForm
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
            this._courseGridView = new System.Windows.Forms.DataGridView();
            this._buttonSend = new System.Windows.Forms.Button();
            this._buttonShowSelectResult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._courseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // courseGridView
            // 
            this._courseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseGridView.Location = new System.Drawing.Point(12, 12);
            this._courseGridView.Name = "courseGridView";
            this._courseGridView.RowHeadersWidth = 51;
            this._courseGridView.RowTemplate.Height = 27;
            this._courseGridView.Size = new System.Drawing.Size(1047, 432);
            this._courseGridView.TabIndex = 0;
            // 
            // buttonSend
            // 
            this._buttonSend.AutoSize = true;
            this._buttonSend.Location = new System.Drawing.Point(660, 451);
            this._buttonSend.Name = "buttonSend";
            this._buttonSend.Size = new System.Drawing.Size(122, 56);
            this._buttonSend.TabIndex = 1;
            this._buttonSend.Text = "確認送出";
            this._buttonSend.UseVisualStyleBackColor = true;
            // 
            // buttonShowSelectResult
            // 
            this._buttonShowSelectResult.AutoSize = true;
            this._buttonShowSelectResult.Location = new System.Drawing.Point(855, 451);
            this._buttonShowSelectResult.Name = "buttonShowSelectResult";
            this._buttonShowSelectResult.Size = new System.Drawing.Size(120, 55);
            this._buttonShowSelectResult.TabIndex = 2;
            this._buttonShowSelectResult.Text = "顯示選課結果";
            this._buttonShowSelectResult.UseVisualStyleBackColor = true;
            // 
            // SelectCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 518);
            this.Controls.Add(this._buttonShowSelectResult);
            this.Controls.Add(this._buttonSend);
            this.Controls.Add(this._courseGridView);
            this.Name = "SelectCourseForm";
            this.Text = "SelectCourseForm";
            this.Load += new System.EventHandler(this.LoadSelectCourseForm);
            ((System.ComponentModel.ISupportInitialize)(this._courseGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _courseGridView;
        private System.Windows.Forms.Button _buttonSend;
        private System.Windows.Forms.Button _buttonShowSelectResult;
    }
}