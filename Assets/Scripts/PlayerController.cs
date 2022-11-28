using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Common;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using UnityEngine;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

public class PlayerController : Singleton<PlayerController>
{
    private InputHandler inputHandler;


    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        GameStateManager.Instance.GameStatePlaying.OnExecute += ClickHandler;
        Invoke("StartGame",0.5f);
    }

    public void StartGame()
    {
        AkaliLevelManager.Instance.LevelIsPlaying();
    }

    public void ClickHandler()
    {
        
        if (inputHandler.isClick)
        {
            CarManager.Instance.SetCarSpeed(PlayerPrefs.GetCarSpeed() + 2.5f);    
        }
        else
        {
            CarManager.Instance.SetCarSpeed(PlayerPrefs.GetCarSpeed());
        }
    }

    public void AddNewCar()
    {
        print("CarAdd");
        CarManager.Instance.AddCar();
    }

    public void MergeCars()
    {
        print("CarMerge");
        StartCoroutine(CarManager.Instance.MergeCarAnim());
    }
}

