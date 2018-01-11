using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.SqlServer
{
    [TestClass]
    public class SqlServerDaoProcedureTest : BaseSqlServerDaoTest
    {
        public SqlServerDaoProcedureTest()
        {
            ParamtersInput.Procedure = true;
        }
    }
}