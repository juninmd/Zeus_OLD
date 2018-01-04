using System.Collections.Generic;
using System.Linq;

namespace Zeus.Core.SGBD.Oracle
{
    public class OracleConnectionStringModel
    {
        public OracleConnectionStringModel(string connection)
        {
            var listKey = connection.Split(';').Select(item => item.Split('='))
                .Select(kv => new KeyValuePair<string, string>(kv[0], kv[1])).ToList();
            host = listKey.FirstOrDefault(key => key.Key == "Data Source").Value;
            user = listKey.FirstOrDefault(key => key.Key == "User Id").Value;
            database = ParamtersInput.DataBase;
            password = listKey.FirstOrDefault(key => key.Key == "Password").Value;
        }

        public string host { get; set; }
        public string user { get; set; }
        public string database { get; set; }
        public string password { get; set; }
    }
}