using System.Collections.Generic;
using System.Configuration;
using Zeus.Core;

namespace Zeus.Test.Postgre
{
    public class BasePostgreTest : BaseTest
    {
        public BasePostgreTest() : base(5)
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["pgConnect"];
            ParamtersInput.NomeTabelas = new List<string> {"teste"};
        }
    }
}