using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace homework
{
    public partial class MyClassForm : Form
    {
        private List<ViewModel.Course> _courseList;
        private Model _model;
        private const string URL = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";

        public MyClassForm(Model model)
        {   
            InitializeComponent();
            InitDataGridView();
            _model = model;
            btnSend.Enabled = false;
        }

        private void MyClassForm_Load(object sender, EventArgs e)
        {
            _courseList = HTMLParser.htmlParser.GetCourseInfo(URL);
            dataGridView1.DataSource = _courseList;
        }

        /// <summary>
        /// 初始化dataGridView設定
        /// </summary>
        /// <history>
        ///     1.  2021.09.30  初始化dataGridView設定
        /// </history>
        private void InitDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AddCheckBox();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CellContentClick += dataGridView1_CheckBoxCheck;
        }

        /// <summary>
        /// 加入CheckBox控制項
        /// </summary>
        /// <history>
        ///     1.  2021.09.30  加入CheckBox控制項
        /// </history>
        private void AddCheckBox()
        {
            DataGridViewColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Width = 45;
            colCheck.Name = "checkBoxCol";
            dataGridView1.Columns.Insert(0, colCheck);
            dataGridView1.Columns[0].HeaderText = "選取";
        }

        private void dataGridView1_CheckBoxCheck(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentCell.RowIndex.ToString());
        }

        private void btnCheckSelect_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_model.GetSelectedData(dataGridView1.Rows));
            //MessageBox.Show(Convert.ToString(dataGridView1.Rows[3].Cells["Number"].Value));
        }
    }
}
