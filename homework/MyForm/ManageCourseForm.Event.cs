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
        /// 監聽 選課表單關閉事件
        /// </summary>
        private void ListenManageCourseFormClosing(object sender, FormClosingEventArgs e)
        {
            _courseManagementPresentationModel._groupBoxChanged -= RefreshGroupBoxStatus;
            _courseManagementPresentationModel._buttonChanged -= RefreshButtonStatus;
            _courseManagementPresentationModel._gridContentChanged -= RefreshDataGridViewStatus;
            _courseManagementPresentationModel._listBoxChanged -= RefreshListBoxStatus;
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
            _courseManagementPresentationModel.ClickAddCourse();
            ClearGroupBoxStatus();
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
            _courseManagementPresentationModel.ClassName = _courseDepartmentComboBox.Text;
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
                SetUpCourseTimeString(columnIndex);
                _courseManagementPresentationModel.RecordCourseTime(time);
                _courseManagementPresentationModel.CheckIsCourseInputValid();
            }
            _isDataGridViewEditing = false;
        }

        /// <summary>
        /// 根據Grid 變動欄位，生成新的字串
        /// </summary>
        private void SetUpCourseTimeString(int columnIndex)
        {
            string courseTime = string.Empty;
            foreach (DataGridViewRow row in _courseTimeDataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[columnIndex].Value))
                {
                    courseTime += string.IsNullOrEmpty(courseTime) ? (row.Index + 1).ToString() : (CourseManageProperty.SPACE + (row.Index + 1).ToString());
                }
            }
            typeof(CourseManagementPresentationModel).GetProperty((DayOfWeek.Sunday + columnIndex - 1).ToString()).SetValue(_courseManagementPresentationModel, courseTime);
        }

        /// <summary>
        /// 監聽 匯入資工課程 按鈕點擊
        /// </summary>
        private void ListenButtonImportClicked(object sender, EventArgs e)
        {

        }
    }
}
