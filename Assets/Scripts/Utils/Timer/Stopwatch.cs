namespace TimerSystem
{
    public class Stopwatch : Timer
	{
		public Stopwatch()
		{
			_secondsPassed = 0f;
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
		}
	}
}
