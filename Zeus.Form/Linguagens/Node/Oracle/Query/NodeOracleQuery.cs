using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Core.SGBD.Oracle;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Node.Oracle.Query
{
    public class NodeOracleQuery : BaseOracleDAO
    {
        public NodeOracleQuery(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var connection = new OracleConnectionStringModel(ParamtersInput.ConnectionString);
            var imports = new StringBuilder();
            imports.Append($"const oracle = require('jano-oracle')({{{N}" +
                           $"        host: '{connection.host}',{N}" +
                           $"        user: '{connection.user}',{N}" +
                           (connection.database != null ? $"        database: '{connection.database}',{N}" : null) +
                           $"        password: '{connection.password}'{N}" +
                           $"}});{N}{N}");

            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"        getById: (id) => {{{N}");
            get.Append(
                $"                return oracle.executeString(`SELECT * FROM {NomeTabela} WHERE {ListaAtributosTabela.First().COLUMN_NAME} = ${{id}}`);{N}");
            get.Append($"        }},{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"        getAll: () => {{{N}");
            get.Append($"                return oracle.executeString(`SELECT * FROM {NomeTabela}`);{N}");
            get.Append($"        }},{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"        insert: (body) => {{ {N}");
            get.Append(
                $"                return oracle.executeObject(`INSERT INTO {NomeTabela} SET ?`, {parametrosQuery(false)});{N}");
            get.Append($"        }},{N}");
            return get;
        }

        private StringBuilder Update()
        {
            var get = new StringBuilder();
            get.Append($"        update: (body) => {{ {N}");
            get.Append(
                $"                return oracle.executeObject(`UPDATE {NomeTabela} SET ? WHERE {ListaAtributosTabela.First().COLUMN_NAME} = ${{body.{ListaAtributosTabela.First().COLUMN_NAME}}}`, {parametrosQuery(true)});{N}");
            get.Append($"        }},{N}");
            return get;
        }

        private StringBuilder Delete()
        {
            var get = new StringBuilder();
            get.Append($"        delete: (id) => {{ {N}");
            get.Append(
                $"                return oracle.executeString(`DELETE FROM {NomeTabela} WHERE {ListaAtributosTabela.First().COLUMN_NAME} = ${{id}}`);{N}");
            get.Append($"        }},{N}");
            return get;
        }

        public StringBuilder GerarClasse()
        {
            var classe = new StringBuilder();
            classe.Append(Imports());
            classe.Append($"module.exports = {{{N}");
            classe.Append(GetById());
            classe.Append(GetAll());
            classe.Append(Add());
            classe.Append(Update());
            classe.Append(Delete());
            classe.Append($"}};{N}");
            return classe;
        }

        private string parametrosQuery(bool full)
        {
            if (full == false)
            {
                var semit = ListaAtributosTabela.Where(x => x.COLUMN_NAME != ListaAtributosTabela.First().COLUMN_NAME);
                return "{ " + string.Join(", ", semit.Select(e => e.COLUMN_NAME + ": " + "body." + e.COLUMN_NAME)) +
                       " }";
            }

            return "{ " + string.Join(", ",
                       ListaAtributosTabela.Select(e => e.COLUMN_NAME + ": " + "body." + e.COLUMN_NAME)) + " }";
        }
    }
}