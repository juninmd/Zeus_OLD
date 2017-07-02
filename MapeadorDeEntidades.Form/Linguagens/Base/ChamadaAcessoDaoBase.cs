using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.CSharp.Firebird.Procedure;
using Zeus.Linguagens.CSharp.Firebird.Query;
using Zeus.Linguagens.CSharp.MYSQL.Procedure;
using Zeus.Linguagens.CSharp.MYSQL.Query;
using Zeus.Linguagens.CSharp.Oracle.Procedure;
using Zeus.Linguagens.CSharp.Oracle.Query;
using Zeus.Linguagens.CSharp.Postgre.Procedure;
using Zeus.Linguagens.CSharp.Postgre.Query;
using Zeus.Linguagens.CSharp.SQL.Procedure;
using Zeus.Linguagens.CSharp.SQL.Query;
using Zeus.Linguagens.Java.Firebird.Procedure;
using Zeus.Linguagens.Java.Firebird.Query;
using Zeus.Linguagens.Java.MySql.Procedure;
using Zeus.Linguagens.Java.MySql.Query;
using Zeus.Linguagens.Java.Oracle.Procedure;
using Zeus.Linguagens.Java.Oracle.Query;
using Zeus.Linguagens.Java.Postgre.Procedure;
using Zeus.Linguagens.Java.Postgre.Query;
using Zeus.Linguagens.Java.SQL.Procedure;
using Zeus.Linguagens.Java.SQL.Query;
using Zeus.Linguagens.Node.Firebird.Procedure;
using Zeus.Linguagens.Node.Firebird.Query;
using Zeus.Linguagens.Node.MySql.Procedure;
using Zeus.Linguagens.Node.MySql.Query;
using Zeus.Linguagens.Node.Postgre.Procedure;
using Zeus.Linguagens.Node.Postgre.Query;
using Zeus.Linguagens.Node.SQL.Procedure;
using Zeus.Linguagens.Node.SQL.Query;
using Zeus.Utilidade;

namespace Zeus.Linguagens.Base
{
    public class ChamadaAcessoDaoBase
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
            if (ParamtersInput.Procedure)
            {
                if (ParamtersInput.Linguagem == 1)
                {
                    if (ParamtersInput.SGBD == 1)
                    {
                        var instancia = new CSharpOracleProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                        var interfacename = instancia.GerarInterfaceSharProc().ToString();
                        File.WriteAllText(local + "I" + nomeTabela.ToLower() + "Repository.cs", interfacename);
                    }
                    else if (ParamtersInput.SGBD == 2)
                    {
                        var instancia = new CSharpSQLProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 3)
                    {
                        var instancia = new CSharpMySqlProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 4)
                    {
                        var instancia = new CSharpFirebirdProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 5)
                    {
                        var instancia = new CSharpPostgreProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                }
                else if (ParamtersInput.Linguagem == 2)
                {
                    if (ParamtersInput.SGBD == 1)
                    {
                        var instancia = new JavaOracleProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 2)
                    {
                        var instancia = new JavaSQLProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 3)
                    {
                        var instancia = new JavaMySqlProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 4)
                    {
                        var instancia = new JavaFirebirdProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 5)
                    {
                        var instancia = new JavaPostgreProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                }
                else if (ParamtersInput.Linguagem == 3)
                {
                    if (ParamtersInput.SGBD == 1)
                    {
                        var instancia = new NodePostgreProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 2)
                    {
                        var instancia = new NodeSQLProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 3)
                    {
                        var instancia = new NodeMySqlProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 4)
                    {
                        var instancia = new NodeFirebirdProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 5)
                    {
                        var instancia = new NodePostgreProcedure(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                }
            }
            else
            {
                if (ParamtersInput.Linguagem == 1)
                {
                    if (ParamtersInput.SGBD == 1)
                    {
                        var instancia = new CsharpOracleQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                        var interfacename = instancia.GerarInterfaceSharProc().ToString();
                        File.WriteAllText(local + "I" + nomeTabela.ToLower() + "Repository.cs", interfacename);
                    }
                    else if (ParamtersInput.SGBD == 2)
                    {
                        var instancia = new CSharpSQLQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 3)
                    {
                        var instancia = new CsharpMySqlQuery(nomeTabela);
                        var classe = instancia.GerarBodyCSharpProc().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 4)
                    {
                        var instancia = new CSharpFirebirdQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToFirstCharToUpper() + "Repository.cs", classe);
                    }
                    else if (ParamtersInput.SGBD == 5)
                    {
                        var instancia = new CSharpPostgreQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.cs", classe);
                    }
                }
                else if (ParamtersInput.Linguagem == 2)
                {
                    if (ParamtersInput.SGBD == 1)
                    {
                        var instancia = new JavaOracleQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.java", classe);
                    }
                    else if (ParamtersInput.SGBD == 2)
                    {
                        var instancia = new JavaSQLQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.java", classe);
                    }
                    else if (ParamtersInput.SGBD == 3)
                    {
                        var instancia = new JavaMySqlQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.java", classe);
                    }
                    else if (ParamtersInput.SGBD == 4)
                    {
                        var instancia = new JavaFirebirdQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.java", classe);
                    }
                    else if (ParamtersInput.SGBD == 5)
                    {
                        var instancia = new JavaPostgreQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.java", classe);
                    }
                }
                else if (ParamtersInput.Linguagem == 3)
                {
                    if (ParamtersInput.SGBD == 1)
                    {
                        var instancia = new NodePostgreQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.js", classe);
                    }
                    else if (ParamtersInput.SGBD == 2)
                    {
                        var instancia = new NodeSQLQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.js", classe);
                    }
                    else if (ParamtersInput.SGBD == 3)
                    {
                        var instancia = new NodeMySqlQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.js", classe);
                    }
                    else if (ParamtersInput.SGBD == 4)
                    {
                        var instancia = new NodeFirebirdQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.js", classe);
                    }
                    else if (ParamtersInput.SGBD == 5)
                    {
                        var instancia = new NodePostgreQuery(nomeTabela);
                        var classe = instancia.GerarClasse().ToString();
                        File.WriteAllText(local + nomeTabela.ToLower() + "Repository.js", classe);
                    }
                }
            }
        }
    }
}
