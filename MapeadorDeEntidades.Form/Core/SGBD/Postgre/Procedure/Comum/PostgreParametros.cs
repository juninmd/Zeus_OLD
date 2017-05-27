using System.Collections.Generic;
using System.Text;

namespace Zeus.Core.SGBD.Postgre.Procedure.Comum
{
    public class PostgreParametros
    {
        public StringBuilder GenerateParams(List<PostgreEntidadeTabela> parametro, bool full)
        {
            if (parametro.Count == (full ? 0 : 1))
                return new StringBuilder();

            var desc = new StringBuilder();

            for (int index = (full ? 0 : 1); index < parametro.Count; index++)
            {
                var item = parametro[index];
                desc.Append($"IN P_{item.column_name} {TrataTipo(item)}{Virgula(parametro.Count, index, full)}");
            }
            return desc;
        }

        private string TrataTipo(PostgreEntidadeTabela tipo)
        {
            if (tipo.data_type == "varchar")
            {
                return $"{tipo.data_type}({tipo.character_maximum_length ?? 255})";
            }
            return tipo.data_type;
        }


        private StringBuilder Virgula(int count, int index, bool full)
        {
            if (count != (full ? 0 : 1) && index != (count - 1))
                return new StringBuilder(", ");
            return new StringBuilder("");

        }
    }
}
