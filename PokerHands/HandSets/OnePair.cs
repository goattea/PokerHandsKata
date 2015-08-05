using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace PokerHands.HandSets
{
	public class OnePair : IHandSet
	{
		private bool _meetsCriteria;

		public double Probability
		{
			get { return Constants.Probability.OnePair; }
		}

		public Card[] Pair { get; private set; }

		public List<Card> Cards { get; set; }

		public OnePair(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose One Pair with hand {0}", hand));
			Cards = hand.Cards;
			SetPairCards(hand);
		}

		private void SetPairCards(Hand hand)
		{
			for (var i = 0; i < hand.Cards.Count - 1; i++)
			{
				if (hand.Cards[i].Face != hand.Cards[i + 1].Face) continue;

				Pair = new[] { hand.Cards[i], hand.Cards[i + 1] };
				break;
			}

		}

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ?
				CompareTo((OnePair)other) :
				other.Probability.CompareTo(Probability);
		}

		public int CompareTo(OnePair other)
		{
			if (Pair.First().Face != other.Pair.First().Face)
			{
				return Pair.First().CompareTo(other.Pair.First());
			}

			var highCard = new HighCard(new Hand(Cards));
			var otherHighCard = new HighCard(new Hand(other.Cards));
			return highCard.CompareTo(otherHighCard);
		}

		public override string ToString()
		{
			return string.Format("Pair of {0}s", Pair.First().Face);
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