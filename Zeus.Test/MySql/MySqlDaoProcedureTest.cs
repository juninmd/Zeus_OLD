using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.MySql
{
    [TestClass]
    public class MySqlDaoProcedureTest : BaseMySqlDaoTest
    {
        public MySqlDaoProcedureTest()
        {
            ParamtersInput.Procedure = false;
        }
    }
}