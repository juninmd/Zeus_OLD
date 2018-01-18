using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Oracle
{
    [TestClass]
    public class BaseOracleDaoTest : BaseOracleTest
    {
        [TestMethod]
        public void GenerateCSharp()
        {
            ParamtersInput.Linguagem = 1;
            Dao();
        }

        [TestMethod]
        public void GenerateJava()
        {
            ParamtersInput.Linguagem = 2;
            Dao();
        }

        [TestMethod]
        public void GenerateNode()
        {
            ParamtersInput.Linguagem = 3;
            Dao();
        }
    }
}