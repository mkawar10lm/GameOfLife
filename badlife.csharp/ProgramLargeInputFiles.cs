//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.IO;

//namespace badlife.csharp
//{
//    public static class ProgramLargeInputFiles
//    {
//        static void Main(string[] args)
//        {
//            var input = new StreamReader("sample_input.txt");
//            var allText = input.ReadToEnd();
//            var lines = allText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

//            var currentStateOfWorld = new Dictionary<int, HashSet<int>>();

//            for (int indexOfLines = 0; indexOfLines < lines.Length; ++indexOfLines)
//            {
//                HashSet<int> indicesOfLiveMembers = new HashSet<int>();

//                for (int indexOfCharacter = 0; indexOfCharacter < lines[indexOfLines].Length; indexOfCharacter++)
//                {
//                    if (lines[indexOfLines][indexOfCharacter] == '*')
//                    {
//                        indicesOfLiveMembers.Add(indexOfCharacter);
//                    }
//                }
//                if (indicesOfLiveMembers.Any())
//                {
//                    currentStateOfWorld.Add(indexOfLines, indicesOfLiveMembers);
//                }
//            }
//            Dictionary<int, HashSet<int>> newWorld = Evolve(currentStateOfWorld, lines.Length, lines[0].Length);

//            for (int iterationRow = 0; iterationRow < currentStateOfWorld.Count; iterationRow++)
//            {
//                string line = "";
//                for (int iterationCol = 0; iterationCol < currentStateOfWorld[iterationRow].Length; ++iterationCol)
//                {
//                    line = line + (currentStateOfWorld[iterationRow][iterationCol] ? '*' : '_');
//                }
//                Console.WriteLine(line);
//            }
//        }
//        public static Dictionary<int, HashSet<int>> Evolve(Dictionary<int, HashSet<int>> currentStateOfWorld, int maxRows, int maxColumns)
//        {
//            var newWorld = new Dictionary<int, HashSet<int>>();

//            for (int iterationRows = 0; iterationRows < maxRows; iterationRows++)
//            {
//                for (int iterationAliveNeighbor = 0; iterationAliveNeighbor < maxColumns; iterationAliveNeighbor++)
//                {
//                    Checking the situation of neighbors
//                    int neighbors = 0;
//                    if (AboveLeftNeighborCheck(currentStateOfWorld, iterationRows, maxRows, iterationAliveNeighbor, maxColumns)) neighbors++;
//                    if (AboveNeighborCheck(currentStateOfWorld, iterationRows, maxRows, iterationAliveNeighbor)) neighbors++;
//                    if (AboveRightNeighborCheck(currentStateOfWorld, iterationRows, maxRows, iterationAliveNeighbor, maxColumns)) neighbors++;
//                    if (LeftNeighborCheck(currentStateOfWorld, iterationRows, maxRows, iterationAliveNeighbor, maxColumns)) neighbors++;
//                    if (RightNeighborCheck(currentStateOfWorld, iterationRows, maxRows, iterationAliveNeighbor, maxColumns)) neighbors++;
//                    if (BelowLeftNeighborCheck(currentStateOfWorld, iterationRows, maxRows, iterationAliveNeighbor, maxColumns)) neighbors++;
//                    if (BelowNeighborCheck(currentStateOfWorld, iterationRows, maxRows, iterationAliveNeighbor, maxColumns)) neighbors++;
//                    if (BelowRightNeighborCheck(currentStateOfWorld, iterationRows, maxRows, iterationAliveNeighbor, maxColumns)) neighbors++;

//                    if (currentStateOfWorld.ContainsKey(iterationRows) && currentStateOfWorld[iterationRows].Contains(iterationAliveNeighbor))
//                    {
//                        if (neighbors == 2 || neighbors == 3)
//                        {
//                            if (newWorld.ContainsKey(iterationRows))
//                            {
//                                newWorld[iterationRows].Add(iterationAliveNeighbor);
//                            }
//                            else
//                            {
//                                newWorld.Add(iterationRows, new HashSet<int> { iterationAliveNeighbor });
//                            }
//                        }
//                    }
//                    else if (neighbors == 3)
//                    {
//                        newWorld.Add(iterationRows, new HashSet<int> { iterationAliveNeighbor });
//                    }
//                }
//            }
//            return newWorld;
//        }
//        public static bool AboveLeftNeighborCheck(Dictionary<int, HashSet<int>> currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
//        {
//            var row = AboveCellRowCheck(iterationRows, rows);
//            var column = LeftCellColumnCheck(iterationCols, cols);

