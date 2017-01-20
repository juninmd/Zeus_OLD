using System;
using System.Linq;
using System.Text;
using Zeus.Core;
using Zeus.Linguagens.Base;
using Zeus.Properties;

namespace Zeus.Linguagens.Node.MySql.Procedure
{
    public class NodeMySqlProcedure : BaseMySqlDAO
    {
        public NodeMySqlProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"var mysql = require('./mysql/initMysql.js');{N}{N}");
            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"    getById: function (id, callback) {{{N}");
            get.Append($"        mysql.executeString({ParamtersInput.ConnectionString.TratarNomeBase()}, \"call {NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "S_" + NomeTabela.TratarNomeTabela() + "_ID(id)"}\",{N}");
            get.Append($"            {{{N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"    getAll: function (callback) {{{N}");
            get.Append($"        mysql.executeString({ParamtersInput.ConnectionString.TratarNomeBase()}, \"call {NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "S_" + NomeTabela.TratarNomeTabela() + "(), function (err, result) {"}{N}");
            get.Append($"            {{{N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"    insert: function (body, callback) {{ {N}");
            get.Append($"        mysql.executeString({ParamtersInput.ConnectionString.TratarNomeBase()}, \"call {NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "I_" + NomeTabela.TratarNomeTabela()}(" + String.Concat(ListaAtributosTabela.Select(e => "body." + e.COLLATION_NAME), ",") + ")\",{N}");
            get.Append($"            {{{N}");
            get.Append($"            function (err, result) {{ {N}");

            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Update()
        {

            var get = new StringBuilder();
            get.Append($"    update: function (body, callback) {{ {N}");
            get.Append($"        mysql.executeString({ParamtersInput.ConnectionString.TratarNomeBase()}, \"call {NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "U_" + NomeTabela.TratarNomeTabela()}\",{N}");
            get.Append($"            {{{N}");
            get.Append($"            function (err, result) {{ {N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }
        private StringBuilder Delete()
        {
            var get = new StringBuilder();
            get.Append($"    delete: function (id, callback) {{ {N}");
            get.Append($"        mysql.executeString({ParamtersInput.ConnectionString.TratarNomeBase()}, \"call {NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "D_" + NomeTabela.TratarNomeTabela()}\",{N}");
            get.Append($"            {{{N}");
            get.Append($"            function (err, result) {{ {N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
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
    }
}
