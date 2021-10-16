
namespace homework
{
    partial class ManageCourseForm
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
            this._alertText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _alertText
            // 
            this._alertText.AutoSize = true;
            this._alertText.Font = new System.Drawing.Font("新細明體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._alertText.Location = new System.Drawing.Point(12, 157);
            this._alertText.Name = "_alertText";
            this._alertText.Size = new System.Drawing.Size(762, 120);
            this._alertText.TabIndex = 0;
            this._alertText.Text = "Comming Soon";
            this._alertText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManageCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._alertText);
            this.Name = "ManageCourseForm";
            this.Text = "ManageCourseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _alertText;
    }
}