using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Firebird;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.CSharp.Firebird.Entidade
{
    public class CSharpFirebirdEntidade : BaseEntity
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
            classe.Append($"    public class {nomeTabela.ToFirstCharToUpper()}Model" + N);
            classe.Append("    {" + N + N);

            var atributos = new FirebirdTables().ListarAtributos(nomeTabela);

            foreach (var item in atributos)
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
