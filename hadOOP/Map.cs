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
        readonly Food _food = new Food();
        private bool drawn = false;
        private bool foodGen = false;

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
            if(drawn == false)
            {
                foreach (var mo in _mapObjects)
                {
                    mo.DrawSelf();
                }
                drawn = true;
            }
            if(foodGen == false)
            {
                _food.DrawSelf();
                foodGen = true;
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
