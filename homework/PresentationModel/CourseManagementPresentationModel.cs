using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;
using homework.ViewModel;

namespace homework.PresentationModel
{
    public class CourseManagementPresentationModel
    {
        private CourseManageModel _courseManageModel;
        private Course _originalCourse;

        public CourseManagementPresentationModel(CourseManageModel courseManageModel)
        {
            _courseManageModel = courseManageModel;
            IsCourseEditReadOnly = true;
            IsCourseComboBoxEnabled = false;
            IsButtonAddCourseEnabled = true;
            IsButtonConfirmEnabled = false;
            ListBoxSelectedIndex = -1;
            GroupBoxTitle = CourseManageProperty.COURSE_EDIT_GROUP_BOX_TITLE;
            ButtonConfirmText = CourseManageProperty.BUTTON_SAVE_TEXT;
            CourseManageState = ((int)CourseManageAction.None);
        }

        public string ButtonConfirmText
        {
            get; set;
        }

        public string GroupBoxTitle
        {
            get; set;
        }

        public int CourseManageState
        {
            get; set;
        }

        public int ListBoxSelectedIndex
        {
            get; set;
        }

        public bool IsButtonConfirmEnabled
        {
            get; set;
        }

        public bool IsButtonAddCourseEnabled
        {
            get; set;
        }

        public bool IsCourseEditReadOnly
        {
            get; set;
        }

        public bool IsCourseComboBoxEnabled
        {
            get; set;
        }

        public string CourseStatus
        {
            get; set;
        }

        public string Number
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Stage
        {
            get; set;
        }

        public string Credit
        {
            get; set;
        }

        public string Teacher
        {
            get; set;
        }

        public string RequiredOrElective
        {
            get; set;
        }

        public string TeachAssistant
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public string Hour
        {
            get; set;
        }

        public string DepartmentName
        {
            get; set;
        }

        /// <summary>
        /// 取得Item型態的所有課程
        /// </summary>
        public List<DataItem> GetCurriculumAsItem()
        {
            return _courseManageModel.GetCurriculumAsItem();
        }

        /// <summary>
        /// 取得Item型態的班級名稱
        /// </summary>
        public List<DataItem> GetDepartmentNameAsItem()
        {
            return _courseManageModel.GetDepartmentNameAsItem();
        }

        /// <summary>
        /// 以課號取得課程
        /// </summary>
        public void GetCourseByCourseNumber(string number)
        {
            _originalCourse = _courseManageModel.GetCourseByCourseNumber(number);
            DepartmentName = _courseManageModel.GetDepartmentNameByCourseNumber(number);
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
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void ClearCourse()
        {
            Number = Name = Stage = Credit = Teacher = RequiredOrElective = TeachAssistant = Language = Note = Hour = DepartmentName = string.Empty;
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
            CourseManageState = ((int)CourseManageAction.Edit);
            GroupBoxTitle = CourseManageProperty.COURSE_EDIT_GROUP_BOX_TITLE;
            IsButtonAddCourseEnabled = true;
            IsButtonConfirmEnabled = false;
            IsCourseEditReadOnly = true;
            IsCourseComboBoxEnabled = false;
            ClearCourse();
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
            IsButtonConfirmEnabled = true;
        }

    }
}
