using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.ViewModel;

namespace homework.Data
{
    public class DataItemManager
    {
        /// <summary>
        /// 將dictionary 轉成 list
        /// </summary>
        /// <history>
        ///     1.  2021.10.31  create function
        /// </history>
        public static List<DataItem> GetDataItems(Dictionary<string, Course> courses)
        {
            List<DataItem> dataItems = new List<DataItem>();

            foreach (var c in courses)
            {
                dataItems.Add(new DataItem(c.Key, c.Value.Name));
            }
            return dataItems;
        }
    }
}
