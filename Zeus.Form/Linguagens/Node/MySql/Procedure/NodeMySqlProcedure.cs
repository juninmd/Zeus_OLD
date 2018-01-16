using System;
using Zeus.Core;
using Zeus.Core.SGBD.MySql;
using Zeus.Linguagens.Base;

namespace Zeus.Linguagens.Node.MySql.Procedure
{
    public class NodeMySqlProcedure : BaseMySqlDAO
    {
        public NodeMySqlProcedure(string nomeTabela) : base(nomeTabela)
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
                parametrosQuery(false), parametrosQuery(true),
                NomeTabela.TratarNomeProcedure(OperationProcedure.Search),
                NomeTabela.TratarNomeProcedure(OperationProcedure.List),
                NomeTabela.TratarNomeProcedure(OperationProcedure.Insert),
                NomeTabela.TratarNomeProcedure(OperationProcedure.Update), 
                NomeTabela.TratarNomeProcedure(OperationProcedure.Delete));

            return p;
        }
    }
}