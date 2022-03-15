using System;
using System.IO;
using System.Linq;

namespace badlife.csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new StreamReader("sample_input.txt");//"D:\DC\GitHubProjects\GameOfLife\GameOfLife\badlife.csharp\sample_input.txt.txt"
            var allText = input.ReadToEnd();
            var lines = allText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (!lines.Any())
            {
                return;
            }

            var currentStateOfWorld = new bool[lines.Length][];
            for (int indexOfLines = 0; indexOfLines < lines.Length; ++indexOfLines)
            {
                currentStateOfWorld[indexOfLines] = new bool[lines[indexOfLines].Length];
                for (int indexOfCharacter = 0; indexOfCharacter < lines[indexOfLines].Length; indexOfCharacter++)
                {
                    if (lines[indexOfLines][indexOfCharacter] == '_')
                    {
                        currentStateOfWorld[indexOfLines][indexOfCharacter] = false;
                    }
                    else if (lines[indexOfLines][indexOfCharacter] == '*')
                        currentStateOfWorld[indexOfLines][indexOfCharacter] = true;
                }
            }

            Evolve(currentStateOfWorld);

            for (int iterationRow = 0; iterationRow < currentStateOfWorld.Length; iterationRow++)
            {
                string line = "";
                for (int iterationCol = 0; iterationCol < currentStateOfWorld[iterationRow].Length; ++iterationCol)
                {
                    line = line + (currentStateOfWorld[iterationRow][iterationCol] ? '*' : '_');
                }
                Console.WriteLine(line);
            }
        }
        static void Evolve(bool[][] currentStateOfWorld)
        {
            var rows = currentStateOfWorld.Length;
            var cols = currentStateOfWorld[0].Length;

            for (var iterationRows = 0; iterationRows < currentStateOfWorld.Length; ++iterationRows)
            {
                for (var iterationCols = 0; iterationCols < currentStateOfWorld[iterationRows].Length; ++iterationCols)
                {
                    int neighbors = 0;
                    if (NeighborChecks.AboveLeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                    if (NeighborChecks.AboveNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols)) neighbors++; 
                    if (NeighborChecks.AboveRightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                    if (NeighborChecks.LeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++; 
                    if (NeighborChecks.RightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                    if (NeighborChecks.BelowLeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++; 
                    if (NeighborChecks.BelowNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++; 
                    if (NeighborChecks.BelowRightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;

                    if (currentStateOfWorld[iterationRows][iterationCols] && neighbors < 2) currentStateOfWorld[iterationRows][iterationCols] = false;
                    if (currentStateOfWorld[iterationRows][iterationCols] && (neighbors == 2 || neighbors == 3)) currentStateOfWorld[iterationRows][iterationCols] = true;
                    if (currentStateOfWorld[iterationRows][iterationCols] && neighbors > 3) currentStateOfWorld[iterationRows][iterationCols] = false;
                    if (!currentStateOfWorld[iterationRows][iterationCols] && neighbors == 3) currentStateOfWorld[iterationRows][iterationCols] = true;
                }
            }
        }
    }
}
