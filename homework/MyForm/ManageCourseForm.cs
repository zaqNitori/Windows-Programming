using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework.ViewModel;

namespace homework
{
    public partial class ManageCourseForm : Form
    {
        private List<int> _courseTime;
        const int COLUMN_WIDTH = 40;
        const string COLUMN_NAME = "courseHour";
        const string COLUMN_TITLE = "節數";
        const string COURSE_MANAGE_TITLE = "課程管理";
        const string CLASS_MANAGE_TITLE = "班級管理";

        public ManageCourseForm()
        {
            InitializeComponent();
            InitializeTabControl();

            _courseTime = new List<int>();
            for (var i = 1; i < 9; i++)
            {
                _courseTime.Add(i);
            }

            InitializeDataGridView();
        }

        /// <summary>
        /// 初始化TabControl
        /// </summary>
        /// <history>
        ///     1.  2021.10.31  create function
        /// </history>
        private void InitializeTabControl()
        {
            _tabPage1.Text = COURSE_MANAGE_TITLE;
            _tabPage2.Text = CLASS_MANAGE_TITLE;
        }

        /// <summary>
        /// 初始化Grid
        /// </summary>
        /// <history>
        ///     1.  2021.10.31  create function
        /// </history>
        private void InitializeDataGridView()
        {
            _courseTimeDataGridView.AutoGenerateColumns = false;
            _courseTimeDataGridView.RowHeadersVisible = false;

            _courseTimeDataGridView.DataSource = _courseTime;
            AddRowNumber();
            AddCheckBox();
        }

        /// <summary>
        /// 節數欄位生成
        /// </summary>
        /// <history>
        ///     1.  2021.10.31  create function
        /// </history>
        private void AddRowNumber()
        {
            _courseTimeDataGridView.Columns.Add(COLUMN_NAME, COLUMN_TITLE);

            //int i = 1;
            //foreach (DataGridViewRow row in _courseTimeDataGridView.Rows)
            //{
            //    row.Cells[COLUMN_NAME].Value = i.ToString();
            //    i++;
            //}

        }

        /// <summary>
        /// Grid CheckBox生成
        /// </summary>
        /// <history>
        ///     1.  2021.10.31  create function
        /// </history>
        private void AddCheckBox()
        {

            for (var i = 0; i < 7; i++)
            {
                DataGridViewColumn columnCheck = new DataGridViewCheckBoxColumn();
                columnCheck.Width = COLUMN_WIDTH;
                columnCheck.Name = (CourseProperty.Sunday + i).ToString();
                _courseTimeDataGridView.Columns.Add(columnCheck);
                _courseTimeDataGridView.Columns[i + 1].HeaderText = (CourseProperty.Sunday + i).ToString();
            }

        }

    }
}
