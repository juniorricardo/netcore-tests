using System;
using System.Data;
using System.Data.SqlClient;
using Poke.API.Interfaces.Provider;

namespace Poke.API.Provider
{
    public class DbManager : IDbManager
    {
        public IDbConnection GetConnection(string con)
        {
            if (string.IsNullOrEmpty(con))
                throw new NullReferenceException("No se ha ingresado cadena de conexion.");
            return new SqlConnection(con);
        }

        public void OpenConnection(IDbConnection connection)
        {
            connection.Open();
        }

        public IDbCommand GetCommand(IDbConnection connection, string commandText)
        {
            var command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public IDataReader GerDataReader(IDbCommand command)
        {
            if (command != null) return command.ExecuteReader();
            throw new NullReferenceException("NO se ha iniciado el comando a ejecutar.");
        }
    }
}