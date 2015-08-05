using System;
using System.Linq;

namespace PokerHands.HandSets
{
	public class Flush : IHandSet
	{
		private Card _highCard;

		public double Probability
		{
			get { return Constants.Probability.Flush; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public Hand Hand { get; private set; }

		public Card HighCard { get {return _highCard; } }

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((Flush)other) : 
				other.Probability.CompareTo(Probability);
		}

		public int CompareTo(Flush other)
		{
			return HighCard.CompareTo(other.HighCard);
		}

		public override string ToString()
		{
			return string.Format("Flush {0} High", _highCard.Face);
		}

		public Flush(Hand hand)
		{
			Hand = hand;
			if(!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose Flush with hand {0}", Hand));
			
			_highCard = Hand.Cards.First();
			
		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			return hand.Cards.GroupBy(f => f.SuitChar).Count() == 1;
		}
	}
}