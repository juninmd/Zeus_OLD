using System;
using System.IO;
using System.Net;
using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Core.SGBD.Microsoft_SQL.Procedure;
using Zeus.Core.SGBD.MySql.Procedure;
using Zeus.Core.SGBD.Oracle.Procedure;
using Zeus.Core.SGBD.Postgre.Procedure;
using Zeus.Utilidade;

namespace Zeus.Linguagens.Base
{
    public class ChamadaProceduresBase
    {
        /// <summary>
        ///     TODO: Melhorar
        /// </summary>
        /// <returns></returns>
        public RequestMessage<string> Orquestrar()
        {
            try
            {
                var max = ParamtersInput.NomeTabelas.Count;
                var i = 0;
                var unificar = new StringBuilder();
                var unificarHeader = new StringBuilder();

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    i++;
                    Util.Barra((int) ((decimal) i / max * 100));
                    Util.Status($"Processando tabela: {nomeTabela}");
                    var body = Implementar(nomeTabela);

                    if (!ParamtersInput.UnificarOutput)
                    {
                        if (ParamtersInput.SGBD == 1)
                            File.WriteAllText($"{ParamtersInput.SelectedPath}{nomeTabela.TratarNomeSQL()}Header.sql",
                                new OracleProcedure(nomeTabela).GerarPackageHeader().ToString());
                        File.WriteAllText($"{ParamtersInput.SelectedPath}{nomeTabela.TratarNomeSQL()}.sql", body);
                    }
                    else
                    {
                        unificar.Append(body);
                        unificar.Append("\n\n");

                        if (ParamtersInput.SGBD == 1)
                        {
                            unificarHeader.Append(new OracleProcedure(nomeTabela).GerarPackageHeader());
                            unificarHeader.Append("\n\n");
                        }
                    }
                }

                if (ParamtersInput.UnificarOutput)
                {
                    File.WriteAllText(ParamtersInput.SelectedPath + $"{ParamtersInput.DataBase ?? "Procedures"}.sql",
                        unificar.ToString());

                    if (ParamtersInput.SGBD == 1)
                        File.WriteAllText(
                            ParamtersInput.SelectedPath + $"{ParamtersInput.DataBase ?? "Procedures"}Header.sql",
                            unificarHeader.ToString());
                }

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
                    StatusCode = HttpStatusCode.InternalServerError,
                    StackTrace = ex.StackTrace
                };
            }
        }

        public string Implementar(string nomeTabela)
        {
            switch (ParamtersInput.SGBD)
            {
                case 1:
                    return new OracleProcedure(nomeTabela).GerarBody();
                case 2:
                    return new SQLProcedure(nomeTabela).GerarBody();
                case 3:
                    return new MySqlProcedure(nomeTabela).GerarBody();
                case 4:
                    throw new NotImplementedException();
                //return new FirebirdProcedure(nomeTabela);
                //break;
            }

            return new PostgreProcedure(nomeTabela).GerarBody();
        }
    }
}