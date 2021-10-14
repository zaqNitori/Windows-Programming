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
        public StartUpForm()
        {
            InitializeComponent();
            _buttonExit.Click += ExitStartUpForm;
            _buttonCourseSelecting.Click += OpenSelectCourseForm;
            _buttonCourseManagement.Click += OpenManageCourseForm;
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
            SelectCourseForm selectCourse = new SelectCourseForm(new PresentationModel.CourseSelectingFormPresentationModel(model));
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

    }
}
