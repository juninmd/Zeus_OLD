using System;
using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Node.MySql.Procedure
{
    public class NodeMySqlProcedure : BaseMySqlDAO
    {
        private string baseDb = ParamtersInput.ConnectionString.TratarNomeBase();

        public NodeMySqlProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"var mysql = require('./config/initMysql.js');{N}");
            imports.Append($"var Promise = require('bluebird');{N}{N}");
            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"    getById: function (id) {{{N}");
            get.Append($"        return new Promise(function (resolve, reject) {{{N}");
            get.Append($"            mysql.executeString({baseDb}, \"select * from {NomeTabela} where {ListaAtributosTabela.First().COLUMN_NAME} =  \"+id,{N}");
            get.Append($"                function (err, result) {{{N}");
            get.Append($"                    if (err) {{{N}");
            get.Append($"                        reject(err);{N}");
            get.Append($"                    }} else {{{N}");
            get.Append($"                        resolve(result);{N}");
            get.Append($"                    }}{N}");
            get.Append($"                }});{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"    getAll: function () {{{N}");
            get.Append($"        return new Promise(function (resolve, reject) {{{N}");
            get.Append($"            mysql.executeString({baseDb}, \"select * from {NomeTabela} \",{N}");
            get.Append($"                function (err, result) {{{N}");
            get.Append($"                    if (err) {{{N}");
            get.Append($"                        reject(err);{N}");
            get.Append($"                    }} else {{{N}");
            get.Append($"                        resolve(result);{N}");
            get.Append($"                    }}{N}");
            get.Append($"                }});{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"    insert: function (body) {{ {N}");
            get.Append($"        return new Promise(function (resolve, reject) {{{N}");
            get.Append($"            mysql.execute({baseDb}, \"INSERT INTO {NomeTabela.ToUpper()} SET ?\", {parametrosQuery(false)},{N}");
            get.Append($"                function (err, result) {{{N}");
            get.Append($"                    if (err) {{{N}");
            get.Append($"                        reject(err);{N}");
            get.Append($"                    }} else {{{N}");
            get.Append($"                        resolve(result);{N}");
            get.Append($"                    }}{N}");
            get.Append($"                }});{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Update()
        {

            var get = new StringBuilder();
            get.Append($"    update: function (body) {{ {N}");
            get.Append($"        return new Promise(function (resolve, reject) {{{N}");
            get.Append($"            mysql.execute({baseDb}, \"UPDATE INTO {NomeTabela.ToUpper()} SET ?\", {parametrosQuery(true)},{N}");
            get.Append($"                function (err, result) {{{N}");
            get.Append($"                    if (err) {{{N}");
            get.Append($"                        reject(err);{N}");
            get.Append($"                    }} else {{{N}");
            get.Append($"                        resolve(result);{N}");
            get.Append($"                    }}{N}");
            get.Append($"                }});{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }
        private StringBuilder Delete()
        {
            var get = new StringBuilder();
            get.Append($"    delete: function (id) {{ {N}");
            get.Append($"        return new Promise(function (resolve, reject) {{{N}");
            get.Append($"            mysql.executeString({baseDb}, \"DELETE {NomeTabela.ToUpper()} WHERE {ListaAtributosTabela.First().COLUMN_NAME} =\" + id,{N}");
            get.Append($"                function (err, result) {{{N}");
            get.Append($"                    if (err) {{{N}");
            get.Append($"                        reject(err);{N}");
            get.Append($"                    }} else {{{N}");
            get.Append($"                        resolve(result);{N}");
            get.Append($"                    }}{N}");
            get.Append($"                }});{N}");
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
                return "{ " + String.Join(", ", semit.Select(e => e.COLUMN_NAME + ": " + "body." + e.COLUMN_NAME)) + " }";

            }
            return "{ " + String.Join(", ", ListaAtributosTabela.Select(e => e.COLUMN_NAME + ": " + "body." + e.COLUMN_NAME)) + " }";
        }
    }
}
