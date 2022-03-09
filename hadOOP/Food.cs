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
        private Random Random = new Random();

        public void DrawSelf()
        {
            int xRnd = Random.Next(1, Console.WindowWidth - 1);
            int yRnd = Random.Next(1, Console.WindowHeight - 1);
            Console.SetCursorPosition(xRnd, yRnd);
            Console.Write('F');
        }

        public bool IsCollision(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
