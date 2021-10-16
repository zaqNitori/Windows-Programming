using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.PresentationModel
{
    public class StartUpPresentationModel
    {
        private bool _isButtonCourseSelectingEnabled = true;
        private bool _isButtonCourseManagementEnabled = true;
        private bool _isButtonExitEnabled = true;

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        /// <returns>button狀態</returns>
        /// <history>
        ///     1.  2021.10.16  create function
        /// </history>
        public bool IsButtonCourseSelectingEnabled()
        {
            return _isButtonCourseSelectingEnabled;
        }

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        /// <returns>button狀態</returns>
        /// <history>
        ///     1.  2021.10.16  create function
        /// </history>
        public bool IsButtonCourseManagementEnabled()
        {
            return _isButtonCourseManagementEnabled;
        }

        /// <summary>
        /// 回傳button狀態 
        /// </summary>
        /// <returns>button狀態</returns>
        /// <history>
        ///     1.  2021.10.16  create function
        /// </history>
        public bool IsButtonExitEnabled()
        {
            return _isButtonExitEnabled;
        }

    }
}
