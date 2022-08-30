using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    private Rigidbody2D _playerRb;
    private float _moveInputHor;
    private float _moveInputVer;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void FixedUpdate()
    {
        _moveInputHor = Input.GetAxis("Horizontal");
        _moveInputVer = Input.GetAxis("Vertical");
        _playerRb.velocity = new Vector2(_moveInputHor * speedPlayer, _moveInputVer * speedPlayer);
    }
}