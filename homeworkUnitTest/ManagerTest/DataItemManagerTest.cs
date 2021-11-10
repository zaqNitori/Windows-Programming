using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using homework.Manager;
using homework.ViewModel;
using System;

namespace homeworkUnitTest.ManagerTest
{
    [TestClass]
    public class DataItemManagerTest
    {
        /// <summary>
        /// 測試將 dictionary 資料來源，轉成DataItem
        /// </summary>
        [TestMethod]
        public void TestGetDataItemByDictionary()
        {
            string key = "123";
            Course course = new Course();
            course.Name = "456";
            Dictionary<string, Course> sources = new Dictionary<string, Course>();
            sources.Add(key, course);

            List<DataItem> dataItems = DataItemManager.GetDataItems(sources);
            Assert.AreEqual(key, dataItems[0].Value);
            Assert.AreEqual(course.Name, dataItems[0].Text);
        }

        /// <summary>
        /// 測試將 List 資料來源，轉成DataItem
        /// </summary>
        [TestMethod]
        public void TestGetDataItemByList()
        {
            string name = "test";
            List<Department> departments = new List<Department>();
            departments.Add(new Department(name, null));

            List<DataItem> dataItems = DataItemManager.GetDataItems(departments);
            Assert.AreEqual(name, dataItems[0].Text);
            Assert.AreEqual(name, dataItems[0].Value);
        }

    }
}
