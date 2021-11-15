
namespace homework
{
    partial class ImportCourseProgressForm
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
            this._loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this._loadingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _loadingProgressBar
            // 
            this._loadingProgressBar.Location = new System.Drawing.Point(12, 43);
            this._loadingProgressBar.Name = "_loadingProgressBar";
            this._loadingProgressBar.Size = new System.Drawing.Size(328, 58);
            this._loadingProgressBar.TabIndex = 0;
            // 
            // _loadingLabel
            // 
            this._loadingLabel.AutoSize = true;
            this._loadingLabel.Location = new System.Drawing.Point(12, 25);
            this._loadingLabel.Name = "_loadingLabel";
            this._loadingLabel.Size = new System.Drawing.Size(41, 15);
            this._loadingLabel.TabIndex = 1;
            this._loadingLabel.Text = "label1";
            // 
            // ImportCourseProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 118);
            this.Controls.Add(this._loadingLabel);
            this.Controls.Add(this._loadingProgressBar);
            this.Name = "ImportCourseProgressForm";
            this.Text = "ImportCourseProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar _loadingProgressBar;
        private System.Windows.Forms.Label _loadingLabel;
    }
}