
namespace homework
{
    partial class StartUpForm
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
            this._buttonCourseSelecting = new System.Windows.Forms.Button();
            this._buttonCourseManagement = new System.Windows.Forms.Button();
            this._buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonCourseSelecting
            // 
            this._buttonCourseSelecting.Font = new System.Drawing.Font("新細明體", 30F);
            this._buttonCourseSelecting.Location = new System.Drawing.Point(12, 12);
            this._buttonCourseSelecting.Name = "_buttonCourseSelecting";
            this._buttonCourseSelecting.Size = new System.Drawing.Size(776, 128);
            this._buttonCourseSelecting.TabIndex = 0;
            this._buttonCourseSelecting.Text = "Course Selecting System";
            this._buttonCourseSelecting.UseVisualStyleBackColor = true;
            // 
            // _buttonCourseManagement
            // 
            this._buttonCourseManagement.Font = new System.Drawing.Font("新細明體", 30F);
            this._buttonCourseManagement.Location = new System.Drawing.Point(12, 179);
            this._buttonCourseManagement.Name = "_buttonCourseManagement";
            this._buttonCourseManagement.Size = new System.Drawing.Size(776, 128);
            this._buttonCourseManagement.TabIndex = 1;
            this._buttonCourseManagement.Text = "Course Management System";
            this._buttonCourseManagement.UseVisualStyleBackColor = true;
            // 
            // _buttonExit
            // 
            this._buttonExit.Font = new System.Drawing.Font("新細明體", 30F);
            this._buttonExit.Location = new System.Drawing.Point(567, 344);
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(221, 77);
            this._buttonExit.TabIndex = 2;
            this._buttonExit.Text = "Exit";
            this._buttonExit.UseVisualStyleBackColor = true;
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._buttonExit);
            this.Controls.Add(this._buttonCourseManagement);
            this.Controls.Add(this._buttonCourseSelecting);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonCourseSelecting;
        private System.Windows.Forms.Button _buttonCourseManagement;
        private System.Windows.Forms.Button _buttonExit;
    }
}