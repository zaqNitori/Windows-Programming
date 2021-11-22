using System.Collections.Generic;

namespace homework.ViewModel
{
    public class Course
    {
        public Course()
        {
            Status = Common.COURSE_STATUS_OPEN;
        }

        public Course(Course course)
        {
            Status = course.Status;
            Number = course.Number;
            Name = course.Name;
            Stage = course.Stage;
            Credit = course.Credit;
            Teacher = course.Teacher;
            RequiredOrElective = course.RequiredOrElective;
            TeachAssistant = course.TeachAssistant;
            Language = course.Language;
            Note = course.Note;
            Hour = course.Hour;
            Sunday = course.Sunday;
            Monday = course.Monday;
            Tuesday = course.Tuesday;
            Wednesday = course.Wednesday;
            Thursday = course.Thursday;
            Friday = course.Friday;
            Saturday = course.Saturday;
            Classroom = course.Classroom;
            NumberOfDropStudent = course.NumberOfDropStudent;
            NumberOfStudent = course.NumberOfStudent;
            Syllabus = course.Syllabus;
            Audit = course.Audit;
            Experiment = course.Experiment;
        }

        public string Status
        {
            get; set;
        }

        public string Number
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Stage
        {
            get; set;
        }

        public string Credit
        {
            get; set;
        }

        public string Hour
        {
            get; set;
        }

        public string RequiredOrElective
        {
            get; set;
        }

        public string Teacher
        {
            get; set;
        }

        public string Sunday
        {
            get; set;
        }

        public string Monday
        {
            get; set;
        }

        public string Tuesday
        {
            get; set;
        }

        public string Wednesday
        {
            get; set;
        }

        public string Thursday
        {
            get; set;
        }

        public string Friday
        {
            get; set;
        }

        public string Saturday
        {
            get; set;
        }

        public string Classroom
        {
            get; set;
        }

        public string NumberOfStudent
        {
            get; set;
        }

        public string NumberOfDropStudent
        {
            get; set;
        }

        public string TeachAssistant
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }

        public string Syllabus
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public string Audit
        {
            get; set;
        }

        public string Experiment
        {
            get; set;
        }

        /// <summary>
        /// 格式化輸出
        /// </summary>
        public override string ToString()
        {
            string text = string.Empty;
            text = AddDoubleQuote(Status) + Common.COMMA + AddDoubleQuote(Number) + Common.COMMA +
                AddDoubleQuote(Name) + Common.COMMA + AddDoubleQuote(Stage) + Common.COMMA +
                AddDoubleQuote(Credit) + Common.COMMA + AddDoubleQuote(Hour) + Common.COMMA +
                AddDoubleQuote(RequiredOrElective) + Common.COMMA + AddDoubleQuote(Teacher) + Common.COMMA +
                AddDoubleQuote(Sunday) + Common.COMMA + AddDoubleQuote(Monday) + Common.COMMA + AddDoubleQuote(Tuesday) + Common.COMMA +
                AddDoubleQuote(Wednesday) + Common.COMMA + AddDoubleQuote(Thursday) + Common.COMMA +
                AddDoubleQuote(Friday) + Common.COMMA + AddDoubleQuote(Saturday) + Common.COMMA +
                AddDoubleQuote(Classroom) + Common.COMMA + AddDoubleQuote(NumberOfStudent) + Common.COMMA + 
                AddDoubleQuote(NumberOfDropStudent) + Common.COMMA + AddDoubleQuote(TeachAssistant) + Common.COMMA +
                AddDoubleQuote(Language) + Common.COMMA + AddDoubleQuote(Syllabus) + Common.COMMA + 
                AddDoubleQuote(Note) + Common.COMMA + AddDoubleQuote(Audit) + Common.COMMA + AddDoubleQuote(Experiment);
            return text;
        }

        /// <summary>
        /// 加上雙引號
        /// </summary>
        private string AddDoubleQuote(string text)
        {
            return Common.DOUBLE_QUOTES + text + Common.DOUBLE_QUOTES;
        }

    }
}
