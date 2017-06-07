using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Postgre;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Java.Postgre.Entidade
{
    public class JavaPostgreEntidade : BasePostgreDAO
    {
        private StringBuilder Imports(List<PostgreEntidadeTabela> entidadeTabela)
        {
            var imports = new StringBuilder();
            if (entidadeTabela.FirstOrDefault(q => q.DATA_TYPE == "date") != null)
            {
                imports.Append($"import java.util.Date;{N}");
            }
            if (entidadeTabela.FirstOrDefault(q => q.DATA_TYPE == "long") != null)
            {
                imports.Append($"import java.math.BigDecimal;{N}");
            }
            
            imports.Append($"{N}");

            return imports;
        }

        private StringBuilder AtributosHeader(List<PostgreEntidadeTabela> entidadeTabela)
        {
            var atributosHeader = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributosHeader.Append($"	private {JavaTypesPostgre.GetTypeAtribute(att)} {att.COLUMN_NAME};{N}");
            }
            atributosHeader.Append($"{N}");
            return atributosHeader;
        }

        private StringBuilder AtributosBody(List<PostgreEntidadeTabela> entidadeTabela)
        {
            var atributoBody = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @return {N}");
                atributoBody.Append($"	 * @Descrição {att.COLUMN_COMMENT} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public {JavaTypesPostgre.GetTypeAtribute(att)} get{att.COLUMN_NAME.ToFirstCharToUpper()}() {{{N}");
                atributoBody.Append($"		return {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");

                atributoBody.Append($"	public void set{att.COLUMN_NAME.ToFirstCharToUpper()}({JavaTypesPostgre.GetTypeAtribute(att)} {att.COLUMN_NAME}) {{{N}");
                atributoBody.Append($"		this.{att.COLUMN_NAME} = {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");
            }
            return atributoBody;
        }

        public string GerarBody()
        {
            var classe = new StringBuilder();
            classe.Append($"package model;{N}{N}");

            classe.Append(Imports(ListaAtributosTabela));
            classe.Append($"public class {NomeTabela} {{{N}");
            classe.Append(AtributosHeader(ListaAtributosTabela));
            classe.Append(AtributosBody(ListaAtributosTabela));
            classe.Append("}" + Environment.NewLine);

            return classe.ToString();
        }

        public JavaPostgreEntidade(string nomeTabela) : base(nomeTabela)
        {
        }
    }
}
