using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.PresentationModel;
using System.Windows.Forms;

namespace homework
{
    public partial class ImportCourseProgressForm : Form
    {
        private ImportCourseProgressPresentationModel _importCourseProgressPresentationModel;
        private string _loadingText = "正在載入課程...";
        private const string PERCENT = "%";

        public ImportCourseProgressForm(ImportCourseProgressPresentationModel importCourseProgressPresentationModel)
        {
            InitializeComponent();
            _importCourseProgressPresentationModel = importCourseProgressPresentationModel;
            _importCourseProgressPresentationModel._progressChanged += StartRunProgressBar;
            InitializeProgressBar();
            this.Shown += ListenImportCourseProgressShow;
        }

        /// <summary>
        /// 初始化 進度條
        /// </summary>
        private void InitializeProgressBar()
        {
            _loadingProgressBar.Visible = true;
            _loadingProgressBar.Minimum = _importCourseProgressPresentationModel.ProgressBarMinimum;
            _loadingProgressBar.Maximum = _importCourseProgressPresentationModel.ProgressBarMaximum;
            _loadingProgressBar.Value = _importCourseProgressPresentationModel.ProgressBarValue;
            _loadingProgressBar.Step = _importCourseProgressPresentationModel.ProgressBarStep;
            _loadingLabel.Text = _loadingText + _loadingProgressBar.Value.ToString() + PERCENT;
        }

        /// <summary>
        /// 監聽表單顯示事件
        /// </summary>
        private void ListenImportCourseProgressShow(object sender, EventArgs e)
        {
            ImportCourses();
            System.Threading.Thread.Sleep(600);
            _importCourseProgressPresentationModel._progressChanged -= StartRunProgressBar;
            this.Close();
        }

        /// <summary>
        /// 匯入資工系課程
        /// </summary>
        private void ImportCourses()
        {
            _importCourseProgressPresentationModel.ImportComputerScienceCourses();
        }

        /// <summary>
        /// 啟動 進度條
        /// </summary>
        private void StartRunProgressBar()
        {
            _loadingProgressBar.PerformStep();
            System.Threading.Thread.Sleep(500);
            _loadingLabel.Text = _loadingText + _loadingProgressBar.Value.ToString() + PERCENT;
            Application.DoEvents();

        }

    }
}
