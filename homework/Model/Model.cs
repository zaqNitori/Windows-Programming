using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace homework.Model
{
    public class Model
    {
        public Model()
        {

        }

        /// <summary>
        /// 取得畫面上選取到的資料內容
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public string GetSelectedData(DataGridViewRowCollection dataSource)
        {
            string message = string.Empty;
            foreach (DataGridViewRow row in dataSource)
            {
                if (Convert.ToBoolean(row.Cells["checkBoxCol"].Value) == true)
                {
                    message += Convert.ToString(row.Cells[ViewModel.CourseProperty.Number.ToString()].Value) 
                        + Convert.ToString(row.Cells[ViewModel.CourseProperty.Name.ToString()].Value) 
                        + Environment.NewLine;
                }
            }
            return message;
        }

    }
}
