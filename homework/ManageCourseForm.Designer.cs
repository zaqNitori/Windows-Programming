
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
            this._CommingSoonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _CommingSoonLabel
            // 
            this._CommingSoonLabel.AutoSize = true;
            this._CommingSoonLabel.Font = new System.Drawing.Font("新細明體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._CommingSoonLabel.Location = new System.Drawing.Point(12, 157);
            this._CommingSoonLabel.Name = "_CommingSoonLabel";
            this._CommingSoonLabel.Size = new System.Drawing.Size(762, 120);
            this._CommingSoonLabel.TabIndex = 0;
            this._CommingSoonLabel.Text = "Comming Soon";
            this._CommingSoonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManageCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._CommingSoonLabel);
            this.Name = "ManageCourseForm";
            this.Text = "ManageCourseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _CommingSoonLabel;
    }
}