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

        private Robot _robot;
        private const string _buttonCourseSelecting = "Course Selecting System";
        private const string _buttonCourseManagement = "Course Management System";
        private const string _buttonExit = "Exit";
        private const string RESULT_CONTROL_NAME = "CalculatorResults";

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

        [TestMethod]
        public void TestSelectCourseSuccess()
        {
            _robot.ClickButton(_buttonCourseSelecting);
            _robot.SwitchTo(COURSE_SELECT_FORM);
            _robot.ClickButton("顯示選課結果");
            _robot.Sleep(2);
        }
    }
}
