using System;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Core.SGBD.Microsoft_SQL.Procedure;
using Zeus.Core.SGBD.MySql.Procedure;
using Zeus.Core.SGBD.Oracle.Procedure;
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
                        return new OracleOrquestradorProcedures().Oracle(salvar);
                    }
                case 2:
                    {
                        return new SQLOrquestradorProcedures().SQL(salvar);
                    }
                case 3:
                    {
                        return new MySqlOrquestradorProcedures().MySql(salvar);
                    }
                default:
                {
                    return new RequestMessage<string>();
                }
            }
        }
    }
}
