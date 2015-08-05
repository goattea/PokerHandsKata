using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokerHands.HandSets
{
	public class FourOfAKind : IHandSet
	{
		public double Probability
		{
			get { return Constants.Probability.FourOfAKind; }
		}

		public Card[] FourOfAKindCards { get; private set; }

		public FourOfAKind(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose Four of a Kind with hand {0}", hand));

			SetFourOfAKindCards(hand);

		}

		private void SetFourOfAKindCards(Hand hand)
		{
			for (var i = 0; i < hand.Cards.Count - 1; i++)
			{
				if (hand.Cards[i].Face == hand.Cards[i + 1].Face && hand.Cards[i].Face == hand.Cards[i + 2].Face && hand.Cards[i].Face == hand.Cards[i + 3].Face)
				{
					FourOfAKindCards = new[] { hand.Cards[i], hand.Cards[i + 1], hand.Cards[i + 2], hand.Cards[i + 3] };
					break;
				}
			}
		}

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ?
				CompareTo((FourOfAKind)other) :
				other.Probability.CompareTo(Probability);
		}

		public int CompareTo(FourOfAKind other)
		{
			return FourOfAKindCards.First().CompareTo(other.FourOfAKindCards.First());
		}

		public override string ToString()
		{
			return string.Format("Four of a Kind with {0}s", FourOfAKindCards.First().Face);
		}
		

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			var regex = new Regex(@"(.)\1{3}", RegexOptions.IgnoreCase);
			var faces = string.Concat(hand.Cards.Select(c => c.FaceChar).ToList());
			var matches = regex.Matches(faces);

			return matches.Count == 1;
		}
	}
}