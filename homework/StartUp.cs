using System.Collections.Generic;
using homework.PresentationModel;
using homework.Model;
using homework.Manager;

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
            _coursesUrl.Add(Common.COMPUTER_SCIENCE_GRADE2_COURSE_URL);
            _coursesUrl.Add(Common.COMPUTER_SCIENCE_GRADE3_COURSE_URL);
        }

        /// <summary>
        /// 初始化設定 
        /// </summary>
        /// <history>
        ///     1.  2021.10.30  create function
        /// </history>
        private void InitializeObject()
        {
            _courseManageModel.FetchCourseInfo(_coursesUrl);

            startUpForm.SetCourseManageModel(_courseManageModel);
            startUpForm.SetCourseSelectModel(_courseModel);
        }

    }
}
