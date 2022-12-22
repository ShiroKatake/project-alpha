using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

namespace Timer
{
	public class TimerBehaviour : MonoBehaviour
	{
		private enum TimerType
		{
			Countdown,
			Stopwatch
		}

		[SerializeField] private TimerType _timerType;
		[SerializeField] private UnityEvent _onTimerEnd = null;
		[SerializeField] private float _duration;

		private Timer timer;

		private void Awake()
		{
			if (_timerType == TimerType.Countdown)
			{
				timer = new Timer(_duration);
				timer.OnCountdownEnd += HandleTimerEnd;
			}
			else
			{
				timer = new Timer();
			}
		}

		private void HandleTimerEnd()
		{
			_onTimerEnd.Invoke();
		}

		private void Update()
		{
			timer.Tick(Time.deltaTime);
		}

		#region Editor
		[CustomEditor(typeof(TimerBehaviour))]
		public class TimeBehaviourEditor : Editor
		{
			private TimerBehaviour timeBehaviour;

			private SerializedProperty timerType;
			private SerializedProperty duration;
			private SerializedProperty onTimerEnd;
			private SerializedProperty secondsPassed;

			void OnEnable()
			{
				timeBehaviour = (TimerBehaviour)target;

				// Link up the properties via the according field names
				timerType = serializedObject.FindProperty(nameof(timeBehaviour._timerType));
				duration = serializedObject.FindProperty(nameof(timeBehaviour._duration));
				onTimerEnd = serializedObject.FindProperty(nameof(timeBehaviour._onTimerEnd));
			}

			public override void OnInspectorGUI()
			{
				// Draw the default script field
				DrawScriptField();

				serializedObject.Update();

				// Draw the fields for if the timer is a countdown timer
				EditorGUILayout.PropertyField(timerType);
				if (timeBehaviour._timerType == TimerType.Countdown)
				{
					EditorGUILayout.PropertyField(duration);
					EditorGUILayout.PropertyField(onTimerEnd);
				}

				// Draw the fields for if the timer is a stopwatch
				else
				{
					EditorGUI.BeginDisabledGroup(true);
					EditorGUILayout.PropertyField(secondsPassed);
					EditorGUI.EndDisabledGroup();
				}

				serializedObject.ApplyModifiedProperties();
			}

			private void DrawScriptField()
			{
				EditorGUI.BeginDisabledGroup(true);
				EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour(timeBehaviour), typeof(TimerBehaviour), false);
				EditorGUI.EndDisabledGroup();

				EditorGUILayout.Space();
			}
		}
		#endregion
	}
}
