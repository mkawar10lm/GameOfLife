using System;
using System.IO;
using System.Linq;

namespace badlife.csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading the intial input for game
            var input = new StreamReader("sample_input.txt");
            var allText = input.ReadToEnd();
            var lines = allText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            //Reading the maximum number of games
            var maxNumberOfGamesUserInput = new StreamReader("max_number_of_games.txt");
            var maxNumberOfGames = Int32.Parse(maxNumberOfGamesUserInput.ReadToEnd());

            // If the input file is empty, the code can be terminated.
            // The data checks here can be extended. 
            // 1) Check if the files only contain "*" and "_"
            // 2) All the lines should have same number of characters. 

            if (!lines.Any())
            {
                return;
            }

            // Creating the current state of world with boolean variables
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

            Evolve(currentStateOfWorld, maxNumberOfGames, 1);

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
        static void Evolve(bool[][] currentStateOfWorld, int maxNumberOfGames, int round)
        {
            var rows = currentStateOfWorld.Length;
            var cols = currentStateOfWorld[0].Length;

            // The first condition is checking if the game round is less than max number of games
            // and the input has atleast one alive cell

            if (round < maxNumberOfGames && currentStateOfWorld.Any(x => x.Any(y => y)))
            {
                for (var iterationRows = 0; iterationRows < currentStateOfWorld.Length; ++iterationRows)
                {
                    for (var iterationCols = 0; iterationCols < currentStateOfWorld[iterationRows].Length; ++iterationCols)
                    {
                        //Checking the situation of neighbors
                        int neighbors = 0;
                        if (NeighborChecks.AboveLeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                        if (NeighborChecks.AboveNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols)) neighbors++;
                        if (NeighborChecks.AboveRightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                        if (NeighborChecks.LeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                        if (NeighborChecks.RightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                        if (NeighborChecks.BelowLeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                        if (NeighborChecks.BelowNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
                        if (NeighborChecks.BelowRightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;

                        // Updating the world
                        if (currentStateOfWorld[iterationRows][iterationCols] && neighbors < 2) currentStateOfWorld[iterationRows][iterationCols] = false;
                        if (currentStateOfWorld[iterationRows][iterationCols] && (neighbors == 2 || neighbors == 3)) currentStateOfWorld[iterationRows][iterationCols] = true;
                        if (currentStateOfWorld[iterationRows][iterationCols] && neighbors > 3) currentStateOfWorld[iterationRows][iterationCols] = false;
                        if (!currentStateOfWorld[iterationRows][iterationCols] && neighbors == 3) currentStateOfWorld[iterationRows][iterationCols] = true;
                    }
                }
                round = round + 1;
                Evolve(currentStateOfWorld, maxNumberOfGames, round);
            }
        }
    }
}
