using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Zeus.Properties;
using Zeus.Utilidade;

namespace Zeus.Core.SGBD.MySql.Procedure
{
    public class MySqlOrquestradorProcedures
    {
        public RequestMessage<string> MySql(FolderBrowserDialog salvar)
        {
            try
            {
                int max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                var local = salvar.SelectedPath + "\\";
                var unificar = new StringBuilder();

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    i++;
                    Util.Barra((int)((((decimal)i / max) * 100)));
                    Util.Status($"Processando tabela: {nomeTabela}");

                    var instancia = new MySqlProcedure(nomeTabela, new MySqlTables().ListarAtributos(nomeTabela));
                    var body = instancia.GerarPackageBody().ToString();

                    if (!Settings.Default.UnificarOutput)
                        File.WriteAllText(local + $"{nomeTabela}.sql", body);
                    else
                    {
                        unificar.Append(body);
                        unificar.Append("\n\n");
                    }
                }

                if (Settings.Default.UnificarOutput)
                    File.WriteAllText(local + $"{ParamtersInput.DataBase}.sql", unificar.ToString());

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
