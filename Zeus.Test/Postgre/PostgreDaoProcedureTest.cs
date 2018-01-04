using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;
using Zeus.Test.Postgre;

namespace Zeus.Test.MySql
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