using System.Linq;
using System.Text;
using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Linguagens.Base;
using MapeadorDeEntidades.Form.Properties;

namespace MapeadorDeEntidades.Form.Linguagens.Node.Oracle.Procedure
{
    public class NodeOracleProcedure : BaseOracleDAO
    {

        public NodeOracleProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        private StringBuilder Imports()
        {
            var imports = new StringBuilder();
            imports.Append($"var oracleDb = require('../oracle/initOracle.js');{N}{N}");
            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"    getById: function (id, callback) {{{N}");//aqui
            get.Append($"        baseOracle.beginProcedureById({ParamtersInput.ConnectionString.TratarNomeBase()}, \"{NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_S_" + NomeTabela.TratarNomeTabela() + "_ID"}\",{N}");
            get.Append($"            {{{N}");
            get.Append($"                P_CURSORSELECT: {{ type: oracleDb.type(\"CURSOR\"), dir: oracleDb.type(\"BIND_OUT\") }},{N}");
            get.Append($"                P_{ListaAtributosTabela.First().COLUMN_NAME}: id,   {N}");
            get.Append($"            }}, function (err, result) {{  {N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"    getAll: function (callback) {{{N}");
            get.Append($"        baseOracle.beginProcedure({ParamtersInput.ConnectionString.TratarNomeBase()}, \"{NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_S_" + NomeTabela.TratarNomeTabela()}\",{N}");
            get.Append($"            {{{N}");
            get.Append($"                P_CURSORSELECT: {{ type: oracleDb.type(\"CURSOR\"), dir: oracleDb.type(\"BIND_OUT\") }}{N}");
            get.Append($"            }},\"P_CURSORSELECT\",  function (err, result) {{  {N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"    insert: function (body, usuario, callback) {{ {N}");
            get.Append($"        baseOracle.executeProcedure({ParamtersInput.ConnectionString.TratarNomeBase()}, \"{NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_I_" + NomeTabela.TratarNomeTabela()}\",{N}");
            get.Append($"            {{{N}");
            get.Append($"                P_RESULT: {{ dir: oracleDb.type(\"BIND_OUT\"), type: oracleDb.type(\"STRING\") }}, {N}");
            for (int i = 1; i < ListaAtributosTabela.Count; i++)
            {
                get.Append($"                P_{ListaAtributosTabela[i].COLUMN_NAME}: body.{ListaAtributosTabela[i].COLUMN_NAME},{N}");
            }
            get.Append($"            }}, \"P_RESULT\",{N}");
            get.Append($"            function (err, result) {{ {N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Update()
        {

            var get = new StringBuilder();
            get.Append($"    update: function (body, usuario, callback) {{ {N}");
            get.Append($"        baseOracle.executeProcedure({ParamtersInput.ConnectionString.TratarNomeBase()}, \"{NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_U_" + NomeTabela.TratarNomeTabela()}\",{N}");
            get.Append($"            {{{N}");
            get.Append($"                P_RESULT: {{ dir: oracleDb.type(\"BIND_OUT\"), type: oracleDb.type(\"STRING\") }}, {N}");
            for (int i = 0; i < ListaAtributosTabela.Count; i++)
            {
                get.Append($"                P_{ListaAtributosTabela[i].COLUMN_NAME}: body.{ListaAtributosTabela[i].COLUMN_NAME},{N}");
            }
            get.Append($"            }}, \"P_RESULT\",{N}");
            get.Append($"            function (err, result) {{ {N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }
        private StringBuilder Delete()
        {
            var get = new StringBuilder();
            get.Append($"    delete: function (body, usuario, callback) {{ {N}");
            get.Append($"        baseOracle.executeProcedure({ParamtersInput.ConnectionString.TratarNomeBase()}, \"{NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_D_" + NomeTabela.TratarNomeTabela()}\",{N}");
            get.Append($"            {{{N}");
            get.Append($"                P_RESULT: {{ dir: oracleDb.type(\"BIND_OUT\"), type: oracleDb.type(\"STRING\") }}, {N}");
            get.Append($"                P_{ListaAtributosTabela.First().COLUMN_NAME}: body.{ListaAtributosTabela.First().COLUMN_NAME},{N}");
            get.Append($"            }}, \"P_RESULT\",{N}");
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
