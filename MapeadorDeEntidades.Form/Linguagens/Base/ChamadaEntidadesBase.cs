using System;
using System.IO;
using System.Net;
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
        public RequestMessage<string> Orquestrar(string local)
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
                    Implementar(local, nomeTabela);
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
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
        public void Implementar(string local, string nomeTabela)
        {
            if (ParamtersInput.Linguagem == 1)
            {
                if (ParamtersInput.SGBD == 1)
                {
                    var instancia = new CSharpOracleEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
                else if (ParamtersInput.SGBD == 2)
                {
                    var instancia = new CSharpSQLEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela.TratarNomeSQL()}.cs", classe);
                }
                else if (ParamtersInput.SGBD == 3)
                {
                    var instancia = new CSharpMySqlEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
                else if (ParamtersInput.SGBD == 4)
                {
                    var instancia = new CSharpFirebirdEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
                else if (ParamtersInput.SGBD == 5)
                {
                    var instancia = new CSharpPostgreEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela}.cs", classe);
                }
            }
            else if (ParamtersInput.Linguagem == 2)
            {
                if (ParamtersInput.SGBD == 1)
                {
                    var instancia = new JavaOracleEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela}.java", classe);
                }
                else if (ParamtersInput.SGBD == 2)
                {
                    var instancia = new JavaSQLEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela.TratarNomeSQL().ToFirstCharToUpper()}.java", classe);
                }
                else if (ParamtersInput.SGBD == 3)
                {
                    var instancia = new JavaMySqlEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela}.java", classe);
                }
                else if (ParamtersInput.SGBD == 4)
                {
                    var instancia = new JavaFirebirdEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela}.java", classe);
                }
                else if (ParamtersInput.SGBD == 5)
                {
                    var instancia = new JavaPostgreEntidade(nomeTabela);
                    var classe = instancia.GerarBody();
                    File.WriteAllText($"{local}\\{nomeTabela}.java", classe);
                }
            }
        }
    }
}
