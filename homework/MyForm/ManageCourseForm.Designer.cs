
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
            this._courseTabControl = new System.Windows.Forms.TabControl();
            this._tabPage1 = new System.Windows.Forms.TabPage();
            this._buttonConfirm = new System.Windows.Forms.Button();
            this._courseTimeDataGridView = new System.Windows.Forms.DataGridView();
            this._courseSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._sunday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._monday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._tuesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._wednesday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._thursday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._friday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._saturday = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._courseGroupBox = new System.Windows.Forms.GroupBox();
            this._courseRequiredOrElectiveComboBox = new System.Windows.Forms.ComboBox();
            this._courseHourComboBox = new System.Windows.Forms.ComboBox();
            this._courseDepartmentLabel = new System.Windows.Forms.Label();
            this._courseDepartmentComboBox = new System.Windows.Forms.ComboBox();
            this._courseHourLabel = new System.Windows.Forms.Label();
            this._courseNoteLabel = new System.Windows.Forms.Label();
            this._courseNoteTextBox = new System.Windows.Forms.TextBox();
            this._courseLanguageLabel = new System.Windows.Forms.Label();
            this._courseLanguageTextBox = new System.Windows.Forms.TextBox();
            this._courseTeachAssistantLabel = new System.Windows.Forms.Label();
            this._courseTeachAssistantTextBox = new System.Windows.Forms.TextBox();
            this._courseRequiredOrElectiveLabel = new System.Windows.Forms.Label();
            this._courseTeacherLabel = new System.Windows.Forms.Label();
            this._courseTeacherTextBox = new System.Windows.Forms.TextBox();
            this._courseCreditLabel = new System.Windows.Forms.Label();
            this._courseCreditTextBox = new System.Windows.Forms.TextBox();
            this._courseStageLabel = new System.Windows.Forms.Label();
            this._courseStageTextBox = new System.Windows.Forms.TextBox();
            this._courseNameTextBox = new System.Windows.Forms.TextBox();
            this._courseNameLabel = new System.Windows.Forms.Label();
            this._courseNumberLabel = new System.Windows.Forms.Label();
            this._courseNumberTextBox = new System.Windows.Forms.TextBox();
            this._courseStatusComboBox = new System.Windows.Forms.ComboBox();
            this._buttonAddCourse = new System.Windows.Forms.Button();
            this._courseListBox = new System.Windows.Forms.ListBox();
            this._tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this._courseTabControl.SuspendLayout();
            this._tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._courseTimeDataGridView)).BeginInit();
            this._courseGroupBox.SuspendLayout();
            this._tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _alertText
            // 
            this._alertText.AutoSize = true;
            this._alertText.Font = new System.Drawing.Font("新細明體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._alertText.Location = new System.Drawing.Point(113, 195);
            this._alertText.Name = "_alertText";
            this._alertText.Size = new System.Drawing.Size(762, 120);
            this._alertText.TabIndex = 0;
            this._alertText.Text = "Comming Soon";
            this._alertText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseTabControl
            // 
            this._courseTabControl.Controls.Add(this._tabPage1);
            this._courseTabControl.Controls.Add(this._tabPage2);
            this._courseTabControl.Location = new System.Drawing.Point(12, 12);
            this._courseTabControl.Name = "_courseTabControl";
            this._courseTabControl.SelectedIndex = 0;
            this._courseTabControl.Size = new System.Drawing.Size(1152, 574);
            this._courseTabControl.TabIndex = 1;
            // 
            // _tabPage1
            // 
            this._tabPage1.Controls.Add(this.button1);
            this._tabPage1.Controls.Add(this._buttonConfirm);
            this._tabPage1.Controls.Add(this._courseTimeDataGridView);
            this._tabPage1.Controls.Add(this._courseGroupBox);
            this._tabPage1.Controls.Add(this._buttonAddCourse);
            this._tabPage1.Controls.Add(this._courseListBox);
            this._tabPage1.Location = new System.Drawing.Point(4, 25);
            this._tabPage1.Name = "_tabPage1";
            this._tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage1.Size = new System.Drawing.Size(1144, 545);
            this._tabPage1.TabIndex = 0;
            this._tabPage1.Text = "tabPage1";
            this._tabPage1.UseVisualStyleBackColor = true;
            // 
            // _buttonConfirm
            // 
            this._buttonConfirm.Location = new System.Drawing.Point(897, 475);
            this._buttonConfirm.Name = "_buttonConfirm";
            this._buttonConfirm.Size = new System.Drawing.Size(241, 61);
            this._buttonConfirm.TabIndex = 4;
            this._buttonConfirm.Text = "儲存";
            this._buttonConfirm.UseVisualStyleBackColor = true;
            // 
            // _courseTimeDataGridView
            // 
            this._courseTimeDataGridView.AllowUserToAddRows = false;
            this._courseTimeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._courseTimeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseTimeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._courseSection,
            this._sunday,
            this._monday,
            this._tuesday,
            this._wednesday,
            this._thursday,
            this._friday,
            this._saturday});
            this._courseTimeDataGridView.Location = new System.Drawing.Point(265, 190);
            this._courseTimeDataGridView.Name = "_courseTimeDataGridView";
            this._courseTimeDataGridView.RowHeadersWidth = 51;
            this._courseTimeDataGridView.RowTemplate.Height = 27;
            this._courseTimeDataGridView.Size = new System.Drawing.Size(867, 273);
            this._courseTimeDataGridView.TabIndex = 3;
            // 
            // _courseSection
            // 
            this._courseSection.HeaderText = "節數";
            this._courseSection.MinimumWidth = 6;
            this._courseSection.Name = "_courseSection";
            this._courseSection.ReadOnly = true;
            // 
            // _sunday
            // 
            this._sunday.FalseValue = "false";
            this._sunday.HeaderText = "日";
            this._sunday.MinimumWidth = 6;
            this._sunday.Name = "_sunday";
            this._sunday.TrueValue = "true";
            // 
            // _monday
            // 
            this._monday.FalseValue = "false";
            this._monday.HeaderText = "一";
            this._monday.MinimumWidth = 6;
            this._monday.Name = "_monday";
            this._monday.TrueValue = "true";
            // 
            // _tuesday
            // 
            this._tuesday.FalseValue = "false";
            this._tuesday.HeaderText = "二";
            this._tuesday.MinimumWidth = 6;
            this._tuesday.Name = "_tuesday";
            this._tuesday.TrueValue = "true";
            // 
            // _wednesday
            // 
            this._wednesday.FalseValue = "false";
            this._wednesday.HeaderText = "三";
            this._wednesday.MinimumWidth = 6;
            this._wednesday.Name = "_wednesday";
            this._wednesday.TrueValue = "true";
            // 
            // _thursday
            // 
            this._thursday.FalseValue = "false";
            this._thursday.HeaderText = "四";
            this._thursday.MinimumWidth = 6;
            this._thursday.Name = "_thursday";
            this._thursday.TrueValue = "true";
            // 
            // _friday
            // 
            this._friday.FalseValue = "false";
            this._friday.HeaderText = "五";
            this._friday.MinimumWidth = 6;
            this._friday.Name = "_friday";
            this._friday.TrueValue = "true";
            // 
            // _saturday
            // 
            this._saturday.FalseValue = "false";
            this._saturday.HeaderText = "六";
            this._saturday.MinimumWidth = 6;
            this._saturday.Name = "_saturday";
            this._saturday.TrueValue = "true";
            // 
            // _courseGroupBox
            // 
            this._courseGroupBox.Controls.Add(this._courseRequiredOrElectiveComboBox);
            this._courseGroupBox.Controls.Add(this._courseHourComboBox);
            this._courseGroupBox.Controls.Add(this._courseDepartmentLabel);
            this._courseGroupBox.Controls.Add(this._courseDepartmentComboBox);
            this._courseGroupBox.Controls.Add(this._courseHourLabel);
            this._courseGroupBox.Controls.Add(this._courseNoteLabel);
            this._courseGroupBox.Controls.Add(this._courseNoteTextBox);
            this._courseGroupBox.Controls.Add(this._courseLanguageLabel);
            this._courseGroupBox.Controls.Add(this._courseLanguageTextBox);
            this._courseGroupBox.Controls.Add(this._courseTeachAssistantLabel);
            this._courseGroupBox.Controls.Add(this._courseTeachAssistantTextBox);
            this._courseGroupBox.Controls.Add(this._courseRequiredOrElectiveLabel);
            this._courseGroupBox.Controls.Add(this._courseTeacherLabel);
            this._courseGroupBox.Controls.Add(this._courseTeacherTextBox);
            this._courseGroupBox.Controls.Add(this._courseCreditLabel);
            this._courseGroupBox.Controls.Add(this._courseCreditTextBox);
            this._courseGroupBox.Controls.Add(this._courseStageLabel);
            this._courseGroupBox.Controls.Add(this._courseStageTextBox);
            this._courseGroupBox.Controls.Add(this._courseNameTextBox);
            this._courseGroupBox.Controls.Add(this._courseNameLabel);
            this._courseGroupBox.Controls.Add(this._courseNumberLabel);
            this._courseGroupBox.Controls.Add(this._courseNumberTextBox);
            this._courseGroupBox.Controls.Add(this._courseStatusComboBox);
            this._courseGroupBox.Location = new System.Drawing.Point(253, 6);
            this._courseGroupBox.Name = "_courseGroupBox";
            this._courseGroupBox.Size = new System.Drawing.Size(885, 463);
            this._courseGroupBox.TabIndex = 2;
            this._courseGroupBox.TabStop = false;
            this._courseGroupBox.Text = "groupBox1";
            // 
            // _courseRequiredOrElectiveComboBox
            // 
            this._courseRequiredOrElectiveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseRequiredOrElectiveComboBox.FormattingEnabled = true;
            this._courseRequiredOrElectiveComboBox.Items.AddRange(new object[] {
            "○",
            "△",
            "☆",
            "●",
            "▲",
            "★"});
            this._courseRequiredOrElectiveComboBox.Location = new System.Drawing.Point(691, 55);
            this._courseRequiredOrElectiveComboBox.Name = "_courseRequiredOrElectiveComboBox";
            this._courseRequiredOrElectiveComboBox.Size = new System.Drawing.Size(122, 23);
            this._courseRequiredOrElectiveComboBox.TabIndex = 24;
            // 
            // _courseHourComboBox
            // 
            this._courseHourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseHourComboBox.FormattingEnabled = true;
            this._courseHourComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this._courseHourComboBox.Location = new System.Drawing.Point(69, 148);
            this._courseHourComboBox.Name = "_courseHourComboBox";
            this._courseHourComboBox.Size = new System.Drawing.Size(127, 23);
            this._courseHourComboBox.TabIndex = 23;
            // 
            // _courseDepartmentLabel
            // 
            this._courseDepartmentLabel.AutoSize = true;
            this._courseDepartmentLabel.Location = new System.Drawing.Point(251, 154);
            this._courseDepartmentLabel.Name = "_courseDepartmentLabel";
            this._courseDepartmentLabel.Size = new System.Drawing.Size(54, 15);
            this._courseDepartmentLabel.TabIndex = 22;
            this._courseDepartmentLabel.Text = "班級(*)";
            // 
            // _courseDepartmentComboBox
            // 
            this._courseDepartmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseDepartmentComboBox.FormattingEnabled = true;
            this._courseDepartmentComboBox.Location = new System.Drawing.Point(311, 148);
            this._courseDepartmentComboBox.Name = "_courseDepartmentComboBox";
            this._courseDepartmentComboBox.Size = new System.Drawing.Size(121, 23);
            this._courseDepartmentComboBox.TabIndex = 21;
            // 
            // _courseHourLabel
            // 
            this._courseHourLabel.AutoSize = true;
            this._courseHourLabel.Location = new System.Drawing.Point(9, 154);
            this._courseHourLabel.Name = "_courseHourLabel";
            this._courseHourLabel.Size = new System.Drawing.Size(54, 15);
            this._courseHourLabel.TabIndex = 20;
            this._courseHourLabel.Text = "時數(*)";
            // 
            // _courseNoteLabel
            // 
            this._courseNoteLabel.AutoSize = true;
            this._courseNoteLabel.Location = new System.Drawing.Point(9, 122);
            this._courseNoteLabel.Name = "_courseNoteLabel";
            this._courseNoteLabel.Size = new System.Drawing.Size(37, 15);
            this._courseNoteLabel.TabIndex = 18;
            this._courseNoteLabel.Text = "備註";
            // 
            // _courseNoteTextBox
            // 
            this._courseNoteTextBox.Location = new System.Drawing.Point(69, 115);
            this._courseNoteTextBox.Name = "_courseNoteTextBox";
            this._courseNoteTextBox.Size = new System.Drawing.Size(744, 25);
            this._courseNoteTextBox.TabIndex = 17;
            // 
            // _courseLanguageLabel
            // 
            this._courseLanguageLabel.AutoSize = true;
            this._courseLanguageLabel.Location = new System.Drawing.Point(421, 91);
            this._courseLanguageLabel.Name = "_courseLanguageLabel";
            this._courseLanguageLabel.Size = new System.Drawing.Size(67, 15);
            this._courseLanguageLabel.TabIndex = 16;
            this._courseLanguageLabel.Text = "授課語言";
            // 
            // _courseLanguageTextBox
            // 
            this._courseLanguageTextBox.Location = new System.Drawing.Point(494, 84);
            this._courseLanguageTextBox.Name = "_courseLanguageTextBox";
            this._courseLanguageTextBox.Size = new System.Drawing.Size(319, 25);
            this._courseLanguageTextBox.TabIndex = 15;
            // 
            // _courseTeachAssistantLabel
            // 
            this._courseTeachAssistantLabel.AutoSize = true;
            this._courseTeachAssistantLabel.Location = new System.Drawing.Point(9, 91);
            this._courseTeachAssistantLabel.Name = "_courseTeachAssistantLabel";
            this._courseTeachAssistantLabel.Size = new System.Drawing.Size(67, 15);
            this._courseTeachAssistantLabel.TabIndex = 14;
            this._courseTeachAssistantLabel.Text = "教學助理";
            // 
            // _courseTeachAssistantTextBox
            // 
            this._courseTeachAssistantTextBox.Location = new System.Drawing.Point(82, 84);
            this._courseTeachAssistantTextBox.Name = "_courseTeachAssistantTextBox";
            this._courseTeachAssistantTextBox.Size = new System.Drawing.Size(311, 25);
            this._courseTeachAssistantTextBox.TabIndex = 13;
            // 
            // _courseRequiredOrElectiveLabel
            // 
            this._courseRequiredOrElectiveLabel.AutoSize = true;
            this._courseRequiredOrElectiveLabel.Location = new System.Drawing.Point(646, 60);
            this._courseRequiredOrElectiveLabel.Name = "_courseRequiredOrElectiveLabel";
            this._courseRequiredOrElectiveLabel.Size = new System.Drawing.Size(39, 15);
            this._courseRequiredOrElectiveLabel.TabIndex = 12;
            this._courseRequiredOrElectiveLabel.Text = "修(*)";
            // 
            // _courseTeacherLabel
            // 
            this._courseTeacherLabel.AutoSize = true;
            this._courseTeacherLabel.Location = new System.Drawing.Point(434, 60);
            this._courseTeacherLabel.Name = "_courseTeacherLabel";
            this._courseTeacherLabel.Size = new System.Drawing.Size(54, 15);
            this._courseTeacherLabel.TabIndex = 10;
            this._courseTeacherLabel.Text = "教師(*)";
            // 
            // _courseTeacherTextBox
            // 
            this._courseTeacherTextBox.Location = new System.Drawing.Point(494, 53);
            this._courseTeacherTextBox.Name = "_courseTeacherTextBox";
            this._courseTeacherTextBox.Size = new System.Drawing.Size(122, 25);
            this._courseTeacherTextBox.TabIndex = 9;
            // 
            // _courseCreditLabel
            // 
            this._courseCreditLabel.AutoSize = true;
            this._courseCreditLabel.Location = new System.Drawing.Point(211, 60);
            this._courseCreditLabel.Name = "_courseCreditLabel";
            this._courseCreditLabel.Size = new System.Drawing.Size(54, 15);
            this._courseCreditLabel.TabIndex = 8;
            this._courseCreditLabel.Text = "學分(*)";
            // 
            // _courseCreditTextBox
            // 
            this._courseCreditTextBox.Location = new System.Drawing.Point(271, 53);
            this._courseCreditTextBox.Name = "_courseCreditTextBox";
            this._courseCreditTextBox.Size = new System.Drawing.Size(122, 25);
            this._courseCreditTextBox.TabIndex = 7;
            // 
            // _courseStageLabel
            // 
            this._courseStageLabel.AutoSize = true;
            this._courseStageLabel.Location = new System.Drawing.Point(9, 60);
            this._courseStageLabel.Name = "_courseStageLabel";
            this._courseStageLabel.Size = new System.Drawing.Size(54, 15);
            this._courseStageLabel.TabIndex = 6;
            this._courseStageLabel.Text = "階段(*)";
            // 
            // _courseStageTextBox
            // 
            this._courseStageTextBox.Location = new System.Drawing.Point(69, 53);
            this._courseStageTextBox.Name = "_courseStageTextBox";
            this._courseStageTextBox.Size = new System.Drawing.Size(122, 25);
            this._courseStageTextBox.TabIndex = 5;
            // 
            // _courseNameTextBox
            // 
            this._courseNameTextBox.Location = new System.Drawing.Point(455, 22);
            this._courseNameTextBox.Name = "_courseNameTextBox";
            this._courseNameTextBox.Size = new System.Drawing.Size(236, 25);
            this._courseNameTextBox.TabIndex = 4;
            // 
            // _courseNameLabel
            // 
            this._courseNameLabel.AutoSize = true;
            this._courseNameLabel.Location = new System.Drawing.Point(365, 29);
            this._courseNameLabel.Name = "_courseNameLabel";
            this._courseNameLabel.Size = new System.Drawing.Size(84, 15);
            this._courseNameLabel.TabIndex = 3;
            this._courseNameLabel.Text = "課程名稱(*)";
            // 
            // _courseNumberLabel
            // 
            this._courseNumberLabel.AutoSize = true;
            this._courseNumberLabel.Location = new System.Drawing.Point(137, 29);
            this._courseNumberLabel.Name = "_courseNumberLabel";
            this._courseNumberLabel.Size = new System.Drawing.Size(54, 15);
            this._courseNumberLabel.TabIndex = 2;
            this._courseNumberLabel.Text = "課號(*)";
            // 
            // _courseNumberTextBox
            // 
            this._courseNumberTextBox.Location = new System.Drawing.Point(197, 22);
            this._courseNumberTextBox.Name = "_courseNumberTextBox";
            this._courseNumberTextBox.Size = new System.Drawing.Size(122, 25);
            this._courseNumberTextBox.TabIndex = 1;
            // 
            // _courseStatusComboBox
            // 
            this._courseStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseStatusComboBox.FormattingEnabled = true;
            this._courseStatusComboBox.Items.AddRange(new object[] {
            "開課",
            "停開"});
            this._courseStatusComboBox.Location = new System.Drawing.Point(6, 24);
            this._courseStatusComboBox.Name = "_courseStatusComboBox";
            this._courseStatusComboBox.Size = new System.Drawing.Size(121, 23);
            this._courseStatusComboBox.TabIndex = 0;
            // 
            // _buttonAddCourse
            // 
            this._buttonAddCourse.Location = new System.Drawing.Point(6, 475);
            this._buttonAddCourse.Name = "_buttonAddCourse";
            this._buttonAddCourse.Size = new System.Drawing.Size(241, 61);
            this._buttonAddCourse.TabIndex = 1;
            this._buttonAddCourse.Text = "新增課程";
            this._buttonAddCourse.UseVisualStyleBackColor = true;
            // 
            // _courseListBox
            // 
            this._courseListBox.FormattingEnabled = true;
            this._courseListBox.ItemHeight = 15;
            this._courseListBox.Location = new System.Drawing.Point(6, 0);
            this._courseListBox.Name = "_courseListBox";
            this._courseListBox.Size = new System.Drawing.Size(241, 469);
            this._courseListBox.TabIndex = 0;
            // 
            // _tabPage2
            // 
            this._tabPage2.Controls.Add(this._alertText);
            this._tabPage2.Location = new System.Drawing.Point(4, 25);
            this._tabPage2.Name = "_tabPage2";
            this._tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this._tabPage2.Size = new System.Drawing.Size(1144, 545);
            this._tabPage2.TabIndex = 1;
            this._tabPage2.Text = "tabPage2";
            this._tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 61);
            this.button1.TabIndex = 5;
            this.button1.Text = "匯入資工系全部課程";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ManageCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 594);
            this.Controls.Add(this._courseTabControl);
            this.DoubleBuffered = true;
            this.Name = "ManageCourseForm";
            this.Text = "ManageCourseForm";
            this._courseTabControl.ResumeLayout(false);
            this._tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._courseTimeDataGridView)).EndInit();
            this._courseGroupBox.ResumeLayout(false);
            this._courseGroupBox.PerformLayout();
            this._tabPage2.ResumeLayout(false);
            this._tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _alertText;
        private System.Windows.Forms.TabControl _courseTabControl;
        private System.Windows.Forms.TabPage _tabPage1;
        private System.Windows.Forms.GroupBox _courseGroupBox;
        private System.Windows.Forms.Label _courseNumberLabel;
        private System.Windows.Forms.TextBox _courseNumberTextBox;
        private System.Windows.Forms.ComboBox _courseStatusComboBox;
        private System.Windows.Forms.Button _buttonAddCourse;
        private System.Windows.Forms.ListBox _courseListBox;
        private System.Windows.Forms.TabPage _tabPage2;
        private System.Windows.Forms.Label _courseCreditLabel;
        private System.Windows.Forms.TextBox _courseCreditTextBox;
        private System.Windows.Forms.Label _courseStageLabel;
        private System.Windows.Forms.TextBox _courseStageTextBox;
        private System.Windows.Forms.TextBox _courseNameTextBox;
        private System.Windows.Forms.Label _courseNameLabel;
        private System.Windows.Forms.Label _courseTeacherLabel;
        private System.Windows.Forms.TextBox _courseTeacherTextBox;
        private System.Windows.Forms.Label _courseRequiredOrElectiveLabel;
        private System.Windows.Forms.Label _courseTeachAssistantLabel;
        private System.Windows.Forms.TextBox _courseTeachAssistantTextBox;
        private System.Windows.Forms.Label _courseLanguageLabel;
        private System.Windows.Forms.TextBox _courseLanguageTextBox;
        private System.Windows.Forms.Label _courseNoteLabel;
        private System.Windows.Forms.TextBox _courseNoteTextBox;
        private System.Windows.Forms.Label _courseHourLabel;
        private System.Windows.Forms.Label _courseDepartmentLabel;
        private System.Windows.Forms.ComboBox _courseDepartmentComboBox;
        private System.Windows.Forms.Button _buttonConfirm;
        private System.Windows.Forms.DataGridView _courseTimeDataGridView;
        private System.Windows.Forms.ComboBox _courseHourComboBox;
        private System.Windows.Forms.ComboBox _courseRequiredOrElectiveComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseSection;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _sunday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _monday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _tuesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _wednesday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _thursday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _friday;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _saturday;
        private System.Windows.Forms.Button button1;
    }
}