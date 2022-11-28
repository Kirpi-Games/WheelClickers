using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Scripts.Utilities;
using DG.Tweening;
using PathCreation.Examples;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    public bool canGoParkour;

    public IEnumerator SetCarIdleToParkour()
    {
        if (canGoParkour)
        {
            for (int i = 0; i < CarManager.Instance.idleCarList.Count; i++)
            {
                CarManager.Instance.cars.Add(CarManager.Instance.idleCarList[i]);
                 
                yield return new WaitForSeconds(0.4f);
                
                CarManager.Instance.idleCarList[i].GetComponent<PathFollower>().pathCreator = ParkourManager.Instance.currentParkour;
                CarManager.Instance.idleCarList.Remove(CarManager.Instance.idleCarList[i]);
                CarManager.Instance.SetCarParkour();
            }    
        }
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer.Equals(Constants.LayerPlayer))
        {
            canGoParkour = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer.Equals(Constants.LayerPlayer))
        {
            canGoParkour = true;
            StartCoroutine(SetCarIdleToParkour());
        }
    }
}
