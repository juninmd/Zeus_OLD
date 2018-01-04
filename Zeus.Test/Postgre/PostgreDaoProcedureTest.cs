using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Postgre
{
    [TestClass]
    public class PostgreDaoProcedureTest : BasePostgreDaoTest
    {
        public PostgreDaoProcedureTest()
        {
            ParamtersInput.Procedure = true;
        }
    }
}