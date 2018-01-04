using System;
using System.Collections.Generic;
using System.Text;

namespace Zeus.Core.SGBD.MySql.Procedure.Comum
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
            for (var i = 1; i < count - 1; i++) param.Append($"		    {listaAtributos[i].COLUMN_NAME}," + N);
            param.Append("		    " + listaAtributos[count - 1].COLUMN_NAME + N);
            param.Append($"	     FROM {nomeTabela};" + N);
            return param;
        }
    }
}