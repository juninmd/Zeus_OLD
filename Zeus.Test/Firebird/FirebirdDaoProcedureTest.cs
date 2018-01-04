using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Firebird
{
    [TestClass]
    public class FirebirdDaoProcedureTest : BaseFirebirdDaoTest
    {
        public FirebirdDaoProcedureTest()
        {
            ParamtersInput.Procedure = true;
        }
    }
}