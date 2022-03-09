using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hadOOP
{
    class Map
    {
        readonly List<IMapObject> _mapObjects = new List<IMapObject>();
        readonly IMovableMapObject _snake = new Snake();

        public Map()
        {
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                _mapObjects.Add(new Wall(i, 0));
                _mapObjects.Add(new Wall(i, Console.WindowHeight-1));
            }
            for(int i = 1; i < Console.WindowHeight-1; i++)
            {
                _mapObjects.Add(new Wall(0, i));
                _mapObjects.Add(new Wall(Console.WindowWidth-1, i));
            }
        }

        public void Draw()
        {
            foreach(var mo in _mapObjects)
            {
                mo.DrawSelf();
            }
            _snake.DrawSelf();
        }

        public void MoveSnake(Direction direction)
        {
            _snake.Move(direction);
            if (_mapObjects.Any(a => a.IsCollision(_snake.X, _snake.Y)))
            {
                throw new CollisionException();
            }
        }
    }
}
