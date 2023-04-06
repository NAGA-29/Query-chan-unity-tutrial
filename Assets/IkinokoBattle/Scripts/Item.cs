using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    /// <summary>
    /// �A�C�e���̎�ޒ�`
    /// </summary>
    public enum ItemType
    {
        Wood, // ��
        Stone, // ��
        ThrowAxe // �����I�m�i�؂Ɛ΂ō��I�j
    }

    [SerializeField] private ItemType type;

    /// <summary>
    /// ����������
    /// </summary>
    public void Initialize()
    {
        // �A�j���[�V�������I���܂�collider�𖳌���
        var colliderCache = GetComponent<Collider>();
        colliderCache.enabled = false;

        // �o���A�j���[�V����
        var transformCache = transform;
        var dropPosition = transform.localPosition +
                           new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        transformCache.DOLocalMove(dropPosition, 0.5f);
        var defaultScale = transformCache.localScale;
        transformCache.localScale = Vector3.zero;
        transformCache.DOScale(defaultScale, 0.5f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                // �A�j���[�V�������I�������collider��L����
                colliderCache.enabled = true;
            });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // �v���C���[�̏����i�Ƃ��Ēǉ�
        OwnedItemsData.Instance.Add(type);
        OwnedItemsData.Instance.Save();
        // �����A�C�e���̃��O�o��
        foreach (var item in OwnedItemsData.Instance.OwnedItems)
        {
            Debug.Log(item.Type + "��" + item.Number + "����");
        }

        // �I�u�W�F�N�g�̔j��
        Destroy(gameObject);
    }
}