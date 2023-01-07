using UnityEngine;
using ShootSystem;

[RequireComponent(typeof(CharacterMovement))]
public class InputManager: MonoBehaviour
{
	private ShootBehaviour _shootBehaviour;
	private CharacterMovement _characterMovement;

	private GameInputs.PlayerActions _playerInput;

	private void Awake()
	{
		_characterMovement = GetComponent<CharacterMovement>();
		_shootBehaviour = GetComponent<ShootBehaviour>();

		_playerInput = new GameInputs().Player;
		_playerInput.Enable();

		_playerInput.Move.performed += context => _characterMovement.MoveDirection = context.ReadValue<Vector2>();
		_playerInput.Move.canceled += _ => _characterMovement.MoveDirection = Vector2.zero;

		_playerInput.Ability1.performed += _ => _shootBehaviour.Shoot.LoadAmmo(0);
		_playerInput.Ability2.performed += _ => _shootBehaviour.Shoot.LoadAmmo(1);
		_playerInput.Ability3.performed += _ => _shootBehaviour.Shoot.LoadAmmo(2);

		_playerInput.Ability1.canceled += _ => _shootBehaviour.Shoot.ShootAmmo(0);
		_playerInput.Ability2.canceled += _ => _shootBehaviour.Shoot.ShootAmmo(1);
		_playerInput.Ability3.canceled += _ => _shootBehaviour.Shoot.ShootAmmo(2);
	}
}
