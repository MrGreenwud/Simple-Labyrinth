using Labyrinth.Engine;

public class GameObject
{
    public Vector2 Position;
    public SymbolDrower Drower { get; private set; }

    public GameObject(Vector2 position, SymbolDrower drower)
    {
        Position = position;
        Drower = drower;
    }
}