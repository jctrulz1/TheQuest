using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{ 
	class Game
	{
		public IEnumerable<Enemy> Enemies { get; private set; }
		public Weapon WeaponInRoom { get; private set; }

		private Player player;
		public Point PlayerLocation { get => player.Location; }
		public IEnumerable<string> PlayerWeapons { get => player.Weapons; }

		public int Level { get; private set; } = 0;

		public Rectangle Boundaries { get; }

		public Game(Rectangle boundaries)
		{
			Boundaries = boundaries;
			player = new Player(this, new Point(boundaries.Left + 10, boundaries.Top + 70));
		}

		public void Move(Direction direction, Random random)
		{
			player.Move(direction);
			foreach(Enemy enemy in Enemies)
			{
				enemy.Move(random);
			}
		}

		public void Equip(string weaponName)
		{
			player.Equip(weaponName);
		}

		public bool CheckPlayerInventory(string weaponName)
		{
			return player.ContainWeapon(weaponName);
		}

		public void HitPlayer(int maxDamage, Random random)
		{
			player.Hit(maxDamage, random);
		}

		public void IncreasePlayerHealth(int health, Random random)
		{
			player.IncreaseHealth(health, random);
		}

		public void Attack(Direction direction, Random random)
		{
			player.Attack(direction, random);
			foreach(Enemy enemy in Enemies)
			{
				enemy.Move(random);
			}
		}

		private Point GetRandomLocation(Random random)
		{
			return new Point(Boundaries.Left + random.Next(Boundaries.Right / 10 - Boundaries.Left / 10) * 10, Boundaries.Top + random.Next(Boundaries.Bottom / 10 - Boundaries.Top / 10) * 10);
		}

		public void NewLevel(Random random)
		{
			Level++;
			switch(Level)
			{
				case 1:
					Enemies = new List<Enemy>()
					{
						new Bat(this, GetRandomLocation(random))
					};
					WeaponInRoom = new Sword(this, GetRandomLocation(random));
					break;
			}
		}
	}
}
