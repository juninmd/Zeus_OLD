using System;
using System.Data;
using System.Runtime.CompilerServices;
using Npgsql;

namespace Zeus.Core.SGBD.Postgre
{
    public abstract class PostgreRepository
    {
        private NpgsqlConnection _connection;

        protected void ExecuteNonResult(string query, bool closeAfterExecution = true)
        {
            try
            {
                OpenConnection();
                NpgsqlCommand cmd = new NpgsqlCommand(query, _connection);
                cmd.ExecuteNonQuery();
                if (closeAfterExecution)
                    _connection.Close();
            }
            catch (Exception)
            {
                _connection.Close();
                throw;
            }
        }

        public IDataReader ExecuteReader(string query, bool closeAfterExecution = true)
        {
            try
            {
                OpenConnection();
                NpgsqlCommand cmd = new NpgsqlCommand(query, _connection);
                NpgsqlDataReader dr = cmd.ExecuteReader(closeAfterExecution
                        ? CommandBehavior.CloseConnection
                        : CommandBehavior.Default);

                return dr;
            }
            catch (Exception ex)
            {
                _connection.Close();
                throw;
            }
        }

        public void CloseConnection()
        {
            _connection?.Close();
        }

        protected void OpenConnection()
        {
            if (_connection == null)
                _connection = new NpgsqlConnection(ParamtersInput.ConnectionString);

            if (_connection.State == ConnectionState.Broken && _connection.State == ConnectionState.Closed)
                throw new Exception("Falha na conexão com o banco de dados:" + _connection.State + _connection.ConnectionString);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }
    }
    public static class NullSafeGetter
    {
        public static T GetValueOrDefault<T>(this IDataRecord r, string columnName, [CallerFilePath]string sourceFilePath = "")
        {
            try
            {
                return (T) r[columnName];
            }
            catch (Exception ex) when (ex.Message == "Unable to find specified column in result set")
            {
                throw new Exception($"{ex.Message}\nNão foi possível encontrar o paramêtro: [{columnName}] da procedure\nClasse: {sourceFilePath}");
            }
            catch (Exception ex)
            {
                if (default(T) == null)
                {
                    throw new Exception($"{ex.Message}\nFalha ao converter parametro: [{columnName}] da procedure. onde deveria ser: {r[columnName].GetType().Name}\nClasse: {sourceFilePath}");

                }
                throw new Exception($"{ex.Message}\nFalha ao converter parametro: [{columnName }] da procedure, para o tipo: {default(T).GetType().Name} / Onde deveria ser: {r[columnName].GetType().Name}\nClasse: {sourceFilePath}");
            }
        }

    }
}