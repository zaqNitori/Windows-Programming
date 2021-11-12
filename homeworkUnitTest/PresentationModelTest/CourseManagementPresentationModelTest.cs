using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework.Manager;
using homework.ViewModel;
using homework.PresentationModel;
using homework.Model;
using System;

namespace homeworkUnitTest.PresentationModelTest
{
    [TestClass]
    public class CourseManagementPresentationModelTest
    {
        private string _className = "資工";
        private string _courseName1 = "Window";
        private string _courseNumber1 = "55688";
        private string _courseName2 = "Window2";
        private string _courseNumber2 = "wrong";
        private StoreDataManager _storeDataManager;
        private CourseManageModel _courseManageModel;
        private CourseManagementPresentationModel _courseManagementPresentationModel;
        private Course _course1, _course2;

        /// <summary>
        /// 初始化設定
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _storeDataManager = new StoreDataManager();
            _courseManageModel = new CourseManageModel(_storeDataManager);
            _courseManagementPresentationModel = new CourseManagementPresentationModel(_courseManageModel);
            SetCourse1Info();
            SetCourse2Info();
            _courseManageModel.AddCourse(_course1, _className);
            _courseManageModel.AddCourse(_course2, _className);
        }

        /// <summary>
        /// 初始化設定課程物件
        /// </summary>
        private void SetCourse1Info()
        {
            _course1 = new Course();
            _course1.Name = _courseName1;
            _course1.Number = _courseNumber1;
            _course1.Credit = "3.0";
            _course1.Stage = "2";
            _course1.Hour = "1";
        }

        /// <summary>
        /// 初始化設定課程物件
        /// </summary>
        private void SetCourse2Info()
        {
            _course2 = new Course();
            _course2.Name = _courseName2;
            _course2.Number = _courseNumber2;
            _course2.Credit = "a";
            _course2.Hour = "bb";
            _course2.Stage = "ccc";
        }

        /// <summary>
        /// 取得Item型態的所有課程
        /// </summary>
        [TestMethod]
        public void TestGetCurriculumAsItem()
        {
            var curriculum = _courseManagementPresentationModel.GetCurriculumAsItem();
            Assert.AreEqual(_courseName1, curriculum[0].Text);
            Assert.AreEqual(_courseNumber1, curriculum[0].Value);
        }

        /// <summary>
        /// 取得Item型態的班級名稱
        /// </summary>
        [TestMethod]
        public void TestGetClassNameAsItem()
        {
            var className = _courseManagementPresentationModel.GetClassNameAsItem();
            Assert.AreEqual(_className, className[0].Text);
            Assert.AreEqual(_className, className[0].Value);
        }

        /// <summary>
        /// 檢測有限制輸入的欄位
        /// </summary>
        [TestMethod]
        public void TestCheckIsNumericInputValidWithValidInput()
        {
            _courseManagementPresentationModel.GetCourseByCourseNumber(_courseNumber1);
            var errorMessage = _courseManagementPresentationModel.CheckIsNumericInputValid();
            Assert.AreEqual(string.Empty, errorMessage);
        }

        /// <summary>
        /// 檢測有限制輸入的欄位
        /// </summary>
        [TestMethod]
        public void TestCheckIsNumericInputValidWithInValidInput()
        {
            _courseManagementPresentationModel.GetCourseByCourseNumber(_courseNumber2);
            var errorMessage = _courseManagementPresentationModel.CheckIsNumericInputValid();
            string expect = "Number" + Environment.NewLine 
                + "Credit" + Environment.NewLine 
                + "Stage" + Environment.NewLine 
                + CourseManageProperty.ERROR_MESSAGE_NOT_NUMBER + Environment.NewLine;
            Assert.AreEqual(expect, errorMessage);
        }

    }
}
