using System;
using System.Linq;

namespace PokerHands.HandSets
{
	public class Straight : IHandSet
	{
		private Card _highCard;
		private const string StraightAceHigh = "AKQJT98765432";
		private const string StraightAceLow = "A5432";

		public double Probability
		{
			get { return Constants.Probability.Straight; }
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
				CompareTo((Straight)other) : 
				other.Probability.CompareTo(Probability); ;
		}

		public int CompareTo(Straight other)
		{
			return HighCard.CompareTo(other.HighCard);
		}

		public override string ToString()
		{
			return string.Format("Straight {0} High", _highCard.Face);
		}

		public Straight(Hand hand)
		{
			Hand = hand;
			if(!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose Straight with hand {0}", Hand));

			SetHighCard();
			
		}

		private void SetHighCard()
		{
			var faces = string.Concat(Hand.Cards.Select(f => f.FaceChar).ToArray());
			if (StraightAceLow.Contains(faces))
			{
				var ace = Hand.Cards.First();
				Hand.Cards.RemoveAt(0);
				Hand.Cards.Add(ace);
			}
			_highCard = Hand.Cards.First();
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