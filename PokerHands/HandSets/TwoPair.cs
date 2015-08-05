using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokerHands.HandSets
{
	public class TwoPair : IHandSet
	{
		public double Probability
		{
			get { return Constants.Probability.TwoPair; }
		}

		public Card[] HighPair { get; private set; }
		public Card[] LowPair { get; private set; }
		public Card HighCard { get; private set; }

		public TwoPair(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose Two Pair with hand {0}", hand));

			SetHighLowPairs(hand);
		}

		private void SetHighLowPairs(Hand hand)
		{
			int highPairIndex = -1, lowPairIndex = 0;

			for (var i = 0; i < hand.Cards.Count - 1; i++)
			{
				if (hand.Cards[i].Face != hand.Cards[i + 1].Face) continue;

				if (highPairIndex == -1)
				{
					highPairIndex = i;
				}
				else
				{
					lowPairIndex = i;
				}
			}

			HighPair = new[] { hand.Cards[highPairIndex], hand.Cards[highPairIndex + 1] };
			LowPair = new[] { hand.Cards[lowPairIndex], hand.Cards[lowPairIndex + 1] };
			HighCard = hand.Cards.First(c => c.Face != HighPair.First().Face && c.Face != LowPair.First().Face);
		}

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((TwoPair)other) : 
				other.Probability.CompareTo(Probability); ;
		}

		public int CompareTo(TwoPair other)
		{
			if (HighPair.First().Face != other.HighPair.First().Face)
			{
				return HighPair.First().CompareTo(other.HighPair.First());
			}

			if (LowPair.First().Face != other.LowPair.First().Face)
			{
				return LowPair.First().CompareTo(other.LowPair.First());
			}

			return HighCard.CompareTo(other.HighCard);
		}

		public override string ToString()
		{
			return string.Format("Two Pair {0}s and {1}s", HighPair.First().Face, LowPair.First().Face);
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