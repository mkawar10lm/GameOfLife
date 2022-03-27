using System;
using System.IO;
using System.Linq;

namespace badlife.csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = new StreamReader("InputFiles/sample_input.txt");
            var games = new StreamReader("InputFiles/max_number_of_games.txt");

            Universe universe = new Universe(input.ReadToEnd());
            MaxGames maxgame = new MaxGames(games.ReadToEnd());

            Game game = new Game(universe, maxgame);

            string stringRepUniverse = game.PlayGame();
            Console.WriteLine(stringRepUniverse);
            Console.ReadLine();
        }
    }
}
