using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework.ViewModel;
using HtmlAgilityPack;

namespace homework.Builder
{
    public class CourseBuilder
    {
        private Course _course;

        public CourseBuilder()
        {
            _course = new Course();
        }

        /// <summary>
        /// 建立課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        public void BuildCourseByNodeCollection(HtmlNodeCollection nodeTableDatas)
        {
            _course.Number = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Number);
            _course.Name = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Name);
            _course.Stage = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Stage);
            _course.Credit = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Credit);
            _course.Hour = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Hour);
            _course.RequiredOrElective = GetCourseInfo(nodeTableDatas, (int)CourseProperty.RequiredOrElective);
            _course.Teacher = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Teacher);
            SetCourseTime(nodeTableDatas);
            _course.Classroom = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Classroom);
            _course.NumberOfStudent = GetCourseInfo(nodeTableDatas, (int)CourseProperty.NumberOfStudent);
            _course.NumberOfDropStudent = GetCourseInfo(nodeTableDatas, (int)CourseProperty.NumberOfDropStudent);
            _course.TeachAssistant = GetCourseInfo(nodeTableDatas, (int)CourseProperty.TeachAssistant);
            _course.Language = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Language);
            _course.Syllabus = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Syllabus);
            _course.Note = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Note);
            _course.Audit = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Audit);
            _course.Experiment = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Experiment);
        }

        /// <summary>
        /// 取得課程
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        public Course GetCourse()
        {
            return _course;
        }

        /// <summary>
        /// 綁訂日期
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        private void SetCourseTime(HtmlNodeCollection nodeTableDatas)
        {
            _course.Sunday = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Sunday);
            _course.Monday = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Monday);
            _course.Tuesday = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Tuesday);
            _course.Wednesday = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Wednesday);
            _course.Thursday = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Thursday);
            _course.Friday = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Friday);
            _course.Saturday = GetCourseInfo(nodeTableDatas, (int)CourseProperty.Saturday);
        }

        /// <summary>
        /// 從資料欄中取得指定資料
        /// </summary>
        /// <history>
        ///     1.  2021.10.24  create function
        /// </history>
        private string GetCourseInfo(HtmlNodeCollection nodeCollection, int index)
        {
            return nodeCollection[index].InnerText.Trim();
        }

    }
}
