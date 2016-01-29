using System;
using System.Text;

namespace MapeadorDeEntidades.Form
{
    public class MapeadorEntidade
    {
        public StringBuilder GerarBody(string nomeTabela)
        {
            var classe = new StringBuilder();
            classe.Append("using System;" + Environment.NewLine + Environment.NewLine);
            classe.Append("namespace MapeadorDeEntidades.Form" + Environment.NewLine);
            classe.Append("{" + Environment.NewLine);
            classe.Append($"    public class {nomeTabela}" + Environment.NewLine);
            classe.Append("    {" + Environment.NewLine + Environment.NewLine);

            var atributos = new Query().ListarAtributos(nomeTabela);
            foreach (var item in atributos)
            {

                var corpo = new StringBuilder();
                corpo.Append("         /// <summary>" + Environment.NewLine);
                corpo.Append($"         /// {item.COMMENTS}" + Environment.NewLine);
                corpo.Append("         /// </summary>" + Environment.NewLine);
                corpo.Append($"         public {item.DATA_TYPE.GetTypeAtribute(item.NULLABLE)} {item.COLUMN_NAME} {{ get; set; }}" + Environment.NewLine);
                corpo.Append(Environment.NewLine);
                classe.Append(corpo);
            }
            classe.Append("    }" + Environment.NewLine);
            classe.Append("}" + Environment.NewLine);

            return classe;
        }
       
     
    }
}
