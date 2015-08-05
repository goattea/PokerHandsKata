using System;
using System.Linq;

namespace PokerHands.HandSets
{
	public class Straight : IHandSet
	{
		private const string StraightAceHigh = "AKQJT98765432";
		private const string StraightAceLow = "A5432";

		public double Probability
		{
			get { return Constants.Probability.Straight; }
		}

		public Card HighCard { get; private set; }

		public Straight(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose Straight with hand {0}", hand));

			SetHighCard(hand);

		}

		private void SetHighCard(Hand hand)
		{
			var faces = string.Concat(hand.Cards.Select(f => f.FaceChar).ToArray());
			HighCard = StraightAceLow.Contains(faces) ? hand.Cards[1] : hand.Cards.First();
		}

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((Straight)other) : 
				other.Probability.CompareTo(Probability); ;
		}

		public int CompareTo(Straight other)
		{
			return HighCard.CompareTo(other.HighCard);
		}

		public override string ToString()
		{
			return string.Format("Straight {0} High", HighCard.Face);
		}

		

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			var faces = string.Concat(hand.Cards.Select(f => f.FaceChar).ToArray());
			if (StraightAceHigh.Contains(faces) || StraightAceLow.Contains(faces))
				return true;

			return false;
		}

		public static bool IsAceHighStraight(Hand hand)
		{
			var faces = string.Concat(hand.Cards.Select(f => f.FaceChar).ToArray());
			return StraightAceHigh.StartsWith(faces);
		}
	}
}