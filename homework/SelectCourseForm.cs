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
    public partial class SelectCourseForm : Form
    {
        private PresentationModel.CoursePresentationModel _coursePresentationModel;
        private string _courseUrl = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
        private int _checkBoxWidth = 45;
        private string _checkBoxName = "checkBoxCol";
        private string _checkBoxTitle = "選取";

        public SelectCourseForm(PresentationModel.CoursePresentationModel coursePresentationModel)
        {
            InitializeComponent();
            InitializeDataGridView();
            _coursePresentationModel = coursePresentationModel;
            courseGridView.CellContentClick += ChangeCourseDataGridViewCheckBoxStatus;
            buttonShowSelectResult.Click += ShowSelectResult;
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.02  create function 
        /// </history>
        private void SelectCourseFormLoad(object sender, EventArgs e)
        {
            RefreshFormObject();
            BindCourseData();
        }

        /// <summary>
        /// Initialize form object
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void RefreshFormObject()
        {
            buttonSend.Enabled = _coursePresentationModel.IsButtonSendEnable();
            buttonShowSelectResult.Enabled = _coursePresentationModel.IsButtonShowSelectResultEnable();
        }

        /// <summary>
        /// 初始化dataGridView設定
        /// </summary>
        /// <history>
        ///     1.  2021.09.30  create function
        /// </history>
        private void InitializeDataGridView()
        {
            courseGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            courseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AddCheckBox();
            courseGridView.RowHeadersVisible = false;
            courseGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 加入CheckBox控制項
        /// </summary>
        /// <history>
        ///     1.  2021.09.30  create function
        /// </history>
        private void AddCheckBox()
        {
            DataGridViewColumn columnCheck = new DataGridViewCheckBoxColumn();
            columnCheck.Width = _checkBoxWidth;
            columnCheck.Name = _checkBoxName;
            courseGridView.Columns.Insert(0, columnCheck);
            courseGridView.Columns[0].HeaderText = _checkBoxTitle;
        }

        /// <summary>
        /// Bind Course Grid View DataSource
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void BindCourseData()
        {
            courseGridView.DataSource = _coursePresentationModel.GetCourse(_courseUrl);
        }

        /// <summary>
        /// dataGridView 內 CheckBox被點擊的事件
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void ChangeCourseDataGridViewCheckBoxStatus(object sender, EventArgs e)
        {
            _coursePresentationModel.SetCourseCheckBoxStatus(courseGridView.CurrentCell.RowIndex);
            buttonSend.Enabled = _coursePresentationModel.IsButtonSendEnable();
        }

        /// <summary>
        /// 顯示選課結果button 點擊事件
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void ShowSelectResult(object sender, EventArgs e)
        {
            MessageBox.Show(_coursePresentationModel.GetSelectedResult(courseGridView.Rows));
        }

    }
}
