using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(MobAttack))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6;
    [SerializeField] private float jumpPower = 10;
    [SerializeField] private Animator animator;

    private CharacterController _characterController;
    private Transform _transform;
    private Vector3 _moveVelocity;
    private PlayerStatus _status;
    private MobAttack _attack;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>(); //毎フレームアクセスするので、負荷を下げるためにキャッシュする
        _transform = transform; //Transformもキャッシュすると少しだけ負荷が下がる
        _status = GetComponent<PlayerStatus>();
        _attack = GetComponent<MobAttack>();

        // 初期高さを設定
        //_characterController.Move(Vector3.down * 0.1f);
        _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
    }

    private void Update()
    {
        Debug.Log(_characterController.isGrounded ? "地上にいます" : "空中です");

        if (Input.GetButtonDown("Fire1"))
        {
            // Fire1ボタン（デフォルトだとマウス左クリック）で攻撃
            _attack.AttackIfPossible();
        }

        if (_status.IsMovable) // 移動可能な状態であれば、ユーザー入力を移動に反映する
        {
            // 入力軸による移動処理（慣性を無視しているので、キビキビ動く）
            _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
            _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

            // 移動方向に向く
            _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0, _moveVelocity.z));
        }
        else
        {
            _moveVelocity.x = 0;
            _moveVelocity.z = 0;
        }

        if (_characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
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