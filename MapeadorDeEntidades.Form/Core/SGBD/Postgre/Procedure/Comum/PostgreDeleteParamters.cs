using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zeus.Core.SGBD.Postgre.Procedure.Comum
{
    public class PostgreDeleteParamters
    {
        private string N => Environment.NewLine;

        public StringBuilder Init(string nomeTabela, List<PostgreEntidadeTabela> listaAtributos)
        {
            var param = new StringBuilder();
            var count = listaAtributos.Count;
            if (count == 0)
                return param;

            param.Append($"	     DELETE FROM {nomeTabela}{N}");
            param.Append($"               WHERE {listaAtributos.First().column_name} = P_{listaAtributos.First().column_name};{N}{N}");
            return param;
        }
    }
}
