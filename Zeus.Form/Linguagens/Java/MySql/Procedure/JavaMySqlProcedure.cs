using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Java.MySql.Procedure
{
    public class JavaMySqlProcedure : BaseMySqlDAO
    {
        public JavaMySqlProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"import java.sql.ResultSet;{N}");
            imports.Append($"import java.util.List;{N}");
            imports.Append($"import model.{NomeTabela};{N}");
            return imports;
        }

        private StringBuilder ProceduresNames()
        {
            var baseProc = NomeTabela.TratarNomeTabela().ToUpper();
            var proc = new StringBuilder();
            proc.Append($"	private enum Proc{N}");
            proc.Append($"	{{{N}");
            proc.Append($"		{baseProc.TratarNomeProcedure(OperationProcedure.Search)},{N}");
            proc.Append($"		{baseProc.TratarNomeProcedure(OperationProcedure.List)},{N}");
            proc.Append($"		{baseProc.TratarNomeProcedure(OperationProcedure.Insert)},{N}");
            proc.Append($"		{baseProc.TratarNomeProcedure(OperationProcedure.Update)},{N}");
            proc.Append($"		{baseProc.TratarNomeProcedure(OperationProcedure.Delete)}{N}");
            proc.Append($"	}}{N}");
            return proc;
        }

        private StringBuilder GetById()
        {
            var nameProc = $"{ParamtersInput.Prefixos.Procedure}S_{NomeTabela.TratarNomeTabela().ToUpper()}_ID";

            var get = new StringBuilder();
            get.Append($"	public {NomeTabela} GetById(int id) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Paramter(\"P_{ListaAtributosTabela.First().COLUMN_NAME}\", java.sql.Types.NUMERIC, id));{N}{N}");
            get.Append($"			ResultSet rs = super.ExecuteReader();{N}{N}");
            get.Append($"			if(rs.next()){{{N}");
            get.Append($"				{NomeTabela} resposta = new {NomeTabela}();{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"				resposta.set{att.COLUMN_NAME}(rs.get{JavaTypesMySql.GetTypeAtribute((att))}(\"{att.COLUMN_NAME}\"));{N}");
            }
            get.Append($"				return resposta;{N}");
            get.Append($"			}};{N}");
            get.Append($"			return null;{N}");
            get.Append($"		}}{N}");
            get.Append($"		catch (Exception ex){{{N}");
            get.Append($"			throw ex;{N}");
            get.Append($"		}}{N}");
            get.Append($"		finally {{{N}");
            get.Append($"			desconecta();{N}");
            get.Append($"		}}{N}");
            get.Append($"	}}{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var nameProc = $"{ParamtersInput.Prefixos.Procedure}S_{NomeTabela.TratarNomeTabela().ToUpper()}";

            var get = new StringBuilder();
            get.Append($"	public List<{NomeTabela}> GetAll() throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			List<{NomeTabela}> lista = new java.util.ArrayList<{NomeTabela}>();{N}{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			ResultSet rs = super.ExecuteReader();{N}{N}");
            get.Append($"			while(rs.next()){{{N}");
            get.Append($"				{NomeTabela} resposta = new {NomeTabela}();{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"				resposta.set{att.COLUMN_NAME}(rs.get{JavaTypesMySql.GetTypeAtribute(att)}(\"{att.COLUMN_NAME}\"));{N}");
            }
            get.Append($"				lista.add(resposta);{N}");
            get.Append($"			}};{N}");
            get.Append($"			return lista;{N}");
            get.Append($"		}}{N}");
            get.Append($"		catch (Exception ex){{{N}");
            get.Append($"			throw ex;{N}");
            get.Append($"		}}{N}");
            get.Append($"		finally {{{N}");
            get.Append($"			desconecta();{N}");
            get.Append($"		}}{N}");
            get.Append($"	}}{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var nameProc = $"{ParamtersInput.Prefixos.Procedure}I_{NomeTabela.TratarNomeTabela().ToUpper()}";

            var get = new StringBuilder();
            get.Append($"	public void Add({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Paramter(\"P_RESULT\", java.sql.Types.VARCHAR, null,\"OUT\"));{N}{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"			AddParamter(new Paramter(\"P_{att.COLUMN_NAME}\", java.sql.Types.{JavaTypesMySql.GetTypeAtribute(att)}, entidade.get{att.COLUMN_NAME}()));{N}");
            }
            get.Append($"			RequestProc();{N}");
            get.Append($"		}}{N}");
            get.Append($"		catch (Exception ex){{{N}");
            get.Append($"			throw ex;{N}");
            get.Append($"		}}{N}");
            get.Append($"		finally {{{N}");
            get.Append($"			desconecta();{N}");
            get.Append($"		}}{N}");
            get.Append($"	}}{N}");
            return get;
        }

        private StringBuilder Update()
        {
            var nameProc = $"{ParamtersInput.Prefixos.Procedure}U_{NomeTabela.TratarNomeTabela().ToUpper()}";

            var get = new StringBuilder();
            get.Append($"	public void Update({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Paramter(\"P_RESULT\", java.sql.Types.VARCHAR, null,\"OUT\"));{N}{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"			AddParamter(new Paramter(\"P_{att.COLUMN_NAME}\", java.sql.Types.{JavaTypesMySql.GetTypeAtribute(att)}, entidade.get{att.COLUMN_NAME}()));{N}");
            }
            get.Append($"			RequestProc();{N}");
            get.Append($"		}}{N}");
            get.Append($"		catch (Exception ex){{{N}");
            get.Append($"			throw ex;{N}");
            get.Append($"		}}{N}");
            get.Append($"		finally {{{N}");
            get.Append($"			desconecta();{N}");
            get.Append($"		}}{N}");
            get.Append($"	}}{N}");
            return get;
        }
        private StringBuilder Delete()
        {
            var nameProc = $"{ParamtersInput.Prefixos.Procedure}U_{NomeTabela.TratarNomeTabela().ToUpper()}";

            var get = new StringBuilder();
            get.Append($"	public void Delete(int ID) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Paramter(\"P_RESULT\", java.sql.Types.VARCHAR, null,\"OUT\"));{N}{N}");
            get.Append($"			RequestProc();{N}");
            get.Append($"		}}{N}");
            get.Append($"		catch (Exception ex){{{N}");
            get.Append($"			throw ex;{N}");
            get.Append($"		}}{N}");
            get.Append($"		finally {{{N}");
            get.Append($"			desconecta();{N}");
            get.Append($"		}}{N}");
            get.Append($"	}}{N}");
            get.Append($"}}{N}");
            return get;
        }

        public StringBuilder GerarClasse()
        {
            var classe = new StringBuilder();
            classe.Append($"package br.meuprojeto.dao;{N}");
            classe.Append(Imports());
            classe.Append($"public class {NomeTabela}Dao extends ComumDao {{ {N}{N}");
            classe.Append(ProceduresNames());
            classe.Append(GetById());
            classe.Append(GetAll());
            classe.Append(Add());
            classe.Append(Update());
            classe.Append(Delete());
            return classe;
        }
    }
}
