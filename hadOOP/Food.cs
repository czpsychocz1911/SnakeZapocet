using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hadOOP
{
    class Food : IMapObject
    {
        public int X { get; }

        public int Y { get; }

        public Food()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            X = rnd.Next(4, Console.WindowWidth - 4);
            Y = rnd.Next(4, Console.WindowHeight - 4);
        }

        public void DrawSelf()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('F');
        }

        public bool IsCollision(int x, int y)
        {
            return X == x && Y == y;
        }
    }
}
