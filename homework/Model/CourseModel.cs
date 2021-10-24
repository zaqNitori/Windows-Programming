using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using homework.Builder;
using homework.ViewModel;

namespace homework.Model
{
    public class CourseModel
    {
        private CourseCrawler _courseCrawler;
        private CourseAnalyzer _courseAnalyzer;
        private Curriculum _curriculum;

        private List<Department> _departments;

        public CourseModel()
        {
            _courseCrawler = new CourseCrawler();
            _courseAnalyzer = new CourseAnalyzer();
            _departments = new List<Department>();
            _curriculum = new Curriculum();

        }

        /// <summary>
        /// 取得課程資訊
        /// </summary>
        /// <returns>Course Data</returns>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public List<Course> GetCourse()
        {
            FetchCourseInfo(new List<string>());
            return _courseAnalyzer.GetCourses();
        }

        /// <summary>
        /// 爬取課程資訊並儲存
        /// </summary>
        /// <returns>Course Data</returns>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public void FetchCourseInfo(List<string> courseUrl)
        {
            String departmentName;
            courseUrl.Add("https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433");

            foreach (var url in courseUrl)
            {
                HtmlNodeCollection nodeCollection = _courseCrawler.GetCourseNodeCollection(url);
                _courseAnalyzer.AnalyzeCourse(nodeCollection);

                departmentName = _courseCrawler.DepartmentName;
                _curriculum.Courses.Add(departmentName, _courseAnalyzer.GetCourses());
                _departments.Add(new Department(departmentName));

            }
        }

    }
}
