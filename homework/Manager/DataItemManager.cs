using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.ViewModel;

namespace homework.Manager
{
    public class DataItemManager
    {
        /// <summary>
        /// 將dictionary 轉成 ItemList
        /// </summary>
        public static List<DataItem> GetDataItems(Dictionary<string, Course> courses)
        {
            List<DataItem> dataItems = new List<DataItem>();

            foreach (var c in courses)
            {
                dataItems.Add(new DataItem(c.Key, c.Value.Name));
            }
            return dataItems;
        }

        /// <summary>
        /// 將List 轉成 ItemList
        /// </summary>
        public static List<DataItem> GetDataItems(List<Department> departments)
        {
            List<DataItem> dataItems = new List<DataItem>();

            foreach (var dep in departments)
            {
                dataItems.Add(new DataItem(dep.DepartmentName, dep.DepartmentName));
            }

            return dataItems;
        }
    }
}
