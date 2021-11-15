using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework.Manager;
using homework.PresentationModel;
using homework.Model;
using System;

namespace homeworkUnitTest.PresentationModelTest
{
    [TestClass]
    public class StartUpPresentationModelTest
    {
        private StoreDataManager _storeDataManager;
        private CourseSelectModel _courseSelectModel;
        private StartUpPresentationModel _startUpPresentationModel;

        /// <summary>
        /// 初始化設定
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
            _courseSelectModel = new CourseSelectModel(_storeDataManager);
            _startUpPresentationModel = new StartUpPresentationModel(_courseSelectModel);
        }

        /// <summary>
        /// 測試 畫面元件狀態的寫入以及取得
        /// </summary>
        [TestMethod]
        public void TestIsButtonCourseSelectingEnabledSetAndGet()
        {
            Assert.AreEqual(true, _startUpPresentationModel.IsButtonCourseSelectingEnabled);
            _startUpPresentationModel.IsButtonCourseSelectingEnabled = false;
            Assert.AreEqual(false, _startUpPresentationModel.IsButtonCourseSelectingEnabled);
        }

        /// <summary>
        /// 測試 畫面元件狀態的寫入以及取得
        /// </summary>
        [TestMethod]
        public void TestIsButtonCourseManagementEnabledSetAndGet()
        {
            Assert.AreEqual(true, _startUpPresentationModel.IsButtonCourseManagementEnabled);
            _startUpPresentationModel.IsButtonCourseManagementEnabled = false;
            Assert.AreEqual(false, _startUpPresentationModel.IsButtonCourseManagementEnabled);
        }

        /// <summary>
        /// 測試 畫面元件狀態的寫入以及取得
        /// </summary>
        [TestMethod]
        public void TestIsButtonExitEnabledSetAndGet()
        {
            Assert.AreEqual(true, _startUpPresentationModel.IsButtonExitEnabled);
            _startUpPresentationModel.IsButtonExitEnabled = false;
            Assert.AreEqual(false, _startUpPresentationModel.IsButtonExitEnabled);
        }
    }
}
