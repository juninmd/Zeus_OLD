using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Comum
{
    public class MySqlDeleteParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<MySqlEntidadeTabela> listaAtributos)
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
