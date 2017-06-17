using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Core.SGBD.Microsoft_SQL.Procedure;
using Zeus.Core.SGBD.MySql.Procedure;
using Zeus.Core.SGBD.Oracle.Procedure;
using Zeus.Core.SGBD.Postgre.Procedure;
using Zeus.Properties;
using Zeus.Utilidade;

namespace Zeus.Linguagens.Base
{
    public class ChamadaProceduresBase
    {
        public RequestMessage<string> Orquestrar(FolderBrowserDialog salvar)
        {
            try
            {
                int max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                var local = $"{salvar.SelectedPath}\\";
                var unificar = new StringBuilder();

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    i++;
                    Util.Barra((int)((((decimal)i / max) * 100)));
                    Util.Status($"Processando tabela: {nomeTabela}");
                    var body = Implementar(nomeTabela);

                    if (!Settings.Default.UnificarOutput)
                        File.WriteAllText($"{local}{nomeTabela.TratarNomeSQL()}.sql", body);
                    else
                    {
                        unificar.Append(body);
                        unificar.Append("\n\n");
                    }
                }

                if (Settings.Default.UnificarOutput)
                    File.WriteAllText(local + $"{ParamtersInput.DataBase}.sql", unificar.ToString());

                return new RequestMessage<string>
                {
                    Message = "Processamento concluído com sucesso!",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new RequestMessage<string>
                {
                    Message = "Falha no sistema!",
                    TechnicalMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
        public string Implementar(string nomeTabela)
        {
            if (ParamtersInput.SGBD == 1)
            {

                ////Sequence
                //var nomeSequence = nomeTabela.TratarNomeSequence().Replace(".NEXTVAL", "");
                //if (!new OracleBatchSkip().Sequence(nomeSequence).IsError)
                //{
                //    var instanciaSequence = new OracleSequence().Init(nomeTabela);
                //    var instanciaSave = new OracleBatch().Init(instanciaSequence);
                //    if (instanciaSave.IsError)
                //    {
                //        return instanciaSave;
                //    }
                //}

                //var instancia = new OracleProcedure(nomeTabela);
                //var header = instancia.GerarPackageHeader().ToString();
                //File.WriteAllText(local + $"{nomeTabela.TratarNomePackage()}_HEADER.sql", header);

                return new OracleProcedure(nomeTabela).GerarBody();
            }
            if (ParamtersInput.SGBD == 2)
            {
                return new SQLProcedure(nomeTabela).GerarBody();
            }
            if (ParamtersInput.SGBD == 3)
            {
                return new MySqlProcedure(nomeTabela).GerarBody();
            }
            if (ParamtersInput.SGBD == 4)
            {
                //  return new FirebirdProcedure(nomeTabela);
            }
            return new PostgreProcedure(nomeTabela).GerarBody();
        }
    }
}
