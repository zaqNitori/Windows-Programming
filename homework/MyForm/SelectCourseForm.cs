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

namespace homework
{
    public partial class SelectCourseForm : Form
    {
        private List<string> _department;
        private PresentationModel.CourseSelectingPresentationModel _courseSelectingPresentationModel;
        private const string BINDING_PROPERTY = "Enabled";

        public SelectCourseForm(PresentationModel.CourseSelectingPresentationModel coursePresentationModel)
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
            _buttonShowSelectResult.Click += ShowSelectResult;
            _buttonSend.DataBindings.Add(BINDING_PROPERTY, _courseSelectingPresentationModel, "IsButtonSendEnable");
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
        /// 顯示選課結果button 點擊事件
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void ShowSelectResult(object sender, EventArgs e)
        {
            //MessageBox.Show(_courseSelectingPresentationModel.GetSelectedResult(_courseGridView.Rows));
        }

    }
}
