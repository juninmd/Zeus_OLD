using System;
using System.Net;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.Base;
using Zeus.Linguagens.CSharp.Firebird;
using Zeus.Linguagens.CSharp.MYSQL;
using Zeus.Utilidade;

namespace Zeus.Middleware
{
    public class OrquestradorChamada
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
            return new ChamadaAcessoDaoBase().Orquestrar(salvar);
        }
    }
}
