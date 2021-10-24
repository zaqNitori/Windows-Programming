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

namespace homework.MyController
{
    public partial class CourseDataGridViewComponent : UserControl
    {
        private PresentationModel.CourseSelectingPresentationModel _courseSelectingPresentationModel;
        const int COLUMN_WIDTH = 45;
        const string COLUMN_NAME = "checkBoxCol";
        const string COLUMN_TITLE = "選取";

        public CourseDataGridViewComponent()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        /// <summary>
        /// 監聽滑鼠點擊釋放
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public void SetPresentationModel(PresentationModel.CourseSelectingPresentationModel courseSelectingPresentationModel)
        {
            _courseSelectingPresentationModel = courseSelectingPresentationModel;
        }

        /// <summary>
        /// 監聽滑鼠點擊釋放
        /// </summary>
        /// <history>
        ///     1.  2021.10.25  create function
        /// </history>
        public void SetDataSource(List<Course> courses)
        {
            _courseDataGridView.DataSource = courses;
        }

        /// <summary>
        /// 監聽滑鼠點擊釋放
        /// </summary>
        /// <history>
        ///     1.  2021.10.04  create function ，為了避免連點問題，改成監聽MouseUp然後呼叫OnValueChanged，來解決。
        ///     2.  2021.10.25  移動到UserControl內
        /// </history>
        private void ListenCourseDataGridOnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Click CheckBox Event
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _courseDataGridView.EndEdit();
            }
        }

        /// <summary>
        /// 初始化dataGridView設定
        /// </summary>
        /// <history>
        ///     1.  2021.09.30  create function
        ///     2.  2021.10.25  移動到UserControl內
        /// </history>
        private void InitializeDataGridView()
        {
            _courseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AddCheckBox();
            _courseDataGridView.RowHeadersVisible = false;
            _courseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            _courseDataGridView.CellValueChanged += ListenCourseDataGridOnCellValueChanged;
            _courseDataGridView.CellMouseUp += ListenCourseDataGridOnCellMouseUp;
        }

        /// <summary>
        /// 加入CheckBox控制項
        /// </summary>
        /// <history>
        ///     1.  2021.09.30  create function
        ///     2.  2021.10.25  移動到UserControl內
        /// </history>
        private void AddCheckBox()
        {
            
            DataGridViewColumn columnCheck = new DataGridViewCheckBoxColumn();
            columnCheck.Width = COLUMN_WIDTH;
            columnCheck.Name = COLUMN_NAME;
            _courseDataGridView.Columns.Insert(0, columnCheck);
            _courseDataGridView.Columns[0].HeaderText = COLUMN_TITLE;
        }

        /// <summary>
        /// 監聽數值變動
        /// </summary>
        /// <history>
        ///     1.  2021.10.04  create function ，為了避免連點問題，改成監聽MouseUp然後呼叫OnValueChanged，來解決。
        ///     2.  2021.10.25  移動到UserControl內
        /// </history>
        private void ListenCourseDataGridOnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Click CheckBox Event
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _courseSelectingPresentationModel.SetCourseCheckBoxStatus(e.RowIndex);
            }
        }

    }
}
