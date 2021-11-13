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

        public SelectCourseForm(CourseSelectingPresentationModel courseSelectingPresentationModel)
        {
            InitializeComponent();

            _courseSelectingPresentationModel = courseSelectingPresentationModel;
            _courseSelectingPresentationModel._modelChanged += RefreshWidgetStatus;
            _courseSelectingPresentationModel._courseChanged += RefreshTabControl;
            _courseDataGridViewComponent1.SetPresentationModel(courseSelectingPresentationModel);
            _courseDataGridViewComponent2.SetPresentationModel(courseSelectingPresentationModel);

            InitializeButton();
            RefreshTabControl();
        }

        /// <summary>
        /// Initial button
        /// </summary>
        private void InitializeButton()
        {
            _buttonShowSelectResult.DataBindings.Add(BINDING_PROPERTY, _courseSelectingPresentationModel, "IsButtonShowSelectResultEnable");
            _buttonShowSelectResult.Click += OpenCourseSelectResultForm;
            _buttonSend.DataBindings.Add(BINDING_PROPERTY, _courseSelectingPresentationModel, "IsButtonSendEnable");
            _buttonSend.Click += SendSelectedCourses;
        }

        /// <summary>
        /// 重整畫面上button的狀態
        /// </summary>
        private void RefreshWidgetStatus()
        {
            _buttonSend.DataBindings[0].ReadValue();
            _buttonShowSelectResult.DataBindings[0].ReadValue();
        }

        /// <summary>
        /// 初始化TabControl設定
        /// </summary>
        private void RefreshTabControl()
        {
            //string controlName = "_courseDataGridViewComponent";
            _department = _courseSelectingPresentationModel.GetAllClassName();
            _courseDataGridViewComponent1.SetDataSource(_courseSelectingPresentationModel.GetCourseByClassName(_department[0]));
            _courseDataGridViewComponent2.SetDataSource(_courseSelectingPresentationModel.GetCourseByClassName(_department[1]));
            //foreach (var dep in _department.Select((value, index) => new 
            //{ 
            //    value, index 
            //}))
            //{
            //    _tabControl.TabPages[dep.index].Text = dep.value;
            //    ((CourseDataGridViewComponent)this.Controls.Find(controlName + (dep.index + 1).ToString(), true)[0]).SetDataSource(_courseSelectingPresentationModel.GetCourseByDepartmentName(dep.value));
            //}
        }

        /// <summary>
        /// 監聽選課結果form關閉事件
        /// </summary>
        private void OpenCourseSelectResultForm(object sender, EventArgs e)
        {
            _courseSelectingResultPresentationModel = new CourseSelectResultPresentationModel(_courseSelectingPresentationModel.GetCourseSelectModel());
            _courseSelectResultForm = new CourseSelectResultForm(_courseSelectingResultPresentationModel);
            _courseSelectResultForm.FormClosed += ListenCourseSelectResultFormClosed;
            _courseSelectingPresentationModel.IsButtonShowSelectResultEnable = false;
            RefreshWidgetStatus();
            _courseSelectResultForm.Show();
        }

        /// <summary>
        /// 送出選取課程
        /// </summary>
        private void SendSelectedCourses(object sender, EventArgs e)
        {
            string message = _courseSelectingPresentationModel.SendSelectedCourses();
            MessageBox.Show(message);
        }

        /// <summary>
        /// 顯示選課結果button 點擊事件
        /// </summary>
        private void ListenCourseSelectResultFormClosed(object sender, FormClosedEventArgs e)
        {
            _courseSelectingPresentationModel.IsButtonShowSelectResultEnable = true;
            RefreshWidgetStatus();
        }

    }
}
