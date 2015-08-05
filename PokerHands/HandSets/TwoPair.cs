using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokerHands.HandSets
{
	public class TwoPair : IHandSet
	{
		private Card[] _highPairCards;
		private Card[] _lowPairCards;

		public double Probability
		{
			get { return Constants.Probability.TwoPair; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public Hand Hand { get; private set; }

		public Card[] HighPairs { get { return _highPairCards; } }
		public Card[] LowPairs { get { return _lowPairCards; } }

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((TwoPair)other) : 
				other.Probability.CompareTo(Probability); ;
		}

		public int CompareTo(TwoPair other)
		{
			if (HighPairs.First().Face != other.HighPairs.First().Face)
			{
				return HighPairs.First().CompareTo(other.HighPairs.First());
			}

			if (LowPairs.First().Face != other.LowPairs.First().Face)
			{
				return LowPairs.First().CompareTo(other.LowPairs.First());
			}

			var highCard = new HighCard(new Hand(Hand.Cards.GetRange(4, Hand.Cards.Count - 4)));
			var otherHighCard = new HighCard(new Hand(other.Hand.Cards.GetRange(4, other.Hand.Cards.Count - 4)));
			return highCard.CompareTo(otherHighCard);
		}

		public override string ToString()
		{
			return string.Format("Two Pair {0}s and {1}s", _highPairCards.First().Face, _lowPairCards.First().Face);
		}

		public TwoPair(Hand hand)
		{
			Hand = hand;

			if (!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose Two Pair with hand {0}", Hand));

			SetHighLowPairs();
		}

		private void SetHighLowPairs()
		{
			int highPairIndex = -1, lowPairIndex = 0;

			for (var i = 0; i < Hand.Cards.Count - 1; i++)
			{
				if (Hand.Cards[i].Face != Hand.Cards[i + 1].Face) continue;

				if (highPairIndex == -1)
				{
					highPairIndex = i;
				}
				else
				{
					lowPairIndex = i;
					break;
				}
			}

			_highPairCards = new[] { Hand.Cards[highPairIndex], Hand.Cards[highPairIndex + 1] };
			Hand.Cards.RemoveRange(highPairIndex, 2);

			lowPairIndex -= 2;
			_lowPairCards = new[] { Hand.Cards[lowPairIndex], Hand.Cards[lowPairIndex + 1] };
			Hand.Cards.RemoveRange(lowPairIndex, 2);

			Hand.Cards.InsertRange(0, _lowPairCards);
			Hand.Cards.InsertRange(0, _highPairCards);
		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			var regex = new Regex(@"(.)\1{1}", RegexOptions.IgnoreCase);
			var faces = string.Concat(hand.Cards.Select(c => c.FaceChar).ToList());
			var matches = regex.Matches(faces);

			return matches.Count == 2;
		}
	}
}