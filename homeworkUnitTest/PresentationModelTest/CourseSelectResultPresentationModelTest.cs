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
    public class CourseSelectResultPresentationModelTest
    {
        private string _className = "資工";
        private string _courseName = "Window";
        private string _courseNumber = "55688";
        private StoreDataManager _storeDataManager;
        private CourseSelectModel _courseSelectModel;
        private CourseSelectResultPresentationModel _courseSelectResultPresentationModel;
        private PrivateObject _privateObject;
        private Course _course;
        private int notify = 0;

        /// <summary>
        /// 初始化設定
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
            _courseSelectModel = new CourseSelectModel(_storeDataManager);
            _courseSelectResultPresentationModel = new CourseSelectResultPresentationModel(_courseSelectModel);
            _privateObject = new PrivateObject(_courseSelectResultPresentationModel);
            SetCourseInfo();
        }

        /// <summary>
        /// 初始化設定課程物件
        /// </summary>
        private void SetCourseInfo()
        {
            _course = new Course();
            _course.Name = _courseName;
            _course.Number = _courseNumber;
            _storeDataManager.AddCourseToClass(_course, _className);
            _storeDataManager.AddSelectedCourses(new List<Course> { _course });
        }

        /// <summary>
        /// 測試Notify功能用
        /// </summary>
        private void ChangeNotify()
        {
            notify = 10;
        }

        /// <summary>
        /// 測試取得選課結果
        /// </summary>
        [TestMethod]
        public void TestGetChosenCourses()
        {
            var courses = _courseSelectResultPresentationModel.GetChosenCourses();
            Assert.AreEqual(1, courses.Count);
            Assert.AreEqual(_courseName, courses[0].Name);
            Assert.AreEqual(_courseNumber, courses[0].Number);
        }

        /// <summary>
        /// 測試撤選課程
        /// </summary>
        [TestMethod]
        public void TestDropCourse()
        {
            var courses = _courseSelectResultPresentationModel.GetChosenCourses();
            Assert.AreEqual(1, courses.Count);
            Assert.AreEqual(_courseName, courses[0].Name);
            Assert.AreEqual(_courseNumber, courses[0].Number);
            _courseSelectResultPresentationModel.DropCourse(0);
            courses = _courseSelectResultPresentationModel.GetChosenCourses();
            Assert.AreEqual(0, courses.Count);
        }

        /// <summary>
        /// 測試通知 function
        /// </summary>
        [TestMethod]
        public void TestNotifyCourseChanged()
        {
            _courseSelectResultPresentationModel._courseChanged += ChangeNotify;
            Assert.AreEqual(0, notify);
            _privateObject.Invoke("NotifyCourseChanged");
            Assert.AreEqual(10, notify);
        }

    }
}
