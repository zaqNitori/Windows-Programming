
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
            this._buttonSend = new System.Windows.Forms.Button();
            this._buttonShowSelectResult = new System.Windows.Forms.Button();
            this._tabPage2 = new System.Windows.Forms.TabPage();
            this._courseDataGridViewComponent2 = new homework.MyController.CourseDataGridViewComponent();
            this._tabPage1 = new System.Windows.Forms.TabPage();
            this._courseDataGridViewComponent1 = new homework.MyController.CourseDataGridViewComponent();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._tabPage2.SuspendLayout();
            this._tabPage1.SuspendLayout();
            this._tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonSend
            // 
            this._buttonSend.AutoSize = true;
            this._buttonSend.Location = new System.Drawing.Point(660, 451);
            this._buttonSend.Name = "_buttonSend";
            this._buttonSend.Size = new System.Drawing.Size(122, 56);
            this._buttonSend.TabIndex = 1;
            this._buttonSend.Text = "確認送出";
            this._buttonSend.UseVisualStyleBackColor = true;
            // 
            // _buttonShowSelectResult
            // 
            this._buttonShowSelectResult.AutoSize = true;
            this._buttonShowSelectResult.Location = new System.Drawing.Point(855, 451);
            this._buttonShowSelectResult.Name = "_buttonShowSelectResult";
            this._buttonShowSelectResult.Size = new System.Drawing.Size(120, 55);
            this._buttonShowSelectResult.TabIndex = 2;
            this._buttonShowSelectResult.Text = "顯示選課結果";
            this._buttonShowSelectResult.UseVisualStyleBackColor = true;
            // 
            // _tabPage2
            // 
            this._tabPage2.Controls.Add(this._courseDataGridViewComponent2);
            this._tabPage2.Location = new System.Drawing.Point(4, 25);
            this._tabPage2.Name = "_tabPage2";
            this._tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage2.Size = new System.Drawing.Size(1039, 388);
            this._tabPage2.TabIndex = 1;
            this._tabPage2.Text = "tabPage2";
            this._tabPage2.UseVisualStyleBackColor = true;
            // 
            // _courseDataGridViewComponent2
            // 
            this._courseDataGridViewComponent2.Location = new System.Drawing.Point(6, 6);
            this._courseDataGridViewComponent2.Name = "_courseDataGridViewComponent2";
            this._courseDataGridViewComponent2.Size = new System.Drawing.Size(1027, 376);
            this._courseDataGridViewComponent2.TabIndex = 0;
            // 
            // _tabPage1
            // 
            this._tabPage1.Controls.Add(this._courseDataGridViewComponent1);
            this._tabPage1.Location = new System.Drawing.Point(4, 25);
            this._tabPage1.Name = "_tabPage1";
            this._tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage1.Size = new System.Drawing.Size(1039, 388);
            this._tabPage1.TabIndex = 0;
            this._tabPage1.Text = "tabPage1";
            this._tabPage1.UseVisualStyleBackColor = true;
            // 
            // _courseDataGridViewComponent1
            // 
            this._courseDataGridViewComponent1.Location = new System.Drawing.Point(6, 6);
            this._courseDataGridViewComponent1.Name = "_courseDataGridViewComponent1";
            this._courseDataGridViewComponent1.Size = new System.Drawing.Size(1027, 376);
            this._courseDataGridViewComponent1.TabIndex = 1;
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabPage1);
            this._tabControl.Controls.Add(this._tabPage2);
            this._tabControl.Location = new System.Drawing.Point(12, 12);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1047, 417);
            this._tabControl.TabIndex = 3;
            // 
            // SelectCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 518);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._buttonShowSelectResult);
            this.Controls.Add(this._buttonSend);
            this.Name = "SelectCourseForm";
            this.Text = "SelectCourseForm";
            this._tabPage2.ResumeLayout(false);
            this._tabPage1.ResumeLayout(false);
            this._tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _buttonSend;
        private System.Windows.Forms.Button _buttonShowSelectResult;
        private System.Windows.Forms.TabPage _tabPage2;
        private MyController.CourseDataGridViewComponent _courseDataGridViewComponent2;
        private System.Windows.Forms.TabPage _tabPage1;
        private MyController.CourseDataGridViewComponent _courseDataGridViewComponent1;
        private System.Windows.Forms.TabControl _tabControl;
    }
}