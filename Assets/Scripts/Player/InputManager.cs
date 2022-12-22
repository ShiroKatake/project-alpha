using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterMovement))]
public class InputManager: MonoBehaviour
{
	private PlayerController _playerController;
	private CharacterMovement _characterMovement;

	private GameInputs.PlayerActions _playerInput;

	private void Awake()
	{
		_characterMovement = GetComponent<CharacterMovement>();

		_playerInput = new GameInputs().Player;
		_playerInput.Enable();

		_playerInput.Move.performed += context => _characterMovement.MoveDirection = context.ReadValue<Vector2>();
		_playerInput.Move.canceled += _ => _characterMovement.MoveDirection = Vector2.zero;

		_playerInput.Shoot.started += context => _playerController.ChargeAmmo(context);
		_playerInput.Shoot.canceled += context => _playerController.ShootAmmo(context);
	}
}
