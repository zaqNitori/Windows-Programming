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
        private Course _course;

        public CourseManagementPresentationModel(CourseManageModel courseManageModel)
        {
            _courseManageModel = courseManageModel;
            IsCourseEditReadOnly = true;
            IsCourseComboBoxEnabled = false;
            IsButtonAddCourseEnabled = true;
            IsButtonConfirmEnabled = false;
            ListBoxSelectedIndex = -1;
            GroupBoxTitle = CourseManageProperty.COURSE_EDIT_GROUP_BOX_TITLE;
        }

        public string GroupBoxTitle
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

        /// <summary>
        /// 取得Item型態的所有課程
        /// </summary>
        public List<DataItem> GetCurriculumAsItem()
        {
            return _courseManageModel.GetCurriculumAsItem();
        }

        /// <summary>
        /// 以課號取得課程
        /// </summary>
        public void GetCourseByCourseNumber(string number)
        {
            _course = _courseManageModel.GetCourseByCourseNumber(number);
            Number = _course.Number;
            Name = _course.Name;
            Stage = _course.Stage;
            Credit = _course.Credit;
            Teacher = _course.Teacher;
            RequiredOrElective = _course.RequiredOrElective;
            TeachAssistant = _course.TeachAssistant;
            Language = _course.Language;
            Note = _course.Note;
            Hour = _course.Hour;
        }

    }
}
