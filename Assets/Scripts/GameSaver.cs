using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Akali.Scripts.Utilities;
using PathCreation.Examples;
using PlayerPrefs = UnityEngine.PlayerPrefs;

public class GameSaver : MonoBehaviour
{
    private float timer = 1;
    private const float SaveInterval = 1; 
    [SerializeField] private GameObject carPrefab;

    private void Start()
    {
        LoadGameData();
    }

    private void Update()
    {
        CallGameDataSave();
    }

    private void CallGameDataSave()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SaveGameData();
            timer = SaveInterval;
        }
    }

    private static CarData GetCarData (Car car)
    {
        return new CarData
        {
            carLevel = car.carLevel,
            carPosition = car.transform.position,
            carDistanceTraveled = car.GetComponent<PathFollower>().distanceTravelled,
        };
    }

    void SaveGameData()
    {
        //find all cars on scene
        var carDataOnScene = new List<CarData>();
    
        Car [] cars = FindObjectsOfType<Car>();
    
        if(cars.Length.Equals(0)) return;
    
        foreach (var car in cars)
        {
            carDataOnScene.Add(GetCarData(car));
        }
        
        //Copy cars to the serializable list
        var carDataList = new CarDataList
        {
            carDataList = carDataOnScene
        };

        PlayerPrefs.SetString(Constants.PrefsCarDataList, JsonUtility.ToJson(carDataList));
    
        PlayerPrefs.Save();
    }
    
    void LoadGameData()
    {
        var carDataList = JsonUtility.FromJson<CarDataList>(PlayerPrefs.GetString(Constants.PrefsCarDataList));

        if (carDataList == null)
        {
            CarManager.Instance.AddCar();
            return;
        } 
        
        //Load all cars
        var carDatas = carDataList.carDataList;
    
        foreach (var carData in carDatas)
        {
            GameObject carOnScene = Instantiate(carPrefab, carData.carPosition, Quaternion.identity);
            var carScript = carOnScene.GetComponent<Car>();
            carScript.carLevel = carData.carLevel;
            carScript.SetLevel();
            
            carOnScene.GetComponent<PathFollower>().distanceTravelled = carData.carDistanceTraveled;

            carOnScene.transform.SetParent(CarManager.Instance.transform);
            CarManager.Instance.cars.Add(carOnScene.GetComponent<Car>());
        } 
    
    }
}

[Serializable]
public class CarData
{
    public int carLevel;
    public Vector3 carPosition;
    public float carDistanceTraveled;
}

[Serializable]
public class CarDataList
{
    public List<CarData> carDataList;
}