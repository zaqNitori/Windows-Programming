using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.PresentationModel
{
    public class StartUpPresentationModel
    {

        public StartUpPresentationModel()
        {
            IsButtonCourseManagementEnabled = true;
            IsButtonCourseSelectingEnabled = true;
            IsButtonExitEnabled = true;
        }

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        /// <returns>button狀態</returns>
        /// <history>
        ///     1.  2021.10.16  create function
        ///     2.  2021.10.23  change function to property
        /// </history>
        public bool IsButtonCourseSelectingEnabled
        {
            get; set;
        }

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        /// <returns>button狀態</returns>
        /// <history>
        ///     1.  2021.10.16  create function
        ///     2.  2021.10.23  change function to property
        /// </history>
        public bool IsButtonCourseManagementEnabled
        {
            get; set;
        }

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        /// <returns>button狀態</returns>
        /// <history>
        ///     1.  2021.10.16  create function
        ///     2.  2021.10.23  change function to property
        /// </history>
        public bool IsButtonExitEnabled
        {
            get; set;
        }

    }
}
