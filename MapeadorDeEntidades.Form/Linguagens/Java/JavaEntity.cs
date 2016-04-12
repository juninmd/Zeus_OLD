using MapeadorDeEntidades.Form.Linguagens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapeadorDeEntidades.Form
{
    public class JavaEntity : BaseEntity
    {
        /// <summary>
        /// Nova Linha
        /// </summary>
   
        public string GetTypeAtribute(EntidadeTabela prop)
        {
            switch (prop.DATA_TYPE)
            {
                case "DATE":
                    return "Date";
                case "NUMBER":
                    {
                        if (prop.DATA_PRECISION == null || prop.DATA_PRECISION <= 4)
                        {
                            return IsNullabe(prop.NULLABLE) ? "Integer" : "int";
                        }
                        else if (prop.DATA_PRECISION <= 15)
                        {
                            return IsNullabe(prop.NULLABLE) ? "Long" : "long";
                        }
                        return "BigDecimal";
                    }

                default:
                    return "String";
            }
        }

        public string GetTypeDsAtribute(EntidadeTabela prop)
        {
            switch (prop.DATA_TYPE)
            {
                case "DATE":
                    return "Date";
                case "NUMBER":
                    {
                        if (prop.DATA_PRECISION == null || prop.DATA_PRECISION <= 4)
                        {
                            return "Int";
                        }
                        else if (prop.DATA_PRECISION <= 15)
                        {
                            return "Long";
                        }
                        return "BigDecimal";
                    }

                default:
                    return "String";
            }
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"import java.util.Date;{N}");
            imports.Append($"import java.math.BigDecimal;{N}");
            imports.Append($"import javax.xml.bind.annotation.XmlRootElement;{N}");
            imports.Append($"{N}");

            return imports;
        }

        private StringBuilder AtributosHeader(List<EntidadeTabela> entidadeTabela)
        {
            var atributosHeader = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributosHeader.Append($"	private {GetTypeAtribute(att)} {att.COLUMN_NAME};{N}");
            }
            atributosHeader.Append($"{N}");
            return atributosHeader;
        }

        private StringBuilder AtributosBody(List<EntidadeTabela> entidadeTabela)
        {
            var atributoBody = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @Descrição {att.COMMENTS} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public {GetTypeAtribute(att)} get{att.COLUMN_NAME}() {{{N}");
                atributoBody.Append($"		return {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");

                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @Descrição {att.COMMENTS} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public void set{att.COLUMN_NAME}({GetTypeAtribute(att)} {att.COLUMN_NAME}) {{{N}");
                atributoBody.Append($"		this.{att.COLUMN_NAME} = {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");
            }
            atributoBody.Append($"{N}");
            return atributoBody;
        }

        public StringBuilder GerarBody(string nomeTabela)
        {
            var atributos = new OracleTables().ListarAtributos(nomeTabela);

            var classe = new StringBuilder();
            classe.Append($"package model;{N}{N}");

            classe.Append(Imports());
            classe.Append("@XmlRootElement" + N);
            classe.Append($"public class {nomeTabela} {{{N}");
            classe.Append(AtributosHeader(atributos));
            classe.Append(AtributosBody(atributos));
            classe.Append("}" + Environment.NewLine);

            return classe;
        }


    }
}
