using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Postgre;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.CSharp.Postgre.Entidade
{
    public class CSharpPostgreEntidade : BasePostgreDAO
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
            classe.Append($"    public class {NomeTabela.ToFirstCharToUpper()}" + N);
            classe.Append("    {" + N + N);

            foreach (var item in ListaAtributosTabela)
            {
                classe.Append($"         public string {item.COLUMN_NAME} {{ get; set; }}" + N);
                classe.Append(N);
            }
            classe.Append("    }" + N);
            classe.Append("}" + N);

            return GerarUsing() + classe.ToString();
        }

        public CSharpPostgreEntidade(string nomeTabela) : base(nomeTabela)
        {
        }
    }
}
