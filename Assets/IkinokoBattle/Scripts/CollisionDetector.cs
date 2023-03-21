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
//    /// Is Trigger��ON�ő���Collider�Əd�Ȃ��Ă���Ƃ��́A���̃��\�b�h����ɃR�[�������
//    /// </summary>
//    /// <param name="other"></param>
//    private void OnTriggerStay(Collider other)
//    {
//        // onTriggerStay�Ŏw�肳�ꂽ���������s����
//        onTriggerStay.Invoke(other);
//    }

//    // UnityEvent���p�������N���X��[Serializable]������t�^���邱�ƂŁAInspector�E�C���h�E��ɕ\���ł���悤�ɂȂ�B
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

    //UnityEvent���p�������N���X��[Serializable] ������t�^���邱�ƂŁAInspector�E�C���h�E��ɕ\���ł���悤�ɂȂ�B
    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>{}
}