using System.Net;

namespace Zeus.Core.SGBD.Oracle.Batch
{
    public class OracleBatch : OracleRepository
    {
        public RequestMessage<string> Init(string conteudoArquivoSql)
        {
            BeginNewStatement(conteudoArquivoSql);
            OpenConnection();

            var response = ExecuteStatement();
            return new RequestMessage<string>
            {
                StatusCode = response == -1 ? HttpStatusCode.OK : HttpStatusCode.BadGateway
            };
        }
    }
}