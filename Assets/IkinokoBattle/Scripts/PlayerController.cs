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
        _characterController = GetComponent<CharacterController>(); //���t���[���A�N�Z�X����̂ŁA���ׂ������邽�߂ɃL���b�V������
        _transform = transform; //Transform���L���b�V������Ə����������ׂ�������
        _status = GetComponent<PlayerStatus>();
        _attack = GetComponent<MobAttack>();

        // ����������ݒ�
        //_characterController.Move(Vector3.down * 0.1f);
        _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
    }

    private void Update()
    {
        Debug.Log(_characterController.isGrounded ? "�n��ɂ��܂�" : "�󒆂ł�");

        if (Input.GetButtonDown("Fire1"))
        {
            // Fire1�{�^���i�f�t�H���g���ƃ}�E�X���N���b�N�j�ōU��
            _attack.AttackIfPossible();
        }

        if (_status.IsMovable) // �ړ��\�ȏ�Ԃł���΁A���[�U�[���͂��ړ��ɔ��f����
        {
            // ���͎��ɂ��ړ������i�����𖳎����Ă���̂ŁA�L�r�L�r�����j
            _moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
            _moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;

            // �ړ������Ɍ���
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