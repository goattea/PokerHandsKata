using System.Linq;
using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class ThreeOfAKindTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", false)]
		[TestCase("5S 3H 3D 3C KD", true)]
		public void PairsDetected(string h1, bool meetsCriteria)
		{
			//Arrange
			var hand1 = new Hand(h1);

			//Act
			var result = ThreeOfAKind.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(meetsCriteria, result);
		}

		[Test, Category("Unit")]
		[TestCase("5S 3H 3D 3C KD", FaceValue.Three)]
		[TestCase("5S KH 3D KC KD", FaceValue.King)]
		public void ThreeOfAKindSet(string handString, string threeOfAKindValue)
		{
			var hand = new Hand(handString);
			var handSet = new ThreeOfAKind(hand);


			Assert.IsTrue(handSet.ThreeOfAKindCards.All(c => c.Face == threeOfAKindValue));
		}

		[Test, Category("Unit")]
		[TestCase("2S 2H 2S 9C AD", "3C 3D 3H 9S KH", -1)]
		[TestCase("AS 2H 3S AC AD", "KC KD 4H 9S KH", 1)]
		public void ThreeOfAKindCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new ThreeOfAKind(hand1);
			var handSet2 = new ThreeOfAKind(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
