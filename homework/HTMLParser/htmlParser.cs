using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace homework.HTMLParser
{
    class htmlParser
    {
        public static List<ViewModel.Course> GetCourseInfo(string url)
        {
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument doc = webClient.Load(url);
            List<ViewModel.Course> courses = new List<ViewModel.Course>();

            HtmlNode nodeTable = doc.DocumentNode.SelectSingleNode("//body/table");
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;

            // 移除 tbody
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>資工三
            nodeTableRow.RemoveAt(0);
            // 移除 table header
            nodeTableRow.RemoveAt(0);
            // 移除 <tr>小計
            nodeTableRow.RemoveAt(nodeTableRow.Count - 1);

            foreach (var node in nodeTableRow)
            {
                HtmlNodeCollection nodeTableDatas = node.ChildNodes;
                // 移除 #text
                nodeTableDatas.RemoveAt(0);

                courses.Add(
                    new ViewModel.Course
                    {
                        Number = nodeTableDatas[0].InnerText.Trim(),                // number
                        Name = nodeTableDatas[1].InnerText.Trim(),                  // name
                        Stage = nodeTableDatas[2].InnerText.Trim(),                 // stage
                        Credit = nodeTableDatas[3].InnerText.Trim(),                // credit
                        Hour = nodeTableDatas[4].InnerText.Trim(),                  // hour
                        RequiredOrElective = nodeTableDatas[5].InnerText.Trim(),    // required/elective
                        Teacher = nodeTableDatas[6].InnerText.Trim(),
                        Sunday = nodeTableDatas[7].InnerText.Trim(),
                        Monday = nodeTableDatas[8].InnerText.Trim(),
                        Tuesday = nodeTableDatas[9].InnerText.Trim(),
                        Wednesday = nodeTableDatas[10].InnerText.Trim(),
                        Thursday = nodeTableDatas[11].InnerText.Trim(),
                        Friday = nodeTableDatas[12].InnerText.Trim(),
                        Saturday = nodeTableDatas[13].InnerText.Trim(),
                        Classroom = nodeTableDatas[14].InnerText.Trim(),            // classroom
                        NumberOfStudent = nodeTableDatas[15].InnerText.Trim(),      // numberOfStudent
                        NumberOfDropStudent = nodeTableDatas[16].InnerText.Trim(),  // numberOfDropStudent
                        TA = nodeTableDatas[17].InnerText.Trim(),                   // TA
                        Language = nodeTableDatas[18].InnerText.Trim(),             // language
                        Syllabus = nodeTableDatas[19].InnerText.Trim(),             // syllabus
                        Note = nodeTableDatas[20].InnerText.Trim(),                 // note
                        Audit = nodeTableDatas[21].InnerText.Trim(),                // audit
                        Experiment = nodeTableDatas[22].InnerText.Trim()            // experiment
                    });

            }

            return courses;
        }
    }
}
