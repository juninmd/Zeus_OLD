using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Linguagens.Node.Oracle.Procedure
{
    public class ChamadaNodeOracleProcedure
    {
        public RequestMessage<string> Node(FolderBrowserDialog salvar)
        {
            try
            {
                int max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {

                    i++;
                    Util.Barra((int)((((decimal)i / max) * 100)));
                    Util.Status($"Processando tabela: {nomeTabela}");

                    var instancia = new NodeOracleProcedure(nomeTabela);

                    var classe = instancia.GerarClasse().ToString();
                    File.WriteAllText($"{salvar.SelectedPath}\\{nomeTabela.TratarNomeTabela().ToLower()}Repository.js", classe);

                    var controller = new NodeController(nomeTabela).GerarClasse().ToString();
                    File.WriteAllText($"{salvar.SelectedPath}\\{nomeTabela.TratarNomeTabela().ToLower()}Ctl.js", controller);

                    var routes = new NodeRoutes(nomeTabela).GerarClasse().ToString();
                    File.WriteAllText($"{salvar.SelectedPath}\\{nomeTabela.TratarNomeTabela().ToLower()}Routes.js", routes);

                }

                return new RequestMessage<string>()
                {
                    Message = "Processamento concluído com sucesso!",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new RequestMessage<string>()
                {
                    Message = "Falha no sistema!",
                    TechnicalMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
