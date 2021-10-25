using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using homework.Builder;
using homework.ViewModel;
using homework.Data;
using System.ComponentModel;

namespace homework.Model
{
    public class CourseModel
    {
        public event CourseChangedEventHandler _courseDropped;
        public delegate void CourseChangedEventHandler();
        private CourseCrawler _courseCrawler;
        private CourseAnalyzer _courseAnalyzer;
        private StoreDataManager _storeDataManager;
        private List<Course> _selectedCourses;
        private const string COMMA = "，"; 
        public const string SAME_COURSE_NAME_TEXT = "課程名稱相同 : ";
        public const string SAME_COURSE_TIME_TEXT = "課程衝堂 : ";

        public CourseModel()
        {
            _courseCrawler = new CourseCrawler();
            _courseAnalyzer = new CourseAnalyzer();
            _storeDataManager = new StoreDataManager();

        }

        /// <summary>
        /// 爬取課程資訊並儲存
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public void FetchCourseInfo(List<string> courseUrl)
        {
            List<Course> courses;
            String departmentName;

            foreach (var url in courseUrl)
            {
                HtmlNodeCollection nodeCollection = _courseCrawler.GetCourseNodeCollection(url);
                _courseAnalyzer.AnalyzeCourse(nodeCollection);

                courses = _courseAnalyzer.GetCourses();
                departmentName = _courseCrawler.DepartmentName;
                _storeDataManager.AddCurriculum(departmentName, courses);
            }

        }

        /// <summary>
        /// 取得所有班級名稱
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<string> GetAllDepartmentName()
        {
            List<Department> departments = _storeDataManager.GetAllDepartment();
            List<string> departmentsName = new List<string>();
            foreach (var dep in departments)
            {
                departmentsName.Add(dep.DepartmentName);
            }
            return departmentsName;
        }

        /// <summary>
        /// 用班級名稱取得可顯示的課表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<Course> GetCourseByDepartmentName(string name)
        {
            List<Course> allCourses = _storeDataManager.GetCourseByDepartmentName(name);
            List<Course> showCourses = new List<Course>();
            foreach (var ac in allCourses)
            {
                if (!IsCourseNumberConflict(ac))
                {
                    showCourses.Add(ac);
                }
            }
            return showCourses;
        }

        /// <summary>
        /// 把已經選取的課號從總課表上移除
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private bool IsCourseNumberConflict(Course course)
        {
            BindingList<Course> chosenCourses = _storeDataManager.GetChosenCourses();
            foreach (var cc in chosenCourses)
            {
                if (GetCourseNumber(cc) == GetCourseNumber(course))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 用課號取得課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public Course GetCurriculumByCourseId(string id)
        {
            return _storeDataManager.GetCourseByCourseId(id);
        }

        /// <summary>
        /// 驗證是否有衝突
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history> 
        public string CheckCoursesConflict(List<String> courses)
        {
            string courseNameConflictErrorMessage = string.Empty;
            string courseTimeConflictErrorMessage = string.Empty;
            _selectedCourses = ConvertSelectedCourses(courses);
            BindingList<Course> chosenCourses = _storeDataManager.GetChosenCourses();

            foreach (var s in _selectedCourses)
            {
                foreach (var c in chosenCourses)
                {
                    courseNameConflictErrorMessage += CheckIfCourseNameConflict(s, c);
                    courseTimeConflictErrorMessage += CheckIfCourseTimeComplicated(s, c);
                }
            }

            return courseNameConflictErrorMessage + courseTimeConflictErrorMessage;
        }

        /// <summary>
        /// 將選取課程放入課表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public void AddSelectedCourses()
        {
            _storeDataManager.AddSelectedCourses(_selectedCourses);
        }

        /// <summary>
        /// 藉由課號清單轉換成課程清單
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private List<Course> ConvertSelectedCourses(List<String> courses)
        {
            List<Course> selectedCourses = new List<Course>();

            foreach (var c in courses)
            {
                selectedCourses.Add(GetCurriculumByCourseId(c));
            }

            return selectedCourses;
        }

        /// <summary>
        /// 判別課程名稱
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private string CheckIfCourseNameConflict(Course course1, Course course2)
        {
            string errorMessage = "";
            if (GetCourseName(course2).Equals(GetCourseName(course1)))
                errorMessage += SAME_COURSE_NAME_TEXT + GetCourseNumber(course1) + GetCourseName(course1) + COMMA + GetCourseNumber(course2) + GetCourseName(course2) + Environment.NewLine;
            return errorMessage;
        }

        /// <summary>
        /// 取得課程名稱
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private string GetCourseName(Course course)
        {
            return course.Name;
        }

        /// <summary>
        /// 取得課程編號
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private string GetCourseNumber(Course course)
        {
            return course.Number;
        }

        /// <summary>
        /// 判別衝堂
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private string CheckIfCourseTimeComplicated(Course course1, Course course2)
        {
            string errorMessage = "";
            if (CheckTimeDuplicate(course1.Sunday, course2.Sunday)
                || CheckTimeDuplicate(course1.Monday, course2.Monday)
                || CheckTimeDuplicate(course1.Tuesday, course2.Tuesday)
                || CheckTimeDuplicate(course1.Wednesday, course2.Wednesday)
                || CheckTimeDuplicate(course1.Thursday, course2.Thursday)
                || CheckTimeDuplicate(course1.Friday, course2.Friday)
                || CheckTimeDuplicate(course1.Saturday, course2.Saturday))
                errorMessage += SAME_COURSE_TIME_TEXT + GetCourseNumber(course1) + GetCourseName(course1) + COMMA + GetCourseNumber(course2) + GetCourseName(course2) + Environment.NewLine;
            return errorMessage;
        }

        /// <summary>
        /// 衝堂
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private bool CheckTimeDuplicate(string courseTime1, string courseTime2)
        {
            string[] courseTimeArray = courseTime1.Split();
            foreach (string time in courseTimeArray)
            {
                if (courseTime2.IndexOf(time) >= 0 && time != "")
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 取得以選取的課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public BindingList<Course> GetSelectedCourses()
        {
            return _storeDataManager.GetChosenCourses();
        }

        /// <summary>
        /// 退選課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history> 
        public void DropCourse(int index)
        {
            _storeDataManager.DropCourse(index);
            NotifyCourseDropped();
        }

        /// <summary>
        /// Drop事件要觸發畫面更新 
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private void NotifyCourseDropped()
        {
            if (_courseDropped != null)
                _courseDropped();
        }

    }
}
