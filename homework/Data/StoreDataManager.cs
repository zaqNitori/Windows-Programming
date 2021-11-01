using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using homework.ViewModel;

namespace homework.Data
{
    public class StoreDataManager
    {

        private Curriculum _curriculum;
        private BindingList<Course> _chosenCourses;
        private List<Department> _departments;

        public StoreDataManager()
        {
            _curriculum = new Curriculum();
            _chosenCourses = new BindingList<Course>();
            _departments = new List<Department>();

        }

        #region Public

        /// <summary>
        /// 新增各班課程表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public void AddCurriculum(string name, List<Course> courses)
        {
            _departments.Add(new Department(name, courses));
            foreach (var course in courses)
            {
                if (!GetCurriculumCourses().ContainsKey(course.Number))
                {
                    GetCurriculumCourses().Add(course.Number, course);
                }
            }
        }

        /// <summary>
        /// 把選取的課程加入課表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
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
        public void AddCourse(Course course, string className)
        {
            foreach (var dep in _departments)
            {
                if (dep.DepartmentName.Equals(className))
                {
                    GetDepartmentCourses(dep).Add(course);
                }
            }
            _curriculum.Courses.Add(course.Number, course);
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
                    RemoveCourse(GetDepartmentCourses(dep), courseNumber);
                    break;
                }
            }
            _curriculum.Courses.Remove(courseNumber);
        }

        /// <summary>
        /// 退選課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history> 
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
        /// 取得所有課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public Dictionary<string, Course> GetCurriculumCourses()
        {
            return _curriculum.Courses;
        }

        /// <summary>
        /// 取得所有班級名稱
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<Department> GetAllDepartment()
        {
            return _departments;
        }

        /// <summary>
        /// 用班級名稱取得課表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public List<Course> GetCoursesByDepartmentName(string name)
        {
            foreach (var dep in _departments)
            {
                if (GetDepartmentName(dep).Equals(name))
                {
                    return GetDepartmentCourses(dep);
                }
            }
            return new List<Course>();
        }

        /// <summary>
        /// 用班級名稱取得課表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public Course GetCourseByCourseNumber(string number)
        {
            return _curriculum.Courses[number];
        }

        /// <summary>
        /// 取得以選取的課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
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
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private string GetDepartmentName(Department department)
        {
            return department.DepartmentName;
        }

        /// <summary>
        /// 取得科系名稱
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private List<Course> GetDepartmentCourses(Department department)
        {
            return department.Courses;
        }

        /// <summary>
        /// 用課號取得班級名稱
        /// </summary>
        /// <history>
        ///     1.  2021.10.31  create function
        /// </history>
        public string GetDepartmentNameByCourseNumber(string number)
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

        #endregion

        /// <summary>
        /// 移除課程
        /// </summary>
        private void RemoveCourse(List<Course> courses, string courseNumber)
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

        #endregion

    }
}
