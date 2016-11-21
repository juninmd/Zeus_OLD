using System.Text;
using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Linguagens.Base;
using MapeadorDeEntidades.Form.Linguagens.Java.MySql;
using MapeadorDeEntidades.Form.Properties;

namespace MapeadorDeEntidades.Form.Linguagens.Java.MySql.Procedure
{
    public class JavaMySqlProcedure : BaseMySqlDAO
    {
        private string MySqlType(string tipo)
        {
            if (tipo == "VARCHAR2")
            {
                tipo = "VARCHAR";
            }
            return tipo;
        }
        public JavaMySqlProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"import java.sql.ResultSet;{N}");
            imports.Append($"import MySql.jdbc.MySqlTypes;{N}{N}");
            return imports;
        }

        private StringBuilder ProceduresNames()
        {
            var baseProc = NomeTabela.TratarNomeTabela().ToUpper();
            var proc = new StringBuilder();
            proc.Append($"	private enum Proc{N}");
            proc.Append($"	{{{N}");
            proc.Append($"		{Settings.Default.PrefixoProcedure}S_{baseProc}_ID,{N}");
            proc.Append($"		{Settings.Default.PrefixoProcedure}S_{baseProc},{N}");
            proc.Append($"		{Settings.Default.PrefixoProcedure}I_{baseProc},{N}");
            proc.Append($"		{Settings.Default.PrefixoProcedure}U_{baseProc},{N}");
            proc.Append($"		{Settings.Default.PrefixoProcedure}D_{baseProc}{N}");
            proc.Append($"	}}{N}");
            return proc;
        }

        private StringBuilder GetById()
        {
            var nameProc = $"{Settings.Default.PrefixoProcedure}S_{NomeTabela.TratarNomeTabela().ToUpper()}_ID";

            var get = new StringBuilder();
            get.Append($"	public {NomeTabela} GetById(int id) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Parameter(\"ID\", MySqlTypes.NUMBER, ID));{N}{N}");
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
            var nameProc = $"{Settings.Default.PrefixoProcedure}S_{NomeTabela.TratarNomeTabela().ToUpper()}";

            var get = new StringBuilder();
            get.Append($"	public List<{NomeTabela}> GetAll(int id) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			List<{NomeTabela}> lista = new java.util.ArrayList<{NomeTabela}>();{N}{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Parameter(\"ID\", MySqlTypes.NUMBER, ID));{N}{N}");
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
            var nameProc = $"{Settings.Default.PrefixoProcedure}I_{NomeTabela.TratarNomeTabela().ToUpper()}";

            var get = new StringBuilder();
            get.Append($"	public RequestMessageLite<String> Add({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Parameter(\"P_RESULT\", MySqlTypes.VARCHAR, null,\"OUT\"));{N}{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"			AddParamter(new Parameter(\"P_{att.COLUMN_NAME}\", MySqlTypes.{MySqlType(att.DATA_TYPE)}, entidade.get{att.COLUMN_NAME}()));{N}");
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
            var nameProc = $"{Settings.Default.PrefixoProcedure}U_{NomeTabela.TratarNomeTabela().ToUpper()}";

            var get = new StringBuilder();
            get.Append($"	public RequestMessageLite<String> Update({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Parameter(\"P_RESULT\", MySqlTypes.VARCHAR, null,\"OUT\"));{N}{N}");
            get.Append($"			AddParamter(new Parameter(\"P_ID\", MySqlTypes.NUMBER, entidade.ID));{N}{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"			AddParamter(new Parameter(\"P_{att.COLUMN_NAME}\", MySqlTypes.{MySqlType(att.DATA_TYPE)}, entidade.get{att.COLUMN_NAME}()));{N}");
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
            var nameProc = $"{Settings.Default.PrefixoProcedure}U_{NomeTabela.TratarNomeTabela().ToUpper()}";

            var get = new StringBuilder();
            get.Append($"	public RequestMessageLite<String> Delete(int ID) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			BeginNewStatement(Proc.{nameProc}, \"{ParamtersInput.DataBase}\");{N}");
            get.Append($"			AddParamter(new Parameter(\"P_RESULT\", MySqlTypes.VARCHAR, null,\"OUT\"));{N}{N}");
            get.Append($"			AddParamter(new Parameter(\"P_ID\", MySqlTypes.NUMBER, ID));{N}{N}");
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
