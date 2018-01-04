using System.Collections.Generic;
using System.Net;

namespace Zeus.Core.SGBD.Microsoft_SQL
{
    public class SQLPing : SQLRepository
    {
        public RequestMessage<List<string>> ConnectaSQL()
        {
            var ping = Ping();
            if (!ping.IsError) ping.Content = new SQLTables().ListaTabelas();
            return ping;
        }

        public RequestMessage<List<string>> Ping()
        {
            BeginNewStatement("SELECT GETDATE() AS DATA");
            OpenConnection();

            using (var r = ExecuteReader())
            {
                if (r.Read())
                    return new RequestMessage<List<string>>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Conexão com SQL SERVER efetuada com sucesso!"
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