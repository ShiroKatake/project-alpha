using System;

namespace TimerSystem
{
    public class Countdown : Timer
    {
		private float _durationSeconds;
		private event Action _onCountdownEnd;

		public float SecondsRemaining => _durationSeconds - SecondsPassed;

		public Countdown(float durationSeconds, Action onCountdownEnd = null)
		{
			_secondsPassed = 0f;
			_durationSeconds = durationSeconds;
			_onCountdownEnd += onCountdownEnd;
		}

		public override void Tick(float deltaTime)
		{
			if (_secondsPassed == _durationSeconds) { return; }
			base.Tick(deltaTime);
			CheckForTimerEnd();
		}

		public void SetNewDuration(float durationSeconds)
		{
			_durationSeconds = durationSeconds;
		}

		private void CheckForTimerEnd()
		{
			if (_secondsPassed < _durationSeconds) { return; }
			_secondsPassed = _durationSeconds;
			_onCountdownEnd?.Invoke();
		}
	}
}
