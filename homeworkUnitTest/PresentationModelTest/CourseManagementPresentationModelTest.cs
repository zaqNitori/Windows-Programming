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
        private PrivateObject _privateObject;
        private Course _course1, _course2;
        private int notify = 0;

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
            _privateObject = new PrivateObject(_courseManagementPresentationModel);
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
            _courseManagementPresentationModel.ClassName = _className;
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
        /// 測試Notify功能用
        /// </summary>
        private void ChangeNotify()
        {
            notify = 10;
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
        public void TestCheckIsNumericInputValidWithInValidInputForAdd()
        {
            _courseManagementPresentationModel.CourseManageState = ((int)CourseManageAction.Add);
            _courseManagementPresentationModel.GetCourseByCourseNumber(_courseNumber1);
            var errorMessage = _courseManagementPresentationModel.CheckIsNumericInputValid();
            Assert.AreEqual("Number" + CourseManageProperty.ERROR_MESSAGE_COURSE_NUMBER_CONFLICT + Environment.NewLine
                , errorMessage);
        }

        /// <summary>
        /// 檢測有限制輸入的欄位
        /// </summary>
        [TestMethod]
        public void TestCheckIsNumericInputValidWithValidInputForAdd()
        {
            _courseManagementPresentationModel.CourseManageState = ((int)CourseManageAction.Add);
            _courseManagementPresentationModel.GetCourseByCourseNumber(_courseNumber1);
            _courseManagementPresentationModel.Number = _courseNumberAdd;
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
        /// 針對必填輸入進行測試，課程時間由於驗證方式相同，因此僅測試禮拜一的部分
        [TestMethod]
        [DataRow("3", "3.0", "None", "▲", "2", "資工", "", "3 4", "", "", "", "", "", true)]
        [DataRow("", "3.0", "None", "▲", "2", "資工", "", "3 4", "", "", "", "", "", false)]
        [DataRow("3", "", "None", "▲", "2", "資工", "", "3 4", "", "", "", "", "", false)]
        [DataRow("3", "3.0", "", "▲", "2", "資工", "", "3 4", "", "", "", "", "", false)]
        [DataRow("3", "3.0", "None", "", "2", "資工", "", "3 4", "", "", "", "", "", false)]
        [DataRow("3", "3.0", "None", "▲", "", "資工", "", "3 4", "", "", "", "", "", false)]
        [DataRow("3", "3.0", "None", "▲", "2", "", "", "3 4", "", "", "", "", "", false)]
        [DataRow("3", "3.0", "None", "▲", "2", "資工", "", "2 3 4", "", "", "", "", "", false)]
        [DataRow("3", "3.0", "None", "▲", "2", "資工", "", "3", "", "", "", "", "", false)]
        public void TestCheckIsCourseInputValid(string stage, string credit
            , string teacher, string requiredOrElective, string hour, string className
            , string Sunday, string Monday, string Tuesday, string Wednesday, string Thursday
            , string Friday, string Saturday, bool expect)
        {
            _courseManagementPresentationModel.GetCourseByCourseNumber(_courseNumber1);
            _courseManagementPresentationModel.Stage = stage;
            _courseManagementPresentationModel.Credit = credit;
            _courseManagementPresentationModel.Teacher = teacher;
            _courseManagementPresentationModel.RequiredOrElective = requiredOrElective;
            _courseManagementPresentationModel.Hour = hour;
            _courseManagementPresentationModel.ClassName = className;
            _courseManagementPresentationModel.Sunday = Sunday;
            _courseManagementPresentationModel.Monday = Monday;
            _courseManagementPresentationModel.Tuesday = Tuesday;
            _courseManagementPresentationModel.Wednesday = Wednesday;
            _courseManagementPresentationModel.Thursday = Thursday;
            _courseManagementPresentationModel.Friday = Friday;
            _courseManagementPresentationModel.Saturday = Saturday;
            foreach(var c in Monday.Split(' '))
            {
                _courseManagementPresentationModel.RecordCourseTime(10 + int.Parse(c));
            }
            _courseManagementPresentationModel.CheckIsCourseInputValid();
            Assert.AreEqual(expect, _courseManagementPresentationModel.IsButtonConfirmEnabled);
        }

        /// <summary>
        /// 檢測 課程資訊是否有更改
        /// </summary>
        [TestMethod]
        [DataRow("Monk", "12345", "2", "2.0", "None", "Required", "None", "None", "2", "Nihongo", "資工", "", "5 6", "", "", "", "", "", false)]
        [DataRow("Monk", "12345", "2", "2.0", "None", "Required", "None", "None", "2", "Nihongo", "資工", "", "", "5 6", "", "", "", "", true)]
        public void TestCheckIsCoursePropertyChanged(string name, string number, 
            string stage, string credit, string teacher, string requiredOrElective
            , string teachAssistant, string note, string hour, string language
            , string className, string Sunday, string Monday, string Tuesday
            , string Wednesday, string Thursday, string Friday, string Saturday
            , bool expect)
        {
            SetAddCourseInfo();
            _courseManagementPresentationModel.ClickConfirm();
            _courseManagementPresentationModel.GetCourseByCourseNumber(_courseNumberAdd);

            _courseManagementPresentationModel.Name = name;
            _courseManagementPresentationModel.Number = number;
            _courseManagementPresentationModel.TeachAssistant = teachAssistant;
            _courseManagementPresentationModel.Note = note;
            _courseManagementPresentationModel.Language = language;
            _courseManagementPresentationModel.Stage = stage;
            _courseManagementPresentationModel.Credit = credit;
            _courseManagementPresentationModel.Teacher = teacher;
            _courseManagementPresentationModel.RequiredOrElective = requiredOrElective;
            _courseManagementPresentationModel.Hour = hour;
            _courseManagementPresentationModel.ClassName = className;
            _courseManagementPresentationModel.Sunday = Sunday;
            _courseManagementPresentationModel.Monday = Monday;
            _courseManagementPresentationModel.Tuesday = Tuesday;
            _courseManagementPresentationModel.Wednesday = Wednesday;
            _courseManagementPresentationModel.Thursday = Thursday;
            _courseManagementPresentationModel.Friday = Friday;
            _courseManagementPresentationModel.Saturday = Saturday;
            _courseManagementPresentationModel.CheckIsCourseInputValid();
            Assert.AreEqual(expect, _courseManagementPresentationModel.IsButtonConfirmEnabled);
        }

        /// <summary>
        /// 測試 Notify function
        /// </summary>
        [TestMethod]
        public void TestNotifyGridContentChanged()
        {
            _courseManagementPresentationModel._gridContentChanged += ChangeNotify;
            Assert.AreEqual(0, notify);
            _privateObject.Invoke("NotifyGridContentChanged");
            Assert.AreEqual(10, notify);
        }

        /// <summary>
        /// 測試 Notify function
        /// </summary>
        [TestMethod]
        public void TestNotifyGroupBoxAndButtonChanged()
        {
            _courseManagementPresentationModel._groupBoxAndButtonChanged += ChangeNotify;
            Assert.AreEqual(0, notify);
            _privateObject.Invoke("NotifyGroupBoxAndButtonChanged");
            Assert.AreEqual(10, notify);
        }

        /// <summary>
        /// 測試 Notify function
        /// </summary>
        [TestMethod]
        public void TestNotifyListBoxChanged()
        {
            _courseManagementPresentationModel._listBoxChanged += ChangeNotify;
            Assert.AreEqual(0, notify);
            _privateObject.Invoke("NotifyListBoxChanged");
            Assert.AreEqual(10, notify);
        }

    }
}
