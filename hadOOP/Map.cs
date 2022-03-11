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
        private Score score = new Score();
        private bool drawn = false;

        public Map()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                _mapObjects.Add(new Wall(i, 1));
                _mapObjects.Add(new Wall(i, Console.WindowHeight - 1));
            }
            for (int i = 1; i < Console.WindowHeight - 1; i++)
            {
                _mapObjects.Add(new Wall(0, i));
                _mapObjects.Add(new Wall(Console.WindowWidth - 1, i));
            }
            score.Count = 0;
            score.DrawSelf();
            _mapObjects.Add(new Food());
        }

        public void Draw()
        {
            FoodCollison();
            if (drawn == false)
            {
                foreach (var mo in _mapObjects)
                {
                    mo.DrawSelf();
                }
                drawn = true;
            }
            _snake.DrawSelf();
        }

        public void MoveSnake(Direction direction)
        {
            _snake.Move(direction);
            FoodCollison();
            if (_mapObjects.Any(a => a.IsCollision(_snake.X, _snake.Y)))
            {
                throw new CollisionException();
            }
        }

        protected void FoodCollison()
        {
            var food = _mapObjects.Where(a => a is Food).FirstOrDefault(a => a.IsCollision(_snake.X, _snake.Y));
            if (food != null)
            {
                score.Count++;
                score.DrawSelf();
                _mapObjects.Remove(food);
                food = new Food();
                _mapObjects.Add(food);
                food.DrawSelf();
            }
        }
    }
}
