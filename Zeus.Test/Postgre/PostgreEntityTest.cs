using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;
using Zeus.Middleware;

namespace Zeus.Test.Postgre
{
    [TestClass]
    public class PostgreEntityTest : BasePostgreTest
    {
        [TestMethod]
        public void GenerateCSharp()
        {
            ParamtersInput.Linguagem = 1;
            var chamada = new OrquestradorMapeamentoEntidade().Generate();
            Assert.AreEqual(HttpStatusCode.OK, chamada.StatusCode, chamada.TechnicalMessage);
            Assert.AreEqual(1, Directory.GetFiles(ParamtersInput.SelectedPath).Length, "Arquivo não foi encontrado.");
            Directory.Delete(ParamtersInput.SelectedPath, true);
        }

        [TestMethod]
        public void GenerateJava()
        {
            ParamtersInput.Linguagem = 2;
            var chamada = new OrquestradorMapeamentoEntidade().Generate();
            Assert.AreEqual(HttpStatusCode.OK, chamada.StatusCode, chamada.TechnicalMessage);
            Assert.AreEqual(1, Directory.GetFiles(ParamtersInput.SelectedPath).Length, "Arquivo não foi encontrado.");
            Directory.Delete(ParamtersInput.SelectedPath, true);
        }
    }
}