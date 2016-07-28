using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL.Procedure.Comum
{
    public class SQLDeleteParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<SQLEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append($"	     DELETE FROM {nomeTabela}{N}");
            param.Append($"               WHERE {listaAtributos.First().COLUMN_NAME} = @{listaAtributos.First().COLUMN_NAME}{N}{N}");
            param.Append($"	     RETURN 0{N}");
            return param;
        }
    }
}
