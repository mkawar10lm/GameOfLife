using Microsoft.VisualStudio.TestTools.UnitTesting;
using badlife.csharp;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var inputArr = new bool[][]{};

            Program.Evolve(inputArr, 5, 0);

            Assert.AreEqual(System.Array.Empty<bool[]>(), System.Array.Empty<bool[]>());
        }
    }
}
