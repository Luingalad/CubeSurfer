using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [NonSerialized]
    public int crystalCount;

    //Başka bir script tarafından kullanılır.
    public Transform CrystalTarget;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void EarnCrystals(int count)
    {
        crystalCount += count;
        UIController.instance.UpdateCrystalCounter();
    }

    public void EarnCrystals()
    {
        crystalCount++;
        UIController.instance.UpdateCrystalCounter();
    }

}
