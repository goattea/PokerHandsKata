using System;
using System.Linq;
using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class OnePairTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", false)]
		[TestCase("5S 3H 3D 9C KD", true)]
		public void OnePairDetected(string h1, bool hasPair)
		{
			//Arrange
			var hand1 = new Hand(h1);
			
			//Act
			var result = OnePair.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(hasPair, result);
		}

		[Test, Category("Unit")]
		[TestCase("5S 3H 3D 9C KD", FaceValue.Three, FaceValue.King, FaceValue.Five)]
		[TestCase("5S KH 3D AC KD", FaceValue.King, FaceValue.Ace, FaceValue.Three)]
		public void OnePairSort(string handString, string pairFaceValue, string highCard, string lowCard)
		{
			var hand = new Hand(handString);
			var handSet = new OnePair(hand);

			var pairs = hand.Cards.GetRange(0, 2).ToList();
			var otherCards = hand.Cards.GetRange(2, hand.Cards.Count - 2).ToList();

			Assert.IsTrue(pairs.All(c => c.Face == pairFaceValue));
			Assert.AreEqual(highCard, otherCards.First().Face);
			Assert.AreEqual(lowCard, otherCards.Last().Face);
		}

		[Test, Category("Unit")]
		[TestCase("2S 2H 3D 9C KD", "2C 2D 3H 9S KH", 0)]
		[TestCase("2S 2H 3D 9C AD", "2C 2D 3H 9S KH", 1)]
		[TestCase("2S 2H 3S 9C AD", "3C 3D 4H 9S KH", -1)]
		[TestCase("AS 2H 3S 9C AD", "KC 3D 4H 9S KH", 1)]
		public void OnePairCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new OnePair(hand1);
			var handSet2 = new OnePair(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
