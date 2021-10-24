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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CourseModel courseModel = new CourseModel();

            CourseSelectingPresentationModel courseSelectingPresentationModel = new CourseSelectingPresentationModel(courseModel);
            StartUpPresentationModel startUpPresentationModel = new StartUpPresentationModel(courseModel);
            
            StartUpForm startUpForm = new StartUpForm(startUpPresentationModel);
            startUpForm.SetCourseSelectingPresentationModel(courseSelectingPresentationModel);

            Application.Run(startUpForm);
        }
    }
}
