using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;

namespace homework.PresentationModel
{
    public class StartUpPresentationModel
    {
        private List<string> _courseUrl;
        private CourseSelectModel _courseModel;

        public StartUpPresentationModel(CourseSelectModel courseModel)
        {
            IsButtonCourseManagementEnabled = true;
            IsButtonCourseSelectingEnabled = true;
            IsButtonExitEnabled = true;
            _courseUrl = new List<string>();
            _courseModel = courseModel;
        }

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        public bool IsButtonCourseSelectingEnabled
        {
            get; set;
        }

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        public bool IsButtonCourseManagementEnabled
        {
            get; set;
        }

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        public bool IsButtonExitEnabled
        {
            get; set;
        }

    }
}
