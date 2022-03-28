using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using badlife.csharp;

namespace TestProject1
{
    [TestClass]
    public class GameOfLifeTest
    {
        // Various input cases for Game Of Life
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

        [TestMethod]
        public void StillLifeGameOfLifeInputTestCaseOne()
        {
            var input = new StreamReader("InputFiles/stillLifeCaseOne.txt");

            var inputArr = new Game(new Universe(input.ReadToEnd()), new MaxGames("9"));

            Assert.AreEqual(inputArr.PlayGame(), "_______*___*_*___*_______");
        }
        [TestMethod]
        public void DeadUniverseGameOfLifeInputTestCase()
        {
            var input = new StreamReader("InputFiles/deaduniverse.txt");

            var inputArr = new Game(new Universe(input.ReadToEnd()), new MaxGames("9"));

            Assert.AreEqual(inputArr.PlayGame(), "");
        }
        [TestMethod]
        public void GliderGameOfLifeInputTestCaseOne()
        {
            var input = new StreamReader("InputFiles/glider.txt");

            var inputArr = new Game(new Universe(input.ReadToEnd()), new MaxGames("9"));

            Assert.AreEqual(inputArr.PlayGame(), "________*______**___**________");
        }

        [TestMethod]
        public void GliderGameOfLifeInputTestCaseTwo()
        {
            var input = new StreamReader("InputFiles/glider.txt");

            var inputArr = new Game(new Universe(input.ReadToEnd()), new MaxGames("1"));

            Assert.AreEqual(inputArr.PlayGame(), "________*______**___**________");
        }

        [TestMethod]
        public void GliderGameOfLifeInputTestCaseThree()
        {
            var input = new StreamReader("InputFiles/glider.txt");

            var inputArr = new Game(new Universe(input.ReadToEnd()), new MaxGames("5"));

            Assert.AreEqual(inputArr.PlayGame(), "______________***___*_________");
        }

        // Test For Data Checks
        [TestMethod]
        public void WrongMemberState()
        {
            Assert.AreEqual(CellState.FromSymbol('&'), null);
        }

    }
}
