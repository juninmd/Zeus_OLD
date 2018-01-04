using System;
using System.IO;
using System.Net;
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
using Zeus.Linguagens.Node.Oracle.Procedure;
using Zeus.Linguagens.Node.Oracle.Query;
using Zeus.Linguagens.Node.Postgre.Procedure;
using Zeus.Linguagens.Node.Postgre.Query;
using Zeus.Linguagens.Node.SQL.Procedure;
using Zeus.Linguagens.Node.SQL.Query;
using Zeus.Utilidade;

namespace Zeus.Linguagens.Base
{
    public class ChamadaAcessoDaoBase
    {
        public RequestMessage<string> Orquestrar()
        {
            try
            {
                var max = ParamtersInput.NomeTabelas.Count;
                var i = 0;

                foreach (var nomeTabela in ParamtersInput.NomeTabelas)
                {
                    i++;
                    Util.Barra((int) ((decimal) i / max * 100));
                    Util.Status($"Processando tabela: {nomeTabela}");
                    Implementar(ParamtersInput.SelectedPath, nomeTabela);
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

        public void Implementar(string local, string nomeTabela)
        {
            Util.Status($"Salvando em: {local}");
            var body = "";
            if (ParamtersInput.Procedure)
                switch (ParamtersInput.Linguagem)
                {
                    case 1:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                            {
                                var instancia = new CSharpOracleProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 2:
                            {
                                var instancia = new CSharpSQLProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 3:
                            {
                                var instancia = new CSharpMySqlProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 4:
                            {
                                var instancia = new CSharpFirebirdProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 5:
                            {
                                var instancia = new CSharpPostgreProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.cs",
                            body);
                        break;
                    case 2:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                            {
                                var instancia = new JavaOracleProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 2:
                            {
                                var instancia = new JavaSQLProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 3:
                            {
                                var instancia = new JavaMySqlProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 4:
                            {
                                var instancia = new JavaFirebirdProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 5:
                            {
                                var instancia = new JavaPostgreProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.java",
                            body);
                        break;
                    case 3:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                            {
                                var instancia = new NodeOracleProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 2:
                            {
                                var instancia = new NodeSQLProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 3:
                            {
                                var instancia = new NodeMySqlProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 4:
                            {
                                var instancia = new NodeFirebirdProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 5:
                            {
                                var instancia = new NodePostgreProcedure(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.js",
                            body);
                        break;
                }
            else
                switch (ParamtersInput.Linguagem)
                {
                    case 1:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                            {
                                var instancia = new CsharpOracleQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 2:
                            {
                                var instancia = new CSharpSQLQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 3:
                            {
                                var instancia = new CsharpMySqlQuery(nomeTabela);
                                body = instancia.GerarBodyCSharpProc().ToString();
                            }
                                break;
                            case 4:
                            {
                                var instancia = new CSharpFirebirdQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 5:
                            {
                                var instancia = new CSharpPostgreQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.cs",
                            body);
                        break;
                    case 2:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                            {
                                var instancia = new JavaOracleQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 2:
                            {
                                var instancia = new JavaSQLQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 3:
                            {
                                var instancia = new JavaMySqlQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 4:
                            {
                                var instancia = new JavaFirebirdQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 5:
                            {
                                var instancia = new JavaPostgreQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.java",
                            body);
                        break;
                    case 3:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                            {
                                var instancia = new NodeOracleQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 2:
                            {
                                var instancia = new NodeSQLQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 3:
                            {
                                var instancia = new NodeMySqlQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 4:
                            {
                                var instancia = new NodeFirebirdQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                            case 5:
                            {
                                var instancia = new NodePostgreQuery(nomeTabela);
                                body = instancia.GerarClasse().ToString();
                            }
                                break;
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToLower()}Repository.js", body);
                        break;
                }
            if (body == "") throw new ArgumentException($"Código da tabela {nomeTabela} não foi gerada");
        }
    }
}