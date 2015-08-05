using System;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace PokerHands.HandSets
{
	public class ThreeOfAKind : IHandSet
	{
		public double Probability
		{
			get { return Constants.Probability.ThreeOfAKind; }
		}

		public Card[] ThreeOfAKindCards { get; private set; }

		public ThreeOfAKind(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose Three of a Kind with hand {0}", hand));

			SetThreeOfAKindCards(hand);

		}

		private void SetThreeOfAKindCards(Hand hand)
		{
			for (var i = 0; i < hand.Cards.Count - 1; i++)
			{
				if (hand.Cards[i].Face == hand.Cards[i + 1].Face && hand.Cards[i].Face == hand.Cards[i + 2].Face)
				{
					ThreeOfAKindCards = new[] { hand.Cards[i], hand.Cards[i + 1], hand.Cards[i + 2] };
					break;
				}
			}

		}
		
		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((ThreeOfAKind)other) : 
				other.Probability.CompareTo(Probability);
		}

		public int CompareTo(ThreeOfAKind other)
		{
			return ThreeOfAKindCards.First().CompareTo(other.ThreeOfAKindCards.First());
		}

		public override string ToString()
		{
			return string.Format("Three {0}s", ThreeOfAKindCards.First().Face);
		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			var regex = new Regex(@"(.)\1{2}", RegexOptions.IgnoreCase);
			var faces = string.Concat(hand.Cards.Select(c => c.FaceChar).ToList());
			var matches = regex.Matches(faces);

			return matches.Count == 1;
		}
	}
}