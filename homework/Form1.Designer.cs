
namespace homework
{
    partial class MyClassForm
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCheckSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1056, 416);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = true;
            this.btnSend.Location = new System.Drawing.Point(812, 434);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(77, 59);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "確認送出";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnCheckSelect
            // 
            this.btnCheckSelect.AutoSize = true;
            this.btnCheckSelect.Location = new System.Drawing.Point(953, 434);
            this.btnCheckSelect.Name = "btnCheckSelect";
            this.btnCheckSelect.Size = new System.Drawing.Size(115, 59);
            this.btnCheckSelect.TabIndex = 2;
            this.btnCheckSelect.Text = "查看選課結果";
            this.btnCheckSelect.UseVisualStyleBackColor = true;
            this.btnCheckSelect.Click += new System.EventHandler(this.btnCheckSelect_Click);
            // 
            // MyClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 505);
            this.Controls.Add(this.btnCheckSelect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MyClassForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MyClassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCheckSelect;
    }
}

