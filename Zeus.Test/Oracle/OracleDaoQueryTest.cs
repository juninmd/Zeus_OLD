using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Oracle
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