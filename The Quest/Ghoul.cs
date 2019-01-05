using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
	class Ghoul : Enemy
	{
		public Ghoul(Game game, Point location) 
			: base(game, location, 10)
		{
		}

		public override void Move(Random random)
		{
			if(HitPoints > 0)
			{
				if(!(random.Next(3) == 1))
				{
					MoveTowardsPlayer();
				}

				if(NearPlayer())
				{
					game.HitPlayer(4, random);
				}
			}
		}
	}
}
