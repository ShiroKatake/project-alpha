using NUnit.Framework;
using TimerSystem;

public class StopwatchTests
{
	[Test]
	public void TickingTwoSeconds_SecondsPassedIsTwoSeconds()
	{
		Stopwatch timer = new Stopwatch();
		timer.Tick(2f);
		Assert.AreEqual(2f, timer.SecondsPassed);
	}

	[Test]
	public void Reset_StopwatchIsReset()
	{
		Stopwatch timer = new Stopwatch();
		timer.Tick(2f);
		Assert.AreEqual(2f, timer.SecondsPassed);
		timer.Reset();
		Assert.AreEqual(0f, timer.SecondsPassed);
	}
}
