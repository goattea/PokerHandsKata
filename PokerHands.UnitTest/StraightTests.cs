using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class StraightTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", false)]
		[TestCase("5S 3H 3D 9C KD", false)]
		[TestCase("5S 4H 3D 2C 6D", true)]
		[TestCase("5S 4H 3D 2C AD", true)]
		[TestCase("KS QH JD TC AD", true)]
		public void StraightsDetected(string h1, bool hasPair)
		{
			//Arrange
			var hand1 = new Hand(h1);

			//Act
			var result = Straight.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(hasPair, result);
		}

		[Test, Category("Unit")]
		[TestCase("TS 8H 9D JC 7D", FaceValue.Jack)]
		[TestCase("5S 4H 3D 2C AD", FaceValue.Five)]
		[TestCase("KS QH JD TC AD", FaceValue.Ace)]
		public void TwoPairSort(string handString, string highCard)
		{
			var hand = new Hand(handString);
			var handSet = new Straight(hand);


			Assert.AreEqual(highCard, handSet.HighCard.Face);
		}

		[Test, Category("Unit")]
		[TestCase("TS 8H 9D JC 7D", "TC 8D 9H JS 7H", 0)]
		[TestCase("5S 4H 3D 2C 6D", "5C 4D 3H 2S AH", 1)]
		[TestCase("5C 4D 3H 2S AH", "KS QH JD TC AD", -1)]
		[TestCase("TS 9H 8S 7C 6D", "9C 8D 7H 6S 5H", 1)]
		public void TwoPairCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new Straight(hand1);
			var handSet2 = new Straight(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
