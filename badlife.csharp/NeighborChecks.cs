using System;
using System.Collections.Generic;

namespace badlife.csharp
{
    public class NeighborChecks
    {
        private CellState[,] cells;
        private int maxRows;
        private int maxColumns;

        public NeighborChecks(CellState[,] cells)
        {
            this.cells = cells;
            this.maxRows = cells.GetLength(0);
            this.maxColumns = cells.GetLength(1);
        }
        public List<CellState.cellstates> NeighborStates(int iterationRows, int iterationCols)
        {
            var neighborCellStates = new List<CellState.cellstates>();
            var neighborCoordinates = CoordinatesOfNeighbors(iterationRows, iterationCols);

            foreach (var iterTuple in neighborCoordinates)
            {
                neighborCellStates.Add(cells[iterTuple.Item1, iterTuple.Item2].State);
            }
            return neighborCellStates;
        }

        public List<Tuple<int, int>> CoordinatesOfNeighbors(int iterationRows, int iterationCols)
        {
            return new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(AboveCellRowCheck(iterationRows), LeftCellColumnCheck(iterationCols)),
                new Tuple<int, int>(AboveCellRowCheck(iterationRows), iterationCols),
                new Tuple<int, int>(AboveCellRowCheck(iterationRows), RightCellColumnCheck(iterationCols)),
                new Tuple<int, int>(iterationRows, LeftCellColumnCheck(iterationCols)),
                new Tuple<int, int>(iterationRows, RightCellColumnCheck(iterationCols)),
                new Tuple<int, int>(BelowCellRowCheck(iterationRows), LeftCellColumnCheck(iterationCols)),
                new Tuple<int, int>(BelowCellRowCheck(iterationRows), iterationCols),
                new Tuple<int, int>(BelowCellRowCheck(iterationRows), RightCellColumnCheck(iterationCols))
            };
        }

        public int AboveCellRowCheck(int iterationRows)
        {
            return iterationRows - 1 < 0 ? maxRows - 1 : iterationRows - 1;
        }
        public int BelowCellRowCheck(int iterationRows)
        {
            return iterationRows + 1 == maxRows ? 0 : iterationRows + 1;
        }
        public int LeftCellColumnCheck(int iterationCols)
        {
            return iterationCols - 1 < 0 ? maxColumns - 1 : iterationCols - 1;
        }
        public int RightCellColumnCheck(int iterationCols)
        {
            return iterationCols + 1 == maxColumns ? 0 : iterationCols + 1;
        }
    }
}
