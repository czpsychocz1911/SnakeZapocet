using CsvHelper;
using SimpleCMenu.Menu;
using System;
using System.Globalization;
using System.IO;

namespace hadOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu consoleMenu = new ConsoleMenu();
            consoleMenu.addMenuItem(0, "Start", Start);
            consoleMenu.addMenuItem(1, "Register", Register);
            consoleMenu.showMenu();
            
        }

        public static void Register()
        {
            Console.WriteLine("Zadejte uživ jmeno");
            var userName = Console.ReadLine();
            Console.WriteLine("Zadejte heslo");
            var password = Console.ReadLine();
            var user = new User(userName, password, 0);
            user.CreateUser(user);
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
