using NUnit.Framework;
using PokerHands.Constants;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class RoyalFlushTests
	{

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", false)]
		[TestCase("5S 3H 3D 9C KD", false)]
		[TestCase("KS QS JS TS AS", true)]
		public void RoyalFlushsDetected(string h1, bool hasPair)
		{
			//Arrange
			var hand1 = new Hand(h1);

			//Act
			var result = RoyalFlush.DoesHandMeetCriteria(hand1);

			//Assert
			Assert.AreEqual(hasPair, result);
		}

		
		[Test, Category("Unit")]
		[TestCase("KS QS JS TS AS", "KD QD JD TD AD", 0)]
		public void Compares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new RoyalFlush(hand1);
			var handSet2 = new RoyalFlush(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);
		}
	}
}
