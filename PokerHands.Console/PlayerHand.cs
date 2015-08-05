using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.Console
{
	internal class PlayerHand
	{
		public string Player { get; private set; }
		public Hand Hand { get; private set; }

		public PlayerHand(string playerName, string handInput)
		{
			Player = playerName;
			Hand = new Hand(handInput);
		}
	}
}
