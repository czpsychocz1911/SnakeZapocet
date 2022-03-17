using SimpleCMenu.Menu;
using System;
namespace hadOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu consoleMenu = new ConsoleMenu();
            consoleMenu.addMenuItem(0, "Start", Start);
            consoleMenu.showMenu();
            
        }

        public static void Start()
        {
            var map = new Map();
            map.Draw();

            try
            {
                while (true)
                {
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            map.MoveSnake(Direction.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            map.MoveSnake(Direction.Down);
                            break;
                        case ConsoleKey.LeftArrow:
                            map.MoveSnake(Direction.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            map.MoveSnake(Direction.Right);
                            break;
                    }
                    map.Draw();
                }
            }
            catch (CollisionException)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Posrals to čůráku");
            }
        }
    }
}
