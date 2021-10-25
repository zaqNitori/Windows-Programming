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
