using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Node.Firebird.Procedure
{
    public class NodeFirebirdProcedure : BaseMySqlDAO
    {
        private readonly string baseDb = ParamtersInput.ConnectionString.TratarNomeBase();

        public NodeFirebirdProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"var mysql = require('./config/initMysql.js');{N}");

            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"    getById: (id) => {{{N}");
            get.Append($"        return new Promise((resolve, reject) => {{{N}");
            get.Append(
                $"            mysql.executeString({baseDb}, \"SELECT * FROM {NomeTabela.ToLower()} WHERE {ListaAtributosTabela.First().COLUMN_NAME} =  \"+id,{N}");
            get.Append($"                (err, result) => err ? reject(err) : resolve(result));{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"    getAll: () => {{{N}");
            get.Append($"        return new Promise((resolve, reject) => {{{N}");
            get.Append($"            mysql.executeString({baseDb}, \"SELECT * FROM {NomeTabela.ToLower()} \",{N}");
            get.Append($"                (err, result) => err ? reject(err) : resolve(result));{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"    insert: (body) => {{ {N}");
            get.Append($"        return new Promise((resolve, reject) => {{{N}");
            get.Append(
                $"            mysql.execute({baseDb}, \"INSERT INTO {NomeTabela.ToLower()} SET ?\", {parametrosQuery(false)},{N}");
            get.Append($"                (err, result) => err ? reject(err) : resolve(result));{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Update()
        {
            var get = new StringBuilder();
            get.Append($"    update: (body) => {{ {N}");
            get.Append($"        return new Promise((resolve, reject) => {{{N}");
            get.Append(
                $"            mysql.execute({baseDb}, \"UPDATE {NomeTabela.ToLower()} SET ? WHERE {ListaAtributosTabela.First().COLUMN_NAME} =\" + body.{ListaAtributosTabela.First().COLUMN_NAME}, {parametrosQuery(true)},{N}");
            get.Append($"                (err, result) => err ? reject(err) : resolve(result));{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Delete()
        {
            var get = new StringBuilder();
            get.Append($"    delete: (id) => {{ {N}");
            get.Append($"        return new Promise((resolve, reject) => {{{N}");
            get.Append(
                $"            mysql.executeString({baseDb}, \"DELETE FROM {NomeTabela.ToLower()} WHERE {ListaAtributosTabela.First().COLUMN_NAME} =\" + id,{N}");
            get.Append($"                (err, result) => err ? reject(err) : resolve(result));{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
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