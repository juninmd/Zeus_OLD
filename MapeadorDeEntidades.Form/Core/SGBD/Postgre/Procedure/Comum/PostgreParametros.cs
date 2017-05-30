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
                desc.Append($"IN P_{item.COLUMN_NAME} {TrataTipo(item)}{Virgula(parametro.Count, index, full)}");
            }
            return desc;
        }

        private string TrataTipo(PostgreEntidadeTabela tipo)
        {
            if (tipo.DATA_TYPE == "varchar")
            {
                return $"{tipo.DATA_TYPE}({tipo.CHARACTER_MAXIMUN_LENGTH ?? 255})";
            }
            return tipo.DATA_TYPE;
        }


        private StringBuilder Virgula(int count, int index, bool full)
        {
            if (count != (full ? 0 : 1) && index != (count - 1))
                return new StringBuilder(", ");
            return new StringBuilder("");

        }
    }
}
