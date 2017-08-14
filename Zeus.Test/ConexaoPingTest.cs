using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;
using Zeus.Core.SGBD.Firebird;
using Zeus.Core.SGBD.Microsoft_SQL;
using Zeus.Core.SGBD.MySql;
using Zeus.Core.SGBD.Oracle;
using Zeus.Core.SGBD.Postgre;

namespace Zeus.Test
{
    [TestClass]
    public class ConexaoPingTest
    {
        [TestMethod]
        public void Oracle()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["oracleConnect"];
            var ping = new OraclePing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }

        [TestMethod]
        public void Mysql()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["mysqlConnect"];
            var ping = new MySqlPing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }

        [TestMethod]
        public void SqlServer()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["sqlserverConnect"];
            var ping = new SQLPing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }

        [TestMethod]
        public void Firebird()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["firebirdConnect"];
            var ping = new FirebirdPing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }

        [TestMethod]
        public void Postgre()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["pgConnect"];
            var ping = new PostgrePing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }
    }
}
