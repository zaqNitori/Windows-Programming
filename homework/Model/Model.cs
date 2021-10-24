using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using homework.Builder;

namespace homework.Model
{
    public class Model
    {
        private CourseCrawler _courseCrawler;
        private CourseAnalyzer _courseAnalyzer;

        public Model(CourseCrawler courseCrawler)
        {
            _courseCrawler = courseCrawler;
            _courseAnalyzer = new CourseAnalyzer();
        }

        /// <summary>
        /// 取得課程資訊
        /// </summary>
        /// <returns>Course Data</returns>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public List<ViewModel.Course> GetCourse()
        {
            HtmlNodeCollection nodeCollection = _courseCrawler.GetCourseNodeCollection();
            return _courseAnalyzer.AnalyzeCourse(nodeCollection);
        }

    }
}
