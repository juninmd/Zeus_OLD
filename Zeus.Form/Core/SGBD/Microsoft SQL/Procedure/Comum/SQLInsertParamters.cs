using System;
using System.Collections.Generic;
using System.Text;

namespace Zeus.Core.SGBD.Microsoft_SQL.Procedure.Comum
{
    public class SQLInsertParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<SQLEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append($"	     INSERT INTO {nomeTabela}" + N);
            param.Append($"					 ");
            param.Append($"({listaAtributos[0].COLUMN_NAME},{N}");
            for (int i = 1; i < count - 1; i++)
            {
                param.Append($"					  {listaAtributos[i].COLUMN_NAME},{N}");
            }
            param.Append($"					  {listaAtributos[count - 1].COLUMN_NAME}");
            param.Append($")" + N);

            param.Append($"			   VALUES");
            param.Append($"(@{listaAtributos[0].COLUMN_NAME},{N}");
            for (int i = 1; i < count - 1; i++)
            {
                param.Append($"					  @{listaAtributos[i].COLUMN_NAME},{N}");
            }
            param.Append($"					  @{listaAtributos[count - 1].COLUMN_NAME}");
            param.Append($"){N}{N}");
            param.Append($"	     RETURN 0{N}");
            return param;
        }
    }
}
