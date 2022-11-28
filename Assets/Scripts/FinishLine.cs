using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts.Utilities;
using Akali.Ui_Materials.Scripts.Components;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void Awake()
    {
        Invoke("EnableCollision",2);
    }

    private void EnableCollision()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(Constants.LayerPlayer))
        {
            MoneyText.Instance.IncreaseMoney(other.GetComponent<Car>().income);
            other.GetComponent<Car>().GainMoney();
        }
    }
}
