using System;
using System.Linq;

namespace PokerHands.HandSets
{
	public class FullHouse : IHandSet
	{

		public double Probability
		{
			get { return Constants.Probability.FullHouse; }
		}

		public Card[] ThreeOfAKindCards { get; private set; }
		public Card[] PairCards { get; private set; }

		public FullHouse(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose Full House with hand {0}", hand));

			SetFullHouseCards(hand);
		}

		private void SetFullHouseCards(Hand hand)
		{
			var threeOfAKind = new ThreeOfAKind(hand);
			ThreeOfAKindCards = threeOfAKind.ThreeOfAKindCards;
			PairCards = hand.Cards.Where(f => f.Face != threeOfAKind.ThreeOfAKindCards.First().Face).ToArray();
		}

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((FullHouse)other) : 
				other.Probability.CompareTo(Probability); ;
		}

		public int CompareTo(FullHouse other)
		{
			return ThreeOfAKindCards.First().CompareTo(other.ThreeOfAKindCards.First());
		}

		public override string ToString()
		{
			return string.Format("Full House with three {0}s and a pair of {1}s", ThreeOfAKindCards.First().Face, PairCards.First().Face);
		}


		public static bool DoesHandMeetCriteria(Hand hand)
		{
			if (!ThreeOfAKind.DoesHandMeetCriteria(hand)) return false;

			var threeOfAKind = new ThreeOfAKind(hand);
			var remainingCards = new Hand(hand.Cards.Where(f => f.Face != threeOfAKind.ThreeOfAKindCards.First().Face).ToList());
			return OnePair.DoesHandMeetCriteria(remainingCards);
		}
	}
}