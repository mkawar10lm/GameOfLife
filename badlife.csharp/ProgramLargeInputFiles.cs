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
//            leet();
//            //Reading the intial input for game
//            var input = new StreamReader("sample_input.txt");
//            var allText = input.ReadToEnd();
//            var lines = allText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

//            // If the input file is empty, the code can be terminated.
//            // The data checks here can be extended. 
//            // 1) Check if the files only contain "*" and "_"
//            // 2) All the lines should have same number of characters. 

//            if (!lines.Any())
//            {
//                return;
//            }

//            // Creating the current state of world with boolean variables
//            var currentStateOfWorld = new Dictionary<int, bool[]>();
//            int indexOfLastRow = 0;
//            int index = 0;
            
//            for (int indexOfLines = 0; indexOfLines < lines.Length; ++indexOfLines)
//            {
//                if (lines[indexOfLines].Contains("*"))
//                {
//                    if (indexOfLines - indexOfLastRow > 1)
//                    {
//                        currentStateOfWorld.Add(index, new bool[lines[indexOfLines].Count()]);
//                        currentStateOfWorld.Add(index + 1, lines[indexOfLines].Select(x => x.Equals('*')).ToArray());
//                        index = index + 2;
//                    }
//                    else
//                    {
//                        currentStateOfWorld.Add(index, lines[indexOfLines].Select(x => x.Equals('*')).ToArray());
//                        index = index + 1;
//                    }
//                    indexOfLastRow = indexOfLines;
//                }
//            }

//            Evolve(currentStateOfWorld);

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
//        public static void Evolve(Dictionary<int, bool[]> currentStateOfWorld)
//        {
//            var rows = currentStateOfWorld.Count;
//            var cols = currentStateOfWorld[0].Length;

//            // The first condition is checking if the game round is less than max number of games
//            // and the input has atleast one alive cell

//            for (var iterationRows = 0; iterationRows < currentStateOfWorld.Count; ++iterationRows)
//            {
//                for (var iterationCols = 0; iterationCols < currentStateOfWorld[iterationRows].Length; ++iterationCols)
//                {
//                    //Checking the situation of neighbors
//                    int neighbors = 0;
//                    if (NeighborChecks.AboveLeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
//                    if (NeighborChecks.AboveNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols)) neighbors++;
//                    if (NeighborChecks.AboveRightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
//                    if (NeighborChecks.LeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
//                    if (NeighborChecks.RightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
//                    if (NeighborChecks.BelowLeftNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
//                    if (NeighborChecks.BelowNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;
//                    if (NeighborChecks.BelowRightNeighborCheck(currentStateOfWorld, iterationRows, rows, iterationCols, cols)) neighbors++;

//                    // Updating the world
//                    if (currentStateOfWorld[iterationRows][iterationCols] && neighbors < 2) currentStateOfWorld[iterationRows][iterationCols] = false;
//                    if (currentStateOfWorld[iterationRows][iterationCols] && (neighbors == 2 || neighbors == 3)) currentStateOfWorld[iterationRows][iterationCols] = true;
//                    if (currentStateOfWorld[iterationRows][iterationCols] && neighbors > 3) currentStateOfWorld[iterationRows][iterationCols] = false;
//                    if (!currentStateOfWorld[iterationRows][iterationCols] && neighbors == 3) currentStateOfWorld[iterationRows][iterationCols] = true;
//                }
//            }
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
//        public static int leet()
//        {
//            int[] people = new int[] { 3, 5, 3, 4 };
//            int limit = 5;
//            Array.Sort(people);
//            int boatCount = 0;
//            int i = people.Count() - 1;
//            Dictionary<int, bool> peopleStatus = new Dictionary<int, bool>();

//            for (int j = 0; j < people.Count(); j++)
//            {
//                peopleStatus.Add(j, false);
//            }
//            while (i >= 0)
//            {
//                if (!peopleStatus[i])
//                {
//                    int weightDiff = limit - people[i];
//                    if (weightDiff == 0)
//                    {
//                        boatCount = boatCount + 1;
//                    }
//                    else
//                    {
//                        int sumWeight = 0;
//                        for (int m = 0; m < people.Count(); m++)
//                        {
//                            sumWeight = sumWeight + people[m];
//                            if (weightDiff > sumWeight)
//                            {
//                                peopleStatus[m] = true;
//                            }
//                            else
//                            {
//                                boatCount = boatCount + 1;
//                                break;
//                            }

//                        }
//                    }
//                }
//                peopleStatus[i] = true;
//                i = i - 1;
//            }
//            return boatCount;

//        }
//    }
//}