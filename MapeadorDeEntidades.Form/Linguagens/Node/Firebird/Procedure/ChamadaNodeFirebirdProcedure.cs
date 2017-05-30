using System;
using System.IO;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.Node.MySql.Procedure;
using Zeus.Utilidade;

namespace Zeus.Linguagens.Node.Firebird.Procedure
{
    public class ChamadaNodeFirebirdProcedure
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

                    var instancia = new NodeMySqlProcedure(nomeTabela);

                    var classe = instancia.GerarClasse().ToString();
                    File.WriteAllText($"{salvar.SelectedPath}\\{nomeTabela.TratarNomeTabela().ToLower()}Repository.js", classe);
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
