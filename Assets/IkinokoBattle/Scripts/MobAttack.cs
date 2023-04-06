using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; //攻撃までのクールダウン
    [SerializeField] private Collider attackCollider;
    [SerializeField] private AudioSource swingSound;

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
        //Debug.Log("敵だ!");

        this.AttackIfPossible();
    }

    public void OnAttackStart()
    {
        this.attackCollider.enabled = true;

        if (this.swingSound != null)
        {
            swingSound.pitch = Random.Range(0.7f, 1.3f);
            swingSound.Play();
        }
    }

    /**attackColliderが攻撃対象にHTIした時に呼ばれる
     */

    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;

        targetMob.Damage(1); //プレイヤーにダメージ
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