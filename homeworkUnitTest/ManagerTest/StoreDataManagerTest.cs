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
        private StoreDataManager _storeDataManager;
        private PrivateObject _privateObject;
        private Course _course;
        private List<Course> courses;

        /// <summary>
        /// 在測試前，將需要使用到的物件先生成
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
            _privateObject = new PrivateObject(_storeDataManager);
            SetCourseInfo();
        }

        /// <summary>
        /// 測試將課程加入到課程總表
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
        /// 測試將課程加入到課程總表
        /// </summary>
        [TestMethod]
        public void TestAddCurriculum()
        {
            var curriculum = _storeDataManager.GetCurriculumCourses();
            Assert.AreEqual(0, curriculum.Count);
            _storeDataManager.AddCurriculum(courses);
            curriculum = _storeDataManager.GetCurriculumCourses();
            Assert.AreEqual(_courseName, curriculum[_courseNumber].Name);
            Assert.AreEqual(_courseNumber, curriculum[_courseNumber].Number);
        }

        /// <summary>
        /// 測試將許多課程加入到指定班級下
        /// </summary>
        [TestMethod]
        public void TestAddDepartmentCourse()
        {
            var classCourse = _storeDataManager.GetCoursesByDepartmentName(_courseName);
            Assert.AreEqual(0, classCourse.Count);
            _storeDataManager.AddClassCourse(_courseName, courses);
            classCourse = _storeDataManager.GetCoursesByDepartmentName(_courseName);
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
            var classCourse = _storeDataManager.GetCoursesByDepartmentName(_courseName);
            Assert.AreEqual(0, classCourse.Count);
            _storeDataManager.AddCourseToClass(_course, _courseName);
            classCourse = _storeDataManager.GetCoursesByDepartmentName(_courseName);
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
            var classCourse = _storeDataManager.GetCoursesByDepartmentName(_courseName);
            Assert.AreEqual(1, classCourse.Count);
            _storeDataManager.RemoveCourse(_courseName, _courseNumber);
            classCourse = _storeDataManager.GetCoursesByDepartmentName(_courseName);
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

    }
}
