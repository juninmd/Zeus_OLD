using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Linguagens.Java.Oracle
{
    public class JavaOracleEntidade
    {
        public RequestMessage<string> Java(FolderBrowserDialog salvar)
        {
            try
            {
                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    Util.Status($"Processando tabela: {nomeTabela}");
                    var classe = new JavaEntity().GerarBody(nomeTabela).ToString();
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
