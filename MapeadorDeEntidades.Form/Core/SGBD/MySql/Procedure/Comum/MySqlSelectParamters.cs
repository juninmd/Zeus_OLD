using System;
using System.Collections.Generic;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;

namespace MapeadorDeEntidades.Form.Core.SGBD.MYSQL.Procedure.Comum
{
    public class MySqlSelectParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<MySqlEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append("	     SELECT");
            param.Append($" {listaAtributos[0].COLUMN_NAME}," + N);
            for (int i = 1; i < count - 1; i++)
            {
                param.Append($"		    {listaAtributos[i].COLUMN_NAME}," + N);
            }
            param.Append("		    " + listaAtributos[count - 1].COLUMN_NAME + N);
            param.Append($"	     FROM {nomeTabela} WITH(NOLOCK)" + N);
            return param;
        }
    }
}
