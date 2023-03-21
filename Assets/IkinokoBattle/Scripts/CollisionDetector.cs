//using System;
//using UnityEngine;
//using UnityEngine.Events;

//[RequireComponent(typeof(Collider))]
//public class CollisionDetector : MonoBehaviour
//{
//    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
//    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();

//    private void OnTriggerEnter(Collider other)
//    {
//        onTriggerEnter.Invoke(other);
//    }

//    /// <summary>
//    /// Is TriggerがONで他のColliderと重なっているときは、このメソッドが常にコールされる
//    /// </summary>
//    /// <param name="other"></param>
//    private void OnTriggerStay(Collider other)
//    {
//        // onTriggerStayで指定された処理を実行する
//        onTriggerStay.Invoke(other);
//    }

//    // UnityEventを継承したクラスに[Serializable]属性を付与することで、Inspectorウインドウ上に表示できるようになる。
//    [Serializable]
//    public class TriggerEvent : UnityEvent<Collider>
//    {
//    }
//}

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    //[SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    //[SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();
    [SerializeField] private UnityEvent<Collider> onTriggerEnter = new TriggerEvent();
    [SerializeField] private UnityEvent<Collider> onTriggerStay = new TriggerEvent();

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay?.Invoke(other);
    }

    //UnityEventを継承したクラスに[Serializable] 属性を付与することで、Inspectorウインドウ上に表示できるようになる。
    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>{}
}