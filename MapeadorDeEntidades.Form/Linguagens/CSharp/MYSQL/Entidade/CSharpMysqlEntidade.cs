using System.Text;
using Zeus.Core.SGBD.MySql;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.CSharp.MySql.Entidade
{
    public class CSharpMySqlEntidade : BaseEntity
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
            classe.Append($"    public class {nomeTabela}" + N);
            classe.Append("    {" + N + N);

            var atributos = new MySqlTables().ListarAtributos(nomeTabela);

            foreach (var item in atributos)
            {
                classe.Append("         /// <summary>" + N);
                classe.Append($"         /// {item.COLUMN_COMMENT}" + N);
                classe.Append("         /// </summary>" + N);
                classe.Append($"         public {CSharpTypesMySql.GetTypeAtribute(item.DATA_TYPE, item.IS_NULLABLE)} {item.COLUMN_NAME} {{ get; set; }}" + N);
                classe.Append(N);
            }
            classe.Append("    }" + N);
            classe.Append("}" + N);

            return GerarUsing() + classe.ToString();
        }


    }
}
