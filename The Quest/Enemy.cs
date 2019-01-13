using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using System.Drawing;

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

			Location = Move(playerDirection, game.Boundaries);
		}

		public void Hit(int maxDamage, Random random)
		{
			HitPoints -= random.Next(1, maxDamage);
			if(HitPoints < 0)
			{
				HitPoints = 0;
			}
		}

		protected bool NearPlayer()
		{
			return Nearby(game.PlayerLocation, NearPlayerDistance);
		}

		protected Direction FindPlayerDirection(Point playerLocation)
		{
			Direction directionToMove;
			if(playerLocation.X > Location.X + 50)
				directionToMove = Direction.Right;
			else if(playerLocation.X < Location.X - 50)
				directionToMove = Direction.Left;
			else if(playerLocation.Y < Location.Y - 50)
				directionToMove = Direction.Up;
			else
				directionToMove = Direction.Down;
			return directionToMove;
		}
	}
}
