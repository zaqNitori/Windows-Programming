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
        private const string BINDING_PROPERTY = "Enabled";

        public StartUpForm(PresentationModel.StartUpPresentationModel startUpPresentationModel)
        {
            _startUpPresentationModel = startUpPresentationModel;
            InitializeComponent();
            RefreshWidgetStatus();
            InitializeCourseSelectingButton();
            InitializeCourseManagementButton();
            InitializeExitButton();
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
        private void OpenCourseSelectForm(object sender, EventArgs e)
        {
            string courseUrl = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
            Model.Model model = new Model.Model(new Model.CourseCrawler(courseUrl));
            SelectCourseForm selectCourse = new SelectCourseForm(new PresentationModel.CourseSelectingPresentationModel(model));
            selectCourse.FormClosed += ListenCourseSelectFormClosed;
            _startUpPresentationModel.IsButtonCourseSelectingEnabled = false;
            RefreshWidgetStatus();
            selectCourse.Show();
        }

        /// <summary>
        /// 監聽表單關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        private void ListenCourseSelectFormClosed(object sender, FormClosedEventArgs e)
        {
            _startUpPresentationModel.IsButtonCourseSelectingEnabled = true;
            RefreshWidgetStatus();
        }

        /// <summary>
        /// 開啟ManageCourseForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.10  create function
        /// </history>
        private void OpenCourseManageForm(object sender, EventArgs e)
        {
            ManageCourseForm manageCourse = new ManageCourseForm();
            _startUpPresentationModel.IsButtonCourseManagementEnabled = false;
            manageCourse.FormClosed += ListenCourseManagementFormClosed;
            RefreshWidgetStatus();
            manageCourse.Show();
        }

        /// <summary>
        /// 監聽表單關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        private void ListenCourseManagementFormClosed(object sender, FormClosedEventArgs e)
        {
            _startUpPresentationModel.IsButtonCourseManagementEnabled = true;
            RefreshWidgetStatus();
        }

        /// <summary>
        /// Initialize form status
        /// </summary>
        /// <history>
        ///     1.  2021.10.16  create function
        /// </history>
        private void RefreshWidgetStatus()
        {
            _buttonExit.Enabled = _startUpPresentationModel.IsButtonExitEnabled;
            _buttonCourseSelecting.Enabled = _startUpPresentationModel.IsButtonCourseSelectingEnabled;
            _buttonCourseManagement.Enabled = _startUpPresentationModel.IsButtonCourseManagementEnabled;
        }

        /// <summary>
        /// Initial button
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        private void InitializeCourseSelectingButton()
        {
            _buttonCourseSelecting.DataBindings.Add(BINDING_PROPERTY, _startUpPresentationModel, "IsButtonCourseSelectingEnabled");
            _buttonCourseSelecting.Click += OpenCourseSelectForm;
        }

        /// <summary>
        /// Initial button
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        private void InitializeCourseManagementButton()
        {
            _buttonCourseManagement.DataBindings.Add(BINDING_PROPERTY, _startUpPresentationModel, "IsButtonCourseManagementEnabled");
            _buttonCourseManagement.Click += OpenCourseManageForm;
        }

        /// <summary>
        /// Initial button
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        private void InitializeExitButton()
        {
            _buttonExit.DataBindings.Add(BINDING_PROPERTY, _startUpPresentationModel, "IsButtonExitEnabled");
            _buttonExit.Click += ExitStartUpForm;
        }

    }
}
