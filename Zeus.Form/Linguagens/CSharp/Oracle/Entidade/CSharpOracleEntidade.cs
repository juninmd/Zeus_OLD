using System.Text;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.CSharp.Oracle.Entidade
{
    public class CSharpOracleEntidade : BaseOracleDAO
    {
        public CSharpOracleEntidade(string nomeTabela) : base(nomeTabela)
        {
        }

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
                classe.Append($"         /// {item.COMMENTS}" + N);
                classe.Append("         /// </summary>" + N);
                classe.Append(
                    $"         public {CSharpTypesOracle.GetTypeAtribute(item.DATA_TYPE, item.NULLABLE)} {item.COLUMN_NAME} {{ get; set; }}" +
                    N);
                classe.Append(N);
            }

            classe.Append("    }" + N);
            classe.Append("}" + N);

            return GerarUsing() + classe.ToString();
        }
    }
}