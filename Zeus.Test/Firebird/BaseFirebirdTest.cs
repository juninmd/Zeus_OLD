using System.Collections.Generic;
using System.Configuration;
using Zeus.Core;

namespace Zeus.Test.Firebird
{
    public class BaseFirebirdTest : BaseTest
    {
        public BaseFirebirdTest() : base(4)
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["firebirdConnect"];
            ParamtersInput.NomeTabelas = new List<string> {"BAIRRO"};
        }
    }
}