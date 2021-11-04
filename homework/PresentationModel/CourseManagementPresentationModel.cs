using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;
using homework.ViewModel;

namespace homework.PresentationModel
{
    public partial class CourseManagementPresentationModel
    {
        public event ListBoxChangedEventHandler _listBoxChanged;
        public delegate void ListBoxChangedEventHandler();
        public event GroupBoxAndButtonChangedEventHandler _groupBoxAndButtonChanged; 
        public delegate void GroupBoxAndButtonChangedEventHandler();
        private CourseManageModel _courseManageModel;
        private Course _originalCourse;
        private string _originalDepartmentName;

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

        public string Sunday
        {
            get; set;
        }

        public string Monday
        {
            get; set;
        }

        public string Tuesday
        {
            get; set;
        }

        public string Wednesday
        {
            get; set;
        }

        public string Thursday
        {
            get; set;
        }

        public string Friday
        {
            get; set;
        }

        public string Saturday
        {
            get; set;
        }

        private string OriginalCourseNumber
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

    }
}
