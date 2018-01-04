using System;
using System.Collections.Generic;
using System.Net;
using Zeus.Core;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Core.SGBD.MySql;
using Zeus.Core.SGBD.Oracle;
using Zeus.Core.SGBD.Postgre;

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
                        return new RequestMessage<List<string>>
                        {
                            Content = new OracleTables().ListaTabelas()
                        };
                    case 2:
                        return new RequestMessage<List<string>>
                        {
                            Content = new SQLTables().ListaTabelas()
                        };
                    case 3:
                        return new RequestMessage<List<string>>
                        {
                            Content = new MySqlTables().ListaTabelas(ParamtersInput.DataBase)
                        };
                    case 5:
                        return new RequestMessage<List<string>>
                        {
                            Content = new PostgreTables().ListaTabelas(ParamtersInput.DataBase)
                        };
                    default:
                        return new RequestMessage<List<string>>
                        {
                            StatusCode = HttpStatusCode.InternalServerError,
                            Message = "Essa linguagem não foi programada"
                        };
                }
            }
            catch (Exception ex)
            {
                return new RequestMessage<List<string>>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = "Ocorreu uma falha, verifique a database",
                    TechnicalMessage = ex.Message
                };
            }
        }
    }
}