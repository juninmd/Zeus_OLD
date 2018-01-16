using System;
using System.Linq;
using Zeus.Core;
using Zeus.Core.SGBD.MySql;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Node.MySql.Query
{
    public class NodeMySqlQuery : BaseMySqlDAO
    {
        public NodeMySqlQuery(string nomeTabela) : base(nomeTabela)
        {
        }

        public string GerarClasse()
        {
            var template = Tratamentos.PathTemplate();
            var connection = new MySqlConnectionStringModel(ParamtersInput.ConnectionString);

            var p = String.Format(template, 
                connection.host, connection.user,
                connection.database, connection.password,
                connection.port, 
                NomeTabela.ToLower(), 
                parametrosQuery(false), 
                parametrosQuery(false),
                ListaAtributosTabela.First().COLUMN_NAME);

            return p;
        }
    }
}