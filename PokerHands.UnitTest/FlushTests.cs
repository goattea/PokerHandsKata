using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class FlushTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", false)]
		[TestCase("5S 3H 3D 9C KD", false)]
		[TestCase("5S 4S 3S 2S 6S", true)]
		[TestCase("KD QD JD TD AD", true)]
		public void FlushDetected(string h1, bool hasPair)
		{
			//Arrange
			var hand1 = new Hand(h1);

			//Act
			var result = Flush.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(hasPair, result);
		}

		[Test, Category("Unit")]
		[TestCase("TS 8S 9S JS 7S", FaceValue.Jack)]
		[TestCase("5D 4D 3D 2D AD", FaceValue.Ace)]
		[TestCase("KH QH JH TH 3H", FaceValue.King)]
		public void FlushSort(string handString, string highCard)
		{
			var hand = new Hand(handString);
			var handSet = new Flush(hand);


			Assert.AreEqual(highCard, handSet.HighCard.Face);
		}

		[Test, Category("Unit")]
		[TestCase("TS 8S 9S JS 7S", "TC 8C 9C JC 7C", 0)]
		[TestCase("KS 8S 9S JS 7S", "TC 8C 9C JC 7C", 1)]
		[TestCase("TS 8S 9S JS 7S", "KC 2C 3C 8C 7C", -1)]
		public void FlushCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new Flush(hand1);
			var handSet2 = new Flush(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
