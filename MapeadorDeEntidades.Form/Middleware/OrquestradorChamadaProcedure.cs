using MapeadorDeEntidades.Form.Core;
using System.Linq;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Linguagens.CSharp.Oracle;
using MapeadorDeEntidades.Form.Linguagens.Java.Oracle;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class OrquestradorChamadaProcedure
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
                        switch (ParamtersInput.Linguagem)
                        {
                            case 1:
                                {
                                    return new ChamadaCsharpOracleProcedure().CSharp(salvar);
                                }
                            case 2:
                                {
                                    return new ChamadaJavaOracleProcedure().Java(salvar);
                                }
                        }
                        break;
                    }
                default:
                    {
                        break;
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
