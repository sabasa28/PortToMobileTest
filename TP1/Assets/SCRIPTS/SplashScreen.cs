using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SplashScreen : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] float timeBeforeFadeOut;
    [SerializeField] float timeFadingOut;
    [SerializeField] float timeBeforeSceneChange;
    Color origTitleCol;
    Color targetTitleCol;
    void Start()
    {
        origTitleCol = title.color;
        targetTitleCol = new Color(title.color.r, title.color.g, title.color.b, 0.0f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeBeforeFadeOut);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / timeFadingOut;
            title.color = Color.Lerp(origTitleCol,targetTitleCol,t);
            yield return null;
        }
        yield return new WaitForSeconds(timeBeforeSceneChange);
        SceneManager.LoadScene(1);
    }
}
