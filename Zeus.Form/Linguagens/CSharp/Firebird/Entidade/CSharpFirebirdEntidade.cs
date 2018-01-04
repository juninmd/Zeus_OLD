using System.Text;
using Zeus.Core;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.CSharp.Firebird.Entidade
{
    public class CSharpFirebirdEntidade : BaseFirebirdDAO
    {
        public CSharpFirebirdEntidade(string nomeTabela) : base(nomeTabela)
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
            classe.Append($"    public class {NomeTabela.ToFirstCharToUpper()}" + N);
            classe.Append("    {" + N + N);


            foreach (var item in ListaAtributosTabela)
            {
                classe.Append($"         public string {item.FIELD_NAME} {{ get; set; }}" + N);
                classe.Append(N);
            }

            classe.Append("    }" + N);
            classe.Append("}" + N);

            return GerarUsing() + classe.ToString();
        }
    }
}