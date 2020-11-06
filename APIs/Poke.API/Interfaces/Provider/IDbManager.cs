using System.Data;

namespace Poke.API.Interfaces.Provider
{
    public interface IDbManager
    {
        IDbConnection GetConnection(string dbConnectionString);
        void OpenConnection(IDbConnection connection);
        IDbCommand GetCommand(IDbConnection connection, string spBalkanGetEmployees);
        IDataReader GerDataReader(IDbCommand command);
    }
}