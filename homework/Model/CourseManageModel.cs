using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Builder;
using homework.Manager;
using homework.ViewModel;
using HtmlAgilityPack;

namespace homework.Model
{
    public class CourseManageModel
    {
        public event ProgressChangedEventHandler _progressChanged;
        public delegate void ProgressChangedEventHandler();
        private StoreDataManager _storeDataManager;
        private CourseCrawler _courseCrawler;
        private CourseAnalyzer _courseAnalyzer;

        public CourseManageModel(StoreDataManager storeDataManager)
        {
            _courseCrawler = new CourseCrawler();
            _courseAnalyzer = new CourseAnalyzer();
            _storeDataManager = storeDataManager;
        }

        /// <summary>
        /// 取得Item型態的所有課程
        /// </summary>
        public List<DataItem> GetCurriculumAsItem()
        {
            Dictionary<string, Course> curriculum = _storeDataManager.GetCurriculumCourses();

            return DataItemManager.GetDataItems(curriculum);
        }

        /// <summary>
        /// 取得Item型態的所有班級名稱
        /// </summary>
        public List<DataItem> GetClassNameAsItem()
        {
            List<Department> classes = _storeDataManager.GetAllClass();

            return DataItemManager.GetDataItems(classes);
        }

        /// <summary>
        /// 用課號取得班級名稱
        /// </summary>
        public string GetClassNameByCourseNumber(string number)
        {
            return _storeDataManager.GetClassNameByCourseNumber(number);
        }

        /// <summary>
        /// 用課號取得課程
        /// </summary>
        public Course GetCourseByCourseNumber(string number)
        {
            Course course = _storeDataManager.GetCourseByCourseNumber(number);
            return new Course(course);
        }

        /// <summary>
        /// 新增課程到指定班級
        /// </summary>
        public void AddCourse(Course course, string className)
        {
            _storeDataManager.AddCourseToClass(course, className);
        }

        /// <summary>
        /// 修改課程，先刪除，再新增
        /// </summary>
        public void EditCourse(Course course, string className, string originalCourseNumber)
        {
            string originClassName = GetClassNameByCourseNumber(originalCourseNumber);
            _storeDataManager.RemoveCourse(originClassName, originalCourseNumber);
            _storeDataManager.AddCourseToClass(course, className);
        }

        /// <summary>
        /// 確認課號是否存在
        /// </summary>
        public bool CheckIsCourseNumberConflict(string courseNumber)
        {
            return _storeDataManager.IsCourseNumberExist(courseNumber);
        }

        /// <summary>
        /// 爬取課程資訊並儲存
        /// </summary>
        public void FetchCourseInfo(List<string> courseUrl)
        {
            List<Course> courses;
            string className;

            foreach (var url in courseUrl)
            {
                HtmlNodeCollection nodeCollection = _courseCrawler.GetCourseNodeCollection(url);
                _courseAnalyzer.AnalyzeCourse(nodeCollection);

                courses = _courseAnalyzer.GetCourses();
                className = _courseCrawler.ClassName;
                _storeDataManager.AddCourse(className, courses);
                NotifyProgressChanged();
            }
        }

        /// <summary>
        /// 匯入資工系課程 進度通知
        /// </summary>
        private void NotifyProgressChanged()
        {
            if (_progressChanged != null)
                _progressChanged();
        }

        /// <summary>
        /// 匯入資工系課程
        /// </summary>
        public void ImportComputerScienceCourses()
        {
            List<string> courseUrl = new List<string>();
            courseUrl.Add(Common.COMPUTER_SCIENCE_GRADE1_COURSE_URL);
            courseUrl.Add(Common.COMPUTER_SCIENCE_GRADE2_COURSE_URL);
            courseUrl.Add(Common.COMPUTER_SCIENCE_GRADE3_COURSE_URL);
            courseUrl.Add(Common.COMPUTER_SCIENCE_GRADE4_COURSE_URL);
            FetchCourseInfo(courseUrl);
        }

    }
}
