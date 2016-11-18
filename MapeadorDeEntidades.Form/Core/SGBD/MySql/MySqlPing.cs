using System.Collections.Generic;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;

namespace MapeadorDeEntidades.Form.Core.SGBD.MySql
{
    public class MySqlPing : MySqlRepository
    {
        public RequestMessage<List<string>> ConnectaSQL()
        {
            var ping = Ping();
            if (!ping.IsError)
            {
                ping.Content = new MySqlTables().ListaTabelas();
            }
            return ping;
        }

        public RequestMessage<List<string>> Ping()
        {
            BeginNewStatement("SELECT SYSDATE() AS DATA");
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
