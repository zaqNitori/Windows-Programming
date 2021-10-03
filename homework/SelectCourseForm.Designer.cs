
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
            this.courseGridView = new System.Windows.Forms.DataGridView();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonShowSelectResult = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.courseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // courseGridView
            // 
            this.courseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseGridView.Location = new System.Drawing.Point(12, 12);
            this.courseGridView.Name = "courseGridView";
            this.courseGridView.RowHeadersWidth = 51;
            this.courseGridView.RowTemplate.Height = 27;
            this.courseGridView.Size = new System.Drawing.Size(1047, 432);
            this.courseGridView.TabIndex = 0;
            // 
            // buttonSend
            // 
            this.buttonSend.AutoSize = true;
            this.buttonSend.Location = new System.Drawing.Point(660, 451);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(122, 56);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "確認送出";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // buttonShowSelectResult
            // 
            this.buttonShowSelectResult.AutoSize = true;
            this.buttonShowSelectResult.Location = new System.Drawing.Point(855, 451);
            this.buttonShowSelectResult.Name = "buttonShowSelectResult";
            this.buttonShowSelectResult.Size = new System.Drawing.Size(120, 55);
            this.buttonShowSelectResult.TabIndex = 2;
            this.buttonShowSelectResult.Text = "顯示選課結果";
            this.buttonShowSelectResult.UseVisualStyleBackColor = true;
            // 
            // SelectCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 518);
            this.Controls.Add(this.buttonShowSelectResult);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.courseGridView);
            this.Name = "SelectCourseForm";
            this.Text = "SelectCourseForm";
            this.Load += new System.EventHandler(this.LoadSelectCourseForm);
            ((System.ComponentModel.ISupportInitialize)(this.courseGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView courseGridView;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonShowSelectResult;
    }
}