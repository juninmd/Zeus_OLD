using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Firebird;
using Zeus.Linguagens.Base;
using Zeus.Linguagens.CSharp.Firebird;

namespace Zeus.Linguagens.Java.MySql.Procedure
{
    public class CSharpFirebirdDirect : BaseMySqlDAO
    {

        public CSharpFirebirdDirect(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"using System.Windows.Forms;{N}");
            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"	public {NomeTabela} GetById(int ID) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"			ResultSet rs = ExecuteReader(\"SELECT * FROM {NomeTabela} WHERE {ListaAtributosTabela.First()} = \"+ID);{N}");
            get.Append($"			if(rs.next()){{{N}");
            get.Append($"				{NomeTabela} resposta = new {NomeTabela}();{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"                        {att.COLUMN_NAME} = \"{att.COLUMN_NAME}\".GetValueOrDefault<{CSharpTypesFirebird.GetTypeAtribute(att.DATA_TYPE, false)}>(reader){N}");
            }
            get.Append($"				return resposta;{N}");
            get.Append($"			}}{N}");
            get.Append($"			return null;{N}");
            get.Append($"	}}{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"	public List<{NomeTabela}> GetAll() throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"	}}{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"	public void Add({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"	}}{N}");
            return get;
        }

        private StringBuilder Update()
        {
            var get = new StringBuilder();
            get.Append($"	public void Update({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"	}}{N}");
            return get;
        }
        private StringBuilder Delete()
        {

            var get = new StringBuilder();
            get.Append($"	public void Delete(int ID) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"	}}{N}");
            get.Append($"}}{N}");
            return get;
        }

        public StringBuilder GerarClasse()
        {
            var classe = new StringBuilder();
            classe.Append(Imports());
            classe.Append($"namespace meuprojeto{N}{{{N}");
            classe.Append($"public class {NomeTabela}Dao : FirebirdRepository {{ {N}{N}");
            classe.Append(GetById());
            classe.Append(GetAll());
            classe.Append(Add());
            classe.Append(Update());
            classe.Append(Delete());
            return classe;
        }

        private StringBuilder GetListaItensGetById(List<FirebirdEntidadeTabela> ListaAtributosTabela)
        {
            var atributoText = new StringBuilder();
            foreach (var item in ListaAtributosTabela)
            {
                atributoText.Append($"                        {item.FIELD_NAME} = \"{item.FIELD_NAME}\".GetValueOrDefault<{CSharpTypesFirebird.GetTypeAtribute(item.FIELD_NAME, item.IS_NULLABLE)}>(reader)," + N);
            }
            return atributoText;
        }
    }
}
