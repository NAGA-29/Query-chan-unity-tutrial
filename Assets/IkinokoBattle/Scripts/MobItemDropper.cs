using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MobStatus))]

public class MobItemDropper : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float dropRate = 0.1f;�@//�A�C�e���̏o���m��
    [SerializeField] private Item itemPrefab;
    [SerializeField] private int number = 1; //�A�C�e���o����

    private MobStatus _status;
    private bool _isDropInvoked;
    private void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    private void Update()
    {
        if(_status.Life <= 0)
        {
            //���C�t���s�������Ɏ��s
            DropIfNeeded();
        }
    }

    /**
     * �K�v�ł���΃A�C�e�����o��������
     */
    private void DropIfNeeded()
    {
        if(_isDropInvoked) return;

        _isDropInvoked = true;

        if (Random.Range(0, 1f) >= dropRate) return;

        for(var i=0; i < number; i++)
        {   
            //�w������̃A�C�e�����o��������
            var item = Instantiate(itemPrefab, transform.position, Quaternion.identity);

            item.Initialize();
        }
    }
}
