using NUnit.Framework;

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
