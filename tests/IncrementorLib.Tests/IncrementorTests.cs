using System;
using System.Threading.Tasks;
using IncrementorLib;
using Xunit;

namespace IncrementorLib.Tests;

public class IncrementorTests
{
	[Fact]
	public void StartsAtZero()
	{
		// Arrange + Act
		var inc = new Incrementor();

		// Assert
		Assert.Equal(0, inc.GetNumber());
	}

	[Fact]
	public void IncrementsAndWraps()
	{
		// Arrange
		var inc = new Incrementor();
		inc.SetMaximumValue(3); // допустимы 0,1,2

		// Act + Assert
		inc.IncrementNumber(); Assert.Equal(1, inc.GetNumber());
		inc.IncrementNumber(); Assert.Equal(2, inc.GetNumber());
		inc.IncrementNumber(); Assert.Equal(0, inc.GetNumber()); // сброс
	}

	[Fact]
	public void ReducingMaximum_Resets_WhenCurrentExceedsNewMax()
	{
		var inc = new Incrementor(10);
		for (int i = 0; i < 5; i++) inc.IncrementNumber(); // стало 5
		inc.SetMaximumValue(3);                             // 5 > 3 поэтому сброс
		Assert.Equal(0, inc.GetNumber());
	}

	[Fact]
	public void ReducingMaximum_DoesNotReset_WhenCurrentIsWithinNewMax()
	{
		var inc = new Incrementor(10);
		inc.IncrementNumber(); // 1
		inc.SetMaximumValue(3); // 1 <= 3 поэтому не сбрасывается
		Assert.Equal(1, inc.GetNumber());
	}
	[Fact]
	public void ReducingMaximum_ToEqualCurrent_Resets()
	{
		var inc = new Incrementor(10);
		for (int i = 0; i < 4; i++) inc.IncrementNumber(); // стало 4
		inc.SetMaximumValue(4);                             // допустимы 0,1,2,3 поэтому должен быть сброс
		Assert.Equal(0, inc.GetNumber());
	}

	[Fact]
	public void ZeroMaximum_AlwaysZero()
	{
		var inc = new Incrementor(0);
		Assert.Equal(0, inc.GetNumber());
		inc.IncrementNumber(); Assert.Equal(0, inc.GetNumber());
		inc.SetMaximumValue(0); Assert.Equal(0, inc.GetNumber());
	}

	[Fact]
	public void MaxEqualsOne_AlwaysZeroAfterAnyIncrement()
	{
		var inc = new Incrementor(1);       // допустим только 0
		inc.IncrementNumber();              // ожидается сброс, так как максимум достигнут
		Assert.Equal(0, inc.GetNumber());
	}

	[Fact]
	public void NegativeMaximum_Throws()
	{
		var inc = new Incrementor();
		Assert.Throws<ArgumentOutOfRangeException>(() => inc.SetMaximumValue(-1));
	}
}