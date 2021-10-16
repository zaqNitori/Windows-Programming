using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework
{
    public partial class StartUpForm : Form
    {
        private PresentationModel.StartUpPresentationModel _startUpPresentationModel;

        public StartUpForm(PresentationModel.StartUpPresentationModel startUpPresentationModel)
        {
            InitializeComponent();
            RefreshWidgetStatus();
            _buttonExit.Click += ExitStartUpForm;
            _buttonCourseSelecting.Click += OpenSelectCourseForm;
            _buttonCourseManagement.Click += OpenManageCourseForm;
            _startUpPresentationModel = startUpPresentationModel;
        }

        /// <summary>
        /// 關閉StartUpForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.10  create function
        /// </history>
        private void ExitStartUpForm(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 開啟SelectCourseForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.10  create function
        /// </history>
        private void OpenSelectCourseForm(object sender, EventArgs e)
        {
            string courseUrl = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
            Model.Model model = new Model.Model(new Model.CourseCrawler(courseUrl));
            SelectCourseForm selectCourse = new SelectCourseForm(new PresentationModel.CourseSelectingPresentationModel(model));
            selectCourse.Show();
        }

        /// <summary>
        /// 開啟ManageCourseForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.10  create function
        /// </history>
        private void OpenManageCourseForm(object sender, EventArgs e)
        {
            ManageCourseForm manageCourse = new ManageCourseForm();
            manageCourse.Show();
        }

        /// <summary>
        /// Initialize form status
        /// </summary>
        /// <history>
        ///     1.  2021.10.16  create function
        /// </history>
        private void RefreshWidgetStatus()
        {
            _buttonExit.Enabled = _startUpPresentationModel.IsButtonExitEnabled();
            _buttonCourseSelecting.Enabled = _startUpPresentationModel.IsButtonCourseSelectingEnabled();
            _buttonCourseManagement.Enabled = _startUpPresentationModel.IsButtonCourseManagementEnabled();
        }

    }
}
