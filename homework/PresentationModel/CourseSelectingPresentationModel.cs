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

        private CourseModel _courseModel;
        private HashSet<string> _courseSelectData;
        private const string ADD_COURSE_SUCCESS = "加選成功";
        private const string ADD_COURSE_FAIL = "加選失敗";

        public CourseSelectingPresentationModel(CourseModel courseModel)
        {
            _courseModel = courseModel;
            _courseSelectData = new HashSet<string>();
            IsButtonSendEnable = false;
            IsButtonShowSelectResultEnable = true;
            _courseModel._courseDropped += NotifyCourseChanged;
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
        /// GridCheckBox點擊事件trigger 
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        /// <summary>
        /// 紀錄當前畫面上checkbox的狀態
        /// </summary>
        public void SetCourseCheckBoxStatus(string courseId)
        {
            if (_courseSelectData.Contains(courseId))
            {
                _courseSelectData.Remove(courseId);
            }
            else
            {
                _courseSelectData.Add(courseId);
            }

            IsButtonSendEnable = (_courseSelectData.Count == 0) ? false : true;
            NotifyModelChanged();
        }

        /// <summary>
        /// 取得畫面上選取到的資料內容
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public string GetSelectedResult()
        {
            string message = string.Empty;
            List<string> selectIndex;
            
            if (_courseSelectData.Count > 0)
            {
                selectIndex = _courseSelectData.ToList();
                selectIndex.Sort();
                foreach (string str in selectIndex)
                {
                    message += str + Environment.NewLine;
                }
            }
            return message;
        }

        /// <summary>
        /// 取得所有班級名稱
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<string> GetAllDepartment()
        {
            return _courseModel.GetAllDepartmentName();
        }

        /// <summary>
        /// 用班級名稱取得課表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<Course> GetCourseByDepartmentName(string name)
        {
            return _courseModel.GetCourseByDepartmentName(name);
        }

        /// <summary>
        /// 送出課表，先檢查
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public void SendSelectedCourses()
        {
            string errorMessage = _courseModel.CheckCoursesConflict(_courseSelectData.ToList());

            if (string.IsNullOrEmpty(errorMessage))
            {
                _courseSelectData.Clear();
                _courseModel.AddSelectedCourses();
                MessageBox.Show(ADD_COURSE_SUCCESS);
                NotifyCourseChanged();
            }
            else
            {
                MessageBox.Show(ADD_COURSE_FAIL + Environment.NewLine + errorMessage);
            }

        }

        /// <summary>
        /// 課程送出後，重整畫面 
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private void NotifyCourseChanged()
        {
            if (_courseChanged != null)
                _courseChanged();
        }

    }
}