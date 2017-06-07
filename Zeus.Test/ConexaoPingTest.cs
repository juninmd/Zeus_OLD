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
            ParamtersInput.ConnectionString = "User Id=USR_BIRL;Data Source=localhost;Password=!USR_BIRL!";
            var ping = new OraclePing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }

        [TestMethod]
        public void Mysql()
        {
            ParamtersInput.ConnectionString = "Server=localhost;Uid=mysql;Pwd=;Port=5500";
            var ping = new MySqlPing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }

        [TestMethod]
        public void SqlServer()
        {
            ParamtersInput.ConnectionString = "Server=localhost;Database=Aula1;Trusted_Connection=True";
            var ping = new SQLPing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }

        [TestMethod]
        public void Firebird()
        {
            ParamtersInput.ConnectionString = "User=SYSDBA;Password=masterkey;Database=D:\\Meus Projetos\\Solutions\\Trabalho Fernando\\BANCO.fdb;DataSource=localhost;Port=3050";
            var ping = new FirebirdPing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }

        [TestMethod]
        public void Postgre()
        {
            ParamtersInput.ConnectionString = "Host=localhost;Database=postgres;User ID=postgres;Password=root;Port=5432";
            var ping = new PostgrePing().Ping();
            Assert.IsFalse(ping.IsError, ping.Message);
        }
    }
}
