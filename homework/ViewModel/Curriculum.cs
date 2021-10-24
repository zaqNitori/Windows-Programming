using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.ViewModel
{
    public class Curriculum
    {
        public Curriculum()
        {
            Courses = new Dictionary<string, List<Course>>();
        }

        public Dictionary<string, List<Course>> Courses
        {
            get; set;
        }
    }
}
