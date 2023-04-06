using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private RectTransform _parentRectTransform;
    private Camera _camera;
    private MobStatus _status;

    private void Update()
    {
        Refresh();
    }

    public void Initialize(RectTransform parentRectTransform, Camera camera, MobStatus status)
    {
        _parentRectTransform = parentRectTransform;
        _camera = camera;
        _status = status;
        Refresh();
    }

    /// <summary>
    /// �̗̓Q�[�W���X�V
    /// </summary>
    private void Refresh()
    {
        //�c��̃��C�t��\��
        fillImage.fillAmount = _status.Life / _status.LifeMax;
        // �Ώ�Mob�̏ꏊ�ɃQ�[�W���ړ�����BWorld���W��Local���W��ϊ�����Ƃ���RectTransformUtility���g��
        var screenPoint = _camera.WorldToScreenPoint(_status.transform.position);
        Vector2 localPoint;
        //Cnavas Render Mode��Screen Space - Overlay�Ȃ̂ő�3������null���w��
        //Screen Space - Camera �̏ꍇ�́A�Ώۂ̃J������n���K�v������
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, screenPoint, null, out localPoint);
        transform.localPosition = localPoint + new Vector2(0, 80);
    }
}