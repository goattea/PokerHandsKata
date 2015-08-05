using System;
using System.Linq;

namespace PokerHands.HandSets
{
	public class FullHouse : IHandSet
	{
		private Card[] _trioCards;
		private Card[] _pairCards;

		public double Probability
		{
			get { return Constants.Probability.FullHouse; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public Hand Hand { get; private set; }

		public Card[] ThreeOfAKindCards { get { return _trioCards; } }
		public Card[] PairCards { get { return _pairCards; } }

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
			return string.Format("Full House with three {0}s and a pair of {1}s", _trioCards.First().Face, _pairCards.First().Face);
		}

		public FullHouse(Hand hand)
		{
			Hand = hand;
			if (!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose Full House with hand {0}", Hand));

			SetFullHouseCards();
		}

		private void SetFullHouseCards()
		{
			var threeOfAKind = new ThreeOfAKind(Hand);
			_trioCards = threeOfAKind.ThreeOfAKindCards;
			_pairCards = Hand.Cards.Where(f => f.Face != threeOfAKind.ThreeOfAKindCards.First().Face).ToArray();
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