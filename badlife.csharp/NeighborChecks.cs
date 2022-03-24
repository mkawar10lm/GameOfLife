using System.Collections.Generic;

namespace badlife.csharp
{
    public class NeighborChecks
    {
        private CellState[][] cells;
        private int maxRows;
        private int maxColumns;

        public NeighborChecks(CellState[][] cells)
        {
            this.cells = cells;
            this.maxRows = cells.Length;
            this.maxColumns = cells[0].Length;
        }
        public List<CellState.cellstates> NeighborStates(int iterationRows, int iterationCols)
        {
            var neighborCellStates = new List<CellState.cellstates>();
            neighborCellStates.Add(AboveLeftNeighborCheck(iterationRows, iterationCols));
            neighborCellStates.Add(AboveNeighborCheck(iterationRows, iterationCols));
            neighborCellStates.Add(AboveRightNeighborCheck(iterationRows, iterationCols));
            neighborCellStates.Add(LeftNeighborCheck(iterationRows, iterationCols));
            neighborCellStates.Add(RightNeighborCheck(iterationRows, iterationCols));
            neighborCellStates.Add(BelowLeftNeighborCheck(iterationRows, iterationCols));
            neighborCellStates.Add(BelowNeighborCheck(iterationRows, iterationCols));
            neighborCellStates.Add(BelowRightNeighborCheck(iterationRows, iterationCols));
            return neighborCellStates;
        }
        public CellState.cellstates AboveLeftNeighborCheck(int iterationRows, int iterationCols)
        {
            return cells[iterationRows - 1 < 0 ? maxRows - 1 : iterationRows - 1][iterationCols - 1 < 0 ? maxColumns - 1 : iterationCols - 1].State;
        }
        public CellState.cellstates AboveNeighborCheck(int iterationRows, int iterationCols)
        {
            return cells[iterationRows - 1 < 0 ? maxRows - 1 : iterationRows - 1][iterationCols].State;
        }
        public CellState.cellstates AboveRightNeighborCheck(int iterationRows, int iterationCols)
        {
            return cells[iterationRows - 1 < 0 ? maxRows - 1 : iterationRows - 1][iterationCols + 1 == maxColumns ? 0 : iterationCols + 1].State;
        }
        public CellState.cellstates LeftNeighborCheck(int iterationRows, int iterationCols)
        {
            return cells[iterationRows][iterationCols - 1 < 0 ? maxColumns - 1 : iterationCols - 1].State;
        }
        public CellState.cellstates RightNeighborCheck(int iterationRows, int iterationCols)
        {
            return cells[iterationRows][iterationCols + 1 == maxColumns ? 0 : iterationCols + 1].State;
        }
        public CellState.cellstates BelowLeftNeighborCheck(int iterationRows, int iterationCols)
        {
            return cells[iterationRows + 1 == maxRows ? 0 : iterationRows + 1][iterationCols - 1 < 0 ? maxColumns - 1 : iterationCols - 1].State;
        }

        public CellState.cellstates BelowNeighborCheck(int iterationRows, int iterationCols)
        {
            return cells[iterationRows + 1 == maxRows ? 0 : iterationRows + 1][iterationCols].State;
        }
        public CellState.cellstates BelowRightNeighborCheck(int iterationRows, int iterationCols)
        {
            return cells[iterationRows + 1 == maxRows ? 0 : iterationRows + 1][iterationCols + 1 == maxColumns ? 0 : iterationCols + 1].State;
        }
    }
}
