using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.Console
{
	class Program
	{
		static void Main()
		{
			//Sample input:
			//Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH
			//Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S
			//Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C KH
			//Black: 2H 3D 5S 9C KD  White: 2D 3H 5C 9S KH


			var pokerGames = new List<PokerGame>();

			while (true)
			{
				var input = System.Console.ReadLine();
				if (string.IsNullOrEmpty(input))
					break;
				pokerGames.Add(new PokerGame(input));
			}

			foreach (PokerGame game in pokerGames)
			{
				game.Player1.Hand.Analyze();
				game.Player2.Hand.Analyze();
				var result = game.Player1.Hand.HandSet.CompareTo(game.Player2.Hand.HandSet);

				switch (result)
				{
					case 1:
						System.Console.WriteLine("{0} wins with {1}", game.Player1.Player, game.Player1.Hand);
						break;

					case -1:
						System.Console.WriteLine("{0} wins with {1}", game.Player2.Player, game.Player2.Hand);
						break;

					default:
						System.Console.WriteLine("Push");
						break;
				}

			}


			System.Console.ReadLine();
		}


	}
}
