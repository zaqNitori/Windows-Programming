using System.Collections.Generic;

namespace homework.ViewModel
{
    public class Course
    {
        public Course()
        {

        }

        public Course(Course course)
        {
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
    }
}
