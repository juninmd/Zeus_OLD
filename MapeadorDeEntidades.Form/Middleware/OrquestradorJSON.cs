using MapeadorDeEntidades.Form.Core;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class OrquestradorJSON
    {
        public void Generate()
        {

        }
        public RequestMessage<string> Generate(FolderBrowserDialog salvar)
        {
            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
                return validate;

            return new RequestMessage<string>()
            {
                Message = "Selecione uma tabela",
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }
}
