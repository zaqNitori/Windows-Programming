using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;
using homework.ViewModel;

namespace homework.PresentationModel
{
    partial class CourseManagementPresentationModel
    {
        /// <summary>
        /// GroupBox以及按鈕 修改事件觸發 
        /// </summary>
        private void NotifyGroupBoxAndButtonChanged()
        {
            if (_groupBoxAndButtonChanged != null)
                _groupBoxAndButtonChanged();
        }

        /// <summary>
        /// ListBox修改事件觸發 
        /// </summary>
        private void NotifyListBoxChanged()
        {
            if (_listBoxChanged != null)
                _listBoxChanged();
        }

        /// <summary>
        /// 以課號取得課程
        /// </summary>
        public void GetCourseByCourseNumber(string number)
        {
            _originalCourse = _courseManageModel.GetCourseByCourseNumber(number);
            DepartmentName = _courseManageModel.GetDepartmentNameByCourseNumber(number);
            _originalDepartmentName = DepartmentName;
            CourseStatus = string.Empty;
            Number = _originalCourse.Number;
            Name = _originalCourse.Name;
            Stage = _originalCourse.Stage;
            Credit = _originalCourse.Credit;
            Teacher = _originalCourse.Teacher;
            RequiredOrElective = _originalCourse.RequiredOrElective;
            TeachAssistant = _originalCourse.TeachAssistant;
            Language = _originalCourse.Language;
            Note = _originalCourse.Note;
            Hour = _originalCourse.Hour;
            IsCourseEditReadOnly = false;
            IsCourseComboBoxEnabled = true;
            NotifyGroupBoxAndButtonChanged();
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void ClearCourse()
        {
            Number = Name = Stage = Credit = Teacher = RequiredOrElective = TeachAssistant = Language = Note = Hour = DepartmentName = string.Empty;
            NotifyGroupBoxAndButtonChanged();
        }

        /// <summary>
        /// 點擊新增課程
        /// </summary>
        public void ClickAddCourse()
        {
            CourseManageState = ((int)CourseManageAction.Add);
            GroupBoxTitle = CourseManageProperty.COURSE_ADD_GROUP_BOX_TITLE;
            ButtonConfirmText = CourseManageProperty.BUTTON_ADD_TEXT;
            IsButtonAddCourseEnabled = false;
            IsButtonConfirmEnabled = false;
            IsCourseEditReadOnly = false;
            IsCourseComboBoxEnabled = true;
            ClearCourse();
        }

        /// <summary>
        /// 點擊新增/儲存
        /// </summary>
        public void ClickConfirm()
        {
            CheckIsNumeric();
            //CourseManageState = ((int)CourseManageAction.Edit);
            //GroupBoxTitle = CourseManageProperty.COURSE_EDIT_GROUP_BOX_TITLE;
            //IsButtonAddCourseEnabled = true;
            //IsButtonConfirmEnabled = false;
            //IsCourseEditReadOnly = true;
            //IsCourseComboBoxEnabled = false;
            //ClearCourse();
        }

        /// <summary>
        /// 點擊新增/儲存
        /// </summary>
        public void SelectedIndexChanged(int selectedIndex)
        {
            ListBoxSelectedIndex = selectedIndex;
            IsCourseEditReadOnly = true;
            IsCourseComboBoxEnabled = false;
            CourseManageState = ((int)CourseManageAction.Edit);
            GroupBoxTitle = CourseManageProperty.COURSE_EDIT_GROUP_BOX_TITLE;
            ButtonConfirmText = CourseManageProperty.BUTTON_SAVE_TEXT;
            IsButtonAddCourseEnabled = true;
            IsButtonConfirmEnabled = false;
            ClearCourse();
            //NotifyGroupBoxAndButtonChanged();
        }

        /// <summary>
        /// 驗證輸入
        /// </summary>
        public void CheckIsCourseInputValid()
        {
            if (!string.IsNullOrEmpty(Name)
                && !string.IsNullOrEmpty(Number)
                && !string.IsNullOrEmpty(Stage)
                && !string.IsNullOrEmpty(Credit)
                && !string.IsNullOrEmpty(Teacher)
                && !string.IsNullOrEmpty(RequiredOrElective)
                && !string.IsNullOrEmpty(Hour)
                && !string.IsNullOrEmpty(DepartmentName)
                && IsCourseComboBoxEnabled)
            {
                CheckIsCoursePropertyChanged();
            }
            else
            {
                IsButtonConfirmEnabled = false;
            }
            NotifyGroupBoxAndButtonChanged();
        }

        /// <summary>
        /// 是否修改
        /// </summary>
        private void CheckIsCoursePropertyChanged()
        {
            IsButtonConfirmEnabled =
                (Name != _originalCourse.Name
                || Number != _originalCourse.Number
                || Stage != _originalCourse.Stage
                || Credit != _originalCourse.Credit
                || Teacher != _originalCourse.Teacher
                || RequiredOrElective != _originalCourse.RequiredOrElective
                || TeachAssistant != _originalCourse.TeachAssistant
                || Note != _originalCourse.Note
                || Hour != _originalCourse.Hour
                || Language != _originalCourse.Language
                || DepartmentName != _originalDepartmentName) ? true : false;
        }

        /// <summary>
        /// 檢測有限制輸入的欄位
        /// </summary>
        private string CheckIsNumeric()
        {
            string errorMessage = string.Empty;
            if (IsNumeric(Number))
            {
                errorMessage += nameof(Number);
            }

            try
            {
                Convert.ToInt32(Credit);
            }
            catch
            {
                errorMessage += nameof(Credit);
            }

            if (IsNumeric(Stage))
            {
                errorMessage += nameof(Credit);
            }
            return errorMessage;
        }

        /// <summary>
        /// 是否為數字
        /// </summary>
        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (c >= CourseManageProperty.ZERO && c <= CourseManageProperty.NINE)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
