using Akali.Common;
using DG.Tweening;
using TMPro;
using UnityEngine;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

namespace Akali.Ui_Materials.Scripts.Components
{
    public class MoneyText : Singleton<MoneyText>
    {
        private TextMeshProUGUI text;
        private float startScale;
        private Color32 startColor;
        [SerializeField] private Color32 increaseColor;
        [SerializeField] private Color32 decreaseColor;

        private void OnEnable()
        {
            text = gameObject.GetComponent<TextMeshProUGUI>();
            text.text = $"{PlayerPrefs.GetMoney()}";
            startColor = text.color;
            startScale = text.transform.localScale.x;
        }

        public void IncreaseMoney(int increase)
        {
            var currentMoney = PlayerPrefs.GetMoney();
            var newMoney = currentMoney + increase;
            text.DOScale(startScale * 1.2f, 0.2f).OnComplete(() => text.DOScale(startScale, 0.1f));
            text.DOColor(increaseColor, 0.2f).OnComplete(() => text.DOColor(startColor, 0.1f));
            text.DOCounter(currentMoney, newMoney, 0.2f).OnComplete(() => PlayerPrefs.SetMoney(newMoney));

        }

        public void DecreaseMoney(int decrease)
        {
            var currentMoney = PlayerPrefs.GetMoney();
            var newMoney = currentMoney - decrease;
            text.DOScale(startScale * 1.2f, 0.2f).OnComplete(() => text.DOScale(startScale, 0.1f));
            text.DOColor(decreaseColor, 0.2f).OnComplete(() => text.DOColor(startColor, 0.1f));
            text.DOCounter(currentMoney, newMoney, 0.2f).OnComplete(() => PlayerPrefs.SetMoney(newMoney));
        }
    }
}