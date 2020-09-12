using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Poke.API.Entities;
using Poke.API.Interfaces;
using Poke.Services;

namespace Poke.API.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private  readonly IEmployeeService _employeeService;
        private  readonly IEnvironmentVariables _environmentVariables;

        public EmployeeBusiness(IEmployeeService employeeService, IEnvironmentVariables environmentVariables)
        {
            _employeeService = employeeService;
            _environmentVariables = environmentVariables;
        }
        
        public async Task<IEnumerable<Employee>> GetEmployeesPerPs()
        {
            ICollection<Employee> list = new List<Employee>();
            var connectionString = _environmentVariables.GetUrl("ConnectionStrings:Balkan");
            if (connectionString == null) throw new Exception();
            var dt = new DataTable();
            await using var sqlConn = new SqlConnection(connectionString);
            const string sql = "sp_balkan_get_employees";
            await using var sqlCmd = new SqlCommand(sql, sqlConn) {CommandType = CommandType.StoredProcedure};
            // sqlCmd.Parameters.AddWithValue("@Param", "SomeValueHereToPass");
            await sqlConn.OpenAsync();
            await using var reader = await sqlCmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Employee()
                {
                    FirstName = (string) reader[0],
                    LastName = (string) reader[1],
                    Title = (string) reader[2]
                });
            }
            // await sqlCmd.ExecuteNonQueryAsync(); // no devuelve datos
            
            // await sqlCmd.exe
            // using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
            // {
            //     sqlAdapter.Fill(dt);
            // }
            return list;
        }
        

        public async Task<IEnumerable<Employee>> GetEmployeePerQuery()
        {
            ICollection<Employee> list = new List<Employee>();
            var connectionString = _environmentVariables.GetUrl("ConnectionStrings:Balkan");
            if (connectionString == null) throw new Exception();
            const string queryString = "select FIRST_NAME, LAST_NAME from EMPLOYEE;";
            await using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(queryString, connection);
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new Employee()
                {
                    FirstName = (string) reader[0],
                    LastName = (string) reader[1]
                });
            }

            return list;
        }

        public Task<Employee> GetEmpoyeeById(string id)
        {
            
            throw new NotImplementedException();
        }
    }

    public interface IEmployeeBusiness
    {
        Task<IEnumerable<Employee>> GetEmployeesPerPs();
        Task<IEnumerable<Employee>> GetEmployeePerQuery();
        Task<Employee> GetEmpoyeeById(string id);
    }
}