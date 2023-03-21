using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Android.Types;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Wood,
        Stone,
        ThrowAxe
    }

    [SerializeField] private ItemType type;
    public void Initialize()
    {
        //�A�j���[�V�������I���܂�Collider�𖳌��ɂ���
        var colliderCache = GetComponent<Collider>();
        colliderCache.enabled = false;

        //�o���A�j���[�V����
        var transformCache = transform;
        var dropPosition = transform.localPosition;

        new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        transformCache.DOLocalMove(dropPosition, 0.5f);
        var defaultScale = transformCache.localScale;

        transformCache.localScale = Vector3.zero;
        transformCache.DOScale(defaultScale, 0.5f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                //�A�j���[�V�������I�������collider��L��������
                colliderCache.enabled = true;
            });
    }

    private void OntriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
            //TODO: �v���C���[�̏����i�Ƃ��Ēǉ�����

            //�I�u�W�F�N�g���폜
            Destroy(gameObject);
    }
}
