using System.Linq;
using NUnit.Framework;
using PokerHands.Constants;

namespace PokerHands.UnitTest
{
	[TestFixture]
	public class CardTests
	{
		[Test, Category("Unit")]
		[TestCase('A', 'S', 14)]
		[TestCase('K', 'S', 13)]
		[TestCase('Q', 'S', 12)]
		[TestCase('J', 'S', 11)]
		[TestCase('T', 'S', 10)]
		[TestCase('9', 'S', 9)]
		[TestCase('8', 'S', 8)]
		[TestCase('7', 'S', 7)]
		[TestCase('6', 'S', 6)]
		public void GetFaceValueForCard(char faceValue, char suit, int result)
		{
			var card = new Card(string.Format("{0}{1}", faceValue, suit));

			Assert.AreEqual(result, FaceValue.GetFaceValue(card.Face));
		}

		[Test, Category("Unit")]
		[TestCase('A', 'D','A','S', 0)]
		[TestCase('A', 'D','Q','S', 1)]
		[TestCase('3', 'S','7','D', -1)]
		public void CompFaceValueofCards(char blackFaceValue,char blackSuit, char whiteFaceValue, char whiteSuit, int expectedResult)
		{
			//Arrange

			var blackCard = new Card(string.Format("{0}{1}", blackFaceValue, blackSuit));
			var whiteCard = new Card(string.Format("{0}{1}", whiteFaceValue, whiteSuit));

			int result = blackCard.CompareTo(whiteCard);

			Assert.AreEqual(expectedResult, result);
		}

	}
}





