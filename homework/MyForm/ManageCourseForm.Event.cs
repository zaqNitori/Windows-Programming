using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework.PresentationModel;
using homework.ViewModel;

namespace homework
{
    partial class ManageCourseForm
    {
        /// <summary>
        /// GroupBox 資料綁定
        /// </summary>
        private void BindObjectWithData()
        {
            _courseNumberTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.Number));
            _courseNameTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.Name));
            _courseStageTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.Stage));
            _courseCreditTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.Credit));
            _courseTeacherTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.Teacher));
            _courseTeachAssistantTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.TeachAssistant));
            _courseLanguageTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.Language));
            _courseNoteTextBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.Note));
            _courseStatusComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.CourseStatus));
            _courseRequiredOrElectiveComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.RequiredOrElective));
            _courseHourComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.Hour));
            _courseDepartmentComboBox.DataBindings.Add(CourseManageProperty.BINDING_TEXT, _courseManagementPresentationModel, nameof(_courseManagementPresentationModel.DepartmentName));
        }

        /// <summary>
        /// GroupBox 事件綁定
        /// </summary>
        private void BindControlEvent()
        {
            _courseNumberTextBox.KeyPress += ListenTextBoxKeyPress;
            _courseStageTextBox.KeyPress += ListenTextBoxKeyPress;
            _courseCreditTextBox.KeyPress += ListenTextBoxKeyPress;
            _courseNumberTextBox.TextChanged += ListenCourseNumberTextChanged;
            _courseNameTextBox.TextChanged += ListenCourseNameTextChanged;
            _courseStageTextBox.TextChanged += ListenCourseStageTextChanged;
            _courseCreditTextBox.TextChanged += ListenCourseCreditTextChanged;
            _courseTeacherTextBox.TextChanged += ListenCourseTeacherTextChanged;
            _courseRequiredOrElectiveComboBox.SelectedIndexChanged += ListenCourseRequiredOrElectiveTextChanged;
            _courseTeachAssistantTextBox.TextChanged += ListenCourseTeachAssistantTextChanged;
            _courseLanguageTextBox.TextChanged += ListenCourseLanguageTextChanged;
            _courseNoteTextBox.TextChanged += ListenCourseNoteTextChanged;
            _courseHourComboBox.SelectedIndexChanged += ListenCourseHourTextChanged;
            _courseStatusComboBox.SelectedIndexChanged += ListenCourseStatusTextChanged;
            _courseDepartmentComboBox.SelectedIndexChanged += ListenCourseClassNameTextChanged;
            _courseTimeDataGridView.CellMouseUp += ListenCourseDataGridOnCellMouseUp;
            _courseTimeDataGridView.CellValueChanged += ListenCourseDataGridOnCellValueChanged;
        }

        /// <summary>
        /// Notify 事件綁定
        /// </summary>
        private void BindNotifyEvent()
        {
            _courseManagementPresentationModel._groupBoxAndButtonChanged += RefreshGroupBoxStatus;
            _courseManagementPresentationModel._groupBoxAndButtonChanged += RefreshButtonStatus;
            _courseManagementPresentationModel._gridContentChanged += RefreshDataGridViewStatus;
            _courseManagementPresentationModel._listBoxChanged += RefreshListBoxStatus;
        }

        /// <summary>
        /// 監聽KeyPress事件， 限制數字輸入
        /// </summary>
        private void ListenTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < CourseManageProperty.FORTY_EIGHT_NUMBER || (int)e.KeyChar > CourseManageProperty.FIFTY_SEVEN_NUMBER) && (int)e.KeyChar != CourseManageProperty.EIGHT_NUMBER)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 監聽ListBox 選取事件
        /// </summary>
        private void ListenCourseListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int selectedIndex = listBox.SelectedIndex;
            DataItem item = (DataItem)listBox.SelectedItem;
            if (selectedIndex != -1)
            {
                _courseManagementPresentationModel.SelectedIndexChanged(selectedIndex);
                _courseManagementPresentationModel.GetCourseByCourseNumber(item.Value);
            }
        }

        /// <summary>
        /// 點擊新增/儲存按鈕
        /// </summary>
        private void ListenButtonConfirmClicked(object sender, EventArgs e)
        {
            string errorMessage = _courseManagementPresentationModel.CheckIsNumericInputValid();
            if (string.IsNullOrEmpty(errorMessage))
            {
                _courseManagementPresentationModel.ClickConfirm();
                ClearGroupBoxStatus();
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        /// <summary>
        /// 點擊新增課程按鈕
        /// </summary>
        private void ListenButtonAddCourseClicked(object sender, EventArgs e)
        {
            ClearGroupBoxStatus();
            _courseManagementPresentationModel.ClickAddCourse();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseNumberTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Number = _courseNumberTextBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseNameTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Name = _courseNameTextBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseStageTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Stage = _courseStageTextBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseCreditTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Credit = _courseCreditTextBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseTeacherTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Teacher = _courseTeacherTextBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseRequiredOrElectiveTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.RequiredOrElective = _courseRequiredOrElectiveComboBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseTeachAssistantTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.TeachAssistant = _courseTeachAssistantTextBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseLanguageTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Language = _courseLanguageTextBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseHourTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Hour = _courseHourComboBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseClassNameTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.DepartmentName = _courseDepartmentComboBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseNoteTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.Note = _courseNoteTextBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽內容修改事件
        /// </summary>
        private void ListenCourseStatusTextChanged(object sender, EventArgs e)
        {
            _courseManagementPresentationModel.CourseStatus = _courseStatusComboBox.Text;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
        }

        /// <summary>
        /// 監聽滑鼠點擊釋放
        /// </summary>
        private void ListenCourseDataGridOnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            _isDataGridViewEditing = true;
            if (e.RowIndex != -1)
            {
                _courseTimeDataGridView.EndEdit();
            }
        }

        /// <summary>
        /// 監聽數值變動
        /// </summary>
        private void ListenCourseDataGridOnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex + 1;
            if (e.RowIndex != -1 && _isDataGridViewEditing)
            {
                int time = (columnIndex - 1) * CourseManageProperty.TEN_NUMBER + (rowIndex);
                SetUpCourseTimeString(columnIndex, rowIndex);
                _courseManagementPresentationModel.RecordCourseTime(time);
                _courseManagementPresentationModel.CheckIsCourseInputValid();
            }
            _isDataGridViewEditing = false;
        }

        /// <summary>
        /// 根據Grid 變動欄位，生成新的字串
        /// </summary>
        private void SetUpCourseTimeString(int columnIndex, int rowIndex)
        {
            string courseTime = string.Empty;
            foreach (DataGridViewRow row in _courseTimeDataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[columnIndex].Value))
                {
                    courseTime += string.IsNullOrEmpty(courseTime) ? rowIndex.ToString() : (CourseManageProperty.SPACE + rowIndex.ToString());
                }
            }
            typeof(CourseManagementPresentationModel).GetProperty((DayOfWeek.Sunday + columnIndex - 1).ToString()).SetValue(_courseManagementPresentationModel, courseTime);
        }

    }
}
