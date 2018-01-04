using System.Collections.Generic;
using System.Net;

namespace Zeus.Core.SGBD.Firebird
{
    public class FirebirdPing : FirebirdRepository
    {
        public RequestMessage<List<string>> ConnectaSQL()
        {
            var ping = Ping();
            if (!ping.IsError) ping.Content = new FirebirdTables().ListaTabelas();
            return ping;
        }

        public RequestMessage<List<string>> Ping()
        {
            using (var r = ExecuteReader("select current_timestamp(0) AS DATA from rdb$database"))
            {
                if (r.Read())
                    return new RequestMessage<List<string>>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Conexão com FIREBIRD efetuada com sucesso!"
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