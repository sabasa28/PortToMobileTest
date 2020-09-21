using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text moneyText;
    float onDisplayMoney;
    private void Start()
    {
        onDisplayMoney = player.Dinero;
        moneyText.text = "MONEY: "+ onDisplayMoney.ToString("C");
    }

    void Update()
    {
        if (onDisplayMoney != player.Dinero)
        {
            onDisplayMoney = player.Dinero;
            moneyText.text = "MONEY: " + onDisplayMoney.ToString("C");
        }
    }
}
