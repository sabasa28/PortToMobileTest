using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] Image transitionBackground;
    [SerializeField] Text winnerText;
    [SerializeField] Text moneyP1Text;
    [SerializeField] Text moneyP2Text;
    [SerializeField] GameObject results;
    [SerializeField] GameObject credits;
    Color panelOnCol;
    Color panelOffCol;
    float timeToTransition = 1.5f;
    float timeToTakeInput = 2.0f;

    void Start()
    {
        panelOnCol = new Color(transitionBackground.color.r, transitionBackground.color.g, transitionBackground.color.b, 1);
        panelOffCol = new Color(transitionBackground.color.r, transitionBackground.color.g, transitionBackground.color.b, 0);
        transitionBackground.color = panelOnCol;
        if (DatosPartida.LadoGanadaor == DatosPartida.Lados.Izq)
        {
            winnerText.text = "The winner is player 1";
            moneyP1Text.text = "Player 1: "+ DatosPartida.PtsGanador.ToString("C");
            moneyP2Text.text = "Player 2: " + DatosPartida.PtsPerdedor.ToString("C");
        }
        else
        {
            winnerText.text = "The winner is player 2";
            moneyP1Text.text = "Player 1: " + DatosPartida.PtsPerdedor.ToString("C");
            moneyP2Text.text = "Player 2: " + DatosPartida.PtsGanador.ToString("C");
        }
        StartCoroutine(Transition());
        StartCoroutine(Input());
    }

    IEnumerator Input()
    {
        yield return new WaitForSeconds(timeToTakeInput);
        bool creditsSeen = false;
        while (!creditsSeen)
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                creditsSeen=true;
                results.SetActive(false);
                credits.SetActive(true);
            }
            yield return null;
        }
        while (true)
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(1);
            }
            yield return null;
        }
    }

    IEnumerator Transition()
    {
        float t = 0.0f;
        while (t < 1)
        {
            t += Time.deltaTime/timeToTransition;
            transitionBackground.color = Color.Lerp(panelOnCol,panelOffCol,t);
            yield return null;
        }
    }
}
