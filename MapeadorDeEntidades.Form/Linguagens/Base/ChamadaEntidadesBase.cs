using System;
using System.IO;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Linguagens.CSharp.Firebird.Entidade;
using Zeus.Linguagens.CSharp.MYSQL.Entidade;
using Zeus.Linguagens.CSharp.Oracle.Entidade;
using Zeus.Linguagens.CSharp.Postgre.Entidade;
using Zeus.Linguagens.CSharp.SQL.Entidade;
using Zeus.Linguagens.Java.Firebird.Entidade;
using Zeus.Linguagens.Java.MySql.Entidade;
using Zeus.Linguagens.Java.Oracle.Entidade;
using Zeus.Linguagens.Java.Postgre.Entidade;
using Zeus.Linguagens.Java.SQL.Entidade;
using Zeus.Utilidade;

namespace Zeus.Linguagens.Base
{
    public class ChamadaEntidadesBase
    {
        public RequestMessage<string> Orquestrar(FolderBrowserDialog salvar)
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
                    Implementar(local, nomeTabela);
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
        public void Implementar(string local, string nomeTabela)
        {
            if (ParamtersInput.Linguagem == 1)
            {
                if (ParamtersInput.SGBD == 1)
                {
                    var instancia = new CSharpOracleEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
                else if (ParamtersInput.SGBD == 2)
                {
                    var instancia = new CSharpSQLEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
                else if (ParamtersInput.SGBD == 3)
                {
                    var instancia = new CSharpMySqlEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
                else if (ParamtersInput.SGBD == 4)
                {
                    var instancia = new CSharpFirebirdEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
                else if (ParamtersInput.SGBD == 5)
                {
                    var instancia = new CSharpPostgreEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
            }
            else if (ParamtersInput.Linguagem == 2)
            {
                if (ParamtersInput.SGBD == 1)
                {
                    var instancia = new JavaOracleEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.java", classe);
                }
                else if (ParamtersInput.SGBD == 2)
                {
                    var instancia = new JavaSQLEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela.TratarNomeSQL().ToFirstCharToUpper()}.java", classe);
                }
                else if (ParamtersInput.SGBD == 3)
                {
                    var instancia = new JavaMySqlEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.java", classe);
                }
                else if (ParamtersInput.SGBD == 4)
                {
                    var instancia = new JavaFirebirdEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.java", classe);
                }
                else if (ParamtersInput.SGBD == 5)
                {
                    var instancia = new JavaPostgreEntidade();
                    var classe = instancia.GerarBody(nomeTabela);
                    File.WriteAllText($"{local}\\{nomeTabela}.java", classe);
                }
            }
        }
    }
}
