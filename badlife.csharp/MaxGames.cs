using System;
using System.IO;

namespace badlife.csharp
{
    public class MaxGames
    {
        private int maxGame;
        public MaxGames(StreamReader maxNumberOfGamesUserInput)
        {
            this.maxGame = makeCellArrayFrom(maxNumberOfGamesUserInput);
        }
        private int makeCellArrayFrom(StreamReader maxNumberOfGamesUserInput)
        {
            return Int32.Parse(maxNumberOfGamesUserInput.ReadToEnd());
        }
        public int getMaxNumberOfGames()
        {
            return maxGame;
        }
    }
}
