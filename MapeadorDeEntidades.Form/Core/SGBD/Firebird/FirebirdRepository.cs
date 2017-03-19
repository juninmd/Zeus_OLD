using System;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using FirebirdSql.Data.FirebirdClient;

namespace Zeus.Core.SGBD.Firebird
{
    public abstract class FirebirdRepository
    {
        private FbConnection _connection;

        protected void ExecuteNonResult(string query, bool closeAfterExecution = true)
        {
            try
            {
                OpenConnection();
                FbCommand cmd = new FbCommand(query, _connection);
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
                FbCommand cmd = new FbCommand(query, _connection);
                FbDataReader dr = cmd.ExecuteReader(closeAfterExecution
                        ? CommandBehavior.CloseConnection
                        : CommandBehavior.Default);

                return dr;
            }
            catch (Exception)
            {
                _connection.Close();
                throw;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null)
                _connection.Close();
        }

        protected void OpenConnection()
        {
            if (_connection == null)
                _connection = new FbConnection(ParamtersInput.ConnectionString);

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
                return r[columnName] == DBNull.Value ? default(T) : (T)r[columnName];
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