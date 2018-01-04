using System;
using System.Data;
using System.Net;
using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;

namespace Zeus.Core.SGBD.MySql
{
    public abstract class MySqlRepository
    {
        #region ••• Construtor •••

        protected MySqlRepository()
        {
            P_RESULT = "P_RESULT";
            _command = new MySqlCommand();
        }

        #endregion

        /// <summary>
        ///     Parametriza qual é o nome do parametro de Resposta
        /// </summary>
        public string P_RESULT { get; set; }

        #region ••• Propriedades •••

        private readonly MySqlCommand _command;
        private bool _closeConnectionAfterExecution;
        private MySqlConnection _connection;
        private MySqlTransaction _transaction;

        #endregion

        #region ••• Metodos •••

        protected void BeginNewStatement(string comando)
        {
            _command.CommandType = CommandType.Text;
            _command.CommandText = comando;
            _command.Parameters.Clear();
        }

        protected void BeginNewStatement(string packageName, string procedureName)
        {
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = packageName + "." + procedureName;
            _command.Parameters.Clear();
        }

        protected void BeginNewStatement(string packageName, object procedureName)
        {
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = packageName + "." + procedureName;
            _command.Parameters.Clear();
        }


        public MySqlConnection Connection()
        {
            return _connection;
        }

        public void SetConnection(MySqlConnection conexao)
        {
            if (conexao.State != ConnectionState.Open)
                throw new Exception("Não foi possível setar a conexão, pois a mesma foi encerrada!");
            _connection = conexao;
            _command.Connection = conexao;
        }


        protected void AddParameter(string name, object value)
        {
            _command.Parameters.AddWithValue("P_" + name, value);
        }


        protected void OpenConnection(bool closeAfterExecution = true)
        {
            if (_connection == null)
                _connection = new MySqlConnection(ParamtersInput.ConnectionString);

            if (_connection.State == ConnectionState.Broken && _connection.State == ConnectionState.Closed)
                throw new Exception("Falha na conexão com o banco de dados:" + _connection.State +
                                    _connection.ConnectionString);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            _closeConnectionAfterExecution = closeAfterExecution && _transaction == null;
            _command.Connection = _connection;
        }


        public void BeginTransaction()
        {
            OpenConnection(false);

            if (_transaction == null)
                _transaction = _connection.BeginTransaction();

            _command.Transaction = _transaction;
        }


        protected int ExecuteStatement()
        {
            try
            {
                var response = _command.ExecuteNonQuery();
                if (_closeConnectionAfterExecution)
                    _connection.Close();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na conexão com o banco de dados" + "\n" + _command.CommandText + "\n" +
                                    "\n" + ex.Message + "\n" + _connection.ConnectionString);
            }
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            OpenConnection(false);

            if (_transaction == null)
                _transaction = _connection.BeginTransaction(isolationLevel);

            _command.Transaction = _transaction;
        }


        public void EndTransaction(bool commit, bool closeConnection = true)
        {
            try
            {
                if (_transaction == null)
                    return;
                if (commit)
                    _transaction.Commit();
                else
                    _transaction.Rollback();
                _command.Transaction = _transaction = null;
                if (closeConnection)
                    _connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na conexão com o banco de dados" + "\n" + _command.CommandText + "\n" +
                                    ex.Message + "\n" + _connection.ConnectionString);
            }
        }


        protected object GetOutputParameter(string name)
        {
            return _command.Parameters["P_" + name].Value;
        }

        protected IDataReader ExecuteReader()
        {
            try
            {
                var retorno = _command.ExecuteReader(_closeConnectionAfterExecution
                    ? CommandBehavior.CloseConnection
                    : CommandBehavior.Default);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na conexão com o banco de dados" + "\n" + _command.CommandText + "\n" +
                                    ex.Message + "\n" + _connection.ConnectionString);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="fecharConexao">Usar false quando usar Transaction</param>
        /// <returns></returns>
        public RequestMessage<string> RequestProc(string caminho, bool fecharConexao = true)
        {
            /* Validar se existe uma transaction*/
            if (fecharConexao && _command.Transaction != null)
                throw new Exception(
                    $"A aplicação não está finalizando uma transaction.\nVerifique o método: {caminho}\nProcedure: {_command.CommandText}");

            OpenConnection(fecharConexao);
            ExecuteStatement();

            var result = _command.Parameters[P_RESULT].Value;

            return new RequestMessage<string>
            {
                Procedure = _command.CommandText,
                StatusCode = result.ToString() == "0" || result.ToString().Contains("ORA-")
                    ? HttpStatusCode.BadRequest
                    : HttpStatusCode.OK,
                Message = result.ToString().Contains("ORA-") ? result.ToString() : "",
                Content = result.ToString().Contains("ORA-") ? "" : result.ToString(),
                MethodApi = caminho,
                Parameter = P_RESULT
            };
        }

        #endregion
    }

    public static class NullSafeGetter
    {
        public static T GetValueOrDefault<T>(this IDataRecord r, string columnName,
            [CallerFilePath] string sourceFilePath = "")
        {
            try
            {
                return r[columnName] == DBNull.Value || r[columnName].ToString() == "" ? default(T) : (T) r[columnName];
            }
            catch (Exception ex) when (ex.Message == "Unable to find specified column in result set")
            {
                throw new Exception(
                    $"{ex.Message}\nNão foi possível encontrar o paramêtro: [{columnName}] da procedure\nClasse: {sourceFilePath}");
            }
            catch (Exception ex)
            {
                if (default(T) == null)
                    throw new Exception(
                        $"{ex.Message}\nFalha ao converter parametro: [{columnName}] da procedure. onde deveria ser: {r[columnName].GetType().Name}\nClasse: {sourceFilePath}");
                throw new Exception(
                    $"{ex.Message}\nFalha ao converter parametro: [{columnName}] da procedure, para o tipo: {default(T).GetType().Name} / Onde deveria ser: {r[columnName].GetType().Name}\nClasse: {sourceFilePath}");
            }
        }
    }
}