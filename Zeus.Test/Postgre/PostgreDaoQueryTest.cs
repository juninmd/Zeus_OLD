using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;
using Zeus.Test.Postgre;

namespace Zeus.Test.MySql
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