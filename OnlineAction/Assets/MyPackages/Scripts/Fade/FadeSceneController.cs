using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 参考：https://kenko-san.com/unity-fade/

public class FadeSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //フェード用のCanvas.
    [SerializeField]
    private Canvas fadeCanvas;

    //フェード用Imageの透明度
    private float fadeAlpha = 0.0f;

    //フェードインアウトのフラグ
    private bool isFadeIn = false;
    private bool isFadeOut = false;

    //フェードしたい時間（単位は秒）
    [SerializeField]
    public float fadeTime = 0.2f;

    //遷移先のシーン番号
    private string nextSceneName = null;

    //フェードイン開始
    public void FadeIn()
    {
        if (fadeCanvas == null)
        {
            return;
        }

        //Debug.Log("Fade in -- start");
        CanvasGroup cg = fadeCanvas.GetComponent<CanvasGroup>();
        cg.blocksRaycasts = true;
        fadeAlpha = cg.alpha = 1.0f;
        isFadeIn = true;
    }

    //フェードアウト開始
    public void FadeOut(string sceneName)
    {
        if (fadeCanvas == null)
        {
            return;
        }

        nextSceneName = sceneName;
        CanvasGroup cg = fadeCanvas.GetComponent<CanvasGroup>();
        cg.blocksRaycasts = true;
        fadeAlpha = cg.alpha = 0.0f;
        fadeCanvas.enabled = true;
        isFadeOut = true;
    }

    protected void UpdateFade()
    {
        if (fadeCanvas == null)
        {
            return;
        }

        CanvasGroup cg = fadeCanvas.GetComponent<CanvasGroup>();

        //フラグ有効なら毎フレームフェードイン/アウト処理.
        if (isFadeIn)
        {
            //経過時間から透明度計算.
            fadeAlpha -= Time.deltaTime / fadeTime;

            //フェードイン終了判定.
            if (fadeAlpha <= 0.0f)
            {
                cg.blocksRaycasts = false;
                isFadeIn = false;
                fadeAlpha = 0.0f;
                fadeCanvas.enabled = false;
            }

            //フェード用Imageの色・透明度設定.
            cg.alpha = fadeAlpha;
        }
        else if (isFadeOut)
        {
            //経過時間から透明度計算.
            fadeAlpha += Time.deltaTime / fadeTime;

            //フェードアウト終了判定.
            if (fadeAlpha >= 1.0f)
            {
                cg.blocksRaycasts = false;
                isFadeOut = false;
                fadeAlpha = 1.0f;

                //次のシーンへ遷移.
                SceneManager.LoadScene(nextSceneName);
            }

            //フェード用Imageの色・透明度設定.
            cg.alpha = fadeAlpha;
        }
    }
}
