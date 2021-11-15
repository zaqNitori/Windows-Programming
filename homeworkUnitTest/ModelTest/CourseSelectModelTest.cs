using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework.Manager;
using homework.ViewModel;
using homework.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace homeworkUnitTest.ModelTest
{
    [TestClass]
    public class CourseSelectModelTest
    {
        const string URL = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
        const string URL2 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=109&sem=1&code=2433";
        private string _className = "資工三";
        private string _courseName = "Window";
        private string _courseNumber = "55688";
        private StoreDataManager _storeDataManager;
        private CourseSelectModel _courseSelectModel;
        private CourseManageModel _courseManageModel;
        private PrivateObject _privateObject;
        private List<string> _courseURL;
        private Course _course;

        /// <summary>
        /// 初始化設定
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
            _courseSelectModel = new CourseSelectModel(_storeDataManager);
            _courseManageModel = new CourseManageModel(_storeDataManager);
            _privateObject = new PrivateObject(_courseSelectModel);
            SetCourseInfo();
            FetchCourseInfo();
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
        /// 初始化設定課程物件
        /// </summary>
        private void FetchCourseInfo()
        {
            _courseURL = new List<string>();
            _courseURL.Add(URL);
            _courseManageModel.FetchCourseInfo(_courseURL);
        }

        /// <summary>
        /// 測試 依據URL爬取課程，並且寫入資料
        /// </summary>
        [TestMethod]
        public void TestFetchCourseInfo()
        {
            var className = _courseSelectModel.GetAllClassName();
            Assert.AreEqual(_className, className[0]);
            var courses = _courseSelectModel.GetCoursesByClassName(className[0]);
            Assert.AreEqual(12, courses.Count);
        }

        /// <summary>
        /// 測試 退選課程
        /// </summary>
        [TestMethod]
        public void TestDropCourse()
        {
            _courseSelectModel.AddSelectedCourses(new List<string> { "291705", "291706" });
            var chosenCourses = _courseSelectModel.GetChosenCourses();
            Assert.AreEqual(2, chosenCourses.Count);
            Assert.AreEqual("資料庫系統", chosenCourses[0].Name);
            Assert.AreEqual("計算機網路", chosenCourses[1].Name);
            _courseSelectModel.DropCourse(1);
            chosenCourses = _courseSelectModel.GetChosenCourses();
            Assert.AreEqual(1, chosenCourses.Count);
            Assert.AreEqual("資料庫系統", chosenCourses[0].Name);
        }

        /// <summary>
        /// 測試 驗證選課是否有衝突
        /// </summary>
        [TestMethod]
        [DataRow("291703", "291704", "課程名稱相同 : 291704博雅選修課程，291703博雅選修課程")]
        [DataRow("294321", "280375", "課程衝堂 : 280375感測技術基礎科學，294321巨量資料分析導論")]
        [DataRow("", "291703 291704", "課程名稱相同 : 291703博雅選修課程，291704博雅選修課程")]
        [DataRow("", "294321 280375", "課程衝堂 : 294321巨量資料分析導論，280375感測技術基礎科學")]
        [DataRow("291705", "291706", "")]
        public void TestCheckCoursesConflict(string class1, string class2, string expect)
        {
            _courseSelectModel.AddSelectedCourses(new List<string> { class1});
            List<string> vs2 = class2.Split(' ').ToList();
            _courseManageModel.FetchCourseInfo(new List<string> { URL2 });
            var errMsg = _courseSelectModel.CheckCoursesConflict(vs2);
            if(!string.IsNullOrEmpty(expect))
            {
                expect += Environment.NewLine;
            }
            Assert.AreEqual(expect, errMsg);
        }

        /// <summary>
        /// 測試 新增選取課程
        /// </summary>
        [TestMethod]
        public void TestAddSelectedCourses()
        {
            var chosenCourses = _courseSelectModel.GetChosenCourses();
            Assert.AreEqual(0, chosenCourses.Count);
            _courseSelectModel.AddSelectedCourses(new List<string> { "291705", "291706" });
            chosenCourses = _courseSelectModel.GetChosenCourses();
            Assert.AreEqual(2, chosenCourses.Count);
            Assert.AreEqual("資料庫系統", chosenCourses[0].Name);
            Assert.AreEqual("計算機網路", chosenCourses[1].Name);
        }

        /// <summary>
        /// 測試 選取幾筆課程後再重新取得課表
        /// </summary>
        [TestMethod]
        public void TestGetCoursesAfterChosenSomeCourses()
        {
            _courseSelectModel.AddSelectedCourses(new List<string> { "291705", "291706" });
            var courses = _courseSelectModel.GetCoursesByClassName(_className);
            Assert.AreEqual(10, courses.Count);
        }

    }
}
