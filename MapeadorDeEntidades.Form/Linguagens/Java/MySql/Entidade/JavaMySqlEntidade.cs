﻿using System;
using System.Collections.Generic;
using System.Text;
using MapeadorDeEntidades.Form.Core.SGBD.MySql;
using MapeadorDeEntidades.Form.Linguagens.Base;

namespace MapeadorDeEntidades.Form.Linguagens.Java.MySql.Entidade
{
    public class JavaMySqlEntidade : BaseEntity
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

        private StringBuilder AtributosHeader(List<MySqlEntidadeTabela> entidadeTabela)
        {
            var atributosHeader = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributosHeader.Append($"	private {JavaTypesMySql.GetTypeAtribute(att)} {att.COLUMN_NAME};{N}");
            }
            atributosHeader.Append($"{N}");
            return atributosHeader;
        }

        private StringBuilder AtributosBody(List<MySqlEntidadeTabela> entidadeTabela)
        {
            var atributoBody = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @Descrição {att.COLUMN_COMMENT} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public {JavaTypesMySql.GetTypeAtribute(att)} get{att.COLUMN_NAME}() {{{N}");
                atributoBody.Append($"		return {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");

                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @Descrição {att.COLUMN_COMMENT} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append($"	public void set{att.COLUMN_NAME}({JavaTypesMySql.GetTypeAtribute(att)} {att.COLUMN_NAME}) {{{N}");
                atributoBody.Append($"		this.{att.COLUMN_NAME} = {att.COLUMN_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");
            }
            atributoBody.Append($"{N}");
            return atributoBody;
        }

        public StringBuilder GerarBody(string nomeTabela)
        {
            var atributos = new MySqlTables().ListarAtributos(nomeTabela);

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