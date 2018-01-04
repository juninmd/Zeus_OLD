using System;
using System.Collections.Generic;
using System.Net;
using Zeus.Core;
using Zeus.Core.SGBD.Firebird;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Core.SGBD.MySql;
using Zeus.Core.SGBD.Oracle;
using Zeus.Core.SGBD.Postgre;

namespace Zeus.Middleware
{
    public class OrquestradorPingSGBD
    {
        public RequestMessage<List<string>> Connect()
        {
            if (string.IsNullOrEmpty(ParamtersInput.ConnectionString))
                return new RequestMessage<List<string>>
                {
                    Message = "Preencha o campo 'Connection String'",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            ;

            try
            {
                switch (ParamtersInput.SGBD)
                {
                    case 1:
                        return new OraclePing().ConnectaOracle();
                    case 2:
                        return new SQLPing().ConnectaSQL();
                    case 3:
                        return new MySqlPing().ConnectaSQL();
                    case 4:
                        return new FirebirdPing().ConnectaSQL();
                    case 5:
                        return new PostgrePing().ConnectaPostgre();
                    default:
                        return new RequestMessage<List<string>>
                        {
                            StatusCode = HttpStatusCode.InternalServerError,
                            Message = "Por favor, selecione algum banco de dados"
                        };
                }
            }
            catch (Exception ex)
            {
                return new RequestMessage<List<string>>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "Ocorreu uma falha, verifique a string",
                    TechnicalMessage = ex.Message
                };
            }
        }
    }
}