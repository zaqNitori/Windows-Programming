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
        private const string NEW_LINE = "\n";
        private const string TARGET = "//body/table";
        private HtmlWeb _webClient;

        public CourseCrawler()
        {
            _webClient = new HtmlWeb();
        }

        public string ClassName
        {
            get; set;
        }

        /// <summary>
        /// 至指定頁面爬取課程資料
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        ///     2.  2021.10.24  修改爬蟲程式，把Course的建立移到Builder
        /// </history>
        public HtmlNodeCollection GetCourseNodeCollection(string courseUrl)
        {
            _webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document = _webClient.Load(courseUrl);
            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(TARGET);
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;

            // 移除 tbody
            RemoveNode(nodeTableRow, 0);
            // 移除 <tr> 科系名稱
            ClassName = GetClassName(nodeTableRow);
            RemoveNode(nodeTableRow, 0);
            // 移除 table header
            RemoveNode(nodeTableRow, 0);
            // 移除 <tr>小計
            RemoveNode(nodeTableRow, nodeTableRow.Count - 1);

            return nodeTableRow;
        }

        /// <summary>
        /// 移除標籤Node
        /// </summary>
        private void RemoveNode(HtmlNodeCollection tableRows, int index)
        {
            tableRows.RemoveAt(index);
        }

        /// <summary>
        /// 取得班級名稱
        /// </summary>
        private string GetClassName(HtmlNodeCollection tableRows)
        {
            return tableRows[0].InnerText.Trim().Replace(NEW_LINE, string.Empty);
        }

    }
}
