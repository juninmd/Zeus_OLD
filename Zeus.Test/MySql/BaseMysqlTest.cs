using System.Collections.Generic;
using System.Configuration;
using Zeus.Core;

namespace Zeus.Test.MySql
{
    public class BaseMysqlTest : BaseTest
    {
        public BaseMysqlTest() : base(3)
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["mysqlConnect"];
            ParamtersInput.DataBase = ConfigurationManager.AppSettings["mysqlSchema"];
            ParamtersInput.NomeTabelas = new List<string> {"channel"};
        }
    }
}