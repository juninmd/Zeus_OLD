using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Firebird
{
    [TestClass]
    public class FirebirdEntityTest : BaseFirebirdTest
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