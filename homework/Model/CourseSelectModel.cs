using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using homework.Builder;
using homework.ViewModel;
using homework.Manager;
using System.ComponentModel;

namespace homework.Model
{
    public class CourseSelectModel
    {
        public event CourseChangedEventHandler _courseChanged;
        public delegate void CourseChangedEventHandler();
        private StoreDataManager _storeDataManager;

        public CourseSelectModel(StoreDataManager storeDataManager)
        {
            _storeDataManager = storeDataManager;
            _storeDataManager._courseChanged += NotifyCourseChanged;
        }

        #region Public

        #region Get
        /// <summary>
        /// 取得所有班級名稱
        /// </summary>
        public List<string> GetAllClassName()
        {
            List<Department> classes = _storeDataManager.GetAllClass();
            List<string> classesName = new List<string>();
            foreach (var dep in classes)
            {
                classesName.Add(dep.DepartmentName);
            }
            return classesName;
        }

        /// <summary>
        /// 用班級名稱取得可顯示的課表
        /// </summary>
        public List<Course> GetCoursesByClassName(string name)
        {
            List<Course> allCourses = _storeDataManager.GetCoursesByClassName(name);
            List<Course> showCourses = new List<Course>();
            foreach (var ac in allCourses)
            {
                if (!IsCourseNumberConflict(ac) && !ac.Status.Equals(Common.COURSE_STATUS_CLOSE))
                {
                    showCourses.Add(ac);
                }
            }
            return showCourses;
        }

        /// <summary>
        /// 取得以選取的課程
        /// </summary>
        public BindingList<Course> GetChosenCourses()
        {
            return _storeDataManager.GetChosenCourses();
        }

        #endregion

        /// <summary>
        /// 退選課程
        /// </summary>
        public void DropCourse(int index)
        {
            _storeDataManager.DropCourse(index);
            NotifyCourseChanged();
        }

        /// <summary>
        /// 驗證所有已選取跟正被選取的課程是否有衝突
        /// </summary>
        public string CheckCoursesConflict(List<string> courses)
        {
            string errorMessage = string.Empty;
            List<Course> selectedCourses = ConvertSelectedCourses(courses);

            errorMessage += CheckSelectedCoursesConflict(selectedCourses);
            errorMessage += CheckExistedCoursesConflict(selectedCourses);

            return errorMessage;
        }

        /// <summary>
        /// 將選取課程放入課表
        /// </summary>
        public void AddSelectedCourses(List<string> courses)
        {
            List<Course> selectedCourses = ConvertSelectedCourses(courses);
            _storeDataManager.AddSelectedCourses(selectedCourses);
        }

        #endregion

        #region Private

        /// <summary>
        /// 把已經選取的課號從總課表上移除
        /// </summary>
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
        /// 驗證正被選取的課程是否有衝突
        /// </summary>
        private string CheckSelectedCoursesConflict(List<Course> selectedCourses)
        {
            string courseNameConflictErrorMessage = string.Empty;
            string courseTimeConflictErrorMessage = string.Empty;
            int length = selectedCourses.Count;

            for (var i = 0; i < length; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    courseNameConflictErrorMessage += CheckIfCourseNameConflict(selectedCourses[i], selectedCourses[j]);
                    courseTimeConflictErrorMessage += CheckIfCourseTimeComplicated(selectedCourses[i], selectedCourses[j]);
                }
            }

            return courseNameConflictErrorMessage + courseTimeConflictErrorMessage;
        }

        /// <summary>
        /// 驗證選取課程是否跟現在課表是否有衝突
        /// </summary>
        private string CheckExistedCoursesConflict(List<Course> selectedCourses)
        {
            string courseNameConflictErrorMessage = string.Empty;
            string courseTimeConflictErrorMessage = string.Empty;
            BindingList<Course> chosenCourses = _storeDataManager.GetChosenCourses();

            foreach (var s in selectedCourses)
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
        /// 藉由課號清單轉換成課程清單
        /// </summary>
        private List<Course> ConvertSelectedCourses(List<string> courses)
        {
            List<Course> selectedCourses = new List<Course>();

            foreach (var c in courses)
            {
                selectedCourses.Add(GetCourseByCourseNumber(c));
            }
            return selectedCourses;
        }

        /// <summary>
        /// 判別課程名稱
        /// </summary>
        private string CheckIfCourseNameConflict(Course course1, Course course2)
        {
            string errorMessage = "";
            if (GetCourseName(course2).Equals(GetCourseName(course1)))
                errorMessage += CourseSelectProperty.SAME_COURSE_NAME_TEXT + GetCourseNumber(course1) + GetCourseName(course1) 
                    + Common.COMMA + GetCourseNumber(course2) + GetCourseName(course2) + Common.NEW_LINE;
            return errorMessage;
        }

        /// <summary>
        /// 取得課程名稱
        /// </summary>
        private string GetCourseName(Course course)
        {
            return course.Name;
        }

        /// <summary>
        /// 取得課程編號
        /// </summary>
        private string GetCourseNumber(Course course)
        {
            return course.Number;
        }

        /// <summary>
        /// 用課號取得課程
        /// </summary>
        private Course GetCourseByCourseNumber(string number)
        {
            return _storeDataManager.GetCourseByCourseNumber(number);
        }

        /// <summary>
        /// 判別衝堂
        /// </summary>
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
                errorMessage += CourseSelectProperty.SAME_COURSE_TIME_TEXT + GetCourseNumber(course1) + GetCourseName(course1) 
                    + Common.COMMA + GetCourseNumber(course2) + GetCourseName(course2) + Common.NEW_LINE;
            return errorMessage;
        }

        /// <summary>
        /// 衝堂
        /// </summary>
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
        /// Drop事件要觸發畫面更新 
        /// </summary>
        private void NotifyCourseChanged()
        {
            if (_courseChanged != null)
                _courseChanged();
        }

        #endregion

    }
}
