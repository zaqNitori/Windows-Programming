using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework.Model;
using homework.PresentationModel;

namespace homework
{
    static class Program
    {

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string COURSE1 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
            const string COURSE2 = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=109&sem=1&code=2433";
            List<string> courseUrl = new List<string>();
            courseUrl.Add(COURSE1);
            courseUrl.Add(COURSE2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CourseModel courseModel = new CourseModel();
            courseModel.FetchCourseInfo(courseUrl);
            CourseSelectingPresentationModel courseSelectingPresentationModel = new CourseSelectingPresentationModel(courseModel);
            CourseSelectResultPresentationModel courseSelectingResultPresentationModel = new CourseSelectResultPresentationModel(courseModel);
            StartUpPresentationModel startUpPresentationModel = new StartUpPresentationModel(courseModel);
            StartUpForm startUpForm = new StartUpForm(startUpPresentationModel);
            startUpForm.SetCourseSelectingPresentationModel(courseSelectingPresentationModel);
            startUpForm.SetCourseSelectingResultPresentationModel(courseSelectingResultPresentationModel);
            Application.Run(startUpForm);
        }
    }
}
