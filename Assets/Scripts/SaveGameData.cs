using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Akali.Scripts.Managers;
using Unity.VisualScripting;

public class SaveGameData : Akali.Common.Singleton<SaveGameData>
{
    string path;
    string[] sa;
    string[] sa2;
    float[] loc;

    int i;

    void Start()
    {
        InvokeRepeating("UpdateSaveFile",0,1);
        path = "c:/Save Info/";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        path = path + "save.txt";

        if (File.Exists(path))
        {
            loc = new float[3];
            sa2 = File.ReadAllText(path).Split("-"[0]);
            i = sa2.Length;
            while(i>0)
            {
                i--;
                sa = sa2[i].Split ("," [0]);
                int i2  = 3; while (i2>0)
                {
                    i2--; 
                    float.TryParse (sa [i2], out loc [i2]);
                    
                }
                for (int j = 0; j < loc[3]; j++)
                {
                    GameObject spawnIdlePos = GameObject.FindGameObjectWithTag("SpawnIdlePos");
                    var carObj = AkaliPoolManager.Instance.Dequeue<Car>();
                    carObj.transform.SetParent(transform);
                    CarManager.Instance.idleCarList.Add(carObj.GetComponent<Car>());
                    CarManager.Instance.SetIdleCarPos(spawnIdlePos.transform.position);
                    StartCoroutine(Spawner.Instance.SetCarIdleToParkour());
                    CarManager.Instance.cars[j].carLevel = (int)loc[2];
                }
            }
            
        }
        
    }


    void UpdateSaveFile()
    {
        print("saving");
        i = 0;
        string txt = "";
        while (i < CarManager.Instance.cars.Count) 
        { 
            if (i != 0) 
            { 
                txt = txt + "-";
            }

            txt = txt + CarManager.Instance.cars[i].transform.position.x +
                  "," + CarManager.Instance.cars[i].carLevel +
                  "," + CarManager.Instance.cars.Count;

            i++;
        }
        File.WriteAllText(path, txt);
    }
}

