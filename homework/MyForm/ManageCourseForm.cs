using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework.PresentationModel;
using homework.ViewModel;

namespace homework
{
    public partial class ManageCourseForm : Form
    {
        private CourseManagementPresentationModel _courseManagementPresentationModel;
        private const string BINDING_READ_ONLY_STATUS = "ReadOnly";
        private const string BINDING_ENABLED_STATUS = "Enabled";
        private const string BINDING_TEXT = "Text";
        private const string SOURCE_COMBO_BOX_ENABLED = "IsCourseComboBoxEnabled";
        private const string SOURCE_READ_ONLY_STATUS = "IsCourseEditReadOnly";
        private const string SOURCE_GROUP_BOX_TITLE = "GroupBoxTitle";
        private const string SOURCE_BUTTON_CONFIRM_ENABLED = "IsButtonConfirmEnabled";
        private const string SOURCE_BUTTON_ADD_ENABLED = "IsButtonConfirmEnabled";
        const string COLUMN_NAME = "courseHour";
        const string COLUMN_TITLE = "節數";

        public ManageCourseForm(CourseManagementPresentationModel courseManagementPresentationModel)
        {
            _courseManagementPresentationModel = courseManagementPresentationModel;
            InitializeComponent();
            InitializeTabControl();
            InitializeButton();
            InitializeListBox();
            SetGroupBoxControlsStatus();
            BindObjectWithData();
        }

        /// <summary>
        /// 初始化TabControl
        /// </summary>
        private void InitializeTabControl()
        {
            _tabPage1.Text = CourseManageProperty.COURSE_MANAGE_TAB_PAGE_TITLE;
            _tabPage2.Text = CourseManageProperty.CLASS_MANAGE_TAB_PAGE_TITLE;
        }

        /// <summary>
        /// 初始化Button
        /// </summary>
        private void InitializeButton()
        {
            _buttonAddCourse.DataBindings.Add(BINDING_ENABLED_STATUS, _courseManagementPresentationModel, SOURCE_BUTTON_ADD_ENABLED);
            _buttonConfirm.DataBindings.Add(BINDING_ENABLED_STATUS, _courseManagementPresentationModel, SOURCE_BUTTON_CONFIRM_ENABLED);
        }

        /// <summary>
        /// 初始化TabControl
        /// </summary>
        private void InitializeListBox()
        {
            _courseListBox.DataSource = _courseManagementPresentationModel.GetCurriculumAsItem();
            _courseListBox.SelectedIndex = -1;
            _courseListBox.SelectedIndexChanged += ListenCourseListBoxSelectedIndexChanged;
        }

        /// <summary>
        /// 設定groupBox 內的元件的狀態
        /// </summary>
        private void SetGroupBoxControlsStatus()
        {
            InitializeDataGridView();
            _courseGroupBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, SOURCE_GROUP_BOX_TITLE);

            foreach (ComboBox c in _courseGroupBox.Controls.OfType<ComboBox>())
            {
                c.DataBindings.Add(BINDING_ENABLED_STATUS, _courseManagementPresentationModel, SOURCE_COMBO_BOX_ENABLED);
            }

            foreach (TextBoxBase c in _courseGroupBox.Controls.OfType<TextBoxBase>())
            {
                c.DataBindings.Add(BINDING_READ_ONLY_STATUS, _courseManagementPresentationModel, SOURCE_READ_ONLY_STATUS);
            }
        }

        /// <summary>
        /// 初始化Grid
        /// </summary>
        private void InitializeDataGridView()
        {
            _courseTimeDataGridView.DataBindings.Add(BINDING_READ_ONLY_STATUS, _courseManagementPresentationModel, SOURCE_READ_ONLY_STATUS);
            _courseTimeDataGridView.AutoGenerateColumns = false;
            _courseTimeDataGridView.RowHeadersVisible = false;

            AddRowNumber();
            AddCheckBox();
        }

        /// <summary>
        /// 節數欄位生成
        /// </summary>
        private void AddRowNumber()
        {
            _courseTimeDataGridView.Columns.Add(COLUMN_NAME, COLUMN_TITLE);

            for (var i = 1; i < 9; i++) 
            {
                _courseTimeDataGridView.Rows.Add();
            }

            //int i = 1;
            //foreach (DataGridViewRow row in _courseTimeDataGridView.Rows)
            //{
            //    row.Cells[COLUMN_NAME].Value = i.ToString();
            //    i++;
            //}

        }

        /// <summary>
        /// Grid CheckBox生成
        /// </summary>
        private void AddCheckBox()
        {

            for (var i = 0; i < 7; i++)
            {
                DataGridViewColumn columnCheck = new DataGridViewCheckBoxColumn();
                columnCheck.Width = CourseManageProperty.COLUMN_WIDTH;
                columnCheck.Name = (CourseProperty.Sunday + i).ToString();
                _courseTimeDataGridView.Columns.Add(columnCheck);
                _courseTimeDataGridView.Columns[i + 1].HeaderText = (CourseProperty.Sunday + i).ToString();
            }

        }

        /// <summary>
        /// GroupBox 資料綁定
        /// </summary>
        private void BindObjectWithData()
        {
            _courseNumberTextBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "Number");
            _courseNameTextBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "Name");
            _courseStageTextBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "Stage");
            _courseCreditTextBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "Credit");
            _courseTeacherTextBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "Teacher");
            _courseRequiredOrElectiveComboBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "RequiredOrElective");
            _courseTeachAssistantTextBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "TeachAssistant");
            _courseLanguageTextBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "Language");
            _courseNoteTextBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "Note");
            _courseHourComboBox.DataBindings.Add(BINDING_TEXT, _courseManagementPresentationModel, "Hour");
        }

        /// <summary>
        /// 監聽ListBox 選取事件
        /// </summary>
        private void ListenCourseListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int selectedIndex = listBox.SelectedIndex;
            int previousIndex = _courseManagementPresentationModel.ListBoxSelectedIndex;
            DataItem item = (DataItem)listBox.SelectedItem;

            if (selectedIndex != previousIndex)
            {
                SetWidgetStatus(selectedIndex);
                _courseManagementPresentationModel.GetCourseByCourseNumber(item.Value);
                RefreshWidgetStatus();
            }

        }

        /// <summary>
        /// 重設元件狀態
        /// </summary>
        private void SetWidgetStatus(int index)
        {
            _courseManagementPresentationModel.ListBoxSelectedIndex = index;
            _courseManagementPresentationModel.IsCourseEditReadOnly = false;
            _courseManagementPresentationModel.IsCourseComboBoxEnabled = true;
        }

        /// <summary>
        /// Initialize form status
        /// </summary>
        private void RefreshWidgetStatus()
        {
            _courseTimeDataGridView.DataBindings[0].ReadValue();

            foreach (TextBoxBase c in _courseGroupBox.Controls.OfType<TextBoxBase>())
            {
                c.DataBindings[0].ReadValue();
                c.DataBindings[1].ReadValue();
            }

            foreach (ComboBox c in _courseGroupBox.Controls.OfType<ComboBox>())
            {
                c.DataBindings[0].ReadValue();
                //MessageBox.Show(c.Name + c.DataBindings.Count.ToString() + Environment.NewLine);
            }
            _courseHourComboBox.DataBindings[1].ReadValue();
            _courseRequiredOrElectiveComboBox.DataBindings[1].ReadValue();
        }

    }
}
