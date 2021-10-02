using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.Model
{
    public class CourseCrawler
    {
        /// <summary>
        /// 至指定頁面爬取課程資料
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public List<ViewModel.Course> GetCourse(string url)
        {
            const string TARGET = "//body/table";
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document = webClient.Load(url);

            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(TARGET);
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;

            // 移除 tbody
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>資工三
            nodeTableRow.RemoveAt(0);
            // 移除 table header
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>小計
            nodeTableRow.RemoveAt(nodeTableRow.Count - 1);

            List<ViewModel.Course> courses = new List<ViewModel.Course>();

            foreach (var node in nodeTableRow)
            {
                node.ChildNodes.RemoveAt(0);
                courses.Add(CreateCourse(node.ChildNodes));
            }

            return courses;
        }

        /// <summary>
        /// 將資料綁到對應的物件上
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private ViewModel.Course CreateCourse(HtmlNodeCollection nodeTableDatas)
        {
            ViewModel.Course course = new ViewModel.Course
            {
                Number = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Number),
                Name = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Name),
                Stage = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Stage),
                Credit = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Credit),
                Hour = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Hour),
                RequiredOrElective = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.RequiredOrElective),
                Teacher = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Teacher),
                Sunday = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Sunday),
                Monday = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Monday),
                Tuesday = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Tuesday),
                Wednesday = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Wednesday),
                Thursday = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Thursday),
                Friday = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Friday),
                Saturday = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Saturday),
                Classroom = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Classroom),
                NumberOfStudent = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.NumberOfStudent),
                NumberOfDropStudent = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.NumberOfDropStudent),
                TeachAssistant = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.TeachAssistant),
                Language = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Language),
                Syllabus = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Syllabus),
                Note = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Note),
                Audit = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Audit),
                Experiment = GetCourseInfo(nodeTableDatas, ViewModel.CourseProperty.Experiment)
            };
            return course;
        }

        /// <summary>
        /// 從資料欄中取得指定資料
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private string GetCourseInfo(HtmlNodeCollection nodeCollection, ViewModel.CourseProperty property)
        {
            return nodeCollection[((int)property)].InnerText.Trim();
        }

    }
}
