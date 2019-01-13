using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace The_Quest
{
	class Player : Mover
	{
		private Weapon equippedWeapon;

		private List<Weapon> inventory = new List<Weapon>();

		public int HitPoints { get; private set; }

		public IEnumerable<string> Weapons
		{
			get
			{
				List<string> names = new List<string>();
				foreach(Weapon weapon in inventory)
				{
					names.Add(weapon.Name);
				}

				return names;
			}
		}

		public Player(Game game, Point location)
			:base(game, location)
		{
			HitPoints = 10;
			equippedWeapon = null;
		}

		public void Move(Direction direction)
		{
			Location = Move(direction, game.Boundaries);
			if(!game.WeaponInRoom.PickedUp)
			{
				if(Nearby(game.WeaponInRoom.Location, Location, 50))
				{
					if(!inventory.Contains(game.WeaponInRoom))
					{
						inventory.Add(game.WeaponInRoom);

						if(inventory.Count == 1)
						{
							equippedWeapon = game.WeaponInRoom;
						}

						game.WeaponInRoom.PickUpWeapon();
					}
				}
			}
		}

		public void Equip(string weaponName)
		{
			foreach(Weapon weapon in inventory)
			{
				if(weapon.Name == weaponName)
				{
					equippedWeapon = weapon;
				}
			}
		}

		public void Hit(int maxDamage, Random random)
		{
			HitPoints -= random.Next(1, maxDamage);
		}

		public void IncreaseHealth(int health, Random random)
		{
			HitPoints += random.Next(1, health);
		}

		public void Attack(Direction direction, Random random)
		{
			if(equippedWeapon != null)
			{
				equippedWeapon.Attack(direction, random);
			}
		}

		public bool ContainWeapon(string weaponName)
		{
			return Weapons.Contains(weaponName);
		}

	}
}
