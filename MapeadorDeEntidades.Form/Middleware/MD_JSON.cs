using MapeadorDeEntidades.Form.Core;
using System.Linq;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class MD_JSON
    {
        public void Generate()
        {

        }
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

         

            return new RequestMessage<string>()
            {
                Message = "Selecione uma tabela",
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
