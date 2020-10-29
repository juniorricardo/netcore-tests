using System.Collections.Generic;
using System.Threading.Tasks;
using Poke.API.Entities;

namespace Poke.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
    }
}