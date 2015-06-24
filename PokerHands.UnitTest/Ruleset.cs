using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.UnitTest
{
	public enum HAND_TYPES
	{
		UNKNOWN,
		HIGH_CARD,
		PAIR,
		TWO_PAIR,
		THREE_OF_A_KIND,
		STRAIGHT,
		FLUSH,
		FULL_HOUSE,
		FOUR_OF_A_KIND,
		STRAIGHT_FLUSH
	}

	public interface IRuleset
	{
		HAND_TYPES Rank { get;  }

		string Name { get;  }

		Hand SortHand();
	}

	public class HighCard : IRuleset
	{
		private Hand _hand;
		private string _name;

		public HAND_TYPES Rank
		{
			get { return HAND_TYPES.HIGH_CARD; }
		}

		public string Name
		{
			get { return _name; }
		}

		public HighCard(Hand hand)
		{
			var card = hand.Cards.Last();
			_hand = hand;
			_name = string.Format("{0} High", card.Face);
		}

		public Hand SortHand()
		{
			_hand.Cards.Reverse();
			return _hand;
		}
	}

	public class Pair : IRuleset
	{
		private HAND_TYPES _rank;
		private string _name;
		private Hand _hand;

		public Pair(Hand hand)
		{
			_hand = hand;
			_rank = getRank();
			_name = string.Format("Two Pair: ");
		}

		private HAND_TYPES getRank()
		{
			int j = 1;
			int pairValue;

			for (int i = 0; i < 4; i++)
			{
				if (_hand.Cards[i].Face == _hand.Cards[i+1].Face)
				{
					return HAND_TYPES.PAIR;
				}
			}

			return HAND_TYPES.UNKNOWN;
		}

		public HAND_TYPES Rank
		{
			get { return _rank; }
		}

		public string Name
		{
			get { throw new NotImplementedException(); }
		}

		public Hand SortHand()
		{
			throw new NotImplementedException();
		}
	}
}
