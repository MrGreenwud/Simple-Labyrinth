public static class Input
{
    public static ConsoleKey Key { get; private set; }

    public static void UpdateInput()
    {
        Key = Console.ReadKey().Key;
    }
}