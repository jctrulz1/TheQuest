using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;


namespace The_Quest
{
	class Mace : Weapon
	{
		public Mace(Game game, Point location) 
			: base(game, location)
		{ }

		public override string Name => "Mace";

		public override void Attack(Direction direction, Random random)
		{
			for(int i = 0; i < 4; i++)
			{
				if(DamageEnemy(direction, 20, 6, random))
				{
					return;
				}
			}
		}
	}
}
