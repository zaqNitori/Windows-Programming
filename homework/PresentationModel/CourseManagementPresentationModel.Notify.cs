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
            Number = OriginalCourseNumber = _originalCourse.Number;
            Name = _originalCourse.Name;
            Stage = _originalCourse.Stage;
            Credit = _originalCourse.Credit;
            Teacher = _originalCourse.Teacher;
            RequiredOrElective = _originalCourse.RequiredOrElective;
            TeachAssistant = _originalCourse.TeachAssistant;
            Language = _originalCourse.Language;
            Note = _originalCourse.Note;
            Hour = _originalCourse.Hour;
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
            Course course = BuildCourse();
            if (CourseManageState.Equals(((int)CourseManageAction.Add)))
            {
                _courseManageModel.AddCourse(course, DepartmentName);
            }
            else
            {
                _courseManageModel.EditCourse(course, DepartmentName, OriginalCourseNumber);
            }

            IsButtonAddCourseEnabled = true;
            IsButtonConfirmEnabled = false;
            IsCourseEditReadOnly = true;
            IsCourseComboBoxEnabled = false;
            ClearCourse();
            NotifyListBoxChanged();
        }

        /// <summary>
        /// 點擊新增/儲存
        /// </summary>
        public void SelectedIndexChanged(int selectedIndex)
        {
            ListBoxSelectedIndex = selectedIndex;
            IsCourseEditReadOnly = false;
            IsCourseComboBoxEnabled = true;
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
            if (!string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Number)
                && !string.IsNullOrWhiteSpace(Stage)
                && !string.IsNullOrWhiteSpace(Credit)
                && !string.IsNullOrWhiteSpace(Teacher)
                && !string.IsNullOrWhiteSpace(RequiredOrElective)
                && !string.IsNullOrWhiteSpace(Hour)
                && !string.IsNullOrWhiteSpace(DepartmentName)
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
                || TeachAssistant.Trim() != _originalCourse.TeachAssistant
                || Note.Trim() != _originalCourse.Note
                || Hour != _originalCourse.Hour
                || Language.Trim() != _originalCourse.Language
                || DepartmentName != _originalDepartmentName) ? true : false;
        }

        /// <summary>
        /// 檢測有限制輸入的欄位
        /// </summary>
        public string CheckIsNumericInputValid()
        {
            string errorMessage = string.Empty;

            errorMessage += CheckIsNumeric();
            if (CourseManageState.Equals(((int)CourseManageAction.Add)))
            {
                errorMessage += CheckIsCourseNumberConflict();
            }

            return errorMessage;
        }

        /// <summary>
        /// 檢測數字輸入
        /// </summary>
        private string CheckIsNumeric()
        {
            string errorMessage = string.Empty;
            if (!IsNumeric(Number))
            {
                errorMessage += nameof(Number) + Environment.NewLine;
            }

            errorMessage += CheckIsCreditNumeric();

            if (!IsNumeric(Stage))
            {
                errorMessage += nameof(Stage) + Environment.NewLine;
            }
            return (string.IsNullOrEmpty(errorMessage) ? errorMessage : errorMessage + CourseManageProperty.ERROR_MESSAGE_NOT_NUMBER + Environment.NewLine);
        }

        /// <summary>
        /// 檢測課號是否重複
        /// </summary>
        private string CheckIsCourseNumberConflict()
        {
            if (_courseManageModel.CheckIsCourseNumberConfict(Number))
            {
                return nameof(Number) + CourseManageProperty.ERROR_MESSAGE_COURSE_NUMBER_CONFLICT + Environment.NewLine;
            }
            return string.Empty;
        }

        /// <summary>
        /// Credit是否為數字
        /// </summary>
        private string CheckIsCreditNumeric()
        {
            try
            {
                int.Parse(Credit, System.Globalization.NumberStyles.AllowDecimalPoint);
            }
            catch
            {
                return nameof(Credit) + Environment.NewLine;
            }
            return string.Empty;
        }

        /// <summary>
        /// 輸入是否為數字
        /// </summary>
        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (c < CourseManageProperty.ZERO || c > CourseManageProperty.NINE)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 建立課程
        /// </summary>
        private Course BuildCourse()
        {
            Course course = new Course(_originalCourse);
            course.Name = Name;
            course.Number = Number;
            course.Stage = Stage;
            course.Credit = Credit;
            course.Teacher = Teacher;
            course.RequiredOrElective = RequiredOrElective;
            course.TeachAssistant = TeachAssistant;
            course.Language = Language;
            course.Note = Note;
            course.Hour = Hour;
            return course;
        }

    }
}
