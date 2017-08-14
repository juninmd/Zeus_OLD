using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;
using Zeus.Middleware;
using Zeus.Utilidade;

namespace Zeus.Test.MySql
{
    [TestClass]
    public class NodeDaoMySqlTest : BaseMysqlDaoTest
    {
        public NodeDaoMySqlTest()
        {
            ParamtersInput.NomeTabelas = new List<string> { "teste" };
            ParamtersInput.Procedure = false;

        }
        [TestMethod]
        public void GenerateCrud()
        {
            var chamada = new OrquestradorChamada().Generate();
            Util.Status(chamada.Message + " - " + chamada.TechnicalMessage);
        }
    }
}
