using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.ViewModel
{
    public class Department
    {
        public Department(string name, List<Course> courses)
        {
            DepartmentName = name;
            Courses = courses;
        }

        public string DepartmentName
        {
            get; set;
        }

        public List<Course> Courses
        {
            get; set;
        }

    }
}
