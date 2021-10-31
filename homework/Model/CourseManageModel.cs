using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Data;
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

    }
}
