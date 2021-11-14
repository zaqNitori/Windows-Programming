using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.Model;

namespace homework.PresentationModel
{
    public class ImportCourseProgressPresentationModel
    {
        public event ProgressChangedEventHandler _progressChanged;
        public delegate void ProgressChangedEventHandler();
        private CourseManageModel _courseManageModel;
        private const int ONE = 1;
        private const int HUNDRED = 100;
        private const int TWENTY_FIVE = 25;

        public ImportCourseProgressPresentationModel(CourseManageModel courseManageModel)
        {
            _courseManageModel = courseManageModel;
            ProgressBarMinimum = ProgressBarValue = ONE;
            ProgressBarStep = TWENTY_FIVE;
            ProgressBarMaximum = HUNDRED;
            _courseManageModel._progressChanged += NotifyProgressChanged;
        }

        public int ProgressBarMinimum
        {
            get; set;
        }

        public int ProgressBarMaximum
        {
            get; set;
        }

        public int ProgressBarValue
        {
            get; set;
        }

        public int ProgressBarStep
        {
            get; set;
        }

        /// <summary>
        /// 匯入資工系課程
        /// </summary>
        public void ImportComputerScienceCourses()
        {
            _courseManageModel.ImportComputerScienceCourses();
        }

        /// <summary>
        /// 匯入資工系課程 進度通知
        /// </summary>
        private void NotifyProgressChanged()
        {
            if (_progressChanged != null)
                _progressChanged();
        }
    }
}
