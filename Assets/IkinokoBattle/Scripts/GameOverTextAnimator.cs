using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverTextAnimator : MonoBehaviour
{
    void Start()
    {
        var transformCache = transform;
        //�I�_�Ƃ��Ďg�p���邽�߁A�������W��ێ�����
        var defaultPosition = transformCache.localPosition;
        //���������̂ق��Ɉړ�������
        transformCache.localPosition = new Vector3(0, 300f);
        //�ړ��A�j���[�V�������J�n
        transformCache.DOLocalMove(defaultPosition, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Debug.Log("Game Over!!");
                //�V�F�C�N�A�j���[�V����
                transformCache.DOShakePosition(1.5f, 100);
            });

        //DOTween�ɂ́ACoroutine���g�p�����C�ӂ̕b�������Ă郁�\�b�h������
        DOVirtual.DelayedCall(10, () =>
        {
            SceneManager.LoadScene("TitleScene");
        });

    }
}
