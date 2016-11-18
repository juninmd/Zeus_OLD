using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle;
using System;
using System.Collections.Generic;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class OrquestradorPingSGBD
    {
        public RequestMessage<List<string>> Connect()
        {
            if (String.IsNullOrEmpty(ParamtersInput.ConnectionString))
            {
                return new RequestMessage<List<string>>
                {
                    Message = "Preencha o campo 'Connection String'",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            };

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
                    default:
                        return new SQLPing().ConnectaSQL();

                }
            }
            catch (Exception ex)
            {
                return new RequestMessage<List<string>>
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Ocorreu uma falha, verifique a string",
                    TechnicalMessage = ex.Message
                };
            }
        }
    }
}
