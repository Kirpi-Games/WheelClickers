using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Akali.Common;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using DG.Tweening;
using PathCreation.Examples;
using UnityEngine;



public class CarManager : Singleton<CarManager>
{
    public bool canMerge;
    public bool canSpawn;
    public List<Car> cars;
    public List<Car> idleCarList;

    private void Awake()
    {
        
        GameStateManager.Instance.GameStatePlaying.OnExecute += CheckMergeStatus;
    }
    
    private void Start()
    {
        SetCarParkour();
    }

    public void SetCarParkour()
    {
        for (int i = 0; i < cars.Count; i++)
        {
            cars[i].GetComponent<PathFollower>().pathCreator = ParkourManager.Instance.currentParkour;
        }
    }

    public void SetCarSpeed(float speed)
    {
        for (int i = 0; i < cars.Count; i++)
        {
            cars[i].SetSpeed(speed);
        }
    }

    public void AddCar()
    {
        GameObject spawnIdlePos = GameObject.FindGameObjectWithTag("SpawnIdlePos");
        var carObj = AkaliPoolManager.Instance.Dequeue<Car>();
        carObj.transform.SetParent(transform);
        carObj.GetComponent<PathFollower>().pathCreator = ParkourManager.Instance.currentParkour;
        idleCarList.Add(carObj.GetComponent<Car>());
        carObj.transform.position = spawnIdlePos.transform.position;
    }

    public void CheckMergeStatus()
    {
        for (int i = 1; i < 7; i++)
        {
            var counter = cars.Count(x => x.GetComponent<Car>().carLevel.Equals(i));

            if (counter >= 3)
            {
                canMerge = true;
                break;
            }
        }
    }

    public IEnumerator MergeCarAnim()
    {
        for (int i = 1; i < 7; i++)
        {
            var matchList = cars.FindAll(match => match.carLevel == i).ToList();
            if (matchList.Count >= 3 && canMerge)
            {
                for (var l = 0; l <= 2; l++)
                {
                    GameObject mergePos = GameObject.FindGameObjectWithTag("MergePos"); 
                    matchList[l].transform.SetParent(null);
                    matchList[l].GetComponent<PathFollower>().pathCreator = null;
                    cars.Remove(matchList[l]);
                    matchList[l].transform.DOMove(mergePos.transform.position,0.7f).SetEase(Ease.OutBounce);
                }
                yield return new WaitForSeconds(0.7f);
                for (int j = 0; j <= 2; j++)
                {
                    AkaliPoolManager.Instance.Enqueue<Car>(matchList[j].gameObject);
                }
                //matchList.ForEach(obj => cars.Remove(obj));
                var carObj = AkaliPoolManager.Instance.Dequeue<Car>();
                carObj.transform.SetParent(transform);
                carObj.GetComponent<Car>().carLevel = i + 1;
                carObj.GetComponent<Car>().SetLevel();
                idleCarList.Add(carObj.GetComponent<Car>());
                SetCarParkour();
                canMerge = false;
                StartCoroutine(Spawner.Instance.SetCarIdleToParkour());
                MergeCar.Instance.button.enabled = true;
                break;
            }
        }
        
        
    }
}

