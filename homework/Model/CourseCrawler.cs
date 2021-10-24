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
        private const string TARGET = "//body/table";
        private HtmlWeb _webClient;

        public CourseCrawler(string url)
        {
            _courseUrl = url;
            _webClient = new HtmlWeb();
        }

        /// <summary>
        /// 至指定頁面爬取課程資料
        /// </summary>
        /// <history>
        ///     1.  2021.10.02  create function
        ///     2.  2021.10.24  修改爬蟲程式，把Course的建立移到Builder
        /// </history>
        public HtmlNodeCollection GetCourseNodeCollection()
        {
            _webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document = _webClient.Load(_courseUrl);
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

            return nodeTableRow;
        }

        /// <summary>
        /// 移除標籤Node
        /// </summary>
        /// <param name="tableRows"></param>
        /// <history>
        ///     1.  2021.10.03  create function
        ///     2.  2021.10.24  將function改為public，讓model建立時可以使用
        /// </history> 
        public void RemoveNode(HtmlNodeCollection tableRows, int index)
        {
            tableRows.RemoveAt(index);
        }        

    }
}
