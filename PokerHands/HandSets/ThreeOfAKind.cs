using System;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace PokerHands.HandSets
{
	public class ThreeOfAKind : IHandSet
	{
		private Card[] _threeCards;
		private bool _meetsCriteria;

		public double Probability
		{
			get { return Constants.Probability.ThreeOfAKind; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public Hand Hand { get; private set; }

		public Card[] ThreeOfAKindCards { get { return _threeCards; } }

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
			return string.Format("Three of a Kind with {0}s", _threeCards.First().Face);
		}

		public ThreeOfAKind(Hand hand)
		{
			Hand = hand;
			if (!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose Three of a Kind with hand {0}", Hand));

			SetThreeOfAKindCards();

		}

		private void SetThreeOfAKindCards()
		{
			for (var i = 0; i < Hand.Cards.Count - 1; i++)
			{
				if (Hand.Cards[i].Face == Hand.Cards[i + 1].Face && Hand.Cards[i].Face == Hand.Cards[i + 2].Face)
				{
					_threeCards = new[] { Hand.Cards[i], Hand.Cards[i + 1], Hand.Cards[i + 2] };
					break;
				}
			}

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