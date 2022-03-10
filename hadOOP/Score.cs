using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hadOOP
{
    class Score : IMapObject
    {
        public int X => throw new NotImplementedException();

        public int Y => throw new NotImplementedException();

        public int Count { get; set; }

        public void DrawSelf()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Vaše skore je: " + Count);
        }

        public bool IsCollision(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
