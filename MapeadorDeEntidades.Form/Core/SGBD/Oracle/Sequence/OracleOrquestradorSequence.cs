using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Core.SGBD.Oracle.Sequence
{
    public class OracleOrquestradorSequence
    {
        public RequestMessage<string> Oracle(FolderBrowserDialog salvar)
        {
            try
            {
                int max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                var local = salvar.SelectedPath + "\\";

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    i++;
                    Util.Barra((int)((((decimal)i / max) * 100)));
                    Util.Status($"Processando tabela: {nomeTabela}");

                    var instancia = new OracleSequence().Init(nomeTabela);
                    File.WriteAllText(local + $"{nomeTabela}_SEQUENCE.sql", instancia);
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