using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace badlife.csharp
{
    class Game
    {
        private Grid universe;
        private MaxGames maxGames;

        public Game(Grid universe, MaxGames maxGames)
        {
            this.universe = universe;
            this.maxGames = maxGames
        }

        public void PlayGame()
        {
            int numberOfGames = maxGames.getMaxNumberOfGames();

            for (int i = 0; i <= numberOfGames; i++)
            {
                for (var iterationRows = 0; iterationRows < universe.getHeight(); ++iterationRows)
                {
                    for (var iterationCols = 0; iterationCols < universe.getWidth(); ++iterationCols)
                    {
                        bool isWorldStagnant = universe.GetUniverse().Where(xcoordinate => xcoordinate.Where(ycoordinate => ycoordinate.State == CellState.cellstates.LIVE_CELL).Any();
                        if (isWorldStagnant)
                        {
                            Evolve(iterationRows, iterationCols);
                        }
                    }
                }
            }
            universe.ConvertUniverseToString();
        }
        public void Evolve(int rowIndex, int columnIndex)
        {
            int neighbors = universe.getLiveNeighboursAt(rowIndex, columnIndex);

            bool isCellAlive = CellState.isCellAlive(getCellAt(rowIndex, columnIndex));

            if (isCellAlive)
            {
                if (neighbors < 2)
                {
                    setCellAt(rowIndex, columnIndex, '_');
                }
                if (neighbors == 2 || neighbors == 3)
                {
                    setCellAt(rowIndex, columnIndex, '*');
                }
                if (neighbors > 3)
                {
                    setCellAt(rowIndex, columnIndex, '_');
                }
            }
            else if (neighbors == 3)
            {
                setCellAt(rowIndex, columnIndex, '*');
            }
        }
        public CellState getCellAt(int x, int y)
        {
            return universe.GetUniverse()[y][x];
        }
        public void setCellAt(int x, int y, char symbol)
        {
            universe.GetUniverse()[y][x] = CellState.fromSymbol(symbol);
        }
    }
}
