using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.HandSets
{
	public static class HandSetFactory
	{
		public static IHandSet Generate(Hand hand)
		{
			if (RoyalFlush.DoesHandMeetCriteria(hand))
				return new RoyalFlush(hand);

			if (StraightFlush.DoesHandMeetCriteria(hand))
				return new StraightFlush(hand);

			if (FourOfAKind.DoesHandMeetCriteria(hand))
				return new FourOfAKind(hand);

			if (FullHouse.DoesHandMeetCriteria(hand))
				return new FullHouse(hand);

			if (Flush.DoesHandMeetCriteria(hand))
				return new Flush(hand);

			if (Straight.DoesHandMeetCriteria(hand))
				return new Straight(hand);

			if (ThreeOfAKind.DoesHandMeetCriteria(hand))
				return new ThreeOfAKind(hand);

			if(TwoPair.DoesHandMeetCriteria(hand))
				return new TwoPair(hand);

			if(OnePair.DoesHandMeetCriteria(hand))
				return new OnePair(hand);

			return new HighCard(hand);
		}
	}
}
