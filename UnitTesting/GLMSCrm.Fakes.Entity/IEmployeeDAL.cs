using System.Collections.Generic;
using System.Threading.Tasks;

namespace GLMSCrm.Fakes.Entity
{
    public interface IEmployeeDAL
    {
        Employee GetEmployeeById(int id);

        List<Employee> GetEmployees();

        bool SaveEmployee(Employee employee);

        Task<int> LongRunningOperationAsync();
    }
}
