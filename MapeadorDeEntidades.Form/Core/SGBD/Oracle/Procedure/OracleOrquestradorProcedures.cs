using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Core.SGBD.Oracle.Procedure
{
    public class OracleOrquestradorProcedures
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

                    var instancia = new OracleProcedure(nomeTabela, new OracleTables().ListarAtributos(nomeTabela));
                    var header = instancia.GerarPackageHeader().ToString();
                    File.WriteAllText(local + $"{nomeTabela.TratarNomePackage()}_HEADER.sql", header);

                    var body = instancia.GerarPackageBody().ToString();
                    File.WriteAllText(local + $"{nomeTabela.TratarNomePackage()}_BODY.sql", body);
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
