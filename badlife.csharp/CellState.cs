using System.IO;

namespace badlife.csharp
{
    public class CellState
    {
        public enum cellstates
        {
            ALIVE,
            DEAD
        }

        private char symbol;
        private cellstates state;

        public CellState(char initialSymbol, cellstates state)
        {
            this.symbol = initialSymbol;
            this.state = state;
        }
        public char Symbol    
        {
            get => symbol;
            set => symbol = value;
        }
        public cellstates State
        {
            get => state;
            set => state = value;
        }

        public static CellState FromSymbol(char symbol)
        {
            CellState cellBySymbol = null;
            if (symbol.Equals(GetLiveCellSymbol()))
            {
                return new CellState(symbol, cellstates.ALIVE);
            }
            else if (symbol.Equals(GetDeadCellSymbol()))
            {
                return new CellState(symbol, cellstates.DEAD);
            }
            else 
            {
                new InvalidDataException("The input data has alien character");
            }
            return cellBySymbol;
        }
        public static bool IsCellAlive(CellState cell)
        {
            return cell.state == cellstates.ALIVE;
        }
        public static char GetDeadCellSymbol()
        {
            return '_';
        }
        public static char GetLiveCellSymbol()
        {
            return '*';
        }

    }
}