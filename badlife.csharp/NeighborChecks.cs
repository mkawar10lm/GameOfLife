namespace badlife.csharp
{
    static class NeighborChecks
    {
        public static bool AboveLeftNeighborCheck(bool[][] currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
        {
            return currentStateOfWorld[iterationRows - 1 < 0 ? rows - 1 : iterationRows - 1][iterationCols - 1 < 0 ? cols - 1 : iterationCols - 1];
        }
        public static bool AboveNeighborCheck(bool[][] currentStateOfWorld, int iterationRows, int rows, int iterationCols)
        {
            return currentStateOfWorld[iterationRows - 1 < 0 ? rows - 1 : iterationRows - 1][iterationCols];
        }
        public static bool AboveRightNeighborCheck(bool[][] currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
        {
            return currentStateOfWorld[iterationRows - 1 < 0 ? rows - 1 : iterationRows - 1][iterationCols + 1 == cols ? 0 : iterationCols + 1];
        }
        public static bool LeftNeighborCheck(bool[][] currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
        {
            return currentStateOfWorld[iterationRows][iterationCols - 1 < 0 ? cols - 1 : iterationCols - 1];
        }
        public static bool RightNeighborCheck(bool[][] currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
        {
            return currentStateOfWorld[iterationRows][iterationCols + 1 == cols ? 0 : iterationCols + 1];
        }
        public static bool BelowLeftNeighborCheck(bool[][] currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
        {
            return currentStateOfWorld[iterationRows + 1 == rows ? 0 : iterationRows + 1][iterationCols - 1 < 0 ? cols - 1 : iterationCols - 1];
        }

        public static bool BelowNeighborCheck(bool[][] currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
        {
            return currentStateOfWorld[iterationRows + 1 == rows ? 0 : iterationRows + 1][iterationCols];
        }
        public static bool BelowRightNeighborCheck(bool[][] currentStateOfWorld, int iterationRows, int rows, int iterationCols, int cols)
        {
            return currentStateOfWorld[iterationRows + 1 == rows ? 0 : iterationRows + 1][iterationCols + 1 == cols ? 0 : iterationCols + 1];
        }
    }
}
