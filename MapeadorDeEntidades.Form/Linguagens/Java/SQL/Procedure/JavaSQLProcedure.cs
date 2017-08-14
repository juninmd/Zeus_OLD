using System.Text;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Java.SQL.Procedure
{
    public class JavaSQLProcedure : BaseSQLDAO
    {
        private string SQLType(string tipo)
        {
            if (tipo == "VARCHAR2")
            {
                tipo = "VARCHAR";
            }
            return tipo;
        }
        public JavaSQLProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"import java.sql.ResultSet;{N}");
            imports.Append($"import SQL.jdbc.SQLTypes;{N}{N}");
            return imports;
        }

        private StringBuilder ProceduresNames()
        {
            var proc = new StringBuilder();
            proc.Append($"	private String Package = \"{NomeTabela}\";{N}{N} ");
            proc.Append($"	private enum Proc{N}");
            proc.Append($"	{{{N}");
            proc.Append($"		S_ID,{N}");
            proc.Append($"		S,{N}");
            proc.Append($"		I,{N}");
            proc.Append($"		U,{N}");
            proc.Append($"		D{N}");
            proc.Append($"	}}{N}");
            return proc;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"	public {NomeTabela} GetById(int id) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Package, Proc.S_ID, \"SOURCE\");{N}");
            get.Append($"			AddParamter(new Parameter(\"ID\", SQLTypes.NUMBER, ID));{N}{N}");
            get.Append($"			ResultSet rs = super.ExecuteReader();{N}{N}");
            get.Append($"			if(rs.next()){{{N}");
            get.Append($"				{NomeTabela} resposta = new {NomeTabela}();{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"				resposta.set{att.COLUMN_NAME}(rs.get{JavaTypesSQL.GetTypeAtribute((att))}(\"{att.COLUMN_NAME}\"));{N}");
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
            var get = new StringBuilder();
            get.Append($"	public List<{NomeTabela}> GetAll(int id) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			List<{NomeTabela}> lista = new java.util.ArrayList<{NomeTabela}>();{N}{N}");
            get.Append($"			BeginNewStatement(Package, Proc.S, \"SOURCE\");{N}");
            get.Append($"			AddParamter(new Parameter(\"ID\", SQLTypes.NUMBER, ID));{N}{N}");
            get.Append($"			ResultSet rs = super.ExecuteReader();{N}{N}");
            get.Append($"			while(rs.next()){{{N}");
            get.Append($"				{NomeTabela} resposta = new {NomeTabela}();{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"				resposta.set{att.COLUMN_NAME}(rs.get{JavaTypesSQL.GetTypeAtribute(att)}(\"{att.COLUMN_NAME}\"));{N}");
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
            var get = new StringBuilder();
            get.Append($"	public RequestMessageLite<String> Add({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Package, Proc.I, \"SOURCE\");{N}");
            get.Append($"			AddParamter(new Parameter(\"P_RESULT\", SQLTypes.VARCHAR, null,\"OUT\"));{N}{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"			AddParamter(new Parameter(\"P_{att.COLUMN_NAME}\", SQLTypes.{SQLType(att.DATA_TYPE)}, entidade.get{att.COLUMN_NAME}()));{N}");
            }
            get.Append($"			return RequestProc();{N}");
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

            var get = new StringBuilder();
            get.Append($"	public RequestMessageLite<String> Update({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Package, Proc.U, \"SOURCE\");{N}");
            get.Append($"			AddParamter(new Parameter(\"P_RESULT\", SQLTypes.VARCHAR, null,\"OUT\"));{N}{N}");
            get.Append($"			AddParamter(new Parameter(\"P_ID\", SQLTypes.NUMBER, entidade.ID));{N}{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"			AddParamter(new Parameter(\"P_{att.COLUMN_NAME}\", SQLTypes.{SQLType(att.DATA_TYPE)}, entidade.get{att.COLUMN_NAME}()));{N}");
            }
            get.Append($"			return RequestProc();{N}");
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

            var get = new StringBuilder();
            get.Append($"	public RequestMessageLite<String> Delete(int ID) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Package, Proc.D, \"SOURCE\");{N}");
            get.Append($"			AddParamter(new Parameter(\"P_RESULT\", SQLTypes.VARCHAR, null,\"OUT\"));{N}{N}");
            get.Append($"			AddParamter(new Parameter(\"P_ID\", SQLTypes.NUMBER, ID));{N}{N}");
            get.Append($"			return RequestProc();{N}");
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
            classe.Append($"package dao;{N}");
            classe.Append(Imports());
            classe.Append($"public class {NomeTabela} extends ComumDao {{ {N}{N}");
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
