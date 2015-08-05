using System.Linq;
using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class FourOfAKindTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", false)]
		[TestCase("3S 3H 3D 3C KD", true)]
		public void FourOfAKindDetected(string h1, bool meetsCriteria)
		{
			//Arrange
			var hand1 = new Hand(h1);

			//Act
			var result = FourOfAKind.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(meetsCriteria, result);
		}

		[Test, Category("Unit")]
		[TestCase("3S 3H 3D 3C KD", FaceValue.Three, FaceValue.King)]
		[TestCase("5S KH KD KC KD", FaceValue.King, FaceValue.Five)]
		public void FourOfAKindSort(string handString, string fourOfAKindValue, string lastCard)
		{
			var hand = new Hand(handString);
			var handSet = new FourOfAKind(hand);

			Assert.IsTrue(handSet.FourOfAKindCards.All(f => f.Face == fourOfAKindValue));
		}

		[Test, Category("Unit")]
		[TestCase("2S 2H 2D 2C KD", "2C 2D 2H 2S KH", 0)] // can't happen
		[TestCase("2S 2H 2S 2C AD", "3C 3D 3H 3S KH", -1)]
		[TestCase("AS AH 3S AC AD", "KC KD 4H KS KH", 1)]
		public void FourOfAKindCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new FourOfAKind(hand1);
			var handSet2 = new FourOfAKind(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
