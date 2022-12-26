using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    public Vector2 MoveDirection { private get; set; }

    public void Move(Vector2 moveDirection)
    {
        if (moveDirection == Vector2.zero) return;

        Vector2 newPosition = _moveSpeed * Time.deltaTime * moveDirection;
        transform.Translate(newPosition, Space.World);
    }

	private void Update()
	{
        Move(MoveDirection);
	}
}
