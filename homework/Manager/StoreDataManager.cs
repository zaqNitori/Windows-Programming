using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using homework.ViewModel;

namespace homework.Manager
{
    public class StoreDataManager
    {
        public event CourseChangedEventHandler _courseChanged;
        public delegate void CourseChangedEventHandler();
        private Curriculum _curriculum;
        private BindingList<Course> _chosenCourses;
        private List<Department> _departments;

        public StoreDataManager()
        {
            _curriculum = new Curriculum();
            _chosenCourses = new BindingList<Course>();
            _departments = new List<Department>();
            _courseChanged += RefreshSelectedResult;
        }

        #region Public

        /// <summary>
        /// 新增課程到班級及課程總表
        /// </summary>
        public void AddCourse(string name, List<Course> courses)
        {
            AddCurriculum(courses);
            AddClassCourse(name, courses);
        }

        /// <summary>
        /// 把選取的課程加入課表
        /// </summary>
        public void AddSelectedCourses(List<Course> courses)
        {
            foreach (var c in courses)
            {
                _chosenCourses.Add(c);
            }
        }

        /// <summary>
        /// 新增課程到指定班級
        /// </summary>
        public void AddCourseToClass(Course course, string className)
        {
            bool isBreak = false;
            foreach (var dep in _departments)
            {
                if (dep.DepartmentName.Equals(className))
                {
                    GetClassCourses(dep).Add(course);
                    isBreak = true;
                    break;
                }
            }
            if (!isBreak)
            {
                AddClassCourse(className, course);
            }
            _curriculum.Courses.Add(course.Number, course);
            NotifyCourseChanged();
        }

        /// <summary>
        /// 用舊的班級名稱取得課程，再呼叫刪除功能
        /// </summary>
        public void RemoveCourse(string className, string courseNumber)
        {
            foreach (var dep in _departments)
            {
                if (dep.DepartmentName.Equals(className))
                {
                    RemoveCourseFromClass(GetClassCourses(dep), courseNumber);
                    break;
                }
            }
            _curriculum.Courses.Remove(courseNumber);
        }

        /// <summary>
        /// 退選課程
        /// </summary>
        public void DropCourse(int index)
        {
            if (_chosenCourses.Count > index)
                _chosenCourses.RemoveAt(index);
        }

        /// <summary>
        /// 確認課號是否已存在
        /// </summary>
        public bool IsCourseNumberExist(string courseNumber)
        {
            return _curriculum.Courses.ContainsKey(courseNumber);
        }

        #region Get

        /// <summary>
        /// 用課號取得班級名稱
        /// </summary>
        public string GetClassNameByCourseNumber(string number)
        {
            foreach (var dep in _departments)
            {
                foreach (var c in dep.Courses)
                {
                    if (c.Number.Equals(number))
                    {
                        return dep.DepartmentName;
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 取得所有課程
        /// </summary>
        public Dictionary<string, Course> GetCurriculumCourses()
        {
            return _curriculum.Courses;
        }

        /// <summary>
        /// 取得所有班級名稱
        /// </summary>
        public List<Department> GetAllClass()
        {
            return _departments;
        }

        /// <summary>
        /// 用班級名稱取得課表
        /// </summary>
        public List<Course> GetCoursesByClassName(string name)
        {
            foreach (var dep in _departments)
            {
                if (GetClassName(dep).Equals(name))
                {
                    return GetClassCourses(dep);
                }
            }
            return new List<Course>();
        }

        /// <summary>
        /// 用班級名稱取得課表
        /// </summary>
        public Course GetCourseByCourseNumber(string number)
        {
            return _curriculum.Courses[number];
        }

        /// <summary>
        /// 取得以選取的課程
        /// </summary>
        public BindingList<Course> GetChosenCourses()
        {
            return _chosenCourses;
        }

        #endregion

        #endregion

        #region Private

        #region Get

        /// <summary>
        /// 取得科系名稱
        /// </summary>
        private string GetClassName(Department department)
        {
            return department.DepartmentName;
        }

        /// <summary>
        /// 取得科系名稱
        /// </summary>
        private List<Course> GetClassCourses(Department department)
        {
            return department.Courses;
        }

        #endregion

        /// <summary>
        /// 新增課程總表
        /// </summary>
        private void AddCurriculum(List<Course> courses)
        {
            foreach (var course in courses)
            {
                if (!GetCurriculumCourses().ContainsKey(course.Number))
                {
                    GetCurriculumCourses().Add(course.Number, course);
                }
            }
        }

        /// <summary>
        /// 新增各班課程表
        /// </summary>s
        private void AddClassCourse(string name, List<Course> courses)
        {
            foreach (var dep in _departments)
            {
                if (dep.DepartmentName.Equals(name))
                {
                    return;
                }
            }
            _departments.Add(new Department(name, courses));
        }

        /// <summary>
        /// 新增各班課程表
        /// </summary>s
        private void AddClassCourse(string name, Course course)
        {
            List<Course> courses = new List<Course>();
            courses.Add(course);
            _departments.Add(new Department(name, courses));
        }

        /// <summary>
        /// 移除課程
        /// </summary>
        private void RemoveCourseFromClass(List<Course> courses, string courseNumber)
        {
            foreach (var c in courses)
            {
                if (c.Number.Equals(courseNumber))
                {
                    courses.Remove(c);
                    return;
                }
            }
        }

        /// <summary>
        /// 課程修改事件，觸發bindingList重新拉值 
        /// </summary>
        private void RefreshSelectedResult()
        {
            BindingList<Course> courses = new BindingList<Course>();
            foreach (var c in _chosenCourses)
            {
                courses.Add(_curriculum.Courses[c.Number]);
            }

            _chosenCourses = courses;
        }

        /// <summary>
        /// 課程修改事件要觸發 課程畫面更新 
        /// </summary>
        private void NotifyCourseChanged()
        {
            if (_courseChanged != null)
                _courseChanged();
        }

        #endregion

    }
}
