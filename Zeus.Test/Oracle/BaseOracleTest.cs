using System.Collections.Generic;
using System.Configuration;
using Zeus.Core;

namespace Zeus.Test.Oracle
{
    public class BaseOracleTest : BaseTest
    {
        public BaseOracleTest() : base(1)
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["oracleConnect"];
            ParamtersInput.NomeTabelas = new List<string> {"teste"};
        }
    }
}