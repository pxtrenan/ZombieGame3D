using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public Image splashImage;
    public Image splashImage2;
    public string loadLevel;

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        splashImage2.canvasRenderer.SetAlpha(0.0f);

        FadeINM();
        yield return new WaitForSeconds(3.5f);
        FadeOutM();
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(loadLevel);
    }

    void FadeINM()
    {
        splashImage.CrossFadeAlpha(2.0f, 3.0f, false);
        splashImage2.CrossFadeAlpha(2.0f, 3.0f, false);
    }
    void FadeOutM()
    {
        splashImage.CrossFadeAlpha(0.0f, 3.5f, false);
        splashImage2.CrossFadeAlpha(0.0f, 3.5f, false);
    }
}
