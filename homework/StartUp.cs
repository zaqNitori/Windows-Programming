using System.Collections.Generic;
using homework.PresentationModel;
using homework.Model;
using homework.Data;

namespace homework
{
    public class StartUp
    {
        private List<string> _coursesUrl;
        private CourseSelectModel _courseModel;
        private CourseManageModel _courseManageModel;
        private StartUpPresentationModel _startUpPresentationModel;
        private StoreDataManager _storeDataManager;

        public StartUp()
        {
            _coursesUrl = new List<string>();
            _storeDataManager = new StoreDataManager();
            _courseModel = new CourseSelectModel(_storeDataManager);
            _courseManageModel = new CourseManageModel(_storeDataManager);
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

            startUpForm.SetCourseManageModel(_courseManageModel);
            startUpForm.SetCourseSelectModel(_courseModel);
        }

    }
}
