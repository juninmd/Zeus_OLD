using System.Text;

namespace MapeadorDeEntidades.Form.Core.SGBD.Oracle
{
    public class OracleToJson : OracleRepository
    {
        public RequestMessage<string> Jsonfy(string nomeTabela)
        {
            BeginNewStatement($"SELECT * FROM {nomeTabela}");
            OpenConnection();

            int rowCount = 0;
            var jsonResult = new StringBuilder();
            using (var r = ExecuteReader())
                while (r.Read())
                {
                    jsonResult.Append("");
                };
            return new RequestMessage<string>
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Connectado com sucesso!"
            };
            return new RequestMessage<string>
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = "Não foi possível connectar!"
            };
        }
    }
}
