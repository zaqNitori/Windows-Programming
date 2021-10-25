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
        private CourseModel _courseModel;

        public CourseSelectResultPresentationModel(CourseModel courseModel)
        {
            _courseModel = courseModel;
        }

        /// <summary>
        /// 取得選課結果
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history> 
        public BindingList<Course> GetSelectedCourses()
        {
            return _courseModel.GetSelectedCourses();
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

    }
}
