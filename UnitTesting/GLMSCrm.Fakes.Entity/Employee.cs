using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMSCrm.Fakes.Entity
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string EmpFName { get; set; }

        public string EmpLName { get; set; }

        public string EmailId { get; set; }

        public Department Department { get; set; }
    }
}
