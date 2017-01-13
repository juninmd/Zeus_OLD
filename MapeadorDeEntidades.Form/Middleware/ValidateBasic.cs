using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Zeus.Core;

namespace Zeus.Middleware
{
    public class ValidateBasic
    {
        public RequestMessage<string> ValidateInput(FolderBrowserDialog salvar)
        {
            if (!ParamtersInput.NomeTabelas.Any())
            {
                return new RequestMessage<string>()
                {
                    Message = "Selecione uma tabela",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

            if (ParamtersInput.SGBD == 3 && String.IsNullOrEmpty(ParamtersInput.DataBase))
            {
                return new RequestMessage<string>()
                {
                    Message = "Selecione uma database",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

            var funcao = salvar.ShowDialog();
            if (funcao != DialogResult.OK)
                return new RequestMessage<string>()
                {
                    Message = "Processamento cancelado!",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

            return new RequestMessage<string> { StatusCode = HttpStatusCode.OK };
        }
    }
}
