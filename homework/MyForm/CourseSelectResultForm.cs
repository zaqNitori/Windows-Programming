using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework.PresentationModel;

namespace homework
{
    public partial class CourseSelectResultForm : Form
    {
        private CourseSelectResultPresentationModel _courseSelectResultPresentationModel;
        const int COLUMN_WIDTH = 45;
        const string COLUMN_NAME = "buttonCol";
        const string COLUMN_TITLE = "退";
        const string COLUMN_TEXT = "退選";

        public CourseSelectResultForm(CourseSelectResultPresentationModel courseSelectResultPresentationModel)
        {
            InitializeComponent();
            AddButton();

            _courseSelectResultPresentationModel = courseSelectResultPresentationModel;
            _courseSelectResultPresentationModel._courseChanged += RefreshSelectResultDataGridView;
            RefreshSelectResultDataGridView();
            _courseSelectResultDataGridView.CellContentClick += ClickCourseSelectResultDataGridViewCellContent;
            Common.ActivateDoubleBuffer(_courseSelectResultDataGridView);
        }

        /// <summary>
        /// 加入button控制項
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        private void AddButton()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Width = COLUMN_WIDTH;
            buttonColumn.Name = COLUMN_NAME;
            buttonColumn.Text = COLUMN_TEXT;
            buttonColumn.UseColumnTextForButtonValue = true;
            _courseSelectResultDataGridView.Columns.Insert(0, buttonColumn);
            _courseSelectResultDataGridView.Columns[0].HeaderText = COLUMN_TITLE;
            _courseSelectResultDataGridView.RowHeadersVisible = false;
        }

        /// <summary>
        /// 退選課程按鈕按下事件
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history> 
        private void ClickCourseSelectResultDataGridViewCellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _courseSelectResultPresentationModel.DropCourse(e.ColumnIndex);
            }
        }

        /// <summary>
        /// 重新拉取選課結果
        /// </summary>
        private void RefreshSelectResultDataGridView()
        {
            _courseSelectResultDataGridView.DataSource = _courseSelectResultPresentationModel.GetChosenCourses();
        }

    }
}
