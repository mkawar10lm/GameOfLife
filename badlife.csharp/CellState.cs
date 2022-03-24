using System.IO;

namespace badlife.csharp
{
    public class CellState
    {
        public enum cellstates
        {
            LIVE_CELL,
            DEAD_CELL
        }

        private char symbol;
        private cellstates state;

        public CellState(char initialSymbol)
        {
            this.symbol = initialSymbol;
        }
        public CellState(cellstates state)
        {
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

        public static CellState fromSymbol(char symbol)
        {
            CellState cellBySymbol = null;
            if (symbol.Equals('*'))
            {
                cellBySymbol.state = cellstates.LIVE_CELL;
                cellBySymbol.symbol = symbol;
            }
            else if (symbol.Equals('_'))
            {
                cellBySymbol.state = cellstates.DEAD_CELL;
                cellBySymbol.symbol = symbol;
            }
            else 
            {
                new InvalidDataException("The input data has alien character");
            }
            return cellBySymbol;
        }
        public static bool isCellAlive(CellState cell)
        {
            return cell.state == cellstates.LIVE_CELL;
        }
    }
}