using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace The_Quest
{
	abstract class Mover
	{
		private const int MoveInterval = 10;

		public Point Location { get; protected set; }

		protected Game game;

		public Mover(Game game, Point location)
		{
			this.game = game;
			Location = location;
		}

		public bool Nearby(Point locationToCheck, int distance)
		{
			return Nearby(locationToCheck, Location, distance);
		}

		public bool Nearby(Point locationToCheck, Point target, int distance)
		{
			return Math.Abs(target.X - locationToCheck.X) < distance &&
				Math.Abs(target.Y - locationToCheck.Y) < distance;
		}

		public Point Move(Direction direction, Rectangle boundaries)
		{
			return Move(direction, Location, boundaries);
		}

		public Point Move(Direction direction, Point target, Rectangle boundaries)
		{
			Point newLocation = target;
			switch(direction)
			{
				case Direction.Up:
					if(newLocation.Y - MoveInterval >= boundaries.Top)
						newLocation.Y -= MoveInterval;
					break;
				case Direction.Down:
					if(newLocation.Y + MoveInterval <= boundaries.Bottom)
						newLocation.Y += MoveInterval;
					break;
				case Direction.Left:
					if(newLocation.X - MoveInterval >= boundaries.Left)
						newLocation.X -= MoveInterval;
					break;
				case Direction.Right:
					if(newLocation.X + MoveInterval <= boundaries.Right)
						newLocation.X += MoveInterval;
					break;
				default: 
					break;
			}

			return newLocation;
		}
	}
}
