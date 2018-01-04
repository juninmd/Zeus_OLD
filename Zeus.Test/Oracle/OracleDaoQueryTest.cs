using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;
using Zeus.Test.Oracle;

namespace Zeus.Test.MySql
{
    [TestClass]
    public class OracleDaoQueryTest : BaseOracleDaoTest
    {
        public OracleDaoQueryTest()
        {
            ParamtersInput.Procedure = false;
        }
    }
}