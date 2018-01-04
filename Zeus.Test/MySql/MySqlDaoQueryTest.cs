using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.MySql
{
    [TestClass]
    public class MySqlDaoQueryTest : BaseMySqlDaoTest
    {
        public MySqlDaoQueryTest()
        {
            ParamtersInput.Procedure = false;
        }
    }
}