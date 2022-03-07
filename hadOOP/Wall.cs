using System;
using System.Collections.Generic;
using System.Text;

namespace hadOOP
{
    class Wall:IMapObject
    {
        public int X { get; }
        public int Y { get; }

        public Wall(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DrawSelf()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("*");
        }

        public bool IsCollision(int x, int y)
        {
            return X == x && Y == y;
        }
    }
}
