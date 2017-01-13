using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Core.SGBD.MySql.Procedure.Comum
{
    public class MySqlUpdateParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<MySqlEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append($"	     UPDATE {nomeTabela}" + N);
            param.Append($"   		   SET {listaAtributos[0].COLUMN_NAME}     = P_{listaAtributos[0].COLUMN_NAME},{N}");
            for (int i = 1; i < count - 1; i++)
            {
                param.Append($"               {listaAtributos[i].COLUMN_NAME}     = P_{listaAtributos[i].COLUMN_NAME},{N}");
            }
            param.Append($"               {listaAtributos[count - 1].COLUMN_NAME}     = P_{listaAtributos[count - 1].COLUMN_NAME}{N}");
            param.Append($"     	   WHERE {listaAtributos.First().COLUMN_NAME} =  P_{listaAtributos.First().COLUMN_NAME};{N}{N}");
            param.Append($"	SELECT 0 INTO P_RESULT;{N}");

            return param;
        }
    }
}
