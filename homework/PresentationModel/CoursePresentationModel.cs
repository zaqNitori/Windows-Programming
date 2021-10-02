using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.PresentationModel
{
    public class CoursePresentationModel
    {
        private bool _isButtonSendEnable = false;
        private bool _isButtonShowSelectResultEnable = true;

        public CoursePresentationModel()
        {

        }

        /// <summary>
        /// Get Course Data from HTMLParser
        /// </summary>
        /// <returns>Course Data</returns>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public List<ViewModel.Course> GetCourse(string url)
        {
            return HTMLParser.GetCourse(url);
        }

        /// <summary>
        /// btnSend status
        /// </summary>
        public bool IsButtonSendEnable()
        {
            return _isButtonSendEnable;
        }

        /// <summary>
        /// btnShowSelectResult status
        /// </summary>
        public bool IsButtonShowSelectResultEnable()
        {
            return _isButtonShowSelectResultEnable;
        }

    }
}
