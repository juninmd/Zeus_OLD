using System;
using System.IO;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form.Core.SGBD.Oracle
{
    public class OracleOrquestradorProcedures
    {
        public RequestMessage<string> Oracle(FolderBrowserDialog salvar)
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

                    var instancia = new OracleProcedure(nomeTabela, new OracleTables().ListarAtributos(nomeTabela));

                    var header = instancia.GerarPackageHeader().ToString();
                    File.WriteAllText(local + $"{nomeTabela}_HEADER.sql", header);

                    var body = instancia.GerarPackageBody().ToString();
                    File.WriteAllText(local + $"{nomeTabela}_BODY.sql", body);
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
