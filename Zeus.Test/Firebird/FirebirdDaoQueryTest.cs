using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeus.Core;

namespace Zeus.Test.Firebird
{
    [TestClass]
    public class FirebirdDaoQueryTest : BaseFirebirdDaoTest
    {
        public FirebirdDaoQueryTest()
        {
            ParamtersInput.Procedure = false;
        }
    }
}