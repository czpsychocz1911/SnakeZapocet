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
            ConsoleMenu loginMenu = new ConsoleMenu();

            ConsoleMenu mainMenu = new ConsoleMenu();

            loginMenu.SubTitle = "-----Login-----";
            loginMenu.SubTitleColor = ConsoleColor.Green;

            mainMenu.SubTitle = "-----Menu-----";
            mainMenu.SubTitleColor = ConsoleColor.Blue;

            loginMenu.addMenuItem(0, "Login", () => Login(mainMenu));
            loginMenu.addMenuItem(1, "Register", Register);
            mainMenu.ParentMenu = loginMenu;
            mainMenu.addMenuItem(0, "Start",Start);
            mainMenu.addMenuItem(1, "High scores", HighScoreList);
            loginMenu.showMenu();
        }

        public static void HighScoreList()
        {
            var user = new User();
            user.LoadUserList();
            foreach(User u in user.users)
            {
                Console.WriteLine(u.UserName + "----" + u.HighScore);
            }
            Console.ReadKey();
        }

        public static void Login(ConsoleMenu consoleMenu)
        {
            Console.WriteLine("Zadej login: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Zadej heslo: ");
            var userPass = Console.ReadLine();
            User user = new User();
            if(user.LoginAsUser(userName,userPass) == true)
            {
                consoleMenu.showMenu();
            }
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
