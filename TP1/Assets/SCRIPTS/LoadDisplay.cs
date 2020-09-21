using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDisplay : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Sprite Load0;
    [SerializeField] Sprite Load1;
    [SerializeField] Sprite Load2;
    [SerializeField] Sprite Load3;
    [SerializeField] Image ImageOnDisplay;
    int bolasasDisplayed;
    void Start()
    {
        bolasasDisplayed = 0;
        ImageOnDisplay.sprite = Load0;
    }

    void Update()
    {
        if (bolasasDisplayed != player.CantBolsAct)
        {
            bolasasDisplayed = player.CantBolsAct;
            switch (bolasasDisplayed)
            {
                case 0:
                    ImageOnDisplay.sprite = Load0;
                    break;
                case 1:
                    ImageOnDisplay.sprite = Load1;
                    break;
                case 2:
                    ImageOnDisplay.sprite = Load2;
                    break;
                case 3:
                    ImageOnDisplay.sprite = Load3;
                    break;
            }
        }
    }
}
