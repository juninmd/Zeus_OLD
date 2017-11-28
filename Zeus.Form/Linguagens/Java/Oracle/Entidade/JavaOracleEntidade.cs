using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Oracle;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Java.Oracle.Entidade
{
    public class JavaOracleEntidade : BaseOracleDAO
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

        private StringBuilder AtributosHeader(List<OracleEntidadeTabela> entidadeTabela)
        {
            var atributosHeader = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributosHeader.Append($"	private {JavaTypesOracle.GetTypeAtribute(att)} {att.COLUMN_NAME};{N}");
            }
            atributosHeader.Append($"{N}");
            return atributosHeader;
        }

        private StringBuilder AtributosBody(List<OracleEntidadeTabela> entidadeTabela)
        {
            var atributoBody = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @Descrição {att.COMMENTS} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public {JavaTypesOracle.GetTypeAtribute(att)} get{att.COLUMN_NAME.ToFirstCharToUpper()}() {{{N}");
                atributoBody.Append($"		return {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");

                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @Descrição {att.COMMENTS} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public void set{att.COLUMN_NAME.ToFirstCharToUpper()}({JavaTypesOracle.GetTypeAtribute(att)} {att.COLUMN_NAME}) {{{N}");
                atributoBody.Append($"		this.{att.COLUMN_NAME} = {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");
            }
            atributoBody.Append($"{N}");
            return atributoBody;
        }

        public string GerarBody()
        {
            var classe = new StringBuilder();
            classe.Append($"package model;{N}{N}");

            classe.Append(Imports());
            classe.Append("@XmlRootElement" + N);
            classe.Append($"public class {NomeTabela} {{{N}");
            classe.Append(AtributosHeader(ListaAtributosTabela));
            classe.Append(AtributosBody(ListaAtributosTabela));
            classe.Append("}" + Environment.NewLine);

            return classe.ToString();
        }

        public JavaOracleEntidade(string nomeTabela) : base(nomeTabela)
        {
        }
    }
}
