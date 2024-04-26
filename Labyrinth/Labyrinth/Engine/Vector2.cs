public class Vector2
{
    public int x;
    public int y;

    public Vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 Clone()
    {
        return new Vector2(x, y);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vector2 vector2 == false)
            return false;

        return vector2.x == x && vector2.y == y;
    }
}