using System;
using System.Collections;
using System.Collections.Generic;
using Akali.Scripts.Managers.StateMachine;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerAction inputSystem;
    public bool isClick = false;
    private float clickCounter = 0;

    private void OnEnable()
    {
        if (inputSystem == null)
        {
            inputSystem = new PlayerAction();

            inputSystem.Click.Click.performed += i => isClick = true;
        }
        
        inputSystem.Enable();
    }

    private void OnDisable()
    {
        inputSystem.Disable();
    }

    private void Awake()
    {
        GameStateManager.Instance.GameStatePlaying.OnExecute += HandleClickInput;
    }

    public void HandleClickInput()
    {
        if (isClick)
        {
            clickCounter += Time.deltaTime;
            if (clickCounter >= 1)
            {
                isClick = false;
                clickCounter = 0;
            }
        }
    }
}
