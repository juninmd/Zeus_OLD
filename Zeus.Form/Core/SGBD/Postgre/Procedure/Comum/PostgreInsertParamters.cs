using System;
using System.Collections.Generic;
using System.Text;

namespace Zeus.Core.SGBD.Postgre.Procedure.Comum
{
    public class PostgreInsertParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<PostgreEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append($"	     INSERT INTO {nomeTabela}" + N);
            param.Append($"					 ");
            param.Append($"({listaAtributos[0].COLUMN_NAME},{N}");
            for (var i = 1; i < count - 1; i++) param.Append($"					  {listaAtributos[i].COLUMN_NAME},{N}");
            param.Append($"					  {listaAtributos[count - 1].COLUMN_NAME}");
            param.Append($")" + N);

            param.Append($"			   VALUES");
            param.Append($"(null,{N}");
            for (var i = 1; i < count - 1; i++) param.Append($"					  P_{listaAtributos[i].COLUMN_NAME},{N}");
            param.Append($"					  P_{listaAtributos[count - 1].COLUMN_NAME}");
            param.Append($");{N}{N}");
            return param;
        }
    }
}