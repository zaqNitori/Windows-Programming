using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework.Model;
using homework.PresentationModel;

namespace homework
{
    public partial class StartUpForm : Form
    {
        private SelectCourseForm _selectCourseForm;
        private CourseSelectingPresentationModel _courseSelectingPresentationModel;
        private ManageCourseForm _manageCourseForm;
        private CourseManagementPresentationModel _courseManagementPresentationModel;
        private StartUpPresentationModel _startUpPresentationModel;
        private CourseModel _courseModel;
        private CourseManageModel _courseManageModel;
        private const string BINDING_PROPERTY = "Enabled";

        public StartUpForm(StartUpPresentationModel startUpPresentationModel)
        {
            _startUpPresentationModel = startUpPresentationModel;
            InitializeComponent();
            InitializeButton();
            RefreshWidgetStatus();
        }

        /// <summary>
        /// 設定PresentationModel
        /// </summary>
        public void SetCourseSelectModel(CourseModel courseModel)
        {
            _courseModel = courseModel;
        }

        /// <summary>
        /// 設定PresentationModel
        /// </summary>
        public void SetCourseManageModel(CourseManageModel courseManageModel)
        {
            _courseManageModel = courseManageModel;
        }

        /// <summary>
        /// 關閉StartUpForm
        /// </summary>
        private void ExitStartUpForm(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 開啟SelectCourseForm
        /// </summary>
        private void OpenCourseSelectForm(object sender, EventArgs e)
        {
            _courseSelectingPresentationModel = new CourseSelectingPresentationModel(_courseModel);
            _selectCourseForm = new SelectCourseForm(_courseSelectingPresentationModel);
            _selectCourseForm.FormClosed += ListenCourseSelectFormClosed;
            _startUpPresentationModel.IsButtonCourseSelectingEnabled = false;
            RefreshWidgetStatus();
            _selectCourseForm.Show();
        }

        /// <summary>
        /// 監聽表單關閉事件
        /// </summary>
        private void ListenCourseSelectFormClosed(object sender, FormClosedEventArgs e)
        {
            _startUpPresentationModel.IsButtonCourseSelectingEnabled = true;
            RefreshWidgetStatus();
        }

        /// <summary>
        /// 開啟ManageCourseForm
        /// </summary>
        private void OpenCourseManageForm(object sender, EventArgs e)
        {
            _courseManagementPresentationModel = new CourseManagementPresentationModel(_courseManageModel);
            _manageCourseForm = new ManageCourseForm(_courseManagementPresentationModel);
            _startUpPresentationModel.IsButtonCourseManagementEnabled = false;
            _manageCourseForm.FormClosed += ListenCourseManagementFormClosed;
            RefreshWidgetStatus();
            _manageCourseForm.Show();
        }

        /// <summary>
        /// 監聽表單關閉事件
        /// </summary>
        private void ListenCourseManagementFormClosed(object sender, FormClosedEventArgs e)
        {
            _startUpPresentationModel.IsButtonCourseManagementEnabled = true;
            RefreshWidgetStatus();
        }

        /// <summary>
        /// Initialize form status
        /// </summary>
        private void RefreshWidgetStatus()
        {
            _buttonExit.DataBindings[0].ReadValue();
            _buttonCourseSelecting.DataBindings[0].ReadValue();
            _buttonCourseManagement.DataBindings[0].ReadValue();
        }

        /// <summary>
        /// Initial button
        /// </summary>
        private void InitializeButton()
        {
            _buttonCourseSelecting.DataBindings.Add(BINDING_PROPERTY, _startUpPresentationModel, "IsButtonCourseSelectingEnabled");
            _buttonCourseManagement.DataBindings.Add(BINDING_PROPERTY, _startUpPresentationModel, "IsButtonCourseManagementEnabled");
            _buttonExit.DataBindings.Add(BINDING_PROPERTY, _startUpPresentationModel, "IsButtonExitEnabled");
            _buttonExit.Click += ExitStartUpForm;
            _buttonCourseManagement.Click += OpenCourseManageForm;
            _buttonCourseSelecting.Click += OpenCourseSelectForm;
        }

    }
}
