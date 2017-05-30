using System;
using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Linguagens.Base;
using Zeus.Linguagens.Java.MySql;

namespace Zeus.Linguagens.Java.SQL.Query
{
    public class JavaOracleQuery : BaseMySqlDAO
    {

        public JavaOracleQuery(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"import java.sql.ResultSet;{N}");
            imports.Append($"import java.util.List;{N}");
            imports.Append($"import java.sql.PreparedStatement;{N}");
            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"	public {NomeTabela} GetById(int ID) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			PreparedStatement conn = BeginNewStatement(\"SELECT * FROM {NomeTabela} WHERE {ListaAtributosTabela.First().COLUMN_NAME} =\"+ ID);{N}");
            get.Append($"			ResultSet rs = conn.executeQuery();{N}");
            get.Append($"			if(rs.next()){{{N}");
            get.Append($"				{NomeTabela} resposta = new {NomeTabela}();{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"				resposta.set{att.COLUMN_NAME.ToFirstCharToUpper()}(rs.get{JavaTypesMySql.GetTypeAtribute((att)).ToFirstCharToUpper()}(\"{att.COLUMN_NAME}\"));{N}");
            }
            get.Append($"				return resposta;{N}");
            get.Append($"			}}{N}");
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
            get.Append($"	public List<{NomeTabela}> GetAll() throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			List<{NomeTabela}> lista = new java.util.ArrayList<{NomeTabela}>();{N}{N}");
            get.Append($"			PreparedStatement conn = BeginNewStatement(\"SELECT * FROM {NomeTabela}\");{N}");
            get.Append($"			ResultSet rs = conn.executeQuery();{N}");
            get.Append($"			while(rs.next()){{{N}");
            get.Append($"				{NomeTabela} resposta = new {NomeTabela}();{N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"				resposta.set{att.COLUMN_NAME.ToFirstCharToUpper()}(rs.get{JavaTypesMySql.GetTypeAtribute((att)).ToFirstCharToUpper()}(\"{att.COLUMN_NAME}\"));{N}");
            }
            get.Append($"				lista.add(resposta);{N}");
            get.Append($"			}}{N}");
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
            get.Append($"	public void Add({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			PreparedStatement conn = BeginNewStatement(\"INSERT INTO {NomeTabela} ({String.Join(", ", ListaAtributosTabela.Where(e => e.COLUMN_NAME != ListaAtributosTabela.First().COLUMN_NAME).Select(e => e.COLUMN_NAME))}) values ({String.Join(", ", ListaAtributosTabela.Where(e => e.COLUMN_NAME != ListaAtributosTabela.First().COLUMN_NAME).Select(q => "?"))})\");{N}");

            for (int index = 1; index < ListaAtributosTabela.Count; index++)
            {
                var att = ListaAtributosTabela[index];
                get.Append($"			conn.set{JavaTypesMySql.GetTypeAtribute(att).ToFirstCharToUpper()}({index}, entidade.get{att.COLUMN_NAME.ToFirstCharToUpper()}());{N}");
            }
            get.Append($"			conn.execute();{N}");
            get.Append($"			commit();{N}");
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
            get.Append($"	public void Update({NomeTabela} entidade) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			PreparedStatement conn = BeginNewStatement(\"UPDATE {NomeTabela} SET {String.Join(", ", ListaAtributosTabela.Where(e => e.COLUMN_NAME != ListaAtributosTabela.First().COLUMN_NAME).Select(e => e.COLUMN_NAME + " = ?"))} WHERE {ListaAtributosTabela.First().COLUMN_NAME} = \" +  entidade.get{ListaAtributosTabela.First().COLUMN_NAME.ToFirstCharToUpper()}());{N}");
            for (int index = 1; index < ListaAtributosTabela.Count; index++)
            {
                var att = ListaAtributosTabela[index];
                get.Append($"			conn.set{JavaTypesMySql.GetTypeAtribute(att).ToFirstCharToUpper()}({index}, entidade.get{att.COLUMN_NAME.ToFirstCharToUpper()}());{N}");
            }
            get.Append($"			conn.execute();{N}");
            get.Append($"			commit();{N}");
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
            get.Append($"	public void Delete(int ID) throws Exception{N}");
            get.Append($"	{{{N}");
            get.Append($"		try{{{N}");
            get.Append($"			PreparedStatement conn = BeginNewStatement(\"DELETE FROM {NomeTabela} WHERE {ListaAtributosTabela.First().COLUMN_NAME} = ?\");{N}");
            get.Append($"			conn.setInt({1}, ID);{N}");
            get.Append($"			conn.execute();{N}");
            get.Append($"			commit();{N}");
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
            classe.Append($"package br.fatecfranca.dao;{N}");
            classe.Append(Imports());
            classe.Append($"public class {NomeTabela}Dao extends ComumDao {{ {N}{N}");
            classe.Append(GetById());
            classe.Append(GetAll());
            classe.Append(Add());
            classe.Append(Update());
            classe.Append(Delete());
            return classe;
        }
    }
}
