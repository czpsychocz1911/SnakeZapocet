using System;
using System.Collections.Generic;
using System.Text;

namespace hadOOP
{
    public interface IMapObject
    {
        int X { get; }
        int Y { get; }
        void DrawSelf();
        bool IsCollision(int x, int y);
    }
}
