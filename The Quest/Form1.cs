using System;
using System.Drawing;
using System.Windows.Forms;

namespace The_Quest
{
	public partial class Form1 : Form
	{
		private Game game;
		private Random random = new Random();

		public Form1()
		{
			InitializeComponent();

			DoubleBuffered = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			game = new Game(new Rectangle(100, 65, 560, 175));
			game.NewLevel(random);
			UpdateCharacters();
			playerHitPointsLBL.Text = game.PlayerHitPoints.ToString();
		}

		private void UpdateCharacters()
		{
			UpdatePlayer();

			int enemiesShown = UpdateEnemiesAndReturnEnemiesShown();

			Control weaponControl = DisplayWeaponInRoom();

			DisplayInventory();

			weaponControl.Location = game.WeaponInRoom.Location;
			if(game.WeaponInRoom.PickedUp)
			{
				weaponControl.Visible = false;
			}
			else
			{
				weaponControl.Visible = true;
			}

			if(game.PlayerHitPoints <= 0)
			{
				MessageBox.Show("You ded");
				Application.Exit();
			}
			if(enemiesShown < 1)
			{
				MessageBox.Show("You have defeated the enemies on this level");
				game.NewLevel(random);
				if(!game.Victory)
				{
					UpdateCharacters();
				}
			}
		}

		private void DisplayInventory()
		{
			if(game.CheckPlayerInventory("Sword"))
			{
				inventorySwordPB.Visible = true;
			}

			if(game.CheckPlayerInventory("Bow"))
			{
				inventoryBowPB.Visible = true;
			}

			if(game.CheckPlayerInventory("Mace"))
			{
				inventoryMacePB.Visible = true;
			}

			if(game.CheckPlayerInventory("Blue Potion"))
			{
				inventoryBluePotionPB.Visible = true;
			}

			if(game.CheckPlayerInventory("Red Potion"))
			{
				inventoryRedPotionPB.Visible = true;
			}
		}

		private Control DisplayWeaponInRoom()
		{
			swordPB.Visible = false;
			bowPB.Visible = false;
			redPotionPB.Visible = false;
			bluePotionPB.Visible = false;
			macePB.Visible = false;
			Control weaponControl = null;
			switch(game.WeaponInRoom.Name)
			{
				case "Sword":
					weaponControl = swordPB; break;
				case "Bow":
					weaponControl = bowPB; break;
				case "Mace":
					weaponControl = macePB; break;
				case "Blue Potion":
					weaponControl = bluePotionPB; break;
				case "Red Potion":
					weaponControl = redPotionPB; break;
				default:
					break;
			}

			weaponControl.Visible = true;

			return weaponControl;
		}

		private void UpdatePlayer()
		{
			playerPB.Location = game.PlayerLocation;
			playerHitPointsLBL.Text = game.PlayerHitPoints.ToString();
		}

		private int UpdateEnemiesAndReturnEnemiesShown()
		{
			int enemiesShown = 0;

			bool showBat = false;
			bool showGhost = false;
			bool showGhoul = false;

			foreach(Enemy enemy in game.Enemies)
			{
				if(enemy is Bat)
				{
					batPB.Location = enemy.Location;
					batHitPointsLBL.Text = enemy.HitPoints.ToString();
					batPB.Visible = true;

					if(enemy.HitPoints > 0)
					{
						showBat = true;
					}
				}

				else if(enemy is Ghost)
				{
					ghostPB.Location = enemy.Location;
					ghostHitPointsLBL.Text = enemy.HitPoints.ToString();
					ghostPB.Visible = true;

					if(enemy.HitPoints > 0)
					{
						showGhost = true;
					}
				}

				else if(enemy is Ghoul)
				{
					ghoulPB.Location = enemy.Location;
					ghoulHitPointsLBL.Text = enemy.HitPoints.ToString();
					ghoulPB.Visible = true;

					if(enemy.HitPoints > 0)
					{
						showGhoul = true;
					}
				}

				if(!showBat)
				{
					batPB.Visible = false;
				}
				if(!showGhost)
				{
					ghostPB.Visible = false;
				}
				if(!showGhoul)
				{
					ghoulPB.Visible = false;
				}
				if(!enemy.Dead)
				{
					enemiesShown++;
				}
			}

			return enemiesShown;
		}

