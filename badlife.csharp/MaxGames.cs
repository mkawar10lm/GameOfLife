using System;
using System.IO;

namespace badlife.csharp
{
    public class MaxGames
    {
        private int maxGame;
        public MaxGames(string maxNumberOfGamesString)
        {
            this.maxGame = gameCount(maxNumberOfGamesString);
        }
        private int gameCount(string maxNumberOfGamesString)
        {
            return Int32.Parse(maxNumberOfGamesString);
        }
        public int getMaxNumberOfGames()
        {
            return maxGame;
        }
    }
}
