namespace TimerSystem
{
	public enum TimerType
	{
		Countdown,
		Stopwatch
	}

	public abstract class Timer
	{
		protected float _secondsPassed;
		protected TimerType _timerType;


		public float SecondsPassed { get => _secondsPassed; }

		public virtual void Tick(float deltaTime) {
			_secondsPassed += deltaTime;
		}

		public void Reset()
		{
			_secondsPassed = 0f;
		}
	}
}
