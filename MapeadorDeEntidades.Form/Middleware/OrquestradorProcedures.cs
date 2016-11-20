using System;
using MapeadorDeEntidades.Form.Core;
using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL.Procedure;
using MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure;
using MapeadorDeEntidades.Form.Core.SGBD.Oracle.Procedure;
using MapeadorDeEntidades.Form.Utilidade;

namespace MapeadorDeEntidades.Form.Middleware
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
