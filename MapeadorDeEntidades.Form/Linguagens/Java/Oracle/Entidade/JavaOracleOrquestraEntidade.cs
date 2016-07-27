using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Linguagens.Java.Oracle.Entidade
{
    public class JavaOracleOrquestraEntidade
    {
        public RequestMessage<string> Java(FolderBrowserDialog salvar)
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

                    var classe = new JavaOracleEntidade().GerarBody(nomeTabela).ToString();
                    File.WriteAllText($"{salvar.SelectedPath}\\{nomeTabela}.java", classe);
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
            };
        }
    }
}
