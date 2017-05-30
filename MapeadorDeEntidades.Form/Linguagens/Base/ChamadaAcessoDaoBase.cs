using System;
using System.IO;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.CSharp.Firebird.Procedure;
using Zeus.Linguagens.CSharp.MYSQL.Procedure;
using Zeus.Linguagens.CSharp.Oracle.Procedure;
using Zeus.Linguagens.CSharp.Postgre.Procedure;
using Zeus.Linguagens.CSharp.SQL.Procedure;
using Zeus.Linguagens.Java.Firebird.Procedure;
using Zeus.Linguagens.Java.MySql.Procedure;
using Zeus.Linguagens.Java.Oracle.Procedure;
using Zeus.Linguagens.Java.Postgre.Procedure;
using Zeus.Linguagens.Java.SQL.Procedure;
using Zeus.Linguagens.Node.Firebird.Procedure;
using Zeus.Linguagens.Node.MySql.Procedure;
using Zeus.Linguagens.Node.Postgre.Procedure;
using Zeus.Linguagens.Node.SQL.Procedure;
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
        }
    }
}
