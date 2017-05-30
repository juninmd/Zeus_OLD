using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Core.SGBD.Postgre.Procedure.Comum
{
    public class PostgreBuscaParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<PostgreEntidadeTabela> listaAtributos)
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
            param.Append($"	     FROM {nomeTabela}" + N);
            param.Append($"	     WHERE {listaAtributos.First().COLUMN_NAME} = P_{listaAtributos.First().COLUMN_NAME};" + N);
            return param;
        }
    }
}
