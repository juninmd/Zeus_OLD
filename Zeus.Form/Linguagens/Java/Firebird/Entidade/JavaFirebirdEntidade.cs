﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Firebird;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Java.Firebird.Entidade
{
    public class JavaFirebirdEntidade : BaseFirebirdDAO
    {
        public JavaFirebirdEntidade(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports(List<FirebirdEntidadeTabela> entidadeTabela)
        {
            var imports = new StringBuilder();
            if (entidadeTabela.FirstOrDefault(q => q.FIELD_NAME == "date") != null)
                imports.Append($"import java.util.Date;{N}");
            if (entidadeTabela.FirstOrDefault(q => q.FIELD_NAME == "long") != null)
                imports.Append($"import java.math.BigDecimal;{N}");

            imports.Append($"{N}");

            return imports;
        }

        private StringBuilder AtributosHeader(List<FirebirdEntidadeTabela> entidadeTabela)
        {
            var atributosHeader = new StringBuilder();

            foreach (var att in entidadeTabela)
                atributosHeader.Append($"	private {JavaTypesFirebird.GetTypeAtribute(att)} {att.FIELD_NAME};{N}");
            atributosHeader.Append($"{N}");
            return atributosHeader;
        }

        private StringBuilder AtributosBody(List<FirebirdEntidadeTabela> entidadeTabela)
        {
            var atributoBody = new StringBuilder();

            foreach (var att in entidadeTabela)
            {
                atributoBody.Append($"	/** {N}");
                atributoBody.Append($"	 * {N}");
                atributoBody.Append($"	 * @return {N}");
                atributoBody.Append($"	 * @Descrição {att.COLUMN_COMMENT} {N}");
                atributoBody.Append($"	 */{N}");
                atributoBody.Append(
                    $"	public {JavaTypesFirebird.GetTypeAtribute(att)} get{att.FIELD_NAME.ToFirstCharToUpper()}() {{{N}");
                atributoBody.Append($"		return {att.FIELD_NAME};{N}");
                atributoBody.Append($"	}}{N}");
                atributoBody.Append($"{N}");

                atributoBody.Append(
                    $"	public void set{att.FIELD_NAME.ToFirstCharToUpper()}({JavaTypesFirebird.GetTypeAtribute(att)} {att.FIELD_NAME}) {{{N}");
                atributoBody.Append($"		this.{att.FIELD_NAME} = {att.FIELD_NAME};{N}");
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
    }
}