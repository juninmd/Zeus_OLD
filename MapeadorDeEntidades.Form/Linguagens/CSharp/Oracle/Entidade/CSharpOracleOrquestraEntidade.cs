using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Linguagens.CSharp.Oracle.Entidade
{
    public class CSharpOracleOrquestraEntidade
    {
        public RequestMessage<string> CSharp(FolderBrowserDialog salvar)
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
                    var classe = new CSharpOracleEntity().GerarBody(nomeTabela);
                    File.WriteAllText($"{salvar.SelectedPath}\\{nomeTabela}.cs", classe);
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
