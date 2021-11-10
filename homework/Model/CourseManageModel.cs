using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Manager;
using homework.ViewModel;

namespace homework.Model
{
    public class CourseManageModel
    {
        private StoreDataManager _storeDataManager;

        public CourseManageModel(StoreDataManager storeDataManager)
        {
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
        public List<DataItem> GetDepartmentNameAsItem()
        {
            List<Department> departments = _storeDataManager.GetAllDepartment();

            return DataItemManager.GetDataItems(departments);
        }

        /// <summary>
        /// 用課號取得班級名稱
        /// </summary>
        public string GetDepartmentNameByCourseNumber(string number)
        {
            return _storeDataManager.GetDepartmentNameByCourseNumber(number);
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
            _storeDataManager.AddCourse(course, className);
        }

        /// <summary>
        /// 修改課程，先刪除，再新增
        /// </summary>
        public void EditCourse(Course course, string className, string originalCourseNumber)
        {
            string originClassName = GetDepartmentNameByCourseNumber(originalCourseNumber);
            _storeDataManager.RemoveCourse(originClassName, originalCourseNumber);
            _storeDataManager.AddCourse(course, className);
        }

        /// <summary>
        /// 確認課號是否存在
        /// </summary>
        public bool CheckIsCourseNumberConflict(string courseNumber)
        {
            return _storeDataManager.IsCourseNumberExist(courseNumber);
        }

    }
}
