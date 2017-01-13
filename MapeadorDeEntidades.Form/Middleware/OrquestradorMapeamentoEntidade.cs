using System;
using System.Net;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.CSharp.Oracle.Entidade;
using Zeus.Linguagens.CSharp.SQL.Entidade;
using Zeus.Linguagens.Java.MySql.Entidade;
using Zeus.Linguagens.Java.Oracle.Entidade;
using Zeus.Utilidade;

namespace Zeus.Middleware
{
    public class OrquestradorMapeamentoEntidade
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
                                    return new CSharpOracleOrquestraEntidade().CSharp(salvar);
                                }
                            case 2:
                                {
                                    return new JavaOracleOrquestraEntidade().Java(salvar);
                                }
                            case 3:
                                {
                                    return new RequestMessage<string>()
                                    {
                                        StatusCode = HttpStatusCode.BadGateway,
                                        Message = "Essa linguagem não tem mapeamento de entidade NODE JS."
                                    };
                                }
                            default:
                                {
                                    return new RequestMessage<string>()
                                    {
                                        StatusCode = HttpStatusCode.BadGateway,
                                        Message = "Essa linguagem não foi programada."
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
                                    return new CSharpSQLOrquestraEntidade().CSharp(salvar);
                                }
                            default:
                                {
                                    return new RequestMessage<string>()
                                    {
                                        StatusCode = HttpStatusCode.BadGateway,
                                        Message = "Essa linguagem não foi programada."
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
                                    return new JavaMySqlOrquestraEntidade().Java(salvar);
                                }
                            default:
                                {
                                    return new RequestMessage<string>()
                                    {
                                        StatusCode = HttpStatusCode.BadGateway,
                                        Message = "Essa linguagem não foi programada."
                                    };
                                }
                        }
                    }
                default:
                    {
                        return new RequestMessage<string>()
                        {
                            StatusCode = HttpStatusCode.BadGateway,
                            Message = "Esse SGBD não foi programado."
                        };
                    }
            }
        }
    }
}
