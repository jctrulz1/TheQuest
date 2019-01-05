using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
	class Bat : Enemy
	{
		public Bat(Game game, Point point)
			: base(game, point, 6)
		{ }

		public override void Move(Random random)
		{
			if(HitPoints > 0)
			{
				if(random.Next(2) == 1)
				{
					MoveTowardsPlayer();
				}
				else
				{
					MoveRandomly(random);
				}
			}

			if(NearPlayer())
			{
				game.HitPlayer(2, random);
			}
		}

		private void MoveRandomly(Random random)
		{
			Direction randomDirection = (Direction)random.Next(4);

			Move(randomDirection, game.Boundaries);
		}
	}
}
