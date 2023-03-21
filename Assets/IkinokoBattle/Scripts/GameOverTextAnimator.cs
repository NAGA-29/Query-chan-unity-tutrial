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
        //終点として使用するため、初期座標を保持する
        var defaultPosition = transformCache.localPosition;
        //いったん上のほうに移動させる
        transformCache.localPosition = new Vector3(0, 300f);
        //移動アニメーションを開始
        transformCache.DOLocalMove(defaultPosition, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Debug.Log("Game Over!!");
                //シェイクアニメーション
                transformCache.DOShakePosition(1.5f, 100);
            });

        //DOTweenには、Coroutineを使用せず任意の秒数を持てるメソッドがある
        DOVirtual.DelayedCall(10, () =>
        {
            SceneManager.LoadScene("TitleScene");
        });

    }
}
