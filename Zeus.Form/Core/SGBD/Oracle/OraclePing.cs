using System.Collections.Generic;
using System.Net;

namespace Zeus.Core.SGBD.Oracle
{
    public class OraclePing : OracleRepository
    {
        public RequestMessage<List<string>> ConnectaOracle()
        {
            var ping = Ping();
            if (!ping.IsError) ping.Content = new OracleTables().ListaTabelas();
            return ping;
        }

        public RequestMessage<List<string>> Ping()
        {
            BeginNewStatement("SELECT SYSDATE FROM DUAL");
            OpenConnection();

            using (var r = ExecuteReader())
            {
                if (r.Read())
                    return new RequestMessage<List<string>>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Conexão com ORACLE efetuada com sucesso!"
                    };
            }

            ;
            return new RequestMessage<List<string>>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = "Não foi possível connectar!"
            };
        }
    }
}