using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using homework.Model;
using homework.ViewModel;

namespace homework.PresentationModel
{
    public class CourseSelectingPresentationModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public event CourseChangedEventHandler _courseChanged;
        public delegate void CourseChangedEventHandler();

        private CourseSelectModel _courseModel;
        private HashSet<string> _courseSelectData;
        private const string ADD_COURSE_SUCCESS = "加選成功";
        private const string ADD_COURSE_FAIL = "加選失敗";

        public CourseSelectingPresentationModel(CourseSelectModel courseModel)
        {
            _courseModel = courseModel;
            _courseSelectData = new HashSet<string>();
            IsButtonSendEnable = false;
            IsButtonShowSelectResultEnable = true;
            _courseModel._courseChanged += NotifyCourseChanged;
        }

        public bool IsButtonSendEnable
        {
            get; set;
        }

        public bool IsButtonShowSelectResultEnable
        {
            get; set;
        }

        /// <summary>
        /// 取得model
        /// </summary>
        public CourseSelectModel GetCourseSelectModel()
        {
            return _courseModel;
        }

        /// <summary>
        /// GridCheckBox點擊事件trigger 
        /// </summary>
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        /// <summary>
        /// 紀錄當前畫面上checkbox的狀態
        /// </summary>
        public void SetCourseCheckBoxStatus(string courseNumber)
        {
            if (_courseSelectData.Contains(courseNumber))
            {
                _courseSelectData.Remove(courseNumber);
            }
            else
            {
                _courseSelectData.Add(courseNumber);
            }

            IsButtonSendEnable = (_courseSelectData.Count == 0) ? false : true;
            NotifyModelChanged();
        }

        /// <summary>
        /// 取得所有班級名稱
        /// </summary>
        public List<string> GetAllClassName()
        {
            return _courseModel.GetAllClassName();
        }

        /// <summary>
        /// 用班級名稱取得課表
        /// </summary>
        public List<Course> GetCourseByClassName(string name)
        {
            return _courseModel.GetCoursesByClassName(name);
        }

        /// <summary>
        /// 送出課表，先檢查
        /// </summary>
        public string SendSelectedCourses()
        {
            List<string> courses = _courseSelectData.ToList();
            string errorMessage = _courseModel.CheckCoursesConflict(courses);

            if (string.IsNullOrEmpty(errorMessage))
            {
                _courseSelectData.Clear();
                _courseModel.AddSelectedCourses(courses);
                NotifyCourseChanged();
                return ADD_COURSE_SUCCESS;
            }
            else
            {
                return ADD_COURSE_FAIL + Environment.NewLine + errorMessage;
            }

        }

        /// <summary>
        /// 課程送出後，重整畫面 
        /// </summary>
        private void NotifyCourseChanged()
        {
            if (_courseChanged != null)
                _courseChanged();
        }

    }
}