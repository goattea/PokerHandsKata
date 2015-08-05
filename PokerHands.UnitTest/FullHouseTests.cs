using System.Linq;
using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class FullHouseTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", false)]
		[TestCase("5S 5H 5D TC TD", true)]
		public void FullHouseDetected(string h1, bool meetsCriteria)
		{
			//Arrange
			var hand1 = new Hand(h1);

			//Act
			var result = FullHouse.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(meetsCriteria, result);
		}

		[Test, Category("Unit")]
		[TestCase("5S 5H 5D TC TD", FaceValue.Five, FaceValue.Ten)]
		[TestCase("5S KH 5D KC KD", FaceValue.King, FaceValue.Five)]
		public void FullHouseSort(string handString, string trio, string pair)
		{
			var hand = new Hand(handString);
			var handSet = new FullHouse(hand);

			Assert.AreEqual(trio, handSet.ThreeOfAKindCards.First().Face);
			Assert.AreEqual(pair, handSet.PairCards.First().Face);
		}

		[Test, Category("Unit")]
		[TestCase("2S 2H 2D 9C 9D", "2C 2D 2H 9S 9H", 0)] // can't happen
		[TestCase("2S 2H 2D AC AD", "2C 2D 2H KS KH", 1)] // this can't either
		[TestCase("2S 2H 2S AC AD", "3C 3D 3H 3S 3H", -1)]
		[TestCase("AS 2H 2S AC AD", "KC KD QH QS KH", 1)]
		public void FullHouseCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new FullHouse(hand1);
			var handSet2 = new FullHouse(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
