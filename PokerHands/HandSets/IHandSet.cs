using System;

namespace PokerHands.HandSets
{
	public interface IHandSet : IComparable<IHandSet>
	{
		double Probability { get; }
	}
}
