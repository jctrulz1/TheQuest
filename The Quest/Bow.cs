using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
	class Bow : Weapon
	{
		public override string Name => "Arrow";

		public Bow(Game game, Point location) : base(game, location)
		{ }

		public override void Attack(Direction direction, Random random)
		{
			DamageEnemy(direction, 30, 1, random);
		}
	}
}
