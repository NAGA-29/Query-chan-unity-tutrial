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
    /// 体力ゲージを更新
    /// </summary>
    private void Refresh()
    {
        //残りのライフを表示
        fillImage.fillAmount = _status.Life / _status.LifeMax;
        // 対象Mobの場所にゲージを移動する。World座標やLocal座標を変換するときはRectTransformUtilityを使う
        var screenPoint = _camera.WorldToScreenPoint(_status.transform.position);
        Vector2 localPoint;
        //Cnavas Render ModeがScreen Space - Overlayなので第3引数にnullを指定
        //Screen Space - Camera の場合は、対象のカメラを渡す必要がある
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, screenPoint, null, out localPoint);
        transform.localPosition = localPoint + new Vector2(0, 80);
    }
}