using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Core.SGBD.Postgre.Procedure.Comum
{
    public class PostgreUpdateParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<PostgreEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append($"	     UPDATE {nomeTabela}" + N);
            param.Append($"   		   SET {listaAtributos[0].column_name}     = P_{listaAtributos[0].column_name},{N}");
            for (int i = 1; i < count - 1; i++)
            {
                param.Append($"               {listaAtributos[i].column_name}     = P_{listaAtributos[i].column_name},{N}");
            }
            param.Append($"               {listaAtributos[count - 1].column_name}     = P_{listaAtributos[count - 1].column_name}{N}");
            param.Append($"     	   WHERE {listaAtributos.First().column_name} =  P_{listaAtributos.First().column_name};{N}{N}");

            return param;
        }
    }
}
