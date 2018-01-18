using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;
using Zeus.Middleware;

namespace Zeus.Test
{
    public class BaseTest
    {
        public BaseTest(int sgbd)
        {
            ParamtersInput.SGBD = sgbd;
            ParamtersInput.SelectedPath = Directory.GetCurrentDirectory() + "\\Test\\" + sgbd + "\\";
            ParamtersInput.Prefixos = new Prefixos();
            if (!Directory.Exists(ParamtersInput.SelectedPath))
                Directory.CreateDirectory(ParamtersInput.SelectedPath);
        }

        public void Dao()
        {
            var chamada = new OrquestradorChamada().Generate();
            Assert.AreEqual(HttpStatusCode.OK, chamada.StatusCode, chamada.TechnicalMessage);
            Assert.AreEqual(1, Directory.GetFiles(ParamtersInput.SelectedPath).Length, "Arquivo não foi encontrado.");
            Directory.Delete(ParamtersInput.SelectedPath, true);
        }

        public void Entity()
        {
            var chamada = new OrquestradorMapeamentoEntidade().Generate();
            Assert.AreEqual(HttpStatusCode.OK, chamada.StatusCode, chamada.TechnicalMessage);
            Assert.AreEqual(1, Directory.GetFiles(ParamtersInput.SelectedPath).Length, "Arquivo não foi encontrado.");
            Directory.Delete(ParamtersInput.SelectedPath, true);
        }
    }
}