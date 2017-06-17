using System;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Linguagens.Base;

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
            var init = new ChamadaEntidadesBase().Orquestrar(salvar.SelectedPath + "\\");
            init.TechnicalMessage = ($"Tempo de processamento: {(DateTime.Now - dataInicial).Seconds}s - Tabelas: {ParamtersInput.NomeTabelas.Count}");
            return init;
        }
    }
}
