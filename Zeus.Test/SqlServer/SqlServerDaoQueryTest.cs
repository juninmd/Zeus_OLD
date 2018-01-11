using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.SqlServer
{
    [TestClass]
    public class SqlServerDaoQueryTest : BaseSqlServerDaoTest
    {
        public SqlServerDaoQueryTest()
        {
            ParamtersInput.Procedure = false;
        }
    }
}