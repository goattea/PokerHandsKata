using System;

namespace PokerHands.HandSets
{
	public class StraightFlush : IHandSet
	{
		private Card _highCard;
		
		public double Probability
		{
			get { return Constants.Probability.StraightFlush; }
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
				CompareTo((StraightFlush)other) : 
				other.Probability.CompareTo(Probability); 
		}

		public int CompareTo(StraightFlush other)
		{
			return HighCard.CompareTo(other.HighCard);
		}

		public override string ToString()
		{
			return string.Format("Straight Flush {0} High", _highCard.Face);
		}

		public StraightFlush(Hand hand)
		{
			Hand = hand;
			if(!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose Straight Flush with hand {0}", Hand));

			SetStraightHighCard();

		}

		private void SetStraightHighCard()
		{
			var straight = new Straight(Hand);
			_highCard = straight.HighCard;
		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			return Straight.DoesHandMeetCriteria(hand) && Flush.DoesHandMeetCriteria(hand);
		}
	}
}