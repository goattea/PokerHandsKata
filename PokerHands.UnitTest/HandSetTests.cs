using System;
using NUnit.Framework;
using PokerHands.HandSets;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class HandSetTests
	{
		[Test, Category("Unit")]
		[TestCase("5S 2H 3D 9C KD", "5S 2H 3D 9C KD", 0)]
		[TestCase("5S AH 3D 9C KD", "5S 2H 3D 9C KD", 1)]
		[TestCase("5S AH 3D 9C QD", "5S AS 3D 9C KD", -1)]
		[TestCase("AH TH 9D 8C 7D", "AD TD 9H 8S 6H", 1)]
		[TestCase("AH TH 9D 8C 6D", "AD TD 9H 8S 7H", -1)]
		public void HighCardCompares(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			var handSet1 = new HighCard(hand1);
			var handSet2 = new HighCard(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);

		}

		[Test, Category("Unit")]
		[TestCase("5S 2H AD 9C KD", "Ace High")]
		[TestCase("5S 3H 3D 9C KD", "King High")]
		[TestCase("3D TH 9D 8C 6D", "10 High")]
		public void HighCardNameIsValid(string h1, string output)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var handSet1 = new HighCard(hand1);

			//Act
			var result = handSet1.Name;

			//Assert
			Assert.AreEqual(output, result);

		}

		[Test, Category("Unit")]
		[TestCase("5S AH 3D 3C KD", "5S 2H 3D 9C KD", 1)]
		[TestCase("5S AH 3D 9C QD", "5S AS 3D 9C 5D", -1)]
		public void PairBeatsHighCard(string h1, string h2, int equality)
		{
			//Arrange
			var hand1 = new Hand(h1);
			var hand2 = new Hand(h2);
			IHandSet handSet1 = OnePair.DoesHandMeetCriteria(hand1) ? (IHandSet)new OnePair(hand1) : (IHandSet)new HighCard(hand1);
			IHandSet handSet2 = OnePair.DoesHandMeetCriteria(hand2) ? (IHandSet)new OnePair(hand2) : (IHandSet)new HighCard(hand2);

			//Act
			var result = handSet1.CompareTo(handSet2);

			//Assert
			Assert.AreEqual(equality, result);

		}

	}
}
