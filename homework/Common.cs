using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework
{
    public class Common
    {
        public const string COMPUTER_SCIENCE_GRADE4_COURSE_URL = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2314";
        public const string COMPUTER_SCIENCE_GRADE3_COURSE_URL = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
        public const string COMPUTER_SCIENCE_GRADE2_COURSE_URL = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=109&sem=1&code=2433";
        public const string COMPUTER_SCIENCE_GRADE1_COURSE_URL = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=108&sem=1&code=2433";

        /// <summary>
        /// 啟用datagridview的doublebuffered
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public static void ActivateDoubleBuffer(DataGridView dataGridView)
        {
            const string DOUBLE_BUFFERED = "DoubleBuffered";

            Type type = dataGridView.GetType();
            PropertyInfo propertyInfo = type.GetProperty(DOUBLE_BUFFERED, BindingFlags.Instance | BindingFlags.NonPublic);
            propertyInfo.SetValue(dataGridView, true, null);
        }
    }
}
