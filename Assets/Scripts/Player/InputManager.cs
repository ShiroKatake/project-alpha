using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class InputManager: MonoBehaviour
{
	private ShootBehaviour _shoot;
	private CharacterMovement _characterMovement;

	private GameInputs.PlayerActions _playerInput;

	private void Awake()
	{
		_characterMovement = GetComponent<CharacterMovement>();
		_shoot = GetComponent<ShootBehaviour>();

		_playerInput = new GameInputs().Player;
		_playerInput.Enable();

		_playerInput.Move.performed += context => _characterMovement.MoveDirection = context.ReadValue<Vector2>();
		_playerInput.Move.canceled += _ => _characterMovement.MoveDirection = Vector2.zero;

		_playerInput.Abiliity1.started += _ => _shoot.LoadBullet(0);
		_playerInput.Abiliity2.started += _ => _shoot.LoadBullet(1);
		_playerInput.Abiliity3.started += _ => _shoot.LoadBullet(2);

		_playerInput.Abiliity1.performed += _ => _shoot.ShootBullet();
		_playerInput.Abiliity2.performed += _ => _shoot.ShootBullet();
		_playerInput.Abiliity3.performed += _ => _shoot.ShootBullet();
	}
}
