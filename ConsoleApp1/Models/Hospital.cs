using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Hospital
    {
        List<Department> DepartmentList { get; set; }
        public Hospital() { }
        public Hospital(List<Department> departmentList)
        {
            this.DepartmentList = departmentList;
        }
    }
}
