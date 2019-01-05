using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
	class RedPotion : Weapon, IPotion
	{
		public override string Name => "Red Potion";

		public bool Used { get; private set; }

		public RedPotion(Game game, Point location) : base(game, location)
		{
			Used = false;
		}

		public override void Attack(Direction direction, Random random)
		{
			Used = true;

			game.IncreasePlayerHealth(10, random);
		}
	}
}
