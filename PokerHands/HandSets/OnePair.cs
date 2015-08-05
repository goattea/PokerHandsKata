using System;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace PokerHands.HandSets
{
	public class OnePair : IHandSet
	{
		private Card[] _pairCards;
		private bool _meetsCriteria;

		public double Probability
		{
			get { return Constants.Probability.OnePair; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public Hand Hand { get; private set; }

		public Card[] Pairs { get { return _pairCards; } }

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((OnePair)other) : 
				other.Probability.CompareTo(Probability);
		}

		public int CompareTo(OnePair other)
		{
			if (Pairs.First().Face != other.Pairs.First().Face)
			{
				return Pairs.First().CompareTo(other.Pairs.First());
			}

			var highCard = new HighCard(new Hand(Hand.Cards.GetRange(2, Hand.Cards.Count - 2)));
			var otherHighCard = new HighCard(new Hand(other.Hand.Cards.GetRange(2, other.Hand.Cards.Count - 2)));
			return highCard.CompareTo(otherHighCard);
		}

		public override string ToString()
		{
			return string.Format("Pair of {0}s", _pairCards.First().Face);
		}

		public OnePair(Hand hand)
		{
			Hand = hand;
			if (!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose One Pair with hand {0}", Hand));

			SetPairCards();

		}

		private void SetPairCards()
		{
			for (var i = 0; i < Hand.Cards.Count - 1; i++)
			{
				if (Hand.Cards[i].Face == Hand.Cards[i + 1].Face)
				{
					_pairCards = new[] { Hand.Cards[i], Hand.Cards[i + 1] };
					Hand.Cards.RemoveRange(i, 2);
					Hand.Cards.InsertRange(0, _pairCards);
					break;
				}
			}

		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			var regex = new Regex(@"(.)\1{1}", RegexOptions.IgnoreCase);
			var faces = string.Concat(hand.Cards.Select(c => c.FaceChar).ToList());
			var matches = regex.Matches(faces);

			return matches.Count == 1;
		}
	}
}