using System.Collections.Generic;

namespace MapeadorDeEntidades.Form
{
    public class OracleTables : OracleRepository
    {
        public List<string> ListaTabelas()
        {
            BeginNewStatement("SELECT table_name FROM user_tables");
            OpenConnection();

            var lista = new List<string>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                    lista.Add(r.GetValueOrDefault<string>("table_name"));
                };
            return lista;
        }

        public List<EntidadeTabela> ListarAtributos(string nomeTabela)
        {

            BeginNewStatement("SELECT " +
                               "A.COLUMN_NAME, " +
                               "A.DATA_TYPE, " +
                               "A.CHAR_LENGTH, " +
                               "A.NULLABLE, " +
                               "B.COMMENTS "+
                               "FROM USER_TAB_COLS A, " +
                               "USER_COL_COMMENTS B " +
                               $"WHERE A.TABLE_NAME = '{nomeTabela}' "+
                               "AND A.COLUMN_NAME = B.COLUMN_NAME " +
                               "AND B.TABLE_NAME = A.TABLE_NAME ");
          
            OpenConnection();

            var lista = new List<EntidadeTabela>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                   lista.Add(new EntidadeTabela
                   {
                       COLUMN_NAME = r.GetValueOrDefault<string>("COLUMN_NAME"),
                       DATA_TYPE = r.GetValueOrDefault<string>("DATA_TYPE"),
                       CHAR_LENGTH = r.GetValueOrDefault<decimal>("CHAR_LENGTH"),
                       NULLABLE = r.GetValueOrDefault<string>("NULLABLE"),
                       COMMENTS = r.GetValueOrDefault<string>("COMMENTS"),
                   });
                };
            return lista;
        }



    }
}
