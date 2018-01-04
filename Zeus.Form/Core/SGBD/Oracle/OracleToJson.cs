using System.Net;
using System.Text;

namespace Zeus.Core.SGBD.Oracle
{
    public class OracleToJson : OracleRepository
    {
        public RequestMessage<string> Jsonfy(string nomeTabela)
        {
            BeginNewStatement($"SELECT * FROM {nomeTabela}");
            OpenConnection();

            var jsonResult = new StringBuilder();
            using (var r = ExecuteReader())
            {
                while (r.Read())
                    jsonResult.Append("");
            }

            return new RequestMessage<string>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Connectado com sucesso!"
            };
        }
    }
}