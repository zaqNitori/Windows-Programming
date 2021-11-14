﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework.Model;
using homework.Manager;

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
            StoreDataManager _storeDataManager = new StoreDataManager();
            CourseManageModel _courseManageModel = new CourseManageModel(_storeDataManager);
            //StartUp startUp = new StartUp();

            //Application.Run(startUp.startUpForm);
            Application.Run(new ImportCourseProgressForm(new homework.PresentationModel.ImportCourseProgressPresentationModel(_courseManageModel)));
        }
    }

}
