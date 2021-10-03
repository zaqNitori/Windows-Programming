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
        private readonly string _courseUrl;

        public CourseCrawler(string url)
        {
            _courseUrl = url;
        }

        /// <summary>
        /// 至指定頁面爬取課程資料
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        public List<ViewModel.Course> GetCourse()
        {
            const string TARGET = "//body/table";
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document = webClient.Load(_courseUrl);
            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(TARGET);
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;

            // 移除 tbody
            RemoveNode(nodeTableRow, 0);
            // 移除 <tr>資工三
            RemoveNode(nodeTableRow, 0);
            // 移除 table header
            RemoveNode(nodeTableRow, 0);
            // 移除 <tr>小計
            RemoveNode(nodeTableRow, nodeTableRow.Count - 1);

            return FetchCourseContent(nodeTableRow);
        }

        /// <summary>
        /// 移除標籤Node
        /// </summary>
        /// <param name="tableRows"></param>
        /// <history>
        ///     1.  2021.10.03  create function
        /// </history> 
        private void RemoveNode(HtmlNodeCollection tableRows, int index)
        {
            tableRows.RemoveAt(index);
        }

        /// <summary>
        /// 移除標籤Node
        /// </summary>
        /// <param name="tableRows"></param>
        /// <history>
        ///     1.  2021.10.03  create function
        /// </history> 
        private List<ViewModel.Course> FetchCourseContent(HtmlNodeCollection nodeTableRow)
        {
            List<ViewModel.Course> courses = new List<ViewModel.Course>();

            foreach (var node in nodeTableRow)
            {
                RemoveNode(node.ChildNodes, 0);
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
                Number = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Number),
                Name = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Name),
                Stage = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Stage),
                Credit = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Credit),
                Hour = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Hour),
                RequiredOrElective = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.RequiredOrElective),
                Teacher = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Teacher),
                Sunday = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Sunday),
                Monday = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Monday),
                Tuesday = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Tuesday),
                Wednesday = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Wednesday),
                Thursday = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Thursday),
                Friday = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Friday),
                Saturday = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Saturday),
                Classroom = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Classroom),
                NumberOfStudent = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.NumberOfStudent),
                NumberOfDropStudent = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.NumberOfDropStudent),
                TeachAssistant = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.TeachAssistant),
                Language = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Language),
                Syllabus = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Syllabus),
                Note = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Note),
                Audit = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Audit),
                Experiment = GetCourseInfo(nodeTableDatas, (int)ViewModel.CourseProperty.Experiment)
            };
            return course;
        }

        /// <summary>
        /// 從資料欄中取得指定資料
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        /// </history>
        private string GetCourseInfo(HtmlNodeCollection nodeCollection, int index)
        {
            return nodeCollection[index].InnerText.Trim();
        }

    }
}
