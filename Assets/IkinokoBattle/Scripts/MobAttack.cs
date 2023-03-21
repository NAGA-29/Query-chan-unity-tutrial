using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; //�U���܂ł̃N�[���_�E��
    [SerializeField] private Collider attackCollider;

    private MobStatus _status;

    private void Start()
    {
        this._status = GetComponent<MobStatus>();
        //Debug.Log(this._status.ToString());
    }

    public void AttackIfPossible()
    {
        if (!this._status.IsAttackable) return;

        this._status.GoToAttackStateIfPossible();
    }

    public void OnAttackRangeEnter(Collider collider)
    {
        //Debug.Log("�G��!");

        this.AttackIfPossible();
    }

    public void OnAttackStart()
    {
        this.attackCollider.enabled = true;
    }

    /**attackCollider���U���Ώۂ�HTI�������ɌĂ΂��
     */
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;

        targetMob.Damage(1); //�v���C���[�Ƀ_���[�W
    }
        
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(this.CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfPossible();
    }
}
