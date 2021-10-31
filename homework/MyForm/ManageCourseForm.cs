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
using homework.ViewModel;

namespace homework
{
    public partial class ManageCourseForm : Form
    {
        private CourseManagementPresentationModel _courseManagementPresentationModel;
        private const string BINDING_PROPERTY = "ReadOnly";
        private const string SOURCE_PROPERTY = "IsCourseEditReadOnly";
        const string COLUMN_NAME = "courseHour";
        const string COLUMN_TITLE = "節數";

        public ManageCourseForm(CourseManagementPresentationModel courseManagementPresentationModel)
        {
            _courseManagementPresentationModel = courseManagementPresentationModel;
            InitializeComponent();
            InitializeTabControl();
            InitializeListBox();
            InitializeDataGridView();
            SetGroupBoxControlsStatus(_courseGroupBox.Controls);
        }

        /// <summary>
        /// 初始化TabControl
        /// </summary>
        private void InitializeTabControl()
        {
            _tabPage1.Text = CourseManageProperty.COURSE_MANAGE_TAB_PAGE_TITLE;
            _tabPage2.Text = CourseManageProperty.CLASS_MANAGE_TAB_PAGE_TITLE;
        }

        /// <summary>
        /// 初始化TabControl
        /// </summary>
        private void InitializeListBox()
        {
            _courseListBox.DataSource = _courseManagementPresentationModel.GetCurriculumAsItem();
            _courseListBox.SelectedIndex = -1;
            _courseListBox.SelectedIndexChanged += ListenCourseListBoxSelectedIndexChanged;
        }

        /// <summary>
        /// 初始化Grid
        /// </summary>
        private void InitializeDataGridView()
        {
            _courseTimeDataGridView.DataBindings.Add(BINDING_PROPERTY, _courseManagementPresentationModel, SOURCE_PROPERTY);
            _courseTimeDataGridView.AutoGenerateColumns = false;
            _courseTimeDataGridView.RowHeadersVisible = false;

            AddRowNumber();
            AddCheckBox();
        }

        /// <summary>
        /// 節數欄位生成
        /// </summary>
        private void AddRowNumber()
        {
            _courseTimeDataGridView.Columns.Add(COLUMN_NAME, COLUMN_TITLE);

            for (var i = 1; i < 9; i++) 
            {
                _courseTimeDataGridView.Rows.Add();
            }

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
        private void AddCheckBox()
        {

            for (var i = 0; i < 7; i++)
            {
                DataGridViewColumn columnCheck = new DataGridViewCheckBoxColumn();
                columnCheck.Width = CourseManageProperty.COLUMN_WIDTH;
                columnCheck.Name = (CourseProperty.Sunday + i).ToString();
                _courseTimeDataGridView.Columns.Add(columnCheck);
                _courseTimeDataGridView.Columns[i + 1].HeaderText = (CourseProperty.Sunday + i).ToString();
            }

        }

        /// <summary>
        /// 監聽ListBox 選取事件
        /// </summary>
        private void ListenCourseListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            //ListBox cmb = (ListBox)sender;
            //DataItem item = (DataItem)cmb.SelectedItem;
            //MessageBox.Show(item.Value + '-' + item.Text);
            _courseManagementPresentationModel.IsCourseEditReadOnly = false;
            RefreshWidgetStatus();
        }

        /// <summary>
        /// 設定groupBox 內的元件的狀態
        /// </summary>
        private void SetGroupBoxControlsStatus(Control.ControlCollection controlCollection)
        {

            if (controlCollection == null)
            {
                return;
            }
            
            foreach (TextBoxBase c in controlCollection.OfType<TextBoxBase>())
            {
                c.DataBindings.Add(BINDING_PROPERTY, _courseManagementPresentationModel, SOURCE_PROPERTY);
            }
        }

        /// <summary>
        /// Initialize form status
        /// </summary>
        private void RefreshWidgetStatus()
        {
            _courseTimeDataGridView.DataBindings[0].ReadValue();
            foreach (TextBoxBase c in _courseGroupBox.Controls.OfType<TextBoxBase>())
            {
                c.DataBindings[0].ReadValue();
            }
        }

    }
}
