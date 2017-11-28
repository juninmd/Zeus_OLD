using System.Text;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.CSharp.MYSQL.Entidade
{
    public class CSharpMySqlEntidade : BaseMySqlDAO
    {
        private StringBuilder GerarUsing()
        {
            var texto = new StringBuilder();
            texto.Append("using System;" + N);
            texto.Append(N);
            return texto;
        }

        public string GerarBody()
        {
            var classe = new StringBuilder();
            classe.Append("namespace Model" + N);
            classe.Append("{" + N);
            classe.Append($"    public class {NomeTabela}" + N);
            classe.Append("    {" + N + N);

            foreach (var item in ListaAtributosTabela)
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


        public CSharpMySqlEntidade(string nomeTabela) : base(nomeTabela)
        {
        }
    }
}
