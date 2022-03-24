using System;
using System.IO;
using System.Linq;

namespace badlife.csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = new StreamReader("sample_input.txt");
            var games = new StreamReader("max_number_of_games.txt");

            Grid universe = new Grid(input);
            MaxGames maxgame = new MaxGames(games);

            Game game = new Game(universe, maxgame);

            game.PlayGame();
        }
    }
}
