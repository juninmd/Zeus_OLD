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
                    Util.Barra((int)((decimal)i / max * 100));
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
                                    body = new CSharpOracleProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 2:
                                {
                                    body = new CSharpSQLProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 3:
                                {
                                    body = new CSharpMySqlProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 4:
                                {
                                    body = new CSharpFirebirdProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 5:
                                {
                                    body = new CSharpPostgreProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.cs", body);
                        break;
                    case 2:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                                {
                                    body = new JavaOracleProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 2:
                                {
                                    body = new JavaSQLProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 3:
                                {
                                    body = new JavaMySqlProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 4:
                                {
                                    body = new JavaFirebirdProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 5:
                                {
                                    body = new JavaPostgreProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                        }
                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.java", body);
                        break;
                    case 3:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                                {
                                    body = new NodeOracleProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 2:
                                {
                                    body = new NodeSQLProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 3:
                                {
                                    body = new NodeMySqlProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 4:
                                {
                                    body = new NodeFirebirdProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 5:
                                {
                                    body = new NodePostgreProcedure(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.js", body);
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
                                    body = new CsharpOracleQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 2:
                                {
                                    body = new CSharpSQLQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 3:
                                {
                                    body = new CsharpMySqlQuery(nomeTabela).GerarBodyCSharpProc().ToString();
                                    break;
                                }
                            case 4:
                                {
                                    body = new CSharpFirebirdQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 5:
                                {
                                    body = new CSharpPostgreQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.cs", body);
                        break;
                    case 2:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                                {
                                    body = new JavaOracleQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 2:
                                {
                                    body = new JavaSQLQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 3:
                                {
                                    body = new JavaMySqlQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 4:
                                {
                                    body = new JavaFirebirdQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 5:
                                {
                                    body = new JavaPostgreQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToFirstCharToUpper()}Repository.java", body);
                        break;
                    case 3:
                        switch (ParamtersInput.SGBD)
                        {
                            case 1:
                                {
                                    body = new NodeOracleQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 2:
                                {
                                    body = new NodeSQLQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 3:
                                {
                                    body = new NodeMySqlQuery(nomeTabela).GerarClasse();
                                    break;
                                }
                            case 4:
                                {
                                    body = new NodeFirebirdQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                            case 5:
                                {
                                    body = new NodePostgreQuery(nomeTabela).GerarClasse().ToString();
                                    break;
                                }
                        }

                        File.WriteAllText($"{local}{nomeTabela.TratarNomeTabela().ToLower()}Repository.js", body);
                        break;
                }
            if (body == "") throw new ArgumentException($"Código da tabela {nomeTabela} não foi gerada");
        }
    }
}