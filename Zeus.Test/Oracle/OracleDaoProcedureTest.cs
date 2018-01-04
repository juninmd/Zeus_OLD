using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Oracle
{
    [TestClass]
    public class OracleDaoProcedureTest : BaseOracleDaoTest
    {
        public OracleDaoProcedureTest()
        {
            ParamtersInput.Procedure = true;
        }
    }
}