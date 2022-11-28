using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Akali.Common;
using Akali.Ui_Materials.Scripts.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

public class BuyCar : Singleton<BuyCar>
{
    private Button button;
    private int money;
    public int moneyIncrease = 22;
    public TextMeshProUGUI moneyText;
    private string moneyTextStr;

    private void Awake()
    {
        money = PlayerPrefs.GetCarBuyAmount();
        button = GetComponent<Button>();
        button.onClick.AddListener(BuyNewCar);
        SortString();
    }

    public void SetButtonMoneyOnLevel()
    {
        money = money + (moneyIncrease * PlayerPrefs.GetBuyCarLevel());
        SortString();
        PlayerPrefs.SetCarBuyAmount(money);    
        print(PlayerPrefs.GetCarBuyAmount());
    }

    public void SortString()
    {
        #region NumberSort

        if (money > 100000000000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 7) + "B";
        }
        else if (money > 10000000000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 6) + "B";
        }
        else if (money > 1000000000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 5) + "B";
        }
        else if (money > 100000000000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 6) + "M";
        }
        else if (money > 10000000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 5) + "M";
        }
        else if (money > 1000000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 4) + "M";
        }
        else if (money > 100000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 5) + "K";
        }
        else if (money > 10000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 4) + "K";
        }
        else if (money > 1000)
        {
            string moneyString = money.ToString("C0");
            moneyTextStr = moneyString.Substring(0, 3) + "K";
        }
        else if (money > 100)
        {
            moneyTextStr = money.ToString();
        }
        else if (money > 10)
        {
            moneyTextStr = money.ToString();
        }
        else if (money > 1)
        {
            moneyTextStr = money.ToString();
        }
        moneyText.text = moneyTextStr;

        #endregion
    }

    public void EnableButton()
    {
        button.enabled = true;
    }
    
    private void BuyNewCar()
    {
        if (PlayerPrefs.GetMoney() >= money)
        {
            button.enabled = false;
            MoneyText.Instance.DecreaseMoney(money);
            PlayerPrefs.SetBuyCarLevel(PlayerPrefs.GetBuyCarLevel() + 1);
            PlayerController.Instance.AddNewCar();
            SetButtonMoneyOnLevel();
            Invoke("EnableButton",0.4f);
        }
    }
    
}


