﻿using System.Collections.Generic;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle;

namespace MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL
{
    public class SQLPing : SQLRepository
    {
        public RequestMessage<List<string>> ConnectaOracle()
        {
            var ping = Ping();
            if (!ping.IsError)
            {
                ping.Content = new OracleTables().ListaTabelas();
            }
            return ping;
        }

        public RequestMessage<List<string>> Ping()
        {
            BeginNewStatement("SELECT SYSDATE FROM DUAL");
            OpenConnection();

            using (var r = ExecuteReader())
                if (r.Read())
                {
                    return new RequestMessage<List<string>>
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Message = "Connectado com sucesso!"
                    };
                };
            return new RequestMessage<List<string>>
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = "Não foi possível connectar!"
            };
        }
    }
}
