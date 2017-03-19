﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using Zeus.Core;
using Zeus.Core.SGBD.Firebird;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Core.SGBD.MySql;
using Zeus.Core.SGBD.Oracle;

namespace Zeus.Middleware
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
                    case 4:
                        return new FirebirdPing().ConnectaSQL();
                    default:
                        return new RequestMessage<List<string>>
                        {
                            StatusCode = System.Net.HttpStatusCode.InternalServerError,
                            Message = "Esse banco de dados não foi programado",
                        };

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
