using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.MyController;
using homework.PresentationModel;

namespace homework
{
    public partial class SelectCourseForm : Form
    {
        private List<string> _department;
        private CourseSelectingPresentationModel _courseSelectingPresentationModel;
        private CourseSelectResultPresentationModel _courseSelectingResultPresentationModel;
        private CourseSelectResultForm _courseSelectResultForm;
        private const string BINDING_PROPERTY = "Enabled";

        public SelectCourseForm(CourseSelectingPresentationModel coursePresentationModel)
        {
            InitializeComponent();

            _courseSelectingPresentationModel = coursePresentationModel;
            _courseSelectingPresentationModel._modelChanged += RefreshWidgetStatus;
            _courseDataGridViewComponent1.SetPresentationModel(coursePresentationModel);
            _courseDataGridViewComponent2.SetPresentationModel(coursePresentationModel);

            InitializeButton();
            InitializeTabControl();
        }

        /// <summary>
        /// Initial button
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private void InitializeButton()
        {
            _buttonShowSelectResult.DataBindings.Add(BINDING_PROPERTY, _courseSelectingPresentationModel, "IsButtonShowSelectResultEnable");
            _buttonShowSelectResult.Click += OpenCourseSelectResultForm;
            _buttonSend.DataBindings.Add(BINDING_PROPERTY, _courseSelectingPresentationModel, "IsButtonSendEnable");
            _buttonSend.Click += SendSelectedCourses;
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
        /// 重整畫面上button的狀態
        /// </summary>
        /// <history>
        ///     1.  2021.10.16  create function
        ///     2.  2021.10.24  相同功能，不同呼叫方式
        /// </history>
        private void RefreshWidgetStatus()
        {
            _buttonSend.DataBindings[0].ReadValue();
            _buttonShowSelectResult.DataBindings[0].ReadValue();
        }

        /// <summary>
        /// 初始化TabControl設定
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private void InitializeTabControl()
        {
            string controlName = "_courseDataGridViewComponent";
            _department = _courseSelectingPresentationModel.GetAllDepartment();
            foreach (var dep in _department.Select((value, index) => new 
            { 
                value, index 
            }))
            {
                _tabControl.TabPages[dep.index].Text = dep.value;
                ((CourseDataGridViewComponent)this.Controls.Find(controlName + (dep.index + 1).ToString(), true)[0]).SetDataSource(_courseSelectingPresentationModel.GetCourseByDepartmentName(dep.value));
            }
        }

        /// <summary>
        /// 監聽選課結果form關閉事件
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void OpenCourseSelectResultForm(object sender, EventArgs e)
        {
            _courseSelectResultForm = new CourseSelectResultForm(_courseSelectingResultPresentationModel);
            _courseSelectResultForm.FormClosed += ListenCourseSelectResultFormClosed;
            _courseSelectingPresentationModel.IsButtonShowSelectResultEnable = false;
            RefreshWidgetStatus();
            _courseSelectResultForm.Show();
        }

        /// <summary>
        /// 送出選取課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void SendSelectedCourses(object sender, EventArgs e)
        {
            _courseSelectingPresentationModel.SendSelectedCourses();
        }

        /// <summary>
        /// 顯示選課結果button 點擊事件
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void ListenCourseSelectResultFormClosed(object sender, FormClosedEventArgs e)
        {
            _courseSelectingPresentationModel.IsButtonShowSelectResultEnable = true;
            RefreshWidgetStatus();
        }

    }
}
