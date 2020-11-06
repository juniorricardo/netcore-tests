using Poke.API.Data;
using Poke.API.Entities;
using Poke.API.Interfaces;

namespace Poke.API.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BalkanContext context) : base(context)
        {
        }

        // public async Task<IEnumerable<Employee>> GetAll()
        // {
        //     return await _entities.find
        // }
    }
}