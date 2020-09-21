using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusDisplay : MonoBehaviour
{
    [SerializeField] Text bonusText;
    Color onColor;
    Color offColor;
    float timeBeforeFadeOut = 0.5f;
    float timeFadingOut = 1.0f;
    Coroutine fading = null;
    void Start()
    {
        onColor = new Color(bonusText.color.r, bonusText.color.g, bonusText.color.b, 1.0f);
        offColor = new Color(bonusText.color.r, bonusText.color.g, bonusText.color.b, 0.0f);
    }

    public void Display()
    {
        if (fading != null)
        {
            StopCoroutine(fading);
        }
        fading = StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        bonusText.color = onColor;
        yield return new WaitForSeconds(timeBeforeFadeOut);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / timeFadingOut;
            bonusText.color = Color.Lerp(onColor, offColor, t);
            yield return null;
        }
    }
}
