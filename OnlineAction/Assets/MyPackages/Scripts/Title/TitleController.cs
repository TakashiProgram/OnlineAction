using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : FadeSceneController
{
    private readonly string NEXT_SCENE = "Select";

    void Start()
    {
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFade();
    }

    public void StartButtonPressed()
    {
        FadeOut(NEXT_SCENE);
    }
}
