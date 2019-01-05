using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
	class Player : Mover
	{
		private Weapon equippedWeapon;
		
		public int HitPoints { get; private set; }

		private List<Weapon> inventory = new List<Weapon>();

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
		}

		public void Move(Direction direction)
		{
			Location = Move(direction, game.Boundaries);
			if(!game.WeaponInRoom.PickedUp)
			{
				// See if weapon is nearby, and possibly pick it up
				// If so, pick it up and add it to the player's inventory.
				// If it's the only weapon, equip it immediately
			
				
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

		}

		public bool ContainWeapon(string weaponName)
		{
			return Weapons.Contains(weaponName);
		}

	}
}
