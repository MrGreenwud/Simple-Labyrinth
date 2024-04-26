using Labyrinth.Engine;

public class Scene
{
    protected char[,] _labyrinth = new char[0, 0];
    private List<GameObject> _gameObjects = new List<GameObject>();

    public char[,]? GetLabyrinth()
    {
        return _labyrinth.Clone() as char[,];
    }

    public char[,]? GetScene()
    {
        char[,]? labyrinth = GetLabyrinth();

        if (labyrinth == null)
            throw new InvalidOperationException();

        foreach (GameObject gameObject in _gameObjects)
        {
            int x = gameObject.Position.x;
            int y = gameObject.Position.y;

            labyrinth[y, x] = gameObject.Drower.Symbol;
        }

        return labyrinth;
    }

    public void Draw()
    {
        char[,]? labyrinth = GetLabyrinth();

        if (labyrinth == null)
            throw new InvalidOperationException();

        int hight = labyrinth.GetLength(0);
        int width = labyrinth.GetLength(1);

        ConsoleColor[,] colorBuffer = new ConsoleColor[hight, width];
        colorBuffer.Fill(ConsoleColor.Gray);

        foreach (GameObject gameObject in _gameObjects)
        {
            int x = gameObject.Position.x;
            int y = gameObject.Position.y;

            labyrinth[y, x] = gameObject.Drower.Symbol;
            colorBuffer[y, x] = gameObject.Drower.Color;
        }

        for (int i = 0; i < labyrinth.GetLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                Console.ForegroundColor = colorBuffer[i, j];
                Console.Write(labyrinth[i, j]);
            }

            Console.WriteLine();
        }
    }

    public void Instantiate(GameObject gameObject)
    {
        if (gameObject == null)
            throw new ArgumentNullException();

        _gameObjects.Add(gameObject);
    }

    public void Destroy(GameObject gameObject)
    {
        if (_gameObjects.Contains(gameObject) == false)
            throw new InvalidOperationException();

        _gameObjects.Remove(gameObject);
    }

    public void DestroyByPosition(Vector2 position)
    {
        foreach (GameObject gameObject in _gameObjects)
        {
            if (gameObject.Position.Equals(position))
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
