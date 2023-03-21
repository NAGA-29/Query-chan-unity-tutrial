using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6;
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private Animator animator;

    private CharacterController _characterController;
    private Transform _transform;
    private Vector3 _moveVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = transform;

        // èâä˙çÇÇ≥Çê›íË
        //_characterController.Move(Vector3.down * 0.1f);
        _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
    }

    void Update()
    {
        Debug.Log(_characterController.isGrounded ? "ínè„Ç…Ç¢Ç‹Ç∑" : "ãÛíÜÇ≈Ç∑");

        _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

        _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));

        if (_characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("ÉWÉÉÉìÉv");
                _moveVelocity.y = jumpPower;
            }
        }
        else
        {
            _moveVelocity.y += (Physics.gravity.y * 2.5f) * Time.deltaTime;
        }
        _characterController.Move(_moveVelocity * Time.deltaTime);

        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
    }
}
