using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace The_Quest
{
	abstract class Weapon : Mover
	{
		public abstract string Name { get; }

		public bool PickedUp { get; set; }

		public Weapon(Game game, Point location) : base(game, location)
		{
			PickedUp = false;
		}

		public void PickUpWeapon()
		{
			PickedUp = true;
		}

		public abstract void Attack(Direction direction, Random random);

		protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
		{
			Point target = game.PlayerLocation;
			for(int distance = 0; distance < radius; distance++)
			{
				foreach(Enemy enemy in game.Enemies)
				{
					if(Nearby(enemy.Location, target, distance))
					{
						enemy.Hit(damage, random);
						return true;
					}
				}

				target = Move(direction, target, game.Boundaries);
			}

			return false;
		}

		private Point Move(Direction direction, Point target, Rectangle Boundaries)
		{
			Location = target;
			Point newLocation = Move(direction, Boundaries);
			return newLocation;
		}

		private bool Nearby(Point location, Point target, int distance)
		{
			
		}
	}
}