public class SymbolDrower
{
    public char Symbol { get; private set; }
    public ConsoleColor Color { get; private set; }

    public SymbolDrower(char symbol, ConsoleColor color)
    {
        Symbol = symbol;
        Color = color;
    }
}