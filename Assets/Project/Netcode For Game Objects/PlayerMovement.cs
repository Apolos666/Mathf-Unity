using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    private const string  MovementX = "Movement X";
    private const string MovementY = "Movement Y";
    
    private Animator _animator;
    private Rigidbody2D _rb2;

    [SerializeField] private float _speed = 5f;
    private Vector2 _movementDir;
    private Vector2 _lastMovementDir;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb2 = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!IsOwner) return;
        
        GetMoveDirection();
        
        RotateCharacter(_movementDir.x);
        
        SetAnimationParams();
        
        _rb2.MovePosition((Vector2)transform.position + _movementDir * (Time.deltaTime * _speed));
    }

    private void RotateCharacter(float movementX)
    {
        transform.localRotation = _lastMovementDir.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
    }

    private void GetMoveDirection()
    {
        _movementDir.x = Input.GetAxisRaw("Horizontal");
        
        _movementDir.y = Input.GetAxisRaw("Vertical");

        if (_movementDir.x != 0 && _movementDir.y != 0)
        {
            _lastMovementDir = _movementDir;
        } else if (_movementDir.x != 0)
        {
            _lastMovementDir = new Vector2(_movementDir.x, 0);
        } else if (_movementDir.y != 0)
        {
            _lastMovementDir = new Vector2(0, _movementDir.y);
        }
    }

    private void SetAnimationParams()
    {
        _animator.SetFloat(MovementX, _lastMovementDir.x);
        _animator.SetFloat(MovementY, _lastMovementDir.y);
    }
}