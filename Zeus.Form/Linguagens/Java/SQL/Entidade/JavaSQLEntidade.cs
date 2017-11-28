using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Java.SQL.Entidade
{
    public class JavaSQLEntidade : BaseSQLDAO
    {
        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"import java.util.Date;{N}");
            imports.Append($"import java.math.BigDecimal;{N}");
            imports.Append($"import javax.xml.bind.annotation.XmlRootElement;{N}");
            imports.Append($"{N}");

            return imports;
        }

        private StringBuilder AtributosHeader(List<SQLEntidadeTabela> entidadeTabela)
        {
            var atributosHeader = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributosHeader.Append($"	private {JavaTypesSQL.GetTypeAtribute(att)} {att.COLUMN_NAME};{N}");
            }
            atributosHeader.Append($"{N}");
            return atributosHeader;
        }

        private StringBuilder AtributosBody(List<SQLEntidadeTabela> entidadeTabela)
        {
            var atributoBody = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @Descrição {att.COMMENTS} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public {JavaTypesSQL.GetTypeAtribute(att)} get{att.COLUMN_NAME.ToFirstCharToUpper()}() {{{N}");
                atributoBody.Append($"		return {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");

                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @Descrição {att.COMMENTS} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public void set{att.COLUMN_NAME.ToFirstCharToUpper()}({JavaTypesSQL.GetTypeAtribute(att)} {att.COLUMN_NAME}) {{{N}");
                atributoBody.Append($"		this.{att.COLUMN_NAME} = {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");
            }
            atributoBody.Append($"{N}");
            return atributoBody;
        }

        public string GerarBody()
        {
            var atributos = new SQLTables().ListarAtributos(NomeTabela);

            var classe = new StringBuilder();
            classe.Append($"package model;{N}{N}");

            classe.Append(Imports());
            classe.Append("@XmlRootElement" + N);
            classe.Append($"public class {NomeTabela.ToFirstCharToUpper()} {{{N}");
            classe.Append(AtributosHeader(atributos));
            classe.Append(AtributosBody(atributos));
            classe.Append("}" + Environment.NewLine);

            return classe.ToString();
        }

        public JavaSQLEntidade(string nomeTabela) : base(nomeTabela)
        {
        }
    }
}
