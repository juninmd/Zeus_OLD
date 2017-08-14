using System.Configuration;
using Zeus.Core;

namespace Zeus.Test.MySql
{
    public class BaseMysqlDaoTest
    {
        public BaseMysqlDaoTest()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["mysqlConnect"];
            ParamtersInput.DataBase = ConfigurationManager.AppSettings["mysqlSchema"]; 
        }
    }
}
