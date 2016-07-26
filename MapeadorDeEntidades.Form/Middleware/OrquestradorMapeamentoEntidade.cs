using System;
using MapeadorDeEntidades.Form.Core;
using System.Linq;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Linguagens.CSharp.Oracle;
using MapeadorDeEntidades.Form.Linguagens.Java.Oracle;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Middleware
{
    public class OrquestradorMapeamentoEntidade
    {
        public RequestMessage<string> Generate(FolderBrowserDialog salvar)
        {
            if (!ParamtersInput.NomeTabelas.Any())
            {
                return new RequestMessage<string>()
                {
                    Message = "Selecione uma tabela",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

            var funcao = salvar.ShowDialog();
            if (funcao != DialogResult.OK)
                return new RequestMessage<string>()
                {
                    Message = "Processamento cancelado!",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

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
                                    return new JavaOracleEntidade().Java(salvar);
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
