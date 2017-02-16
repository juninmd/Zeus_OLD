using System;
using System.Net;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.CSharp.Oracle.Procedure;
using Zeus.Linguagens.CSharp.SQL.Procedure;
using Zeus.Linguagens.Java.MySql.Procedure;
using Zeus.Linguagens.Java.Oracle.Procedure;
using Zeus.Linguagens.Node.MySql;
using Zeus.Linguagens.Node.Oracle.Procedure;
using Zeus.Utilidade;

namespace Zeus.Middleware
{
    public class OrquestradorChamadaProcedure
    {
        public RequestMessage<string> Generate(FolderBrowserDialog salvar)
        {
            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
                return validate;

            var dataInicial = DateTime.Now;
            var init = Init(salvar);
            var dataFinal = DateTime.Now;
            Util.Status($"Tempo de processamento: {(dataFinal - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}");
            return init;
        }

        public RequestMessage<string> Init(FolderBrowserDialog salvar)
        {


            switch (ParamtersInput.SGBD)
            {
                case 1:
                    {
                        switch (ParamtersInput.Linguagem)
                        {
                            case 1:
                                {
                                    return new ChamadaCsharpOracleProcedure().CSharp(salvar);
                                }
                            case 2:
                                {
                                    return new ChamadaJavaOracleProcedure().Java(salvar);
                                }
                            case 3:
                                {
                                    return new ChamadaNodeOracleProcedure().Node(salvar);
                                }
                            default:
                                {
                                    return new RequestMessage<string>()
                                    {
                                        StatusCode = HttpStatusCode.InternalServerError,
                                        Message = "Essa linguagem não foi programada!"
                                    };
                                }
                        }

                    }
                case 2:
                    {
                        switch (ParamtersInput.Linguagem)
                        {
                            case 1:
                                {
                                    return new ChamadaCsharpSQLProcedure().CSharp(salvar);
                                }
                            default:
                                {
                                    return new RequestMessage<string>()
                                    {
                                        StatusCode = HttpStatusCode.InternalServerError,
                                        Message = "Essa linguagem não foi programada!"
                                    };
                                }
                        }

                    }
                case 3:
                    {
                        switch (ParamtersInput.Linguagem)
                        {
                            case 2:
                                {
                                    return new ChamadaJavaMySqlProcedure().Java(salvar);
                                }
                            case 3:
                                {
                                    return new ChamadaNodeMySqlProcedure().Node(salvar);
                                }
                            default:
                                {
                                    return new RequestMessage<string>()
                                    {
                                        StatusCode = HttpStatusCode.InternalServerError,
                                        Message = "Essa linguagem não foi programada!"
                                    };
                                }
                        }

                    }
                default:
                    {
                        return new RequestMessage<string>()
                        {
                            StatusCode = HttpStatusCode.InternalServerError,
                            Message = "Essa linguagem não foi programada!"
                        };
                    }
            }
        }
    }
}
