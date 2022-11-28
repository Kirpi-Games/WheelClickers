using System.Collections;
using System.Collections.Generic;
using Akali.Ui_Materials.Scripts.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;
public class NextMap : MonoBehaviour
{
    [HideInInspector] public Button button;
    private int money;
    public TextMeshProUGUI moneyText;
    private string moneyTextStr;

    private void Awake()
    {
        money = 8020000;
        button = GetComponent<Button>();
        button.onClick.AddListener(NextParkour);
        SortString();
    }

    public void SetButtonMoneyOnLevel()
    {
        SortString();
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

    private void NextParkour()
    {
        if (PlayerPrefs.GetMoney() >= money)
        {
            button.enabled = false;
            MoneyText.Instance.DecreaseMoney(money);
            PlayerPrefs.SetParkourLevel(PlayerPrefs.GetParkourLevel() + 1);
            CarManager.Instance.SetCarParkour();
            SetButtonMoneyOnLevel();
        }
    }
}
