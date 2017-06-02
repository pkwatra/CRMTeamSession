using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLMSCrm.Fakes.Entity
{
    public interface IEmployeeBusiness
    {
        List<string> GetAllEmployeesName();

        Employee GetEmployeeById(int id);

        bool Save(Employee employee);

        Task<int> MyMethodAsync();
    }
}
