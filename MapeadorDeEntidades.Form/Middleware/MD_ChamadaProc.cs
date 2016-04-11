using MapeadorDeEntidades.Form.Core;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class MD_ChamadaProc
    {

        private void CSharp(SaveFileDialog salvar)
        {
            foreach (var nomeTabela in ParamtersInput.NomeTabelas)
            {
                var instancia = new CSharpADO(nomeTabela);
                var classe = instancia.GerarBodyCSharpProc().ToString();
                salvar.AddExtension = true;
                salvar.FileName = nomeTabela.ToLower() + "Repository.cs";

                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    var local = salvar.FileName;
                    File.WriteAllText(local, classe);
                }

                var interfacename = instancia.GerarInterfaceSharProc().ToString();
                salvar.FileName = "I" + nomeTabela.ToLower() + "Repository.cs";


                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    var local = salvar.FileName;
                    File.WriteAllText(local, interfacename);
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
