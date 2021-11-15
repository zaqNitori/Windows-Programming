using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework.Manager;
using homework.Model;
using homework.PresentationModel;
using System;

namespace homeworkUnitTest.PresentationModelTest
{
    [TestClass]
    public class ImportCourseProgressPresentationModelTest
    {
        private StoreDataManager _storeDataManager;
        private CourseManageModel _courseManageModel;
        private ImportCourseProgressPresentationModel _importCourseProgressPresentationModel;
        private PrivateObject _privateObject;
        private int notify = 0;

        /// <summary>
        /// 初始化設定
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
            _courseManageModel = new CourseManageModel(_storeDataManager);
            _importCourseProgressPresentationModel = new ImportCourseProgressPresentationModel(_courseManageModel);
            _privateObject = new PrivateObject(_importCourseProgressPresentationModel);
        }

        /// <summary>
        /// 測試Notify功能用
        /// </summary>
        private void ChangeNotify()
        {
            notify = 10;
        }

        /// <summary>
        /// 測試 Notify function
        /// </summary>
        [TestMethod]
        public void TestNotifyProgressChanged()
        {
            _importCourseProgressPresentationModel._progressChanged += ChangeNotify;
            Assert.AreEqual(0, notify);
            _privateObject.Invoke("NotifyProgressChanged");
            Assert.AreEqual(10, notify);
        }

        /// <summary>
        /// 測試 匯入課程
        /// </summary>
        [TestMethod]
        public void TestImportCourses()
        {
            _importCourseProgressPresentationModel.ImportComputerScienceCourses();
        }

        /// <summary>
        /// 測試 內部屬性
        /// </summary>
        [TestMethod]
        public void TestProgressBarMinimumGetAndSet()
        {
            int seven = 7;
            Assert.AreEqual(0, _importCourseProgressPresentationModel.ProgressBarMinimum);
            _importCourseProgressPresentationModel.ProgressBarMinimum = seven;
            Assert.AreEqual(seven, _importCourseProgressPresentationModel.ProgressBarMinimum);
        }

        /// <summary>
        /// 測試 內部屬性
        /// </summary>
        [TestMethod]
        public void TestProgressBarMaximumGetAndSet()
        {
            int seven = 7;
            Assert.AreEqual(100, _importCourseProgressPresentationModel.ProgressBarMaximum);
            _importCourseProgressPresentationModel.ProgressBarMaximum = seven;
            Assert.AreEqual(seven, _importCourseProgressPresentationModel.ProgressBarMaximum);
        }

        /// <summary>
        /// 測試 內部屬性
        /// </summary>
        [TestMethod]
        public void TestProgressBarValueGetAndSet()
        {
            int seven = 7;
            Assert.AreEqual(0, _importCourseProgressPresentationModel.ProgressBarValue);
            _importCourseProgressPresentationModel.ProgressBarValue = seven;
            Assert.AreEqual(seven, _importCourseProgressPresentationModel.ProgressBarValue);
        }

        /// <summary>
        /// 測試 內部屬性
        /// </summary>
        [TestMethod]
        public void TestProgressBarStepGetAndSet()
        {
            int seven = 7;
            Assert.AreEqual(25, _importCourseProgressPresentationModel.ProgressBarStep);
            _importCourseProgressPresentationModel.ProgressBarStep = seven;
            Assert.AreEqual(seven, _importCourseProgressPresentationModel.ProgressBarStep);
        }

    }
}
