using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework.Manager;
using homework.ViewModel;
using homework.Model;
using System;

namespace homeworkUnitTest.ModelTest
{
    [TestClass]
    public class CourseManageModelTest
    {
        private string _courseName = "Window";
        private string _courseNumber = "55688";
        private StoreDataManager _storeDataManager;
        private CourseManageModel _courseManageModel;
        private Course _course;
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
            _privateObject = new PrivateObject(_courseManageModel);
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
        }

        /// <summary>
        /// 測試Notify功能用
        /// </summary>
        private void ChangeNotify()
        {
            notify = 10;
        }

        /// <summary>
        /// 測試取得 課程轉成DataItem 物件
        /// </summary>
        [TestMethod]
        public void TestGetCurriculumAsItem()
        {
            var curriculum = _courseManageModel.GetCurriculumAsItem();
            Assert.AreEqual(0, curriculum.Count);
            _courseManageModel.AddCourse(_course, _courseName);
            curriculum = _courseManageModel.GetCurriculumAsItem();
            Assert.AreEqual(1, curriculum.Count);
        }

        /// <summary>
        /// 測試取得 課程名稱轉成DataItem 物件
        /// </summary>
        [TestMethod]
        public void TestGetClassNameAsItem()
        {
            var className = _courseManageModel.GetClassNameAsItem();
            Assert.AreEqual(0, className.Count);
            _courseManageModel.AddCourse(_course, _courseName);
            className = _courseManageModel.GetClassNameAsItem();
            Assert.AreEqual(1, className.Count);
        }

        /// <summary>
        /// 測試 利用課號取得課程名稱
        /// </summary>
        [TestMethod]
        public void TestGetClassNameByCourseNumber()
        {
            _courseManageModel.AddCourse(_course, _courseName);
            var className = _courseManageModel.GetClassNameByCourseNumber(_courseNumber);
            Assert.AreEqual(_courseName, className);
        }

        /// <summary>
        /// 測試 利用課號取得課程
        /// </summary>
        [TestMethod]
        public void TestGetCourseByCourseNumber()
        {
            _courseManageModel.AddCourse(_course, _courseName);
            var course = _courseManageModel.GetCourseByCourseNumber(_courseNumber);
            Assert.AreEqual(_courseName, course.Name);
            Assert.AreEqual(_courseNumber, course.Number);
        }

        /// <summary>
        /// 測試 新增課程
        /// </summary>
        [TestMethod]
        public void TestAddCourse()
        {
            var curriculum = _courseManageModel.GetCurriculumAsItem();
            Assert.AreEqual(0, curriculum.Count);
            _courseManageModel.AddCourse(_course, _courseName);
            curriculum = _courseManageModel.GetCurriculumAsItem();
            Assert.AreEqual(_courseName, curriculum[0].Text);
            Assert.AreEqual(_courseNumber, curriculum[0].Value);
        }

        /// <summary>
        /// 測試 編輯課程
        /// </summary>
        [TestMethod]
        public void TestEditCourse()
        {
            string name = "edit";
            string number = "12345";
            Course editCourse = new Course();
            editCourse.Name = name;
            editCourse.Number = number;
            _courseManageModel.AddCourse(_course, _courseName);
            _courseManageModel.EditCourse(editCourse, _courseName, _courseNumber);
            var curriculum = _courseManageModel.GetCurriculumAsItem();
            Assert.AreEqual(name, curriculum[0].Text);
            Assert.AreEqual(number, curriculum[0].Value);
        }

        /// <summary>
        /// 測試 檢查課號是否衝突
        /// </summary>
        [TestMethod]
        public void TestCheckIsCourseNumberConflict()
        {
            _courseManageModel.AddCourse(_course, _courseName);
            var conflict = _courseManageModel.CheckIsCourseNumberConflict(_courseNumber);
            Assert.AreEqual(true, conflict);
        }

        /// <summary>
        /// 測試 匯入課程
        /// </summary>
        [TestMethod]
        public void TestImportCourses()
        {
            _courseManageModel.ImportComputerScienceCourses();
            var courses = _courseManageModel.GetClassNameAsItem();
            Assert.AreEqual(4, courses.Count);
        }

        /// <summary>
        /// 測試 Notify function
        /// </summary>
        [TestMethod]
        public void NotifyProgressChanged()
        {
            _courseManageModel._progressChanged += ChangeNotify;
            Assert.AreEqual(0, notify);
            _privateObject.Invoke("NotifyProgressChanged");
            Assert.AreEqual(10, notify);
        }

    }
}
