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
            _courses = new List<Course>();
        }

        /// <summary>
        /// 從htmlCode擷取出課程資訊
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        public List<Course> AnalyzeCourse(HtmlNodeCollection nodeCollection)
        {

            foreach (var node in nodeCollection)
            {
                HtmlNodeCollection nodeTableDatas = node.ChildNodes;
                nodeTableDatas.RemoveAt(0);
                _courses.Add(BuildCourse(nodeTableDatas));
            }

            return _courses;
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

    }
}
