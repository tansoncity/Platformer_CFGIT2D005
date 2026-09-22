using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigid;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private InputAction _moveAction;
    private InputAction _jumpAction;

    private void Start()
    {
        _moveAction = InputSystem.actions["Move"];
        _moveAction.Enable();
        _jumpAction = InputSystem.actions["Jump"];
        _jumpAction.Enable();
    }

    private void Update()
    {
        var direction = _moveAction.ReadValue<Vector2>();
        UpdateRotation(direction);
        UpdateMovement(direction);
        
        if (_jumpAction.triggered)
        {
            Jump();
        }

        PlayRunAnimation(direction);
    }

    private void Jump()
    {
        if (_groundChecker.IsOnGround)
        {
            _rigid.linearVelocityY = _jumpSpeed;
        }
    }

    private void UpdateRotation(Vector2 direction)
    {
        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void UpdateMovement(Vector2 direction)
    {
        if (direction.x != 0)
        {
            _rigid.linearVelocityX = direction.x * _runSpeed;
        }
    }

    private void PlayRunAnimation(Vector2 direction)
    {
        if (direction.x != 0) 
        {
            _animator.Play("PlayerRun");
        }
        else
        {
            _animator.Play("PlayerIdle");
        }
    }
}
