using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Ui_Materials.Scripts.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

public class MergeCar : Singleton<MergeCar>
{
    [HideInInspector] public Button button;
    private int money;
    public int moneyIncrease = 22;
    public TextMeshProUGUI moneyText;
    private string moneyTextStr;

    private void Awake()
    {
        money = PlayerPrefs.GetCarMergeAmount();
        button = GetComponent<Button>();
        button.onClick.AddListener(MergeNewCar);
        SortString();
    }

    public void SetButtonMoneyOnLevel()
    {
        money = money + (moneyIncrease * PlayerPrefs.GetMergeCarLevel());
        SortString();
        PlayerPrefs.SetCarMergeAmount(money);
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

    private void MergeNewCar()
    {
        if (PlayerPrefs.GetMoney() >= money && CarManager.Instance.canMerge)
        {
            button.enabled = false;
            MoneyText.Instance.DecreaseMoney(money);
            PlayerPrefs.SetMergeCarLevel(PlayerPrefs.GetMergeCarLevel() + 1);
            PlayerController.Instance.MergeCars();
            SetButtonMoneyOnLevel();
        }
    }
}
