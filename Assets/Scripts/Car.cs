using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Akali.Scripts.Utilities;
using DG.Tweening;
using PathCreation.Examples;
using TMPro;
using UnityEngine;


public class Car : MonoBehaviour
{
    public int carLevel;
    public TextMeshPro gainEffect;
    public int income = 2;
    private PathFollower pathFollower;
    public GameObject[] carLevelMesh;

    private void Awake()
    {
        pathFollower = GetComponent<PathFollower>();
    }
    

    private void Start()
    {
        SetLevel();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer.Equals(Constants.LayerPlayer))
        {
            if (other.gameObject.GetInstanceID() > GetInstanceID())
            {
                pathFollower.distanceTravelled -= Time.deltaTime*3;
            }
        }
    }


    public void SetLevel()
    {
        for (int i = 0; i < carLevelMesh.Length; i++)
        {
            carLevelMesh[i].SetActive(false);
            carLevelMesh[carLevel].SetActive(true);
        }
        income *= (carLevel+1);
        gainEffect.text = "+" + income;
    }
    
    public void SetSpeed(float speed)
    {
        DOTween.To(()=> pathFollower.speed, x=> pathFollower.speed = x, speed, 0.5f);
        pathFollower.speed = speed;
    }

    public void GainMoney()
    {
        //gainEffect.transform.DOLookAt(-1 * Camera.main.transform.position, 0.8f);
        gainEffect.transform.DOScale(1.5f, 0.5f).OnComplete((() => gainEffect.transform.DOScale(0f, 0.3f)));
        gainEffect.transform.DOLocalMoveY(2.5f, 0.8f).OnComplete((() => gainEffect.transform.DOLocalMoveY(0f, 0.2f)));
    }
}

