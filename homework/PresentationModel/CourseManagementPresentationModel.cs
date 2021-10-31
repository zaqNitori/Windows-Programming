using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;
using homework.ViewModel;

namespace homework.PresentationModel
{
    public class CourseManagementPresentationModel
    {
        private CourseManageModel _courseManageModel;

        public CourseManagementPresentationModel(CourseManageModel courseManageModel)
        {
            _courseManageModel = courseManageModel;
            IsCourseEditReadOnly = true;
        }

        public bool IsCourseEditReadOnly
        {
            get; set;
        }

        /// <summary>
        /// 取得Item型態的所有課程
        /// </summary>
        public List<DataItem> GetCurriculumAsItem()
        {
            return _courseManageModel.GetCurriculumAsItem();
        }

    }
}
