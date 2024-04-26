public static class ArrayExtention
{
    public static void Fill<T>(this T[,] array, T value)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                array[i, j] = value;
        }
    }
}