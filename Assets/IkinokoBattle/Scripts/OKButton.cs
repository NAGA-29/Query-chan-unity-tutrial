using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OKButton : MonoBehaviour
{
    private void Start()
    {
        //�{�^����������OK�̉�����悤�ɂ���
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.Play("ok");
        });
    }
}