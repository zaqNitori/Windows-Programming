using System;
using System.Linq;
using System.Windows.Forms;
using homework.PresentationModel;
using homework.ViewModel;

namespace homework
{
    public partial class ManageCourseForm : Form
    {
        private CourseManagementPresentationModel _courseManagementPresentationModel;

        public ManageCourseForm(CourseManagementPresentationModel courseManagementPresentationModel)
        {
            _courseManagementPresentationModel = courseManagementPresentationModel;
            InitializeComponent();
            InitializeTabControl();
            InitializeButton();
            InitializeListBox();
            SetGroupBoxControlsStatus();
            BindObjectWithData();
            BindObjectEvent();
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
            _buttonConfirm.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, CourseManageProperty.SOURCE_BUTTON_CONFIRM_TEXT);
            _buttonConfirm.Click += ListenButtonConfirmClicked;
        }

        /// <summary>
        /// 點擊新增/儲存按鈕
        /// </summary>
        private void ListenButtonConfirmClicked(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.ClickConfirm();
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
        /// 設定groupBox 內的元件的狀態
        /// </summary>
        private void SetGroupBoxControlsStatus()
        {
            InitializeDataGridView();
            _courseDepartmentComboBox.DataSource = _courseManagementPresentationModel.GetDepartmentNameAsItem();
            _courseGroupBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, CourseManageProperty.SOURCE_GROUP_BOX_TITLE);

            foreach (ComboBox c in _courseGroupBox.Controls.OfType<ComboBox>())
            {
                c.DataBindings.Add(CourseManageProperty.BINDING_ENABLED_STATUS, _courseManagementPresentationModel, CourseManageProperty.SOURCE_COMBO_BOX_ENABLED);
            }

            foreach (TextBoxBase c in _courseGroupBox.Controls.OfType<TextBoxBase>())
            {
                c.DataBindings.Add(CourseManageProperty.BINDING_READ_ONLY_STATUS, _courseManagementPresentationModel, CourseManageProperty.SOURCE_READ_ONLY_STATUS);
            }
            ClearGroupBoxStatus();
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
        }

        /// <summary>
        /// 節數欄位生成
        /// </summary>
        private void AddRowNumber()
        {
            for (var j = 1; j < 9; j++)
            {
                _courseTimeDataGridView.Rows.Add();
            }

            int index = 1;
            foreach (DataGridViewRow row in _courseTimeDataGridView.Rows)
            {
                row.Cells[0].Value = index.ToString();
                index++;
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
            _courseTeachAssistantTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "TeachAssistant");
            _courseLanguageTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Language");
            _courseNoteTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Note");
            _courseStatusComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "CourseStatus");
            _courseRequiredOrElectiveComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "RequiredOrElective");
            _courseHourComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "Hour");
            _courseDepartmentComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, "DepartmentName");
        }

        /// <summary>
        /// GroupBox 事件綁定
        /// </summary>
        private void BindObjectEvent()
        {
            _courseNumberTextBox.KeyPress += ListenTextBoxKeyPress;
            _courseStageTextBox.KeyPress += ListenTextBoxKeyPress;
            _courseCreditTextBox.KeyPress += ListenTextBoxKeyPress;
            _courseNumberTextBox.MouseDown += ListenLeaveEvent;
            _courseNameTextBox.MouseLeave += ListenLeaveEvent;
            _courseStageTextBox.MouseLeave += ListenLeaveEvent;
            _courseCreditTextBox.MouseLeave += ListenLeaveEvent;
            _courseTeacherTextBox.MouseLeave += ListenLeaveEvent;
            _courseRequiredOrElectiveComboBox.MouseLeave += ListenLeaveEvent;
            _courseTeachAssistantTextBox.MouseLeave += ListenLeaveEvent;
            _courseLanguageTextBox.MouseLeave += ListenLeaveEvent;
            _courseNoteTextBox.MouseLeave += ListenLeaveEvent;
            _courseHourComboBox.MouseLeave += ListenLeaveEvent;
            _courseStatusComboBox.MouseLeave += ListenLeaveEvent;
            _courseDepartmentComboBox.MouseLeave += ListenLeaveEvent;
            _courseGroupBox.MouseCaptureChanged += ListenGroupBoxMouseCaptureChanged;
        }

        /// <summary>
        /// 重整按鈕狀態
        /// </summary>
        private void RefreshButtonStatus()
        {
            _buttonAddCourse.DataBindings[0].ReadValue();
            _buttonConfirm.DataBindings[0].ReadValue();
            _buttonConfirm.DataBindings[1].ReadValue();
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
                c.DataBindings[1].ReadValue();
            }
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

        /// <summary>
        /// 監聽KeyPress事件， 限制數字輸入
        /// </summary>
        private void ListenTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 監聽TextChanged事件， 處理button顯示
        /// </summary>
        private void ListenLeaveEvent(object sender, EventArgs e)
        {
            if (!_courseManagementPresentationModel.IsCourseEditReadOnly)
            {
                ListenGroupBoxMouseCaptureChanged(sender, e);
                _courseManagementPresentationModel.IsCourseInputValid();
                RefreshButtonStatus();
            }
        }

        /// <summary>
        /// 監聽MouseCaptureChanged事件， 處理資料修改顯示
        /// </summary>
        private void ListenGroupBoxMouseCaptureChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Number = _courseNumberTextBox.Text;
            _courseManagementPresentationModel.Name = _courseNameTextBox.Text;
            _courseManagementPresentationModel.Stage = _courseStageTextBox.Text;
            _courseManagementPresentationModel.Credit = _courseCreditTextBox.Text;
            _courseManagementPresentationModel.Teacher = _courseTeacherTextBox.Text;
            _courseManagementPresentationModel.RequiredOrElective = _courseRequiredOrElectiveComboBox.Text;
            _courseManagementPresentationModel.TeachAssistant = _courseTeachAssistantTextBox.Text;
            _courseManagementPresentationModel.Language = _courseLanguageTextBox.Text;
            _courseManagementPresentationModel.Note = _courseNoteTextBox.Text;
            _courseManagementPresentationModel.Hour = _courseHourComboBox.Text;
            _courseManagementPresentationModel.CourseStatus = _courseStatusComboBox.Text;
            _courseManagementPresentationModel.DepartmentName = _courseDepartmentComboBox.Text;
        }
    }
}
