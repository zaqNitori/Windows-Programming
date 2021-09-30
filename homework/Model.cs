using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace homework
{
    public class Model
    {
        public Model()
        {

        }

        public string GetSelectedData(DataGridViewRowCollection dataSRC)
        {
            string msg = string.Empty;
            foreach (DataGridViewRow row in dataSRC)
            {
                if (Convert.ToBoolean(row.Cells["checkBoxCol"].Value) == true)
                {
                    msg += Convert.ToString(row.Cells["Number"].Value) 
                        + Convert.ToString(row.Cells["Name"].Value) 
                        + Environment.NewLine;
                }
            }
            return msg;
        }

    }
}
