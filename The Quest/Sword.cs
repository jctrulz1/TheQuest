using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
	class Sword : Weapon
	{
		public override string Name => "Sword";

		public Sword(Game game, Point location)
			: base(game, location)
		{ }

		public override void Attack(Direction direction, Random random)
		{
			if(DamageEnemy(direction, 10, 3, random))
			{
				return;
			}

			if(direction == Direction.Left)
			{
				direction = Direction.Up;
			}

			if(DamageEnemy(direction, 10, 3, random))
			{
				return;
			}

			if(direction == Direction.Up)
			{
				direction = Direction.Left;
			}

			DamageEnemy(direction, 10, 3, random);
		}
	}
}
