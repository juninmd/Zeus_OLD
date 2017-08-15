using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;
using Zeus.Middleware;

namespace Zeus.Test.Oracle
{
    [TestClass]
    public class OracleDaoTest : BaseOracleTest
    {
        public OracleDaoTest()
        {
            ParamtersInput.Procedure = false;
        }

        [TestMethod]
        public void GenerateCSharp()
        {
            ParamtersInput.Linguagem = 1;
            var chamada = new OrquestradorChamada().Generate();
            Assert.AreEqual(HttpStatusCode.OK, chamada.StatusCode, chamada.Message);
            Assert.AreEqual(1, Directory.GetFiles(ParamtersInput.SelectedPath).Length, "Arquivo não foi encontrado.");
            Directory.Delete(ParamtersInput.SelectedPath, true);
        }

        [TestMethod]
        public void GenerateJava()
        {
            ParamtersInput.Linguagem = 2;
            var chamada = new OrquestradorChamada().Generate();
            Assert.AreEqual(HttpStatusCode.OK, chamada.StatusCode, chamada.Message);
            Assert.AreEqual(1, Directory.GetFiles(ParamtersInput.SelectedPath).Length, "Arquivo não foi encontrado.");
            Directory.Delete(ParamtersInput.SelectedPath, true);
        }

        [TestMethod]
        public void GenerateNode()
        {
            ParamtersInput.Linguagem = 3;
            var chamada = new OrquestradorChamada().Generate();
            Assert.AreEqual(HttpStatusCode.OK, chamada.StatusCode, chamada.Message);
            Assert.AreEqual(1, Directory.GetFiles(ParamtersInput.SelectedPath).Length, "Arquivo não foi encontrado.");
            Directory.Delete(ParamtersInput.SelectedPath, true);
        }
    }
}
