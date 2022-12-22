using NUnit.Framework;

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
