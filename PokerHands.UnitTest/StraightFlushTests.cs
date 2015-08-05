using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class StraightFlusTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2S AS 9S KS", false)]
		[TestCase("5S 4H 3D 2C AD", false)]
		[TestCase("5S 4S 3S 2S 6S", true)]
		[TestCase("5D 4D 3D 2D AD", true)]
		[TestCase("KH QH JH TH AH", true)]
		public void StraightFlushsDetected(string h1, bool hasPair)
		{
			//Arrange
			var hand1 = new Hand(h1);

			//Act
			var result = StraightFlush.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(hasPair, result);
		}

		[Test, Category("Unit")]
		[TestCase("TS 8S 9S JS 7S", FaceValue.Jack)]
		[TestCase("5D 4D 3D 2D AD", FaceValue.Five)]
		[TestCase("KH QH JH TH AH", FaceValue.Ace)]
		public void StraightFlushSet(string handString, string highCard)
		{
			var hand = new Hand(handString);
			var handSet = new StraightFlush(hand);


			Assert.AreEqual(highCard, handSet.HighCard.Face);
		}

		[Test, Category("Unit")]
		[TestCase("TS 8S 9S JS 7S", "TC 8C 9C JC 7C", 0)]
		[TestCase("5S 4S 3S 2S 6S", "5C 4C 3C 2C AC", 1)]
		[TestCase("5C 4C 3C 2C AC", "KD QD JD TD AD", -1)]
		[TestCase("TD 9D 8D 7D 6D", "9C 8C 7C 6C 5C", 1)]
		public void StraightFlushCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new StraightFlush(hand1);
			var handSet2 = new StraightFlush(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
