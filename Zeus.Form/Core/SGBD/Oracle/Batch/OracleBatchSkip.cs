using System.Net;

namespace Zeus.Core.SGBD.Oracle.Batch
{
    public class OracleBatchSkip : OracleRepository
    {
        public RequestMessage<string> Package(string source, bool body)
        {
            BeginNewStatement($"select count(*) as contagem from user_source where name = '{source}' and TYPE = '{(body ? "PACKAGE BODY" : "PACKAGE")}' ");
            OpenConnection();

            var retorno = ExecuteQueryString();

            decimal valor = 0;

            if (retorno.Read())
            {
                valor = retorno.GetValueOrDefault<decimal>("contagem");
            }

            EndTransaction(true);

            return new RequestMessage<string>()
            {
                StatusCode = valor == 0 ? HttpStatusCode.OK : HttpStatusCode.BadGateway
            };
        }

        public RequestMessage<string> Sequence(string source)
        {
            BeginNewStatement($"SELECT COUNT(*) as contagem FROM user_sequences WHERE sequence_name = '{source}'");
            OpenConnection();

            var retorno = ExecuteQueryString();

            decimal valor = 0;

            if (retorno.Read())
            {
                valor = retorno.GetValueOrDefault<decimal>("contagem");
            }

            EndTransaction(true);

            return new RequestMessage<string>()
            {
                StatusCode = valor == 0 ? HttpStatusCode.OK : HttpStatusCode.BadGateway
            };
        }


    }
}
