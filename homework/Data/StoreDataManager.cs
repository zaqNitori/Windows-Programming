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
        public List<Course> GetCourseByDepartmentName(string name)
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
        /// 用班級名稱取得課表
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public Course GetCourseByCourseId(string id)
        {
            return _curriculum.Courses[id];
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

    }
}
