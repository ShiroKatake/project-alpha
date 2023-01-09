using System;
using UnityEngine;
using TimerSystem;

namespace ShootSystem
{
	public class Ammo : MonoBehaviour
    {
        [SerializeField] private AmmoType _ammoType;

		private SpriteRenderer _spriteRenderer;
		private Countdown _lifetimeTimer;
		private Action<Ammo> _onAmmoDie;

		public AmmoType AmmoType
		{
			get => _ammoType;
			set => _ammoType = value;
		}

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_lifetimeTimer = new Countdown(0, OnCountdownEnd);
		}

		public void OnAmmoDie(Action<Ammo> killAction)
		{
			_onAmmoDie = killAction;
		}

		private void OnEnable()
		{
			_spriteRenderer.sprite = _ammoType.sprite;
			_lifetimeTimer.SetNewDuration(_ammoType.lifetimeSeconds);
		}

		private void Update()
		{
			_lifetimeTimer.Tick(Time.deltaTime);
		}

		private void OnCountdownEnd()
		{
			_onAmmoDie(this);
			_lifetimeTimer.Reset();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			_onAmmoDie(this);
		}
	}
}