//            if (currentStateOfWorld.ContainsKey(row) && currentStateOfWorld[row].Contains(column))
//            {
//                return true;
//            }
//            return false;
//        }
//        public static bool AboveNeighborCheck(Dictionary<int, HashSet<int>> currentStateOfWorld, int iterationRows, int rows, int iterationCols)
//        {
//            var row = AboveCellRowCheck(iterationRows, rows);
//            if (currentStateOfWorld.ContainsKey(row) && currentStateOfWorld[row].Contains(iterationCols))
//            {
//                return true;
//            }
//            return false;
//        }
//        public static bool AboveRightNeighborCheck(Dictionary<int, HashSet<int>> currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
//        {
//            var row = AboveCellRowCheck(iterationRows, rows);
//            var column = RightCellColumnCheck(iterationCols, cols);
//            if (currentStateOfWorld.ContainsKey(row) && currentStateOfWorld[row].Contains(column))
//            {
//                return true;
//            }
//            return false;

//        }
//        public static bool LeftNeighborCheck(Dictionary<int, HashSet<int>> currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
//        {
//            var column = LeftCellColumnCheck(iterationCols, cols);
//            if (currentStateOfWorld.ContainsKey(iterationRows) && currentStateOfWorld[iterationRows].Contains(column))
//            {
//                return true;
//            }
//            return false;
//        }
//        public static bool RightNeighborCheck(Dictionary<int, HashSet<int>> currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
//        {
//            var column = RightCellColumnCheck(iterationCols, cols);
//            if (currentStateOfWorld.ContainsKey(iterationRows) && currentStateOfWorld[iterationRows].Contains(column))
//            {
//                return true;
//            }
//            return false;
//        }
//        public static bool BelowLeftNeighborCheck(Dictionary<int, HashSet<int>> currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
//        {
//            var row = BelowCellRowCheck(iterationRows, rows);
//            var column = LeftCellColumnCheck(iterationCols, cols);

//            if (currentStateOfWorld.ContainsKey(row) && currentStateOfWorld[row].Contains(column))
//            {
//                return true;
//            }
//            return false;
//        }

//        public static bool BelowNeighborCheck(Dictionary<int, HashSet<int>> currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
//        {
//            var row = BelowCellRowCheck(iterationRows, rows);

//            if (currentStateOfWorld.ContainsKey(row) && currentStateOfWorld[row].Contains(iterationCols))
//            {
//                return true;
//            }
//            return false;
//        }
//        public static bool BelowRightNeighborCheck(Dictionary<int, HashSet<int>> currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
//        {
//            var row = BelowCellRowCheck(iterationRows, rows);
//            var column = RightCellColumnCheck(iterationCols, cols);

//            if (currentStateOfWorld.ContainsKey(row) && currentStateOfWorld[row].Contains(column))
//            {
//                return true;
//            }
//            return false;
//        }


//        public static int AboveCellRowCheck(int iterationRows, int maxRows)
//        {
//            return iterationRows - 1 < 0 ? maxRows - 1 : iterationRows - 1;
//        }
//        public static int BelowCellRowCheck(int iterationRows, int maxRows)
//        {
//            return iterationRows + 1 == maxRows ? 0 : iterationRows + 1;
//        }
//        public static int LeftCellColumnCheck(int iterationCols, int maxColumns)
//        {
//            return iterationCols - 1 < 0 ? maxColumns - 1 : iterationCols - 1;
//        }
//        public static int RightCellColumnCheck(int iterationCols, int maxColumns)
//        {
//            return iterationCols + 1 == maxColumns ? 0 : iterationCols + 1;
//        }
//        public static void AddingElementToDictionary(ref Dictionary<int, bool[]> currentStateOfWorld, int index, bool[] arr)
//        {
//            bool isAnyMemberAlive = arr.Any(x => x);
//            if (currentStateOfWorld.ContainsKey(index) && isAnyMemberAlive)
//            {
//                currentStateOfWorld[index] = arr;
//            }
//            else
//            {
//                if (!currentStateOfWorld.ContainsKey(index))
//                {
//                    currentStateOfWorld.Add(index, arr);
//                }
//            }
//        }
//    }
//}