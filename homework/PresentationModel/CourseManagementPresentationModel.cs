using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;

namespace homework.PresentationModel
{
    public class CourseManagementPresentationModel
    {
        private CourseModel _courseModel;

        public CourseManagementPresentationModel(CourseModel courseModel)
        {
            _courseModel = courseModel;
        }
    }
}
