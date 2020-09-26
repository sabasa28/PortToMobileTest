using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    Button menuSelectedButton;
    [SerializeField]
    Button playButton;
    [SerializeField]
    Button creditsButton;
    [SerializeField]
    Button optionsButton;
    [SerializeField]
    GameObject menuPanel;
    [SerializeField]
    GameObject creditsPanel;
    [SerializeField]
    Button creditsFirstButton;
    [SerializeField]
    GameObject optionsPanel;
    [SerializeField]
    Button optionsFirstButton;
    [SerializeField]
    GameObject modeSelecPanel;
    [SerializeField]
    Button modeSelecFirstButton;
    void Start()
    {
        animator.SetTrigger("Show");
        menuSelectedButton = playButton;
        menuSelectedButton.Select();
    }

    public void PlaySinglePlayer()
    {
        DatosPartida.Singleplayer = true;
        SceneManager.LoadScene(2);
        Debug.Log("Comenzando juego (single player)");
    }

    public void PlaySplitScreen()
    {
        DatosPartida.Singleplayer = false;
        SceneManager.LoadScene(2);
        Debug.Log("Comenzando juego (split screen)");
    }

    public void ShowModeSelection()
    {
        modeSelecPanel.SetActive(true);
        modeSelecFirstButton.Select();
        menuSelectedButton = playButton;
    }

    public void HideModeSelection()
    {
        modeSelecPanel.SetActive(false);
        menuSelectedButton.Select();
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
        menuPanel.SetActive(false);
        optionsFirstButton.Select();
        menuSelectedButton = optionsButton;
    }
    public void HideOptions()
    {
        optionsPanel.SetActive(false);
        menuPanel.SetActive(true);
        menuSelectedButton.Select();
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
        menuPanel.SetActive(false);
        creditsFirstButton.Select();
        menuSelectedButton = creditsButton;
    }
    public void HideCredits()
    {
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true);
        menuSelectedButton.Select();
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }


}
