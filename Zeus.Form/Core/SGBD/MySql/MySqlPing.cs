﻿using System.Collections.Generic;
using System.Net;

namespace Zeus.Core.SGBD.MySql
{
    public class MySqlPing : MySqlRepository
    {
        public RequestMessage<List<string>> ConnectaSQL()
        {
            var ping = Ping();
            if (!ping.IsError) ping.Content = new MySqlTables().ListaDataBases();
            return ping;
        }

        public RequestMessage<List<string>> Ping()
        {
            BeginNewStatement("SELECT SYSDATE() AS DATA");
            OpenConnection();

            using (var r = ExecuteReader())
            {
                if (r.Read())
                    return new RequestMessage<List<string>>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Conexão com MYSQL efetuada com sucesso!"
                    };
            }

            return new RequestMessage<List<string>>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Não foi possível connectar!"
            };
        }
    }
}