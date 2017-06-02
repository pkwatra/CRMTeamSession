using GLMSCrm.Fakes.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GLMSCrm.Fakes.DAL
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public Employee GetEmployeeById(int id) {
            return new Employee { EmpId = 1, EmpFName = "FName", EmpLName = "LName", EmailId = "a@b.com", Department = new Department { DeptId = 1, DeptName = "IT"} };
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>() { new Employee { EmpId = 1, EmpFName = "FName", EmpLName = "LName", EmailId = "a@b.com", Department = new Department { DeptId = 1, DeptName = "IT"} },
                                          new Employee { EmpId = 2, EmpFName = "F1Name", EmpLName = "L1Name", EmailId = "a1@b1.com", Department = new Department { DeptId = 2, DeptName = "FIN"} }
            };
        }

        public bool SaveEmployee(Employee employee)
        {
            return false;
        }

        public async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
        {
            await Task.Delay(3000); //1 seconds delay
            return 1;
        }
    }
}
