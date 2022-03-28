
namespace badlife.csharp
{
    public class Game
    {
        private Universe universe;
        private MaxGames maxGames;

        public Game(Universe universe, MaxGames maxGames)
        {
            this.universe = universe;
            this.maxGames = maxGames;
        }

        public string PlayGame()
        {
            int numberOfGames = maxGames.getMaxNumberOfGames();
            
            Universe nextGeneration = NextGeneration(universe);

            for (int i = 2; i <= numberOfGames; i++)
            {
                nextGeneration = NextGeneration(nextGeneration);
            }
            return nextGeneration.ConvertUniverseToString();
        }
        private Universe NextGeneration(Universe universe)
        {
            Universe nextGeneration = new Universe(universe.GetHeight(), universe.GetWidth());

            for (var iterationRows = 0; iterationRows < universe.GetHeight(); ++iterationRows)
            {
                for (var iterationCols = 0; iterationCols < universe.GetWidth(); ++iterationCols)
                {
                    bool isWorldActive = IsAnyMemberAlive(universe);
                    if (isWorldActive)
                    {
                        SetCell(iterationRows, iterationCols, Evolve(iterationRows, iterationCols, universe), nextGeneration);
                    }
                }
            }
            return nextGeneration;
        }
        
        private CellState Evolve(int rowIndex, int columnIndex, Universe universe)
        {
            int neighbors = universe.GetLiveNeighboursAt(rowIndex, columnIndex);

            bool isCellAlive = CellState.IsCellAlive(GetCellAt(rowIndex, columnIndex));

            if (isCellAlive)
            {
                if (neighbors < 2)
                {
                    return CellState.FromSymbol(CellState.GetDeadCellSymbol());
                }
                if (neighbors == 2 || neighbors == 3)
                {
                    return CellState.FromSymbol(CellState.GetLiveCellSymbol());
                }
                if (neighbors > 3)
                {
                    return CellState.FromSymbol(CellState.GetDeadCellSymbol());
                }
                else
                {
                    return CellState.FromSymbol(CellState.GetDeadCellSymbol());
                }
            }
            else if (neighbors == 3)
            {
                return CellState.FromSymbol(CellState.GetLiveCellSymbol());
            }
            else 
            {
                return CellState.FromSymbol(CellState.GetDeadCellSymbol());
            }
        }
        private CellState GetCellAt(int x, int y)
        {
            return universe.GetUniverse()[x,y];
        }
        public void SetCell(int x, int y, CellState cell, Universe universe)
        {
            universe.GetUniverse()[x, y] = cell;
        }

        private bool IsAnyMemberAlive(Universe universe)
        {
            for (int i = 0; i < universe.GetHeight(); i++)
            {
                for (int j = 0; j < universe.GetWidth(); j++)
                {
                    var cells = universe.GetUniverse();
                    if (cells[i, j] != null && cells[i, j].State == CellState.cellstates.ALIVE)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
