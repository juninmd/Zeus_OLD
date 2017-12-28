using System.Collections.Generic;
using System.Linq;
using Zeus.Core;

namespace Zeus.Core.SGBD.MySql
{
    public class MySqlConnectionStringModel
    {
        public MySqlConnectionStringModel(string connection)
        {
            var listKey = connection.Split(';').Select(item => item.Split('=')).Select(kv => new KeyValuePair<string, string>(kv[0], kv[1])).ToList();
            this.host = listKey.FirstOrDefault(key => key.Key == "Server").Value;
            this.user = listKey.FirstOrDefault(key => key.Key == "Uid").Value;
            this.database = ParamtersInput.DataBase;
            this.password = listKey.FirstOrDefault(key => key.Key == "Pwd").Value;
            this.port = int.Parse(listKey.FirstOrDefault(key => key.Key == "Port").Value);
        }

        public string host { get; set; }
        public string user { get; set; }
        public string database { get; set; }
        public string password { get; set; }
        public int port { get; set; }
    }
}
