using System.Linq;
using System.Text;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Node.Firebird.Query
{
    public class NodeFirebirdQuery : BaseFirebirdDAO
    {
        public NodeFirebirdQuery(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"const Firebird = require('jano-firebird')({{{N}" +
                           $"        host: '123',{N}" +
                           $"        user: '123',{N}" +
                           $"        database: '123',{N}" +
                           $"        password: '123',{N}" +
                           $"        port: 123{N}" +
                           $"}});{N}{N}");

            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"        getById: (id) => {{{N}");
            get.Append(
                $"                return Firebird.executeString(`SELECT * FROM {NomeTabela.ToLower()} WHERE {ListaAtributosTabela.First().FIELD_NAME} = ${{id}}`);{N}");
            get.Append($"        }},{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"        getAll: () => {{{N}");
            get.Append($"                return Firebird.executeString(`SELECT * FROM {NomeTabela.ToLower()}`);{N}");
            get.Append($"        }},{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"        insert: (body) => {{ {N}");
            get.Append(
                $"                return Firebird.executeObject(`INSERT INTO {NomeTabela.ToLower()} SET ?`, {parametrosQuery(false)});{N}");
            get.Append($"        }},{N}");
            return get;
        }

        private StringBuilder Update()
        {
            var get = new StringBuilder();
            get.Append($"        update: (body) => {{ {N}");
            get.Append(
                $"                return Firebird.executeObject(`UPDATE {NomeTabela.ToLower()} SET ? WHERE {ListaAtributosTabela.First().FIELD_NAME} = ${{body.{ListaAtributosTabela.First().FIELD_NAME}}}`, {parametrosQuery(true)});{N}");
            get.Append($"        }},{N}");
            return get;
        }

        private StringBuilder Delete()
        {
            var get = new StringBuilder();
            get.Append($"        delete: (id) => {{ {N}");
            get.Append(
                $"                return Firebird.executeString(`DELETE FROM {NomeTabela.ToLower()} WHERE {ListaAtributosTabela.First().FIELD_NAME} = ${{id}}`);{N}");
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
                var semit = ListaAtributosTabela.Where(x => x.FIELD_NAME != ListaAtributosTabela.First().FIELD_NAME);
                return "{ " + string.Join(", ", semit.Select(e => e.FIELD_NAME + ": " + "body." + e.FIELD_NAME)) + " }";
            }

            return "{ " + string.Join(", ",
                       ListaAtributosTabela.Select(e => e.FIELD_NAME + ": " + "body." + e.FIELD_NAME)) + " }";
        }
    }
}