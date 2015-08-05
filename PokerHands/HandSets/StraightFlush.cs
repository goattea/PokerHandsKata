using System;

namespace PokerHands.HandSets
{
	public class StraightFlush : IHandSet
	{

		public double Probability
		{
			get { return Constants.Probability.StraightFlush; }
		}

		public Card HighCard { get; private set; }

		public StraightFlush(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose Straight Flush with hand {0}", hand));

			SetStraightHighCard(hand);

		}

		private void SetStraightHighCard(Hand hand)
		{
			var straight = new Straight(hand);
			HighCard = straight.HighCard;
		}

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
			return string.Format("Straight Flush {0} High", HighCard.Face);
		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			return Straight.DoesHandMeetCriteria(hand) && Flush.DoesHandMeetCriteria(hand);
		}
	}
}