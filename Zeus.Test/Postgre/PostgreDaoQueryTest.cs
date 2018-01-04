using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Postgre
{
    [TestClass]
    public class PostgreDaoQueryTest : BasePostgreDaoTest
    {
        public PostgreDaoQueryTest()
        {
            ParamtersInput.Procedure = false;
        }
    }
}