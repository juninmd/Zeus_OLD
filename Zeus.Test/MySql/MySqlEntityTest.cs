using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.MySql
{
    [TestClass]
    public class MySqlEntityTest : BaseMysqlTest
    {
        [TestMethod]
        public void GenerateCSharp()
        {
            ParamtersInput.Linguagem = 1;
            Entity();
        }

        [TestMethod]
        public void GenerateJava()
        {
            ParamtersInput.Linguagem = 2;
            Entity();
        }
    }
}