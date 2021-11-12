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
        private string _courseNameAdd = "Monk";
        private string _courseNumberAdd = "12345";
        private string _courseNameEdit = "Edit";
        private string _courseNumberEdit = "98765";
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
            _courseManagementPresentationModel.ClassName = _className;
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
        /// 新增課程設定用
        /// </summary>
        private void SetAddCourseInfo()
        {
            _courseManagementPresentationModel.Name = _courseNameAdd;
            _courseManagementPresentationModel.Number = _courseNumberAdd;
            _courseManagementPresentationModel.Credit = "2.0";
            _courseManagementPresentationModel.Hour = "2";
            _courseManagementPresentationModel.Stage = "2";
            _courseManagementPresentationModel.Teacher = "None";
            _courseManagementPresentationModel.RequiredOrElective = "Required";
            _courseManagementPresentationModel.TeachAssistant = "None";
            _courseManagementPresentationModel.Language = "Nihongo";
            _courseManagementPresentationModel.Note = "None";
            _courseManagementPresentationModel.Sunday = _courseManagementPresentationModel.Tuesday 
                = _courseManagementPresentationModel.Wednesday = _courseManagementPresentationModel.Thursday 
                = _courseManagementPresentationModel.Friday = _courseManagementPresentationModel.Saturday = "";
            _courseManagementPresentationModel.Monday = "5 6";
            _courseManagementPresentationModel.CourseManageState = ((int)CourseManageAction.Add);
        }

        /// <summary>
        /// 編輯課程設定用
        /// </summary>
        private void SetEditCourseInfo()
        {
            _courseManagementPresentationModel.Name = _courseNameEdit;
            _courseManagementPresentationModel.Number = _courseNumberEdit;
            _courseManagementPresentationModel.CourseManageState = ((int)CourseManageAction.Edit);
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

        /// <summary>
        /// 檢測 以課號取得課程
        /// </summary>
        [TestMethod]
        public void TestGetCourseByCourseNumber()
        {
            _courseManagementPresentationModel.GetCourseByCourseNumber(_courseNumber1);
            Assert.AreEqual(_courseName1, _courseManagementPresentationModel.Name);
            Assert.AreEqual(_courseNumber1, _courseManagementPresentationModel.Number);
        }

        /// <summary>
        /// 檢測 點擊新增課程後， View的元件狀態改變
        /// </summary>
        [TestMethod]
        public void TestClickAddCourse()
        {
            Assert.AreEqual(true, _courseManagementPresentationModel.IsCourseEditReadOnly);
            Assert.AreEqual(false, _courseManagementPresentationModel.IsCourseComboBoxEnabled);
            Assert.AreEqual(true, _courseManagementPresentationModel.IsButtonAddCourseEnabled);
            Assert.AreEqual(false, _courseManagementPresentationModel.IsButtonConfirmEnabled);
            Assert.AreEqual(CourseManageProperty.COURSE_EDIT_GROUP_BOX_TITLE, _courseManagementPresentationModel.GroupBoxTitle);
            Assert.AreEqual(CourseManageProperty.BUTTON_SAVE_TEXT, _courseManagementPresentationModel.ButtonConfirmText);
            _courseManagementPresentationModel.ClickAddCourse();
            Assert.AreEqual(false, _courseManagementPresentationModel.IsCourseEditReadOnly);
            Assert.AreEqual(true, _courseManagementPresentationModel.IsCourseComboBoxEnabled);
            Assert.AreEqual(false, _courseManagementPresentationModel.IsButtonAddCourseEnabled);
            Assert.AreEqual(false, _courseManagementPresentationModel.IsButtonConfirmEnabled);
            Assert.AreEqual(CourseManageProperty.COURSE_ADD_GROUP_BOX_TITLE, _courseManagementPresentationModel.GroupBoxTitle);
            Assert.AreEqual(CourseManageProperty.BUTTON_ADD_TEXT, _courseManagementPresentationModel.ButtonConfirmText);
        }

        /// <summary>
        /// 檢測 ListBox選取課程改變，View的元件狀態改變
        /// </summary>
        [TestMethod]
        public void TestSelectedIndexChanged()
        {
            int index = 5;
            Assert.AreEqual(true, _courseManagementPresentationModel.IsCourseEditReadOnly);
            Assert.AreEqual(false, _courseManagementPresentationModel.IsCourseComboBoxEnabled);
            Assert.AreEqual(true, _courseManagementPresentationModel.IsButtonAddCourseEnabled);
            Assert.AreEqual(false, _courseManagementPresentationModel.IsButtonConfirmEnabled);
            Assert.AreEqual(((int)CourseManageAction.None), _courseManagementPresentationModel.CourseManageState);
            _courseManagementPresentationModel.SelectedIndexChanged(index);
            Assert.AreEqual(false, _courseManagementPresentationModel.IsCourseEditReadOnly);
            Assert.AreEqual(true, _courseManagementPresentationModel.IsCourseComboBoxEnabled);
            Assert.AreEqual(true, _courseManagementPresentationModel.IsButtonAddCourseEnabled);
            Assert.AreEqual(false, _courseManagementPresentationModel.IsButtonConfirmEnabled);
            Assert.AreEqual(index, _courseManagementPresentationModel.ListBoxSelectedIndex);
            Assert.AreEqual(((int)CourseManageAction.Edit), _courseManagementPresentationModel.CourseManageState);
        }

        /// <summary>
        /// 檢測 儲存課程時間的邏輯
        /// </summary>
        [TestMethod]
        public void TestRecordCourseTime()
        {
            int t1, t2, t3;
            t1 = t2 = 5;
            t3 = 10;
            Assert.AreEqual(1, _courseManagementPresentationModel.RecordCourseTime(t1));
            Assert.AreEqual(2, _courseManagementPresentationModel.RecordCourseTime(t3));
            Assert.AreEqual(1, _courseManagementPresentationModel.RecordCourseTime(t2));
        }

        /// <summary>
        /// 檢測 按下送出後執行新增課程
        /// </summary>
        [TestMethod]
        public void TestClickConfirmAndDoAddCourse()
        {
            SetAddCourseInfo();
            var curriculum = _courseManagementPresentationModel.GetCurriculumAsItem();
            Assert.AreEqual(2, curriculum.Count);
            _courseManagementPresentationModel.ClickConfirm();
            curriculum = _courseManagementPresentationModel.GetCurriculumAsItem();
            Assert.AreEqual(3, curriculum.Count);
            Assert.AreEqual(_courseNameAdd, curriculum[2].Text);
            Assert.AreEqual(_courseNumberAdd, curriculum[2].Value);
        }

        /// <summary>
        /// 檢測 按下送出後執行編輯課程
        /// </summary>
        [TestMethod]
        public void TestClickConfirmAndDoEditCourse()
        {
            SetAddCourseInfo();
            _courseManagementPresentationModel.ClickConfirm();
            _courseManagementPresentationModel.GetCourseByCourseNumber(_courseNumberAdd);
            var curriculum = _courseManagementPresentationModel.GetCurriculumAsItem();
            Assert.AreEqual(_courseNameAdd, curriculum[2].Text);
            Assert.AreEqual(_courseNumberAdd, curriculum[2].Value);
            SetEditCourseInfo();
            _courseManagementPresentationModel.ClickConfirm();
            curriculum = _courseManagementPresentationModel.GetCurriculumAsItem();
            Assert.AreEqual(_courseNameEdit, curriculum[2].Text);
            Assert.AreEqual(_courseNumberEdit, curriculum[2].Value);
        }

        /// <summary>
        /// 檢測 按下送出後執行編輯課程
        /// </summary>
        [TestMethod]
        [DataRow]
        public void TestCheckIsCourseInputValid()
        {

        }

    }
}
