using System;
using System.Linq;
using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class TwoPairTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", false)]
		[TestCase("5S 3H 3D 9C KD", false)]
		[TestCase("5S 3H 3D 5C KD", true)]
		public void PairsDetected(string h1, bool hasPair)
		{
			//Arrange
			var hand1 = new Hand(h1);

			//Act
			var result = TwoPair.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(hasPair, result);
		}

		[Test, Category("Unit")]
		[TestCase("5S 3H 3D 5C KD", FaceValue.Five, FaceValue.Three, FaceValue.King)]
		[TestCase("KS AH 3D AC KD", FaceValue.Ace, FaceValue.King, FaceValue.Three)]
		public void TwoPairSort(string handString, string highPairFaceValue, string lowPairFaceValue, string highCard)
		{
			var hand = new Hand(handString);
			var handSet = new TwoPair(hand);

			var highPairs = hand.Cards.GetRange(0, 2).ToList();
			var lowPairs = hand.Cards.GetRange(2, 2).ToList();
			var otherCards = hand.Cards.GetRange(4, hand.Cards.Count - 4).ToList();

			Assert.IsTrue(highPairs.All(c => c.Face == highPairFaceValue));
			Assert.IsTrue(lowPairs.All(c => c.Face == lowPairFaceValue));
			Assert.AreEqual(highCard, otherCards.First().Face);
		}

		[Test, Category("Unit")]
		[TestCase("2S 2H 3D 3C KD", "2C 2D 3H 3S KH", 0)]
		[TestCase("2S 2H 3D 3C AD", "2C 2D 3H 3S KH", 1)]
		[TestCase("2S 2H 3S 3H AD", "3C 3D 4H 4S KH", -1)]
		[TestCase("AS 2H 2S 9C AD", "KC 3D 9H 9S KH", 1)]
		public void TwoPairCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new TwoPair(hand1);
			var handSet2 = new TwoPair(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
