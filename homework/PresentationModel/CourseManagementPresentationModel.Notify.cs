using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;
using homework.ViewModel;
using System.Reflection;

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
        /// 以課號取得課程，處理資料的取得
        /// </summary>
        public void GetCourseByCourseNumber(string number)
        {
            _originalCourse = _courseManageModel.GetCourseByCourseNumber(number);
            _originalDepartmentName = DepartmentName = _courseManageModel.GetDepartmentNameByCourseNumber(number);
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
            SetCourseTime();
            NotifyGroupBoxAndButtonChanged();
        }

        /// <summary>
        /// 綁定課程時間
        /// </summary>
        private void SetCourseTime()
        {
            _courseTimeRecord.Clear();
            string[] courseTime;
            for (var day = DayOfWeek.Sunday; day <= DayOfWeek.Saturday; day++)
            {
                string property = (string)typeof(Course).GetProperty(day.ToString()).GetValue(_originalCourse, null);
                typeof(CourseManagementPresentationModel).GetProperty(day.ToString()).SetValue(this, property);
                if (!string.IsNullOrEmpty(property))
                {
                    courseTime = property.Split(CourseManageProperty.SPACE, CourseManageProperty.NEW_LINE);
                    foreach (var s in courseTime)
                    {
                        _courseTimeRecord.Add(((int)day) * CourseManageProperty.TEN_NUMBER + int.Parse(s));
                    }
                }
            }

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
        /// 變更點選課程，處理畫面物件的狀態
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
        }

        /// <summary>
        /// 紀錄課程時間
        /// </summary>
        public void RecordCourseTime(int time)
        {
            if (_courseTimeRecord.Contains(time))
            {
                _courseTimeRecord.Remove(time);
            }
            else
            {
                _courseTimeRecord.Add(time);
            }
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
        /// 建立課程
        /// </summary>
        private Course BuildCourse()
        {
            Course course = new Course();
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
            for (var day = DayOfWeek.Sunday; day <= DayOfWeek.Saturday; day++)
            {
                string property = (string)typeof(CourseManagementPresentationModel).GetProperty(day.ToString()).GetValue(this, null);
                typeof(Course).GetProperty(day.ToString()).SetValue(course, property);
            }
            return course;
        }

    }
}
