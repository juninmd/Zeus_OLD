using System;
using System.IO;
using System.Windows.Forms;
using Zeus.Utilidade;

namespace Zeus.Core.SGBD.Microsoft_SQL.Procedure
{
    public class SQLOrquestradorProcedures
    {
        public RequestMessage<string> SQL(FolderBrowserDialog salvar)
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

                    var instancia = new SQLProcedure(nomeTabela, new SQLTables().ListarAtributos(nomeTabela));
                    var body = instancia.GerarPackageBody().ToString();
                    File.WriteAllText(local + $"{nomeTabela.TratarNomeSQL()}.sql", body);
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
