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
            _buttonAddCourse.DataBindings.Add(CourseManageProperty.BINDING_ENABLED_STATUS, _courseManagementPresentationModel, CourseManageProperty.SOURCE_BUTTON_ADD_ENABLED);
            _buttonAddCourse.Click += ListenButtonAddCourseClicked; 
            _buttonConfirm.DataBindings.Add(CourseManageProperty.BINDING_ENABLED_STATUS, _courseManagementPresentationModel, CourseManageProperty.SOURCE_BUTTON_CONFIRM_ENABLED);
            _buttonConfirm.Click += ListenButtonConfirmClicked;
        }

        /// <summary>
        /// 點擊新增/儲存按鈕
        /// </summary>
        private void ListenButtonConfirmClicked(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.ClickConfirm();
            _courseManagementPresentationModel.ClearCourse();
            ClearGroupBoxStatus();
            RefreshGroupBoxStatus();
            RefreshButtonStatus();
        }

        /// <summary>
        /// 點擊新增課程按鈕
        /// </summary>
        private void ListenButtonAddCourseClicked(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.ClickAddCourse();
            _courseManagementPresentationModel.ClearCourse();
            ClearGroupBoxStatus();
            RefreshGroupBoxStatus();
            RefreshButtonStatus();
        }

        /// <summary>
        /// 初始化TabControl
        /// </summary>
        private void InitializeListBox()
        {
            RefreshListBoxStatus();
            _courseListBox.SelectedIndexChanged += ListenCourseListBoxSelectedIndexChanged;
        }

        /// <summary>
        /// 設定groupBox 內的元件的狀態
        /// </summary>
        private void SetGroupBoxControlsStatus()
        {
            InitializeDataGridView();
            _courseGroupBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, CourseManageProperty.SOURCE_GROUP_BOX_TITLE);

            foreach (ComboBox c in _courseGroupBox.Controls.OfType<ComboBox>())
            {
                c.DataBindings.Add(CourseManageProperty.BINDING_ENABLED_STATUS, _courseManagementPresentationModel, CourseManageProperty.SOURCE_COMBO_BOX_ENABLED);
            }

            foreach (TextBoxBase c in _courseGroupBox.Controls.OfType<TextBoxBase>())
            {
                c.DataBindings.Add(CourseManageProperty.BINDING_READ_ONLY_STATUS, _courseManagementPresentationModel, CourseManageProperty.SOURCE_READ_ONLY_STATUS);
            }
        }

        /// <summary>
        /// 初始化Grid
        /// </summary>
        private void InitializeDataGridView()
        {
            _courseTimeDataGridView.DataBindings.Add(CourseManageProperty.BINDING_READ_ONLY_STATUS, _courseManagementPresentationModel, CourseManageProperty.SOURCE_READ_ONLY_STATUS);
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
            _courseNumberTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Number");
            _courseNameTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Name");
            _courseStageTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Stage");
            _courseCreditTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Credit");
            _courseTeacherTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Teacher");
            _courseRequiredOrElectiveComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "RequiredOrElective");
            _courseTeachAssistantTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "TeachAssistant");
            _courseLanguageTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Language");
            _courseNoteTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Note");
            _courseHourComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Hour");
        }

        /// <summary>
        /// 監聽ListBox 選取事件
        /// </summary>
        private void ListenCourseListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int selectedIndex = listBox.SelectedIndex;
            DataItem item = (DataItem)listBox.SelectedItem;

            _courseManagementPresentationModel.SelectedIndexChanged(selectedIndex);
            _courseManagementPresentationModel.GetCourseByCourseNumber(item.Value);
            RefreshGroupBoxStatus();
            RefreshButtonStatus();
        }

        /// <summary>
        /// 重整按鈕狀態
        /// </summary>
        private void RefreshButtonStatus()
        {
            _buttonAddCourse.DataBindings[0].ReadValue();
            _buttonConfirm.DataBindings[0].ReadValue();
        }

        /// <summary>
        /// 重整ListBox狀態
        /// </summary>
        private void RefreshListBoxStatus()
        {
            _courseListBox.DataSource = _courseManagementPresentationModel.GetCurriculumAsItem();
            _courseListBox.SelectedIndex = -1;
        }

        /// <summary>
        /// 重整GroupBox狀態
        /// </summary>
        private void RefreshGroupBoxStatus()
        {
            _courseGroupBox.DataBindings[0].ReadValue();
            _courseTimeDataGridView.DataBindings[0].ReadValue();

            foreach (TextBoxBase c in _courseGroupBox.Controls.OfType<TextBoxBase>())
            {
                c.DataBindings[0].ReadValue();
                c.DataBindings[1].ReadValue();
            }

            foreach (ComboBox c in _courseGroupBox.Controls.OfType<ComboBox>())
            {
                c.DataBindings[0].ReadValue();
            }
            _courseHourComboBox.DataBindings[1].ReadValue();
            _courseRequiredOrElectiveComboBox.DataBindings[1].ReadValue();
        }

        /// <summary>
        /// 清除GroupBox狀態，回到預設值
        /// </summary>
        private void ClearGroupBoxStatus()
        {
            foreach (TextBoxBase c in _courseGroupBox.Controls.OfType<TextBoxBase>())
            {
                c.Clear();
            }

            foreach (ComboBox c in _courseGroupBox.Controls.OfType<ComboBox>())
            {
                c.SelectedIndex = -1;
            }
        }

    }
}
