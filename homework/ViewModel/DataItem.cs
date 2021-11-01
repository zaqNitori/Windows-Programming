using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.ViewModel
{
    public class DataItem
    {
        public DataItem(string value, string text)
        {
            Text = text;
            Value = value;
        }

        public string Text
        { 
            get; set; 
        }

        public string Value 
        { 
            get; set; 
        }

        /// <summary>
        /// 取得字串
        /// </summary>
        /// <history>
        ///     1.  2021.10.31  create function
        /// </history>
        public override string ToString() 
        { 
            return Text; 
        }
    }
}