		private void UpdateEnemy(Enemy enemy)
		{
			
		}

		private void moveUpBtn_Click(object sender, EventArgs e)
		{
			MoveUp();
		}

		private void moveRightBtn_Click(object sender, EventArgs e)
		{
			MoveRight();
		}

		private void moveLeftBtn_Click(object sender, EventArgs e)
		{
			MoveLeft();
		}

		private void moveDownBtn_Click(object sender, EventArgs e)
		{
			MoveDown();
		}

		private void attackUpBtn_Click(object sender, EventArgs e)
		{
			AttackUp();
		}

		private void attackLeftBtn_Click(object sender, EventArgs e)
		{
			AttackLeft();
		}

		private void attackRightBtn_Click(object sender, EventArgs e)
		{
			AttackRight();
		}

		private void attackDownBtn_Click(object sender, EventArgs e)
		{
			AttackDown();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.W:
					MoveUp();
					break;
				case Keys.S:
					MoveDown();
					break;
				case Keys.D:
					MoveRight();
					break;
				case Keys.A:
					MoveLeft();
					break;
				case Keys.I:
					AttackUp();
					break;
				case Keys.K:
					AttackDown();
					break;
				case Keys.L:
					AttackRight();
					break;
				case Keys.J:
					AttackLeft();
					break;
			}
		}

		private void MoveLeft()
		{
			game.Move(Direction.Left, random);
			UpdateCharacters();
		}

		private void MoveRight()
		{
			game.Move(Direction.Right, random);
			UpdateCharacters();
		}

		private void MoveDown()
		{
			game.Move(Direction.Down, random);
			UpdateCharacters();
		}

		private void MoveUp()
		{
			game.Move(Direction.Up, random);
			UpdateCharacters();
		}

		private void AttackUp()
		{
			game.Attack(Direction.Up, random);
			UpdateCharacters();
		}

		private void AttackDown()
		{
			game.Attack(Direction.Down, random);
			UpdateCharacters();
		}

		private void AttackRight()
		{
			game.Attack(Direction.Right, random);
			UpdateCharacters();
		}

		private void AttackLeft()
		{
			game.Attack(Direction.Left, random);
			UpdateCharacters();
		}

		private void DisplayEquippedWeaponInventory(string weaponName)
		{
			inventorySwordPB.BorderStyle = BorderStyle.None;
			inventoryBowPB.BorderStyle = BorderStyle.None;
			inventoryMacePB.BorderStyle = BorderStyle.None;
			inventoryBluePotionPB.BorderStyle = BorderStyle.None;
			inventoryRedPotionPB.BorderStyle = BorderStyle.None;

			switch(weaponName)
			{
				case "Sword":
					inventorySwordPB.BorderStyle = BorderStyle.FixedSingle;
					break;
				case "Bow":
					inventoryBowPB.BorderStyle = BorderStyle.FixedSingle;
					break;
				case "Mace":
					inventoryMacePB.BorderStyle = BorderStyle.FixedSingle;
					break;
				case "Blue Potion":
					inventoryBluePotionPB.BorderStyle = BorderStyle.FixedSingle;
					break;
				case "Red Potion":
					inventoryRedPotionPB.BorderStyle = BorderStyle.FixedSingle;
					break;
			}
		}

		private void inventoryBluePotionPB_Click(object sender, EventArgs e)
		{
			string weaponName = "Blue Potion";
			game.Equip(weaponName);
			DisplayEquippedWeaponInventory(weaponName);
		}

		private void inventoryRedPotionPB_Click(object sender, EventArgs e)
		{
			string weaponName = "Red Potion";
			game.Equip(weaponName);
			DisplayEquippedWeaponInventory(weaponName);
		}

		private void inventoryMacePB_Click(object sender, EventArgs e)
		{
			string weaponName = "Mace";
			game.Equip(weaponName);
			DisplayEquippedWeaponInventory(weaponName);
		}

		private void inventoryBowPB_Click(object sender, EventArgs e)
		{
			string weaponName = "Bow";
			game.Equip(weaponName);
			DisplayEquippedWeaponInventory(weaponName);
		}

		private void inventorySwordPB_Click(object sender, EventArgs e)
		{
			string weaponName = "Sword";
			game.Equip(weaponName);
			DisplayEquippedWeaponInventory(weaponName);
		}
	}
}