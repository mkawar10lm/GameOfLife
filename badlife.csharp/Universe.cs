using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace badlife.csharp
{
    public class Universe
    {
        private CellState[,] cells;        
        public Universe(string stringRepOfUniverse)
        {
            this.cells = CreateTheIntialUnivese(stringRepOfUniverse);
        }
        public Universe(int rowIndex, int columnIndex)
        {
            this.cells = new CellState[rowIndex, columnIndex];
        }

        public int GetLiveNeighboursAt(int rowIndex, int columnIndex)
        {
            NeighborChecks neighborChecks = new NeighborChecks(cells);
            List<CellState.cellstates> neighborCellStates = neighborChecks.NeighborStates(rowIndex, columnIndex);
            return neighborCellStates.FindAll(x=> x.Equals(CellState.cellstates.ALIVE)).Count;
        }
        public CellState[,] GetUniverse()
        {
            return cells;
        }

        public int GetWidth()
        {
            return cells.GetLength(1);
        }
        public int GetHeight()
        {
            return cells.GetLength(0);
        }
        public string ConvertUniverseToString()
        {
            StringBuilder printedGrid = new StringBuilder();
            for (int row = 0; row < GetHeight(); row++)
            {
                for (int col = 0; col < GetWidth(); col++)
                {
                    printedGrid.Append(cells[row, col].Symbol);
                }
            }
            return printedGrid.ToString();
        }
        private static CellState[,] CreateTheIntialUnivese(string stringRepOfUniverse)
        {
            //string allText = input.ReadToEnd();
            string[] lines = SplitIntoRows(stringRepOfUniverse);
            CellState[,] currentStateOfWorld = SplitIntoCells(lines);
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
        private static CellState[,] SplitIntoCells(string[] rows)
        {
            CellState[,] universe = new CellState[rows.Length, rows[0].Length];
            for (int i = 0; i < rows.Length; i++)
            {
                char[] charArr = rows[i].ToCharArray();
                for (int j = 0; j < charArr.Length; j++)
                {
                    universe[i, j] = CellState.FromSymbol(charArr[j]);
                }
            }
            return universe;
        }
    }
}
