using System;
using MapeadorDeEntidades.Form.Core;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Linguagens.CSharp.Oracle.Procedure;
using MapeadorDeEntidades.Form.Linguagens.CSharp.SQL.Procedure;
using MapeadorDeEntidades.Form.Linguagens.Java.Oracle.Procedure;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Middleware
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
                            default:
                                {
                                    return new RequestMessage<string>();
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
                                    return new RequestMessage<string>();
                                }
                        }

                    }
                default:
                    {
                        return new RequestMessage<string>();
                    }
            }
        }
    }
}
