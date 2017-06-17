using System;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.Base;
using Zeus.Utilidade;

namespace Zeus.Middleware
{
    public class OrquestradorProcedures
    {
        public RequestMessage<string> Generate(FolderBrowserDialog salvar)
        {
            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
                return validate;

            var dataInicial = DateTime.Now;
            var init = new ChamadaProceduresBase().Orquestrar(salvar);
            var dataFinal = DateTime.Now;
            Util.Status($"Tempo de processamento: {(dataFinal - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}");
            return init;
        }
    }
}
