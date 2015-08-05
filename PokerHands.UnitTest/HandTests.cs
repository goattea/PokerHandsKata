using System.Linq;
using NUnit.Framework;
using PokerHands.Constants;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class HandTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H 3D 9C KD", FaceValue.Two, FaceValue.King)]
		[TestCase("AS TH 6D 9C KD", FaceValue.Six, FaceValue.Ace)]
		public void CardAreSorted(string handValue, string lowFaceValue, string highFaceValue)
		{
			Hand hand = new Hand(handValue);

			Assert.AreEqual(highFaceValue, hand.Cards.First().Face);
			Assert.AreEqual(lowFaceValue, hand.Cards.Last().Face);
		}

		[Test, Category("Unit")]
		[TestCase("5S 2H 3D 9C KD", Probability.HighCard)]
		[TestCase("AS TH 6D TC KD", Probability.OnePair)]
		[TestCase("AS TH 6D TC AD", Probability.TwoPair)]
		[TestCase("AS AH 6D TC AD", Probability.ThreeOfAKind)]
		[TestCase("AS AH 6D AC AD", Probability.FourOfAKind)]
		[TestCase("AS KH QD JC TD", Probability.Straight)]
		[TestCase("AS 5H 4D 3C 2D", Probability.Straight)]
		[TestCase("5S 2S 3S 9S KS", Probability.Flush)]
		[TestCase("AS AH TD TC AD", Probability.FullHouse)]
		[TestCase("AS 5S 4S 3S 2S", Probability.StraightFlush)]
		[TestCase("AS KS QS JS TS", Probability.RoyalFlush)]
		public void HandsAnalyze(string handValue, double probability)
		{
			Hand hand = new Hand(handValue);

			hand.Analyze();

			Assert.AreEqual(probability, hand.HandSet.Probability);
		}

	
	}
}





