using System.Text;
using Zeus.Core.SGBD.MySql.Procedure.Verbos;
using Zeus.Linguagens.Base;

namespace Zeus.Core.SGBD.MySql.Procedure
{
    public class MySqlProcedure : BaseMySqlDAO
    {
        public MySqlProcedure(string nomeTabela) : base(nomeTabela)
        {
        }

        public string GerarBody()
        {
            var baseProc = NomeTabela.TratarNomeTabela().ToUpper();
            var header = new StringBuilder();
            header.Append(new MySqlGet().Init($"{NomeTabela.TratarNomeProcedure(OperationProcedure.List)}", NomeTabela,
                ListaAtributosTabela));
            header.Append(new MySqlBuscar().Init($"{NomeTabela.TratarNomeProcedure(OperationProcedure.Search)}",
                NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlInsert().Init($"{NomeTabela.TratarNomeProcedure(OperationProcedure.Insert)}",
                NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlUpdate().Init($"{NomeTabela.TratarNomeProcedure(OperationProcedure.Update)}",
                NomeTabela, ListaAtributosTabela));
            header.Append(new MySqlDelete().Init($"{NomeTabela.TratarNomeProcedure(OperationProcedure.Delete)}",
                NomeTabela, ListaAtributosTabela));
            return header.ToString();
        }
    }
}