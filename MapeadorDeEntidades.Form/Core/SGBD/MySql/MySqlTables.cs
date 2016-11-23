using System.Collections.Generic;

namespace MapeadorDeEntidades.Form.Core.SGBD.MySql
{
    public class MySqlTables : MySqlRepository
    {
        public List<string> ListaTabelas(string database)
        {
            BeginNewStatement($"select * from information_schema.tables where table_schema = \"{database}\" order by table_name");
            OpenConnection();

            var lista = new List<string>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                    lista.Add(r.GetValueOrDefault<string>("TABLE_NAME"));
                };
            return lista;
        }
        public List<string> ListaDataBases()
        {
            BeginNewStatement("show databases");
            OpenConnection();

            var lista = new List<string>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                    lista.Add(r.GetValueOrDefault<string>("Database"));
                };
            return lista;
        }

        public List<MySqlEntidadeTabela> ListarAtributos(string nomeTabela)
        {
            BeginNewStatement($"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{ParamtersInput.DataBase}' AND TABLE_NAME = '{nomeTabela}';");

            OpenConnection();

            var lista = new List<MySqlEntidadeTabela>();

            using (var r = ExecuteReader())
                while (r.Read())
                {
                    lista.Add(new MySqlEntidadeTabela
                    {
                        TABLE_CATALOG = r.GetValueOrDefault<string>("TABLE_CATALOG"),
                        TABLE_SCHEMA = r.GetValueOrDefault<string>("TABLE_SCHEMA"),
                        TABLE_NAME = r.GetValueOrDefault<string>("TABLE_NAME"),
                        COLUMN_NAME = r.GetValueOrDefault<string>("COLUMN_NAME"),
                        ORDINAL_POSITION = r.GetInt32(r.GetOrdinal("ORDINAL_POSITION")),
                        COLUMN_DEFAULT = r.GetValueOrDefault<int?>("COLUMN_DEFAULT"),
                        IS_NULLABLE = r.GetValueOrDefault<string>("IS_NULLABLE"),
                        DATA_TYPE = r.GetValueOrDefault<string>("DATA_TYPE"),
                      //  CHARACTER_MAXIMUM_LENGTH = r.GetInt32(r.GetOrdinal("CHARACTER_MAXIMUM_LENGTH")),
                       // CHARACTER_OCTET_LENGTH = r.GetValueOrDefault<int?>("CHARACTER_OCTET_LENGTH"),
                 //       NUMERIC_PRECISION = r.GetInt32(r.GetOrdinal("NUMERIC_PRECISION")),
                        COLUMN_COMMENT = r.GetValueOrDefault<string>("COLUMN_COMMENT"),
                    });
                };

            return lista;
        }
    }
}
