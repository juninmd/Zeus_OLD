using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Firebird
{
    [TestClass]
    public class BaseFirebirdTest : BaseTest
    {
        public BaseFirebirdTest()
        {
            ParamtersInput.ConnectionString = ConfigurationManager.AppSettings["firebirdConnect"];

            ParamtersInput.NomeTabelas = new List<string> {"BAIRRO"};
            ParamtersInput.SelectedPath = Directory.GetCurrentDirectory() + "\\Test\\";
            ParamtersInput.SGBD = 4;

            if (!Directory.Exists(ParamtersInput.SelectedPath))
                Directory.CreateDirectory(ParamtersInput.SelectedPath);
        }
    }
}