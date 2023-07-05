public static class Matrix
{
    public static int GetAreaCount(string matrixString)
    {
        var dimensions = GetDimensions(matrixString);
        var matrix = GetMatrix(matrixString, dimensions);
        var result = 0;
        for (var i = 0; i < matrix.GetLength(0); i++)
            for (var j = 0; j < matrix.GetLength(1); j++)
                if (MarkArea(matrix, i, j))
                    result++;

        return result;
    }

    public static (int, int) GetDimensions(string matrixString)
    {
        var width = 1;
        var height = 1;
        var i = 0;

        for (; i < matrixString.Length && matrixString[i] != ';'; i++)
            if (matrixString[i] == ',')
                width++;

        for (; i < matrixString.Length; i++)
            if (matrixString[i] == ';')
                height++;

        return (width, height);
    }

    private static bool MarkArea(byte[,] matrix, int i, int j)
    {
        if (matrix[i, j] != 1)
            return false;
        matrix[i, j] = 2;
        if (i > 0)
            MarkArea(matrix, i - 1, j);
        if (j > 0)
            MarkArea(matrix, i, j - 1);
        if (i < matrix.GetLength(0) - 1)
            MarkArea(matrix, i + 1, j);
        if (j < matrix.GetLength(1) - 1)
            MarkArea(matrix, i, j + 1);
        return true;
    }

    private static byte[,] GetMatrix(string matrixString, (int, int) dimensions)
    {
        var (width, height) = dimensions;
        var matrix = new byte[height, width];
        var i = 0;
        var j = 0;
        foreach (var value in matrixString)
        {
            switch (value)
            {
                case ',':
                    j++;
                    if (j >= width)
                        throw new ArgumentException("Width exceeded", nameof(matrixString));
                    break;
                case ';':
                    i++;
                    j = 0;
                    break;
                default:
                    matrix[i, j] = (byte)(value - '0');
                    break;
            }
        }
        return matrix;
    }
}
