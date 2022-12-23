using NUnit.Framework;
using UnityEngine.TestTools;
using TimerSystem;

[ExcludeFromCoverage]
public class StopwatchTests
{
	[Test]
	public void StartingDurationIsSet()
	{
		var timer = new Timer();
		Assert.IsNaN(timer.SecondsRemaining);
	}

	[Test]
	public void TickingTwoSeconds_SecondsPassedIsTwoSeconds()
	{
		var timer = new Timer();
		timer.Tick(2f);
		Assert.IsNaN(timer.SecondsRemaining);
		Assert.IsTrue(timer.SecondsPassed == 2f);
	}

	[Test]
	public void InitializedAsStopWatch_EventIsNotRaised()
	{
		var timer = new Timer();
		bool eventHasBeenRaised = false;
		timer.OnCountdownEnd += () => eventHasBeenRaised = true;

		timer.Tick(1f);

		Assert.IsFalse(eventHasBeenRaised);
	}
}

[ExcludeFromCoverage]
public class CountdownTests
{
	[Test]
	[TestCase(1f)]
	[TestCase(5f)]
	[TestCase(36.3f)]
	public void StartingDurationIsSet(float duration)
	{
		var timer = new Timer(duration);
		Assert.IsTrue(timer.SecondsRemaining == duration);
	}

	[Test]
	public void TickingBelowZeroSeconds_StopsAtZero()
	{
		var timer = new Timer(1f);
		timer.Tick(2f);
		Assert.IsTrue(timer.SecondsRemaining == 0f);
	}

	[Test]
	public void TimerEnds_EventIsRaised()
	{
		var timer = new Timer(1f);
		bool eventHasBeenRaised = false;
		timer.OnCountdownEnd += () => eventHasBeenRaised = true;

		timer.Tick(1f);

		Assert.IsTrue(eventHasBeenRaised);
	}

	[Test]
	public void TimerDoesNotEnds_EventIsNotRaised()
	{
		var timer = new Timer(1f);
		bool eventHasBeenRaised = false;
		timer.OnCountdownEnd += () => eventHasBeenRaised = true;

		timer.Tick(0.5f);

		Assert.IsFalse(eventHasBeenRaised);
	}
}
