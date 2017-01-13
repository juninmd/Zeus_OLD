using System;
using System.Collections.Generic;
using Zeus.Core;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Core.SGBD.MySql;
using Zeus.Core.SGBD.Oracle;

namespace Zeus.Middleware
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
