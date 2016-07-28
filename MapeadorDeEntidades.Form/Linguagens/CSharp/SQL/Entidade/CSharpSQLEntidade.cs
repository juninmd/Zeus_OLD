using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.Microsoft_SQL;
using MapeadorDeEntidades.Form.Linguagens.Base;

namespace MapeadorDeEntidades.Form.Linguagens.CSharp.SQL.Entidade
{
    public class CSharpSQLEntidade : BaseEntity
    {
        private StringBuilder GerarUsing()
        {
            var texto = new StringBuilder();
            texto.Append("using System;" + N);
            texto.Append(N);
            return texto;
        }

        public string GerarBody(string nomeTabela)
        {
            var classe = new StringBuilder();
            classe.Append("namespace Model" + N);
            classe.Append("{" + N);
            classe.Append($"    public class {nomeTabela.TratarNomeSQL()}" + N);
            classe.Append("    {" + N + N);

            var atributos = new SQLTables().ListarAtributos(nomeTabela);

            foreach (var item in atributos)
            {
                classe.Append("         /// <summary>" + N);
                classe.Append($"         /// {item.COMMENTS}" + N);
                classe.Append("         /// </summary>" + N);
                classe.Append($"         public {CSharpTypesSQL.GetTypeAtribute(item.DATA_TYPE, item.NULLABLE)} {item.COLUMN_NAME} {{ get; set; }}" + N);
                classe.Append(N);
            }
            classe.Append("    }" + N);
            classe.Append("}" + N);

            return GerarUsing() + classe.ToString();
        }


    }
}
