using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonBlinker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartBlink();
    }

    private void StartBlink()
    {
        Image image = gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.DOFade(0.7f, 1.5f).SetEase(Ease.InQuart).SetLoops(-1, LoopType.Yoyo);
        }

    }
}
