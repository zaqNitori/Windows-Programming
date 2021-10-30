using System.Collections.Generic;
using homework.PresentationModel;
using homework.Model;

namespace homework
{
    public class StartUp
    {
        private List<string> _coursesUrl;
        private CourseModel _courseModel;
        private CourseSelectingPresentationModel _courseSelectingPresentationModel;
        private CourseSelectResultPresentationModel _courseSelectingResultPresentationModel;
        private CourseManagementPresentationModel _courseManagementPresentationModel;
        private StartUpPresentationModel _startUpPresentationModel;

        public StartUp()
        {
            _coursesUrl = new List<string>();
            _courseModel = new CourseModel();
            _courseSelectingPresentationModel = new CourseSelectingPresentationModel(_courseModel);
            _courseSelectingResultPresentationModel = new CourseSelectResultPresentationModel(_courseModel);
            _courseManagementPresentationModel = new CourseManagementPresentationModel(_courseModel);
            _startUpPresentationModel = new StartUpPresentationModel(_courseModel);
            startUpForm = new StartUpForm(_startUpPresentationModel);
            SetCoursesUrl();
            InitializeObject();
        }

        public StartUpForm startUpForm
        {
            get; 
        }

        /// <summary>
        /// 設定爬蟲目標網址 
        /// </summary>
        /// <history>
        ///     1.  2021.10.30  create function
        /// </history>
        private void SetCoursesUrl()
        {
            const string COURSE1 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
            const string COURSE2 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=109&sem=1&code=2433";
            _coursesUrl.Add(COURSE1);
            _coursesUrl.Add(COURSE2);
        }

        /// <summary>
        /// 初始化設定 
        /// </summary>
        /// <history>
        ///     1.  2021.10.30  create function
        /// </history>
        private void InitializeObject()
        {
            _courseModel.FetchCourseInfo(_coursesUrl);

            startUpForm.SetCourseSelectingPresentationModel(_courseSelectingPresentationModel);
            startUpForm.SetCourseSelectingResultPresentationModel(_courseSelectingResultPresentationModel);
            startUpForm.SetCourseManagementPresentationModel(_courseManagementPresentationModel);
        }

    }
}
