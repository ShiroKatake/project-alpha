using System;

namespace TimerSystem
{
	public class Timer
	{
		private float _countdownDuration;
		public event Action OnCountdownEnd;

		public float SecondsPassed { get; private set; }
		public float SecondsRemaining { get => IsCountdownTimer ? _countdownDuration - SecondsPassed : float.NaN; }

		private bool IsCountdownTimer { get => _countdownDuration > -1f; }

		// Initialize timer as stopwatch
		public Timer()
		{
			SecondsPassed = 0f;
			_countdownDuration = -1f;
		}

		// Initialize timer as countdown
		public Timer(float duration)
		{
			SecondsPassed = 0f;
			_countdownDuration = duration;
		}

		public void Tick(float deltaTime)
		{
			if (SecondsPassed == _countdownDuration) { return; }

			SecondsPassed += deltaTime;

			if (IsCountdownTimer)
			{
				CheckForTimerEnd();
			}
		}

		private void CheckForTimerEnd()
		{
			if (SecondsPassed < _countdownDuration) { return; }
			SecondsPassed = _countdownDuration;
			OnCountdownEnd?.Invoke();
		}
	}
}
