using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using homework.ViewModel;

namespace homework.Builder
{
    public class CourseAnalyzer
    {
        private List<Course> _courses;

        public CourseAnalyzer()
        {
            ResetCourses();
        }

        /// <summary>
        /// 取得建立完成的課程資訊
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<Course> GetCourses()
        {
            return _courses;
        }

        /// <summary>
        /// 從htmlCode擷取出課程資訊
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        public void AnalyzeCourse(HtmlNodeCollection nodeCollection)
        {
            ResetCourses();

            foreach (var node in nodeCollection)
            {
                HtmlNodeCollection nodeTableDatas = node.ChildNodes;
                nodeTableDatas.RemoveAt(0);
                _courses.Add(BuildCourse(nodeTableDatas));
            }

        }

        /// <summary>
        /// 呼叫buildere建立課程
        /// </summary>
        /// <returns>Course Data</returns>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        private Course BuildCourse(HtmlNodeCollection nodeData)
        {
            CourseBuilder courseBuilder = new CourseBuilder();
            courseBuilder.BuildCourseByNodeCollection(nodeData);
            return courseBuilder.GetCourse();
        }

        /// <summary>
        /// 重新產生，避免影響到之前的課程
        /// </summary>
        /// <returns>Course Data</returns>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private void ResetCourses()
        {
            _courses = new List<Course>();
        }

    }
}
