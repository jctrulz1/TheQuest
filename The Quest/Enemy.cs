using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
	abstract class Enemy : Mover
	{
		private const int NearPlayerDistance = 25;

		public int HitPoints { get; private set; }
		public bool Dead
		{
			get
			{
				if(HitPoints <= 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public Enemy(Game game, Point location, int hitPoints)
			: base(game, location)
		{
			HitPoints = hitPoints;
		}

		abstract public void Move(Random random);

		protected void MoveTowardsPlayer()
		{
			Direction playerDirection = FindPlayerDirection(game.PlayerLocation);

			Move(playerDirection, game.Boundaries);
		}

		public void Hit(int maxDamage, Random random)
		{
			HitPoints -= random.Next(1, maxDamage);
		}

		protected bool NearPlayer()
		{
			return Nearby(game.PlayerLocation, NearPlayerDistance);
		}

		protected Direction FindPlayerDirection(Point playerLocation)
		{
			Direction directionToMove;
			if(playerLocation.X > Location.X + 10)
				directionToMove = Direction.Right;
			else if(playerLocation.X < Location.X - 10)
				directionToMove = Direction.Left;
			else if(playerLocation.Y < Location.Y - 10)
				directionToMove = Direction.Up;
			else
				directionToMove = Direction.Down;
			return directionToMove;
		}
	}
}
