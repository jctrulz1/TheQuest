using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace The_Quest
{
	class BluePotion : Weapon, IPotion
	{
		public override string Name => "Blue Potion";

		public bool Used { get; private set; }

		public BluePotion(Game game, Point location) : base(game, location)
		{
			Used = false;
		}

		public override void Attack(Direction direction, Random random)
		{
			if(!Used)
			{
				game.IncreasePlayerHealth(5, random);
				Used = true;
			}
		}
	}
}
