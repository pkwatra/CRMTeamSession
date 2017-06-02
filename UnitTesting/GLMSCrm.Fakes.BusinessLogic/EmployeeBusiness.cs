using GLMSCrm.Fakes.Entity;
using GLMSCrm.Fakes.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GLMSCrm.Fakes.BusinessLogic
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        IEmployeeDAL _employeeDAL { get; set; }

        public EmployeeBusiness(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        public List<string> GetAllEmployeesName()
        {

            var empNameList = new List<string>();
            var employees = _employeeDAL.GetEmployees();

            foreach (var item in employees)
            {
                empNameList.Add(item.EmpFName);
            }

            return empNameList;
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new IncorrectInputValueException("Id value must be greator then 0.");
                }

                var employee = _employeeDAL.GetEmployeeById(id);

                return employee;
            }
            catch (IncorrectInputValueException ex)
            {
                throw new IncorrectInputValueException("Id value must be greator then 0.");
            }
        }

        public bool Save(Employee employee) {
            return _employeeDAL.SaveEmployee(employee);
        }

        public async Task<int> MyMethodAsync()
        {
            Task<int> longRunningTask = _employeeDAL.LongRunningOperationAsync();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            //and now we call await on the task 
            int result = await longRunningTask;

            return result;
        }
    }
}
