using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle;
using System;
using System.Collections.Generic;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class OrquestradorTabelasSGBD
    {
        public RequestMessage<List<string>> Connect()
        {
            try
            {
                switch (ParamtersInput.SGBD)
                {
                    case 1:
                        return new RequestMessage<List<string>>()
                        {
                            Content = new OracleTables().ListaTabelas()
                        };
                    case 2:
                        return new RequestMessage<List<string>>()
                        {
                            Content = new SQLTables().ListaTabelas()
                        };
                    case 3:
                        return new RequestMessage<List<string>>()
                        {
                            Content = new MySqlTables().ListaTabelas(ParamtersInput.DataBase)
                        };
                    default:
                        return new SQLPing().ConnectaSQL();

                }
            }
            catch (Exception ex)
            {
                return new RequestMessage<List<string>>
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Ocorreu uma falha, verifique a database",
                    TechnicalMessage = ex.Message
                };
            }
        }
    }
}
