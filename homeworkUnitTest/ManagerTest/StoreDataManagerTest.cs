using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using homework.Manager;
using homework.ViewModel;
using System;

namespace homeworkUnitTest.ManagerTest
{
    [TestClass]
    public class StoreDataManagerTest
    {
        private StoreDataManager _storeDataManager;

        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
        }

        /// <summary>
        /// 測試將 dictionary 資料來源，轉成DataItem
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
