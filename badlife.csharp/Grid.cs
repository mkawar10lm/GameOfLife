using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace badlife.csharp
{
    public class Grid
    {
        private CellState[][] cells;
        
        public Grid(StreamReader input)
        {
            this.cells = CreateTheIntialUnivese(input);
        }
        public int getLiveNeighboursAt(int rowIndex, int columnIndex)
        {
            NeighborChecks neighborChecks = new NeighborChecks(cells);
            List<CellState.cellstates> neighborCellStates = neighborChecks.NeighborStates(rowIndex, columnIndex);
            return neighborCellStates.FindAll(x=> x.Equals(CellState.cellstates.LIVE_CELL)).Count;
        }
        public CellState[][] GetUniverse()
        {
            return cells;
        }

        public int getWidth()
        {
            return cells[0].Length;
        }
        public int getHeight()
        {
            return cells.Length;
        }
        public string ConvertUniverseToString()
        {
            StringBuilder printedGrid = new StringBuilder();
            for (int row = 0; row < getHeight(); row++)
            {
                for (int col = 0; col < getWidth(); col++)
                {
                    printedGrid.Append(cells[row][col].Symbol);
                }
            }
            return printedGrid.ToString();
        }
        private static CellState[][] CreateTheIntialUnivese(StreamReader input)
        {
            var allText = input.ReadToEnd();
            var lines = SplitIntoRows(allText);
            var currentStateOfWorld = lines.Select(str => SplitIntoCells(str)).ToArray();
            return currentStateOfWorld;
        }
        private static string[] SplitIntoRows(string gridContents)
        {
            string[] lines = gridContents.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length <= 0)
            {
                new InvalidDataException("The input data is empty. Intial state is required to start the Game Of Life");
            }
            return lines;
        }
        private static CellState[] SplitIntoCells(string row)
        {
            return row.Select(x => CellState.fromSymbol(x)).ToArray();
        }

    }
}
