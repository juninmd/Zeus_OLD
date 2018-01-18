using System.Collections.Generic;
using System.Configuration;
using Zeus.Core;

namespace Zeus.Test.SqlServer
{
    public class BaseSqlServerTest : BaseTest
    {
        public BaseSqlServerTest() : base(2)
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["sqlserverConnect"];
            ParamtersInput.NomeTabelas = new List<string> {"teste"};
        }
    }
}