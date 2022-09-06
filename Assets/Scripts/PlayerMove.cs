using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    private Rigidbody2D _playerRb;
    private float _moveInputHor;
    private float _moveInputVer;
    [FormerlySerializedAs("_cam")] public Camera cam;

    private Vector2 _mousePos;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        _moveInputHor = Input.GetAxis("Horizontal");
        _moveInputVer = Input.GetAxis("Vertical");
        
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        
        _playerRb.velocity = new Vector2(_moveInputHor * speedPlayer, _moveInputVer * speedPlayer);
        var lookDir = _mousePos - _playerRb.position;
        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 270f;
        _playerRb.rotation = angle;
    }
}