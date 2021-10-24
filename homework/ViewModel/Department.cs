using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework.ViewModel
{
    public class Department
    {
        public Department(string name)
        {
            DepartmentName = name;
        }

        public string DepartmentName
        {
            get; set;
        }
    }
}
