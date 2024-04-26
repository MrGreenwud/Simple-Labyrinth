namespace Labyrinth.Engine
{
    internal class Engine
    {
        private static void Main(string[] args)
        {
            Level1 level1 = new Level1();

            SymbolDrower playerVisual = new SymbolDrower('A', ConsoleColor.Green);
            GameObject player = new GameObject(new Vector2(1, 1), playerVisual);

            SymbolDrower coinVisual = new SymbolDrower('o', ConsoleColor.Yellow);

            GameObject coin1 = new GameObject(new Vector2(5, 5), coinVisual);
            GameObject coin2 = new GameObject(new Vector2(4, 2), coinVisual);
            GameObject coin3 = new GameObject(new Vector2(10, 5), coinVisual);
            GameObject coin4 = new GameObject(new Vector2(7, 7), coinVisual);
            GameObject coin5 = new GameObject(new Vector2(2, 5), coinVisual);

            level1.Instantiate(player);

            level1.Instantiate(coin1);
            level1.Instantiate(coin2);
            level1.Instantiate(coin3);
            level1.Instantiate(coin4);
            level1.Instantiate(coin5);

            int coins = 0;

            while (true)
            {
                level1.Draw();

                Console.WriteLine($"Coins: {coins}");

                Input.UpdateInput();

                Vector2 newPlayerPosition = player.Position.Clone();

                if (Input.Key == ConsoleKey.W)
                    newPlayerPosition.y--;
                else if (Input.Key == ConsoleKey.S)
                    newPlayerPosition.y++;
                else if (Input.Key == ConsoleKey.A)
                    newPlayerPosition.x--;
                else if (Input.Key == ConsoleKey.D)
                    newPlayerPosition.x++;

                if (level1.GetScene()[newPlayerPosition.y, newPlayerPosition.x] == 'o')
                {
                    coins++;
                    level1.DestroyByPosition(newPlayerPosition);
                }

                if (level1.GetScene()[newPlayerPosition.y, newPlayerPosition.x] != '#')
                    player.Position = newPlayerPosition;

                Console.Clear();
            }
        }
    }
}
