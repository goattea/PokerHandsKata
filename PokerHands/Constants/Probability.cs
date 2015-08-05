using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.Constants
{
	public static class Probability
	{
		public const double HighCard =		1.0;
		public const double OnePair =		0.0499;
		public const double TwoPair =		0.00762;
		public const double ThreeOfAKind =	0.00287;
		public const double Straight =		0.00076;
		public const double Flush =			0.000367;
		public const double FullHouse =		0.00017;
		public const double FourOfAKind =	0.0000256;
		public const double StraightFlush =	0.0000014;
		public const double RoyalFlush =	0.000000154;
	}
}
