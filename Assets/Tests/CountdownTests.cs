using NUnit.Framework;
using TimerSystem;


public class CountdownTests
{
	[Test]
	[TestCase(1f)]
	[TestCase(5f)]
	[TestCase(36.3f)]
	public void StartingDurationIsSet(float duration)
	{
		Countdown timer = new Countdown(duration);
		Assert.AreEqual(duration, timer.SecondsRemaining);
	}

	[Test]
	public void TickingBelowZeroSeconds_StopsAtZero()
	{
		Countdown timer = new Countdown(1f);
		timer.Tick(2f);
		Assert.AreEqual(0f, timer.SecondsRemaining);
	}

	[Test]
	public void CountdownEnds_EventIsRaised()
	{
		bool eventHasBeenRaised = false;
		Countdown timer = new Countdown(1f, () => eventHasBeenRaised = true);

		timer.Tick(1f);

		Assert.IsTrue(eventHasBeenRaised);
	}

	[Test]
	public void CountdownHasNotEnded_EventIsNotRaised()
	{
		bool eventHasBeenRaised = false;
		Countdown timer = new Countdown(1f, () => eventHasBeenRaised = true);

		timer.Tick(0.5f);

		Assert.IsFalse(eventHasBeenRaised);
	}

	[Test]
	public void SetNewTime_CountdownCountsToNewTime()
	{
		Countdown timer = new Countdown(1f);
		timer.Tick(0.5f);
		Assert.IsTrue(timer.SecondsRemaining == 0.5f);

		timer.SetNewDuration(2f);
		Assert.IsTrue(timer.SecondsRemaining == 1.5f);
	}

	[Test]
	public void Reset_CountdownIsReset()
	{
		Countdown timer = new Countdown(2f);
		timer.Tick(2f);
		Assert.AreEqual(2f, timer.SecondsPassed);

		timer.Reset();
		Assert.AreEqual(0f, timer.SecondsPassed);
		Assert.AreEqual(2f, timer.SecondsRemaining);
	}
}
