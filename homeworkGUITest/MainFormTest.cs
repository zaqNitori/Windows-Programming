using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkGUITest
{
    [TestClass()]
    public class MainFormTest
    {
        private string targetAppPath;
        private const string START_UP_FORM = "StartUpForm";
        private const string COURSE_SELECT_FORM = "SelectCourseForm";
        private const string COURSE_SELECT_RESULT_FORM = "CourseSelectResultForm";
        private const string NEW_LINE = "\n";

        private Robot _robot;
        private const string _buttonCourseSelecting = "Course Selecting System";
        private const string _buttonCourseManagement = "Course Management System";
        private const string _buttonExit = "Exit";
        private const string SELECTING_DATA_GRID_VIEW = "_courseDataGridView";
        private const string SELECT_RESULT_DATA_GRID_VIEW = "_courseSelectResultDataGridView";
        private const string EE_GRADE3_COURSES_GRIDVIEW = "_courseDataGridViewComponent1";
        private const string CSIE_GRADE3_COURSES_GRIDVIEW = "_courseDataGridViewComponent2";
        private const string CSIE_GRADE1_COURSES_GRIDVIEW = "_courseDataGridViewComponent3";
        private const string CSIE_GRADE2_COURSES_GRIDVIEW = "_courseDataGridViewComponent4";
        private const string CSIE_GRADE4_COURSES_GRIDVIEW = "_courseDataGridViewComponent5";
        private const string TAB_PAGE_CSIE_GRADE3 = "資工三";
        private const string _buttonShowSelectResult = "顯示選課結果";
        private const string _buttonSend = "確認送出";

        private string[] EE3_Course4 = { "退選", "開課", "291505", "應用軟體設計實習", "1", "1.0", "3", "▲", "黃士嘉", "", "", "", "", "", "B C D", "", "共同312(e)", "49", "2", "", "", "查詢", "*計網中心電腦教室", "", "是" };
        private string[] CSIE3_Course4 = { "退選", "開課", "291705", "資料庫系統", "1", "3.0", "3", "▲", "劉建宏", "", "", "7", "8 9", "", "", "", "六教327(e)", "100", "1", "", "", "查詢", "◎", "", "" };

       // init
       [TestInitialize]
        public void Initialize()
        {
            var projectName = "homework";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "homework.exe");
            _robot = new Robot(targetAppPath, START_UP_FORM);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        /// <summary>
        /// 測試成功選課，以及退選
        /// </summary>
        [TestMethod]
        public void TestSelectCourseSuccess()
        {
            _robot.ClickButton(_buttonCourseSelecting);
            _robot.SwitchTo(COURSE_SELECT_FORM);

            //_robot.AssertDataGridViewRowCountBy(DATA_GRID_VIEW, 25);
            //_robot.AssertDataGridViewRowCountBy(DATA_GRID_VIEW, 12);

            _robot.ClickDataGridViewCellBy(SELECTING_DATA_GRID_VIEW, 4, "選取");
            _robot.ClickTabControl(TAB_PAGE_CSIE_GRADE3);
            _robot.ClickDataGridViewCellBy(SELECTING_DATA_GRID_VIEW, 4, "選取");
            _robot.ClickButton(_buttonSend);
            _robot.CloseMessageBox();

            //_robot.AssertDataGridViewRowCountBy(DATA_GRID_VIEW, 24);
            //_robot.AssertDataGridViewRowCountBy(DATA_GRID_VIEW, 11);

            _robot.ClickButton(_buttonShowSelectResult);
            _robot.SwitchTo(COURSE_SELECT_RESULT_FORM);

            _robot.AssertDataGridViewRowDataBy(SELECT_RESULT_DATA_GRID_VIEW, 0, EE3_Course4);
            _robot.AssertDataGridViewRowDataBy(SELECT_RESULT_DATA_GRID_VIEW, 1, CSIE3_Course4);

            _robot.ClickDataGridViewCellBy(SELECT_RESULT_DATA_GRID_VIEW, 0, "退");
            _robot.ClickDataGridViewCellBy(SELECT_RESULT_DATA_GRID_VIEW, 0, "退");

            _robot.SwitchTo(COURSE_SELECT_FORM);

            //_robot.AssertDataGridViewRowCountBy(DATA_GRID_VIEW, 25);
            //_robot.AssertDataGridViewRowCountBy(DATA_GRID_VIEW, 12);

            _robot.Sleep(2);
        }

        /// <summary>
        /// 測試衝堂，選課失敗
        /// </summary>
        [TestMethod]
        public void TestSelectCourseFailByCourseTimeConflict()
        {
            //string errMsg = "加選失敗\n課程衝堂 : 291539數位信號處理,291706計算機網路\n";

            _robot.ClickButton(_buttonCourseSelecting);
            _robot.SwitchTo(COURSE_SELECT_FORM);

            _robot.ClickDataGridViewCellBy(SELECTING_DATA_GRID_VIEW, 7, "選取");
            _robot.ClickDataGridViewCellBy(SELECTING_DATA_GRID_VIEW, 8, "選取");
            _robot.ClickTabControl(TAB_PAGE_CSIE_GRADE3);
            _robot.ClickDataGridViewCellBy(SELECTING_DATA_GRID_VIEW, 5, "選取");
            _robot.ClickButton(_buttonSend);

            //_robot.AssertText(errMsg, errMsg);
            _robot.Sleep(1);
            _robot.CloseMessageBox();
            _robot.Sleep(1);
        }

        /// <summary>
        /// 測試名稱相同，選課失敗
        /// </summary>
        [TestMethod]
        public void TestSelectCourseFailByCourseNameConflict()
        {
            //string errMsg = "加選失敗\n課程名稱相同 : 291506實務專題(一),291707實務專題(一)\n";

            _robot.ClickButton(_buttonCourseSelecting);
            _robot.SwitchTo(COURSE_SELECT_FORM);

            _robot.ClickDataGridViewCellBy(SELECTING_DATA_GRID_VIEW, 4, "選取");
            _robot.ClickDataGridViewCellBy(SELECTING_DATA_GRID_VIEW, 5, "選取");
            _robot.ClickTabControl(TAB_PAGE_CSIE_GRADE3);
            _robot.ClickDataGridViewCellBy(SELECTING_DATA_GRID_VIEW, 6, "選取");
            _robot.ClickButton(_buttonSend);

            //_robot.AssertText(errMsg, errMsg);
            _robot.Sleep(1);
            _robot.CloseMessageBox();
            _robot.Sleep(1);
        }

    }
}
