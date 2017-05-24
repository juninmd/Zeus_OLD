using System.Collections.Generic;

namespace Zeus.Core.SGBD.Postgre
{
    public class PostgreTables : PostgreRepository
    {
        public List<string> ListaTabelas(string schema)
        {
            var lista = new List<string>();
            var query = $"select table_name from information_schema.tables where table_schema = '{schema}' order by table_name";

            using (var r = ExecuteReader(query))
                while (r.Read())
                {
                    lista.Add(r.GetValueOrDefault<string>("table_name").Trim());
                };
            CloseConnection();
            return lista;
        }

        public List<string> ListaSchema()
        {
            var lista = new List<string>();
            var query = $"select schema_name from information_schema.schemata order by schema_name";

            using (var r = ExecuteReader(query))
                while (r.Read())
                {
                    lista.Add(r.GetValueOrDefault<string>("schema_name").Trim());
                };
            CloseConnection();
            return lista;
        }

        public List<PostgreEntidadeTabela> ListarAtributos(string nomeTabela)
        {
            var lista = new List<PostgreEntidadeTabela>();
            var sql = $"select column_name, data_type, character_maximum_length from INFORMATION_SCHEMA.COLUMNS where table_name = '{nomeTabela}'";

            using (var r = ExecuteReader(sql))
                while (r.Read())
                {
                    lista.Add(new PostgreEntidadeTabela
                    {
                        column_name = r.GetValueOrDefault<string>("column_name").Trim(),
                        data_type = r.GetValueOrDefault<string>("data_type"),
                        character_maximum_length = r.GetValueOrDefault<int>("character_maximum_length"),
                    });
                };
            CloseConnection();

            return lista;
        }
    }
}
