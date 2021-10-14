using System;
using System.Windows.Forms;

namespace homework
{
    public partial class SelectCourseForm : Form
    {
        private PresentationModel.CourseSelectingFormPresentationModel _coursePresentationModel;
        private int _checkBoxWidth = 45;
        private string _checkBoxName = "checkBoxCol";
        private string _checkBoxTitle = "選取";

        public SelectCourseForm(PresentationModel.CourseSelectingFormPresentationModel coursePresentationModel)
        {
            InitializeComponent();
            InitializeDataGridView();
            _coursePresentationModel = coursePresentationModel;
            _courseGridView.CellValueChanged += ListenCourseDataGridOnCellValueChanged;
            _courseGridView.CellMouseUp += ListenCourseDataGridOnCellMouseUp;
            _buttonShowSelectResult.Click += ShowSelectResult;
        }

        /// <summary>
        /// 監聽數值變動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.04  create function ，為了避免連點問題，改成監聽MouseUp然後呼叫OnValueChanged，來解決。
        /// </history>
        private void ListenCourseDataGridOnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Click CheckBox Event
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _coursePresentationModel.SetCourseCheckBoxStatus(e.RowIndex);
                _buttonSend.Enabled = _coursePresentationModel.IsButtonSendEnable();
            }
        }

        /// <summary>
        /// 監聽滑鼠點擊釋放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.04  create function ，為了避免連點問題，改成監聽MouseUp然後呼叫OnValueChanged，來解決。
        /// </history>
        private void ListenCourseDataGridOnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Click CheckBox Event
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _courseGridView.EndEdit();
            }
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        ///     1.  2021.10.02  create function 
        /// </history>
        private void LoadSelectCourseForm(object sender, EventArgs e)
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
            _buttonSend.Enabled = _coursePresentationModel.IsButtonSendEnable();
            _buttonShowSelectResult.Enabled = _coursePresentationModel.IsButtonShowSelectResultEnable();
        }

        /// <summary>
        /// 初始化dataGridView設定
        /// </summary>
        /// <history>
        ///     1.  2021.09.30  create function
        /// </history>
        private void InitializeDataGridView()
        {
            _courseGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _courseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AddCheckBox();
            _courseGridView.RowHeadersVisible = false;
            _courseGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            _courseGridView.Columns.Insert(0, columnCheck);
            _courseGridView.Columns[0].HeaderText = _checkBoxTitle;
        }

        /// <summary>
        /// Bind Course Grid View DataSource
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void BindCourseData()
        {
            _courseGridView.DataSource = _coursePresentationModel.GetCourse();
        }

        /// <summary>
        /// 顯示選課結果button 點擊事件
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private void ShowSelectResult(object sender, EventArgs e)
        {
            MessageBox.Show(_coursePresentationModel.GetSelectedResult(_courseGridView.Rows));
        }

    }
}
