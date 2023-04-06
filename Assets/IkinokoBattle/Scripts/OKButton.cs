using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OKButton : MonoBehaviour
{
    private void Start()
    {
        //ƒ{ƒ^ƒ“‰Ÿ‰ºŽž‚ÉOK‚Ì‰¹‚ª–Â‚é‚æ‚¤‚É‚·‚é
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.Play("ok");
        });
    }
}