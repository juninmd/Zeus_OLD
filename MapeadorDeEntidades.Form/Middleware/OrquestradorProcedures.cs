using MapeadorDeEntidades.Form.Core;
using System.Linq;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class OrquestradorProcedures
    {
        public RequestMessage<string> Generate(FolderBrowserDialog salvar)
        {
            if (!ParamtersInput.NomeTabelas.Any())
            {
                return new RequestMessage<string>()
                {
                    Message = "Selecione uma tabela",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

            switch (ParamtersInput.SGBD)
            {
                case 1:
                    {
                        return new OracleOrquestradorProcedures().Oracle(salvar);
                    }
            }

            return new RequestMessage<string>()
            {
                Message = "Selecione uma tabela",
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
