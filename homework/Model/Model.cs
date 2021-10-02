using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace homework.Model
{
    public class Model
    {
        private CourseCrawler _courseCrawler;
        public Model(CourseCrawler courseCrawler)
        {
            _courseCrawler = courseCrawler;
        }

        /// <summary>
        /// 取得課程資訊
        /// </summary>
        /// <returns>Course Data</returns>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public List<ViewModel.Course> GetCourse(string url)
        {
            return _courseCrawler.GetCourse(url);
        }
    }
}
