using MapeadorDeEntidades.Form.Core;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class MD_MapeamentoEntidade
    {
        private void CSharp(SaveFileDialog salvar)
        {
            foreach (var nomeTabela in ParamtersInput.NomeTabelas)
            {
                var classe = new CSharpEntity().GerarBody(nomeTabela).ToString();
                salvar.AddExtension = true;
                salvar.FileName = nomeTabela + ".cs";
                salvar.DefaultExt = "cs";

                var funcao = salvar.ShowDialog();

                if (funcao == DialogResult.OK)
                {
                    var local = salvar.FileName;
                    File.WriteAllText(local, classe);
                }
            }
        }

        public RequestMessage<string> Generate(SaveFileDialog salvar)
        {
            if (!ParamtersInput.NomeTabelas.Any())
            {
                return new RequestMessage<string>()
                {
                    Message = "Selecione uma tabela",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

            CSharp(salvar);
            return new RequestMessage<string>()
            {
                Message = "Selecione uma tabela"
            };

        }
    }
}
