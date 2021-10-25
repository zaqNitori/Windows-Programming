﻿using System;
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
        private CourseSelectResultPresentationModel _courseSelectingResultPresentationModel;
        private ManageCourseForm _manageCourseForm;
        private StartUpPresentationModel _startUpPresentationModel;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        public void SetCourseSelectingPresentationModel(CourseSelectingPresentationModel courseSelectingPresentationModel)
        {
            _courseSelectingPresentationModel = courseSelectingPresentationModel;
        }

        /// <summary>
        /// 設定PresentationModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public void SetCourseSelectingResultPresentationModel(CourseSelectResultPresentationModel courseSelectingResultPresentationModel)
        {
            _courseSelectingResultPresentationModel = courseSelectingResultPresentationModel;
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
            _selectCourseForm = new SelectCourseForm(_courseSelectingPresentationModel);
            _selectCourseForm.SetCourseSelectingResultPresentationModel(_courseSelectingResultPresentationModel);
            _selectCourseForm.FormClosed += ListenCourseSelectFormClosed;
            _startUpPresentationModel.IsButtonCourseSelectingEnabled = false;
            RefreshWidgetStatus();
            _selectCourseForm.Show();
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
            _manageCourseForm = new ManageCourseForm();
            _startUpPresentationModel.IsButtonCourseManagementEnabled = false;
            _manageCourseForm.FormClosed += ListenCourseManagementFormClosed;
            RefreshWidgetStatus();
            _manageCourseForm.Show();
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
        ///     2.  2021.10.24  相同功能，不同呼叫方式
        /// </history>
        private void RefreshWidgetStatus()
        {
            _buttonExit.DataBindings[0].ReadValue();
            _buttonCourseSelecting.DataBindings[0].ReadValue();
            _buttonCourseManagement.DataBindings[0].ReadValue();
        }

        /// <summary>
        /// Initial button
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
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
