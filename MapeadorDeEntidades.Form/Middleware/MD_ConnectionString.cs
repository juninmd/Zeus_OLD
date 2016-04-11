﻿using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle;
using System;
using System.Collections.Generic;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class MD_ConnectionString
    {

        private RequestMessage<List<string>> ConnectaOracle()
        {
            var ping = new OraclePing().Ping();
            if (!ping.IsError)
            {
                ping.Content = new OracleTables().ListaTabelas();
            }
            return ping;
        }

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
                        return ConnectaOracle();
                    default:
                        return new RequestMessage<List<string>>();
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
