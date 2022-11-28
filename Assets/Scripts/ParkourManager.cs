using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using PathCreation;
using UnityEngine;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

public class ParkourManager : Singleton<ParkourManager>
{
    public List<PathCreator> parkours;
    public PathCreator currentParkour;
    

    private void Awake()
    {
        ActiveParkour();
    }

    public void ActiveParkour()
    {
        for (int i = 0; i < parkours.Count; i++)
        {
            parkours[i].gameObject.SetActive(false);
            currentParkour = null;
            parkours[PlayerPrefs.GetParkourLevel()].gameObject.SetActive(true);
            currentParkour = parkours[PlayerPrefs.GetParkourLevel()];
        }
    }
    
}
