using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokerHands.HandSets
{
	public class FourOfAKind : IHandSet
	{
		private Card[] _fourCards;

		public double Probability
		{
			get { return Constants.Probability.FourOfAKind; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public Hand Hand { get; private set; }

		public Card[] FourOfAKindCards { get {return _fourCards; } }

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
			return string.Format("Four of a Kind with {0}s", _fourCards.First().Face);
		}

		public FourOfAKind(Hand hand)
		{
			Hand = hand;

			if (!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose Four of a Kind with hand {0}", Hand));

			SetFourOfAKindCards();

		}

		private void SetFourOfAKindCards()
		{
			for (var i = 0; i < Hand.Cards.Count - 1; i++)
			{
				if (Hand.Cards[i].Face == Hand.Cards[i + 1].Face && Hand.Cards[i].Face == Hand.Cards[i + 2].Face && Hand.Cards[i].Face == Hand.Cards[i + 3].Face)
				{
					_fourCards = new[] { Hand.Cards[i], Hand.Cards[i + 1], Hand.Cards[i + 2], Hand.Cards[i + 3] };
					break;
				}
			}

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