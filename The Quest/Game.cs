using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;

namespace The_Quest
{ 
	class Game
	{
		public IEnumerable<Enemy> Enemies { get; private set; }
		public Weapon WeaponInRoom { get; private set; }

		public bool Victory { get; set; }

		private Player player;
		public int PlayerHitPoints { get => player.HitPoints;}
		public Point PlayerLocation { get => player.Location; }
		public IEnumerable<string> PlayerWeapons { get => player.Weapons; }

		public int Level { get; private set; } = 0;

		public Rectangle Boundaries { get; }

		public Game(Rectangle boundaries)
		{
			Boundaries = boundaries;
			Victory = false;
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

				case 2:
					Enemies = new List<Enemy>()
					{
						new Ghost(this, GetRandomLocation(random))
					};
					WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
					break;
				case 3:
					Enemies = new List<Enemy>()
					{
						new Ghoul(this, GetRandomLocation(random))
					};
					WeaponInRoom = new Bow(this, GetRandomLocation(random));
					break;
				case 4:
					Enemies = new List<Enemy>()
					{
						new Bat(this, GetRandomLocation(random)),
						new Ghost(this, GetRandomLocation(random))
					};
					if(WeaponInRoom.PickedUp && !CheckPlayerInventory("Blue Potion"))
					{
						WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
					}
					break;
				case 5:
					Enemies = new List<Enemy>()
					{
						new Bat(this, GetRandomLocation(random)),
						new Ghoul(this, GetRandomLocation(random))
					};
					WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
					break;
				case 6:
					Enemies = new List<Enemy>()
					{
						new Ghost(this, GetRandomLocation(random)),
						new Ghoul(this, GetRandomLocation(random))
					};
					WeaponInRoom = new Mace(this, GetRandomLocation(random));
					break;
				case 7:
					Enemies = new List<Enemy>()
					{
						new Ghost(this, GetRandomLocation(random)),
						new Ghoul(this, GetRandomLocation(random))
					};
					if(WeaponInRoom.PickedUp && CheckPlayerInventory("Red Potion"))
					{
						WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
					}
					break;
				default:
					Victory = true;
					Application.Exit();
					break;
			}
		}
	}
}
