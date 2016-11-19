using System;
using System.IO;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure
{
    public class MySqlOrquestradorProcedures
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

                    var instancia = new MySqlProcedure(nomeTabela, new MySqlTables().ListarAtributos(nomeTabela));
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
