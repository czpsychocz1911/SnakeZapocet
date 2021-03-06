using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hadOOP
{
    class Snake : IMovableMapObject
    {
        record Point(int X, int Y);

        List<Point> _bodyPoints = new List<Point>() { new Point(Console.WindowWidth / 2, Console.WindowHeight / 2) };

        public int X => _bodyPoints[0].X;

        public int Y => _bodyPoints[0].Y;

        public void DrawSelf()
        {
            foreach (var (X, Y) in _bodyPoints)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("-");
            }
        }

        public void Move(Direction direction)
        {
            var headOriginalPosition = _bodyPoints[0];
            var tailPosition = _bodyPoints.LastOrDefault();
            switch (direction)
            {
                case Direction.Down:
                    Console.SetCursorPosition(tailPosition.X,tailPosition.Y);
                    Console.Write(' ');
                    _bodyPoints[0] = _bodyPoints[0] with { Y = _bodyPoints[0].Y + 1 };
                    break;
                case Direction.Up:
                    Console.SetCursorPosition(tailPosition.X, tailPosition.Y);
                    Console.Write(' ');
                    _bodyPoints[0] = _bodyPoints[0] with { Y = _bodyPoints[0].Y - 1 };
                    break;
                case Direction.Left:
                    Console.SetCursorPosition(tailPosition.X, tailPosition.Y);
                    Console.Write(' ');
                    _bodyPoints[0] = _bodyPoints[0] with { X = _bodyPoints[0].X - 1 };
                    break;
                case Direction.Right:
                    Console.SetCursorPosition(tailPosition.X, tailPosition.Y);
                    Console.Write(' ');
                    _bodyPoints[0] = _bodyPoints[0] with { X = _bodyPoints[0].X + 1 };
                    break;
                default:
                    throw new ArgumentException();
            }

            for(int i = 1; i < _bodyPoints.Count; i++)
            {
                var tmp = _bodyPoints[i];
                _bodyPoints[i] = headOriginalPosition;
                headOriginalPosition = tmp;
            }

            if(_bodyPoints.Skip(1).Any(a=>a.X == _bodyPoints[0].X && a.Y == _bodyPoints[0].Y))
            {
                throw new CollisionException();
            }
        }

        public void grow()
        {
            Point point = new Point(X, Y);
            _bodyPoints.Add(point);
        }

        public bool IsCollision(int x, int y)
        {
            if(_bodyPoints[0].X == x && _bodyPoints[0].Y == y)
            {
                grow();
                return true;
            }
            return false;
        }
    }
}
