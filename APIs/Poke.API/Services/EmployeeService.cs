using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Poke.API.Entities;
using Poke.API.Enum;
using Poke.API.Interfaces;
using Poke.API.Interfaces.Provider;

namespace Poke.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private const string SqlConn = "sp_balkan_get_employees";
        private readonly IDbManager _dbManager;
        private readonly IEnvironmentVariables _environmentVariables;

        public EmployeeService(IDbManager dbManager, IEnvironmentVariables environmentVariables)
        {
            _dbManager = dbManager;
            _environmentVariables = environmentVariables;
        }

        public Task<ICollection<Employee>> GetAll()
        {
            ICollection<Employee> list = new List<Employee>();
            Thread.Sleep(10000);
            var connectionString =
                _environmentVariables.GetUrl(EnvironmentSection.ConnectionStrings, EnvironmentService.Balkan);
            using var connection = _dbManager.GetConnection(connectionString);

            using var command = _dbManager.GetCommand(connection, SqlConn);
            // sqlCmd.Parameters.AddWithValue("@Param", "SomeValueHereToPass");
            _dbManager.OpenConnection(connection);

            using var reader = _dbManager.GerDataReader(command);
            while (reader.Read())
                list.Add(new Employee
                {
                    FirstName = (string) reader["FIRST_NAME"],
                    LastName = (string) reader["LAST_NAME"],
                    Title = (string) reader["TITLE"]
                });

            return Task.FromResult(list);
        }
    }

    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetAll();
    }
}