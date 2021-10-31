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
        private CourseModel _courseModel;

        public CourseManagementPresentationModel(CourseModel courseModel)
        {
            _courseModel = courseModel;
        }

        /// <summary>
        /// 取得Item型態的所有課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.31  create function
        /// </history>
        public List<DataItem> GetCurriculumAsItem()
        {
            return _courseModel.GetCurriculumAsItem();
        }

    }
}
