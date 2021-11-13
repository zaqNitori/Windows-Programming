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
        public event GridChangedEventHandler _gridContentChanged;
        public delegate void GridChangedEventHandler();
        private CourseManageModel _courseManageModel;
        private Course _originalCourse;
        private string _originalClassName;
        private HashSet<int> _courseTimeRecord;

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
            _courseTimeRecord = new HashSet<int>();
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

        public string ClassName
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
        public List<DataItem> GetClassNameAsItem()
        {
            return _courseManageModel.GetClassNameAsItem();
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
            if (_courseManageModel.CheckIsCourseNumberConflict(Number))
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

    }
}
