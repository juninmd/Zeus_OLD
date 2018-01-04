using System.Collections.Generic;

namespace Zeus.Core.SGBD.Postgre
{
    public class PostgreTables : PostgreRepository
    {
        public List<string> ListaTabelas(string schema)
        {
            var lista = new List<string>();
            var query =
                $"select table_name from information_schema.tables where table_schema = '{schema}' order by table_name";

            using (var r = ExecuteReader(query))
            {
                while (r.Read())
                    lista.Add(r.GetValueOrDefault<string>("table_name").Trim());
            }

            ;
            CloseConnection();
            return lista;
        }

        public List<string> ListaSchema()
        {
            var lista = new List<string>();
            var query = $"select schema_name from information_schema.schemata order by schema_name";

            using (var r = ExecuteReader(query))
            {
                while (r.Read())
                    lista.Add(r.GetValueOrDefault<string>("schema_name").Trim());
            }

            ;
            CloseConnection();
            return lista;
        }

        public List<PostgreEntidadeTabela> ListarAtributos(string nomeTabela)
        {
            var lista = new List<PostgreEntidadeTabela>();
            var sql =
                $"select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUN_LENGTH from INFORMATION_SCHEMA.COLUMNS where table_name = '{nomeTabela}'";

            using (var r = ExecuteReader(sql))
            {
                while (r.Read())
                    lista.Add(new PostgreEntidadeTabela
                    {
                        COLUMN_NAME = r.GetValueOrDefault<string>("COLUMN_NAME").Trim(),
                        DATA_TYPE = r.GetValueOrDefault<string>("DATA_TYPE"),
                        CHARACTER_MAXIMUN_LENGTH = r.GetValueOrDefault<int?>("CHARACTER_MAXIMUN_LENGTH")
                    });
            }

            ;
            CloseConnection();

            return lista;
        }
    }
}