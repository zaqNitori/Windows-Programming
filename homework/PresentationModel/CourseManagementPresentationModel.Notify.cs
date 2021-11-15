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
        private void NotifyButtonChanged()
        {
            if (_buttonChanged != null)
                _buttonChanged();
        }

        /// <summary>
        /// GroupBox以及按鈕 修改事件觸發 
        /// </summary>
        private void NotifyGroupBoxChanged()
        {
            if (_groupBoxChanged != null)
                _groupBoxChanged();
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
        /// Grid CheckBox點擊事件觸發 
        /// </summary>
        private void NotifyGridContentChanged()
        {
            if (_gridContentChanged != null)
                _gridContentChanged();
        }

        /// <summary>
        /// 以課號取得課程，處理資料的取得
        /// </summary>
        public void GetCourseByCourseNumber(string number)
        {
            _originalCourse = _courseManageModel.GetCourseByCourseNumber(number);
            _originalClassName = ClassName = _courseManageModel.GetClassNameByCourseNumber(number);
            CourseStatus = _originalCourse.Status;
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
            NotifyGroupBoxChanged();
            NotifyGridContentChanged();
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
        private void ClearCourse()
        {
            Number = Name = Stage = Credit = Teacher = RequiredOrElective = TeachAssistant = Language = Note = Hour = ClassName = Sunday = Monday = Tuesday = Wednesday = Thursday = Friday = Saturday = CourseStatus = string.Empty;
            _courseTimeRecord.Clear();
            NotifyGroupBoxChanged();
            NotifyButtonChanged();
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
                _courseManageModel.AddCourse(course, ClassName);
            }
            else
            {
                _courseManageModel.EditCourse(course, ClassName, OriginalCourseNumber);
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
        public int RecordCourseTime(int time)
        {
            if (_courseTimeRecord.Contains(time))
            {
                _courseTimeRecord.Remove(time);
            }
            else
            {
                _courseTimeRecord.Add(time);
            }
            return _courseTimeRecord.Count;
        }

        /// <summary>
        /// 驗證輸入
        /// </summary>
        public void CheckIsCourseInputValid()
        {
            IsButtonConfirmEnabled = false;
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Number) && !string.IsNullOrWhiteSpace(Stage) && !string.IsNullOrWhiteSpace(Credit)
                && !string.IsNullOrWhiteSpace(Teacher) && !string.IsNullOrWhiteSpace(RequiredOrElective) && !string.IsNullOrWhiteSpace(Hour) && !string.IsNullOrWhiteSpace(ClassName)
                && int.Parse(Hour).Equals(_courseTimeRecord.Count))
            {
                if (CourseManageState.Equals((int)CourseManageAction.Edit))
                {
                    CheckIsCoursePropertyChanged();
                }
                else 
                {
                    IsButtonConfirmEnabled = true;
                }
            }
            NotifyButtonChanged();
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
                || ClassName != _originalClassName
                || CourseStatus != _originalCourse.Status
                || CheckIsCourseTimeChanged()) ? true : false;
        }

        /// <summary>
        /// 課程時間是否修改
        /// </summary>
        private bool CheckIsCourseTimeChanged()
        {
            for (var day = DayOfWeek.Sunday; day <= DayOfWeek.Saturday; day++)
            {
                string oldTime = (string)typeof(Course).GetProperty(day.ToString()).GetValue(_originalCourse, null);
                string newTime = (string)typeof(CourseManagementPresentationModel).GetProperty(day.ToString()).GetValue(this, null);
                if (!oldTime.Equals(newTime))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 建立課程
        /// </summary>
        private Course BuildCourse()
        {
            Course course = new Course();
            course.Status = CourseStatus;
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
            BuildCourseTime(course);
            return course;
        }

        /// <summary>
        /// 建立課程時間
        /// </summary>
        private void BuildCourseTime(Course course)
        {
            for (var day = DayOfWeek.Sunday; day <= DayOfWeek.Saturday; day++)
            {
                string property = (string)typeof(CourseManagementPresentationModel).GetProperty(day.ToString()).GetValue(this, null);
                typeof(Course).GetProperty(day.ToString()).SetValue(course, property);
            }
        }

    }
}
