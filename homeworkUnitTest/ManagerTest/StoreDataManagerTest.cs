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
        private string _courseName = "Window";
        private string _courseNumber = "55688";
        private string _courseName2 = "Window222";
        private string _courseNumber2 = "55688222";
        private StoreDataManager _storeDataManager;
        private PrivateObject _privateObject;
        private Course _course, _course2;
        private List<Course> courses;

        #region PublicTest
        /// <summary>
        /// 在測試前，將需要使用到的物件先生成
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
            _privateObject = new PrivateObject(_storeDataManager);
            SetCourseInfo();
            SetCourse2Info();
        }

        /// <summary>
        /// 初始化設定課程物件
        /// </summary>
        private void SetCourseInfo()
        {
            _course = new Course();
            _course.Name = _courseName;
            _course.Number = _courseNumber;
            courses = new List<Course>();
            courses.Add(_course);
        }

        /// <summary>
        /// 初始化設定課程物件
        /// </summary>
        private void SetCourse2Info()
        {
            _course2 = new Course();
            _course2.Name = _courseName2;
            _course2.Number = _courseNumber2;
        }

        /// <summary>
        /// 測試將課程加入到課程總表
        /// </summary>
        [TestMethod]
        public void TestAddCurriculum()
        {
            var curriculum = _storeDataManager.GetCurriculumCourses();
            Assert.AreEqual(0, curriculum.Count);
            _storeDataManager.AddCourse(_courseName, courses);
            curriculum = _storeDataManager.GetCurriculumCourses();
            Assert.AreEqual(_courseName, curriculum[_courseNumber].Name);
            Assert.AreEqual(_courseNumber, curriculum[_courseNumber].Number);
        }

        /// <summary>
        /// 測試將許多課程加入到指定班級下
        /// </summary>
        [TestMethod]
        public void TestAddClassCourse()
        {
            var classCourse = _storeDataManager.GetCoursesByClassName(_courseName);
            Assert.AreEqual(0, classCourse.Count);
            _storeDataManager.AddCourse(_courseName, courses);
            classCourse = _storeDataManager.GetCoursesByClassName(_courseName);
            Assert.AreEqual(_courseName, classCourse[0].Name);
            Assert.AreEqual(_courseNumber, classCourse[0].Number);
        }

        /// <summary>
        /// 測試將課程加入到選取課程下
        /// </summary>
        [TestMethod]
        public void TestAddSelectedCourses()
        {
            var chosenCourses = _storeDataManager.GetChosenCourses();
            Assert.AreEqual(0, chosenCourses.Count);
            _storeDataManager.AddSelectedCourses(courses);
            chosenCourses = _storeDataManager.GetChosenCourses();
            Assert.AreEqual(_courseName, chosenCourses[0].Name);
            Assert.AreEqual(_courseNumber, chosenCourses[0].Number);
        }

        /// <summary>
        /// 測試將一筆課程加入到指定班級下
        /// </summary>
        [TestMethod]
        public void TestAddCourseToClass()
        {
            var classCourse = _storeDataManager.GetCoursesByClassName(_courseName);
            Assert.AreEqual(0, classCourse.Count);
            _storeDataManager.AddCourseToClass(_course, _courseName);
            classCourse = _storeDataManager.GetCoursesByClassName(_courseName);
            Assert.AreEqual(1, classCourse.Count);
            Assert.AreEqual(_courseName, classCourse[0].Name);
            Assert.AreEqual(_courseNumber, classCourse[0].Number);
        }

        /// <summary>
        /// 測試刪除課程
        /// </summary>
        [TestMethod]
        public void TestRemoveCourse()
        {
            _storeDataManager.AddCourseToClass(_course, _courseName);
            var classCourse = _storeDataManager.GetCoursesByClassName(_courseName);
            Assert.AreEqual(1, classCourse.Count);
            _storeDataManager.RemoveCourse(_courseName, _courseNumber);
            classCourse = _storeDataManager.GetCoursesByClassName(_courseName);
            Assert.AreEqual(0, classCourse.Count);
        }

        /// <summary>
        /// 測試撤選課程
        /// </summary>
        [TestMethod]
        public void TestDropCourse()
        {
            _storeDataManager.AddSelectedCourses(courses);
            var chosenCourses = _storeDataManager.GetChosenCourses();
            Assert.AreEqual(1, chosenCourses.Count);
            _storeDataManager.DropCourse(0);
            Assert.AreEqual(0, chosenCourses.Count);
        }

        /// <summary>
        /// 測試確認課程是否存在
        /// </summary>
        [TestMethod]
        public void TestIsCourseNumberExist()
        {
            var number = _storeDataManager.IsCourseNumberExist(_courseNumber);
            Assert.AreEqual(false, number);
            _storeDataManager.AddCourseToClass(_course, _courseName);
            number = _storeDataManager.IsCourseNumberExist(_courseNumber);
            Assert.AreEqual(true, number);
        }
        #endregion

        /// <summary>
        /// 測試從班級刪除課程
        /// </summary>
        [TestMethod]
        public void TestRemoveCourseFromClass()
        {
            _storeDataManager.AddCourseToClass(_course, _courseName);
            var classCourse = _storeDataManager.GetCoursesByClassName(_courseName);
            Assert.AreEqual(1, classCourse.Count);
            _privateObject.Invoke("RemoveCourseFromClass", new object[] { classCourse, _courseNumber });
            classCourse = _storeDataManager.GetCoursesByClassName(_courseName);
            Assert.AreEqual(0, classCourse.Count);
        }

        /// <summary>
        /// 測試 用課號取得 班級名稱
        /// </summary>
        [TestMethod]
        public void TestGetClassNameByCourseNumber()
        {
            _storeDataManager.AddCourseToClass(_course, _courseName);
            var className = _storeDataManager.GetClassNameByCourseNumber(_courseNumber);
            Assert.AreEqual(_courseName, className);
        }

        /// <summary>
        /// 測試 用課號取得 課程
        /// </summary>
        [TestMethod]
        public void TestGetCourseByCourseNumber()
        {
            _storeDataManager.AddCourseToClass(_course, _courseName);
            var course = _storeDataManager.GetCourseByCourseNumber(_courseNumber);
            Assert.AreEqual(_courseName, course.Name);
            Assert.AreEqual(_courseNumber, course.Number);
        }

        /// <summary>
        /// 測試 用課號取得 班級名稱 且沒有此課號
        /// </summary>
        [TestMethod]
        public void TestGetClassNameByCourseNumberWithNoSuchCourseNumber()
        {
            var className = _storeDataManager.GetClassNameByCourseNumber(_courseNumber);
            Assert.AreEqual(string.Empty, className);
        }

        /// <summary>
        /// 測試 用課號取得 課程
        /// </summary>
        [TestMethod]
        public void TestGetAllClass()
        {
            _storeDataManager.AddCourseToClass(_course, _courseName);
            _storeDataManager.AddCourseToClass(_course2, _courseName2);
            var classList = _storeDataManager.GetAllClass();
            Assert.AreEqual(_courseName, classList[0].DepartmentName);
            Assert.AreEqual(_courseName2, classList[1].DepartmentName);
        }

        /// <summary>
        /// 重新拉取選取課表
        /// </summary>
        [TestMethod]
        public void TestRefreshChosenCourses()
        {
            _storeDataManager.AddCourse(_courseName, courses);
            _storeDataManager.AddSelectedCourses(courses);
            _privateObject.Invoke("RefreshSelectedResult");
        }

    }
}
