using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core;

namespace MapeadorDeEntidades.Form.Linguagens.Java.Oracle
{
    public class ChamadaJavaOracleProcedure
    {
        public RequestMessage<string> Java(FolderBrowserDialog salvar)
        {
            try
            {
                var funcao = salvar.ShowDialog();
                if (funcao != DialogResult.OK)
                    return new RequestMessage<string>()
                    {
                        Message = "Processamento cancelado!",
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    var local = salvar.SelectedPath + "\\";

                    var instancia = new JavaOracleRepository(nomeTabela);

                    var classe = instancia.GerarClasse().ToString();
                    File.WriteAllText(local + nomeTabela.ToLower() + "Dao.java", classe);
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
