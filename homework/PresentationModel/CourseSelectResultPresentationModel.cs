using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;
using homework.ViewModel;

namespace homework.PresentationModel
{
    public class CourseSelectResultPresentationModel
    {
        public event CourseChangedEventHandler _courseChanged;
        public delegate void CourseChangedEventHandler();
        private CourseSelectModel _courseModel;

        public CourseSelectResultPresentationModel(CourseSelectModel courseModel)
        {
            _courseModel = courseModel;
            _courseModel._courseChanged += NotifyCourseChanged;
        }

        /// <summary>
        /// 取得選課結果
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history> 
        public BindingList<Course> GetChosenCourses()
        {
            return _courseModel.GetChosenCourses();
        }

        /// <summary>
        /// 退選課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history> 
        public void DropCourse(int index)
        {
            _courseModel.DropCourse(index);
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
