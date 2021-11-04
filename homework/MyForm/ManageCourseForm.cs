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
        private bool _isDataGridViewEditing = false;

        public ManageCourseForm(CourseManagementPresentationModel courseManagementPresentationModel)
        {
            _courseManagementPresentationModel = courseManagementPresentationModel;
            InitializeComponent();
            InitializeTabControl();
            InitializeButton();
            InitializeListBox();
            SetGroupBoxControlsStatus();
            BindObjectWithData();
            BindControlEvent();
            BindNotifyEvent();
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
            for (var j = 1; j < 10; j++)
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
        /// 重整按鈕狀態
        /// </summary>
        private void RefreshButtonStatus()
        {
            _buttonAddCourse.DataBindings[0].ReadValue();
            _buttonConfirm.DataBindings[0].ReadValue();
            _buttonConfirm.DataBindings[1].ReadValue();
        }

        /// <summary>
        /// 重整Grid內容狀態
        /// </summary>
        private void RefreshDataGridViewStatus()
        {
            string dayOfWeek;
            string[] courseTime;
            for (var day = DayOfWeek.Sunday; day <= DayOfWeek.Saturday; day++)
            {
                dayOfWeek = (string)typeof(CourseManagementPresentationModel).GetProperty(day.ToString()).GetValue(_courseManagementPresentationModel, null);
                ResetDataGridViewCheckBox(day);
                if (!string.IsNullOrEmpty(dayOfWeek))
                {
                    courseTime = dayOfWeek.Split(CourseManageProperty.SPACE, CourseManageProperty.NEW_LINE);
                    foreach (var s in courseTime)
                    {
                        _courseTimeDataGridView.Rows[int.Parse(s) - 1].Cells[((int)day) + 1].Value = true;
                    }
                }
            }
        }

        /// <summary>
        /// 清除checkbox的狀態
        /// </summary>
        private void ResetDataGridViewCheckBox(DayOfWeek day)
        {
            foreach (DataGridViewRow row in _courseTimeDataGridView.Rows)
            {
                row.Cells[((int)day) + 1].Value = false;
            }
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

    }
}
