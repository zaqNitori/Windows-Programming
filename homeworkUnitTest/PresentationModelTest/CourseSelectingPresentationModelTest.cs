using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework.Manager;
using homework.PresentationModel;
using homework.Model;
using homework.ViewModel;
using System.Collections.Generic;
using System;

namespace homeworkUnitTest.PresentationModelTest
{
    [TestClass]
    public class CourseSelectingPresentationModelTest
    {
        const string URL = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
        private string _className = "資工三";
        private string _courseNumber = "55688";
        private StoreDataManager _storeDataManager;
        private CourseSelectModel _courseSelectModel;
        private CourseManageModel _courseManageModel;
        private CourseSelectingPresentationModel _courseSelectingPresentationModel;
        private PrivateObject _privateObject;
        private int notify = 0;

        /// <summary>
        /// 初始化設定
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
            _courseSelectModel = new CourseSelectModel(_storeDataManager);
            _courseManageModel = new CourseManageModel(_storeDataManager);
            _courseSelectingPresentationModel = new CourseSelectingPresentationModel(_courseSelectModel);
            _privateObject = new PrivateObject(_courseSelectingPresentationModel);
            FetchCourseInfo();
        }

        /// <summary>
        /// 初始化設定課程物件
        /// </summary>
        private void FetchCourseInfo()
        {
            _courseManageModel.FetchCourseInfo(new List<string> {URL});
        }

        /// <summary>
        /// 測試Notify功能用
        /// </summary>
        private void ChangeNotify()
        {
            notify = 10;
        }

        /// <summary>
        /// 測試 取得model
        /// </summary>
        [TestMethod]
        public void TestGetCourseSelectModel()
        {
            Assert.AreEqual(_courseSelectModel, _courseSelectingPresentationModel.GetCourseSelectModel());
        }

        /// <summary>
        /// 測試 取得model
        /// </summary>
        [TestMethod]
        public void TestIsButtonShowSelectResultEnableGetAndSet()
        {
            Assert.AreEqual(true, _courseSelectingPresentationModel.IsButtonShowSelectResultEnable);
            _courseSelectingPresentationModel.IsButtonShowSelectResultEnable = false;
            Assert.AreEqual(false, _courseSelectingPresentationModel.IsButtonShowSelectResultEnable);
        }

        /// <summary>
        /// 測試 Notify function
        /// </summary>
        [TestMethod]
        public void TestNotifyModelChanged()
        {
            _courseSelectingPresentationModel._modelChanged += ChangeNotify;
            Assert.AreEqual(0, notify);
            _privateObject.Invoke("NotifyModelChanged");
            Assert.AreEqual(10, notify);
        }

        /// <summary>
        /// 測試 Notify function
        /// </summary>
        [TestMethod]
        public void TestNotifyCourseChanged()
        {
            _courseSelectingPresentationModel._courseChanged += ChangeNotify;
            Assert.AreEqual(0, notify);
            _privateObject.Invoke("NotifyCourseChanged");
            Assert.AreEqual(10, notify);
        }

        /// <summary>
        /// 測試 是否點選課程，以修改畫面元件顯示狀態
        /// </summary>
        [TestMethod]
        public void TestSetCourseCheckBoxStatus()
        {
            Assert.AreEqual(false, _courseSelectingPresentationModel.IsButtonSendEnable);
            _courseSelectingPresentationModel.SetCourseCheckBoxStatus(_courseNumber);
            Assert.AreEqual(true, _courseSelectingPresentationModel.IsButtonSendEnable);
            _courseSelectingPresentationModel.SetCourseCheckBoxStatus(_courseNumber);
            Assert.AreEqual(false, _courseSelectingPresentationModel.IsButtonSendEnable);
        }

        /// <summary>
        /// 測試 取得所有班級名稱
        /// </summary>
        [TestMethod]
        public void TestGetAllClassName()
        {
            var classesName = _courseSelectingPresentationModel.GetAllClassName();
            Assert.AreEqual(1, classesName.Count);
            Assert.AreEqual(_className, classesName[0]);
        }

        /// <summary>
        /// 測試 取得所有班級名稱
        /// </summary>
        [TestMethod]
        public void TestGetCourseByClassName()
        {
            var courses = _courseSelectingPresentationModel.GetCourseByClassName(_className);
            Assert.AreEqual(12, courses.Count);
            Assert.AreEqual("資料庫系統", courses[4].Name);
            Assert.AreEqual("計算機網路", courses[5].Name);
        }

        /// <summary>
        /// 測試 送出課表前的檢查動作
        /// </summary>
        [TestMethod]
        [DataRow("291703", "291704", "加選失敗", "課程名稱相同 : 291703博雅選修課程，291704博雅選修課程")]
        [DataRow("291705", "291706", "加選成功", "")]
        public void TestSendSelectedCourses(string course1, string course2, string expect1, string expect2)
        {
            _courseSelectingPresentationModel.SetCourseCheckBoxStatus(course1);
            _courseSelectingPresentationModel.SetCourseCheckBoxStatus(course2);
            if (!string.IsNullOrEmpty(expect2))
            {
                expect1 += Common.NEW_LINE + expect2 + Common.NEW_LINE;
            }
            Assert.AreEqual(expect1, _courseSelectingPresentationModel.SendSelectedCourses());
        }

    }
}
