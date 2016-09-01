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
            imports.Append($"var connection = require(\"../config/services/relational.js\"),{N}");
            imports.Append($"    oracleDB = require(\"oracledb\"),{N}");
            imports.Append($"    moment = require(\"moment\"),{N}");
            imports.Append($"    error = require('../config/services/log/errors.js'),{N}");
            imports.Append($"    baseOracle = require('../config/services/baseOracle.js');{N}{N}");
            return imports;
        }

        private StringBuilder GetById()
        {
            var get = new StringBuilder();
            get.Append($"    getByCodigo: function (id, callback) {{{N}");
            get.Append($"        baseOracle.beginProcedureById(connection, \"{NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_S_" + NomeTabela.TratarNomeTabela() + "_ID"}(:P_CURSORSELECT,:P_{ListaAtributosTabela.First().COLUMN_NAME})\",{N}");
            get.Append($"            {{{N}");
            get.Append($"                P_CURSORSELECT: {{ type: oracleDB.CURSOR, dir: oracleDB.BIND_OUT }},{N}");
            get.Append($"                P_{ListaAtributosTabela.First().COLUMN_NAME}: id,   {N}");
            get.Append($"            }}, function (err, result) {{  {N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"                return;{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder GetAll()
        {
            var get = new StringBuilder();
            get.Append($"    getAll: function (callback) {{{N}");
            get.Append($"        baseOracle.beginProcedure(connection, \"{NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_S_" + NomeTabela.TratarNomeTabela()}(:P_CURSORSELECT)\",{N}");
            get.Append($"            {{{N}");
            get.Append($"                P_CURSORSELECT: {{ type: oracleDB.CURSOR, dir: oracleDB.BIND_OUT }}{N}");
            get.Append($"            }}, function (err, result) {{  {N}");
            get.Append($"                callback(err, result);{N}");
            get.Append($"                return;{N}");
            get.Append($"            }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Add()
        {
            var get = new StringBuilder();
            get.Append($"    insert: function (body, usuario, callback) {{ {N}");
            get.Append($"        connection.getConnection(function (conn) {{ {N}");
            get.Append($"            conn.execute(\"BEGIN {NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_I_" + NomeTabela.TratarNomeTabela()}(\" +{N}");
            get.Append($"                \":P_RESULT\"+{N}");
            for (int i = 1; i < ListaAtributosTabela.Count - 1; i++)
            {
                get.Append($"                \":P_{ListaAtributosTabela[i].COLUMN_NAME}\" +{N}");
            }
            get.Append($"                \":P_{ListaAtributosTabela[ListaAtributosTabela.Count - 1].COLUMN_NAME});\" +{N}");
            get.Append($"                \"END;\",{N}");
            get.Append($"                {{{N}");
            get.Append($"                    P_RESULT: {{ dir: oracleDB.BIND_OUT, type: oracleDB.STRING }}, {N}");
            for (int i = 1; i < ListaAtributosTabela.Count; i++)
            {
                get.Append($"                    P_{ListaAtributosTabela[i].COLUMN_NAME}: body.{ListaAtributosTabela[i].COLUMN_NAME},{N}");
            }
            get.Append($"                }},{N}");
            get.Append($"                function (err, result) {{ {N}");
            get.Append($"                    if (err) {{ {N}");
            get.Append($"                        conn.releaseConnection(conn, false, function (connError) {{ {N}");
            get.Append($"                            callback(error.PROC_EXECUTION_FAIL, err, connError); {N}");
            get.Append($"                        }});{N}");
            get.Append($"                    }}{N}");
            get.Append($"                    else {{{N}");
            get.Append($"                        connection.releaseConnection(function () {{ {N}");
            get.Append($"                            callback(null, \"\");{N}");
            get.Append($"                        }}); {N}");
            get.Append($"                    }}{N}");
            get.Append($"                }});{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }

        private StringBuilder Update()
        {

            var get = new StringBuilder();
            get.Append($"    update: function (body, usuario, callback) {{ {N}");
            get.Append($"        connection.getConnection(function (conn) {{ {N}");
            get.Append($"            conn.execute(\"BEGIN {NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_U_" + NomeTabela.TratarNomeTabela()}(\" +{N}");
            get.Append($"                \":P_RESULT\"+{N}");
            for (int i = 0; i < ListaAtributosTabela.Count - 1; i++)
            {
                get.Append($"                \":P_{ListaAtributosTabela[i].COLUMN_NAME}\" +{N}");
            }
            get.Append($"                \":P_{ListaAtributosTabela[ListaAtributosTabela.Count - 1].COLUMN_NAME});\" +{N}");
            get.Append($"                \"END;\",{N}");
            get.Append($"                {{{N}");
            get.Append($"                    P_RESULT: {{ dir: oracleDB.BIND_OUT, type: oracleDB.STRING }}, {N}");
            foreach (var att in ListaAtributosTabela)
            {
                get.Append($"                    P_{att.COLUMN_NAME}: body.{att.COLUMN_NAME},{N}");
            }
            get.Append($"                }},{N}");
            get.Append($"                function (err, result) {{ {N}");
            get.Append($"                    if (err) {{ {N}");
            get.Append($"                        conn.releaseConnection(conn, false, function () {{ {N}");
            get.Append($"                            callback(errorObject(500, \"Ocorreu uma falha ao submeter os dados.\", err.message), null); {N}");
            get.Append($"                        }});{N}");
            get.Append($"                    }}{N}");
            get.Append($"                    else {{{N}");
            get.Append($"                        connection.releaseConnection(function () {{ {N}");
            get.Append($"                            callback(null, \"\");{N}");
            get.Append($"                        }}); {N}");
            get.Append($"                    }}{N}");
            get.Append($"                }});{N}");
            get.Append($"        }});{N}");
            get.Append($"    }},{N}");
            return get;
        }
        private StringBuilder Delete()
        {

            var get = new StringBuilder();
            get.Append($"    delete: function (body, usuario, callback) {{ {N}");
            get.Append($"        connection.getConnection(function (conn) {{ {N}");
            get.Append($"            conn.execute(\"BEGIN {NomeTabela.TratarNomePackage()}.{Settings.Default.PrefixoProcedure + "_D_" + NomeTabela.TratarNomeTabela()}(\" +{N}");
            get.Append($"                \":P_RESULT\",{N}");
            get.Append($"                \":P_{ListaAtributosTabela.First().COLUMN_NAME})\",{N}");
            get.Append($"                \"END;\",{N}");
            get.Append($"                {{{N}");
            get.Append($"                    P_RESULT: {{ dir: oracleDB.BIND_OUT, type: oracleDB.STRING }}, {N}");
            get.Append($"                    P_{ListaAtributosTabela.First().COLUMN_NAME}: body.{ListaAtributosTabela.First().COLUMN_NAME},{N}");
            get.Append($"                }},{N}");
            get.Append($"                function (err, result) {{ {N}");
            get.Append($"                    if (err) {{ {N}");
            get.Append($"                        connection.releaseConnection(conn, false, function (connError) {{ {N}");
            get.Append($"                            callback(error.PROC_EXECUTION_FAIL, err, connError); {N}");
            get.Append($"                        }});{N}");
            get.Append($"                    }}{N}");
            get.Append($"                    else {{{N}");
            get.Append($"                        connection.releaseConnection(function () {{ {N}");
            get.Append($"                            callback(null, \"\");{N}");
            get.Append($"                        }}); {N}");
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
    }
}
