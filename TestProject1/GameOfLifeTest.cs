using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using badlife.csharp;

namespace TestProject1
{
    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void OscillationGameOfLifeInputTestCaseFirstState()
        {
            var input = new StreamReader("InputFiles/sample_input.txt");

            var inputArr = new Game(new Universe(input.ReadToEnd()), new MaxGames("10"));

            Assert.AreEqual(inputArr.PlayGame(), "______________***__***______________");
        }
        [TestMethod]
        public void OscillationGameOfLifeInputTestCaseSecondState()
        {
            var input = new StreamReader("InputFiles/sample_input.txt");

            var inputArr = new Game(new Universe(input.ReadToEnd()), new MaxGames("9"));

            Assert.AreEqual(inputArr.PlayGame(), "_________*___*__*__*__*___*_________");
        }
    }
}
