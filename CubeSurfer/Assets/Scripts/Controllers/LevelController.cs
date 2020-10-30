using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private bool isLevelStarted = false;

    private int EarnedCrystalCount = 0;

    private PlayerController playerController;
    public Transform LastFinishLine;

    private float StartZvalue;
    private float FinishZvalue;

    [Header("Level Settings")]
    public int MaxLadderLevel;
    public int HugeBonus;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        StartZvalue = playerController.transform.position.z;
        FinishZvalue = LastFinishLine.position.z;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if(Input.GetAxis("Fire1") > .5f && !isLevelStarted)
        {
            LevelStart();
            UIController.instance.GameStart();
        }

        if(isLevelStarted)
        {
            float ratio = Mathf.Abs(playerController.transform.position.z - StartZvalue) / Mathf.Abs(FinishZvalue - StartZvalue);
            UIController.instance.UpdateDistanceSlider(ratio);
        }
    }

    public void LevelOver(int Bonus, bool isSucceed)
    {
        if(isSucceed)
        {
            Debug.Log("Yupppiiii!! " + Bonus);
            if (Bonus > MaxLadderLevel) Bonus = HugeBonus;
            GameController.instance.EarnCrystals(Bonus * EarnedCrystalCount);
            EarnedCrystalCount += EarnedCrystalCount * Bonus;

            if (PlayerEffects.instance != null) PlayerEffects.instance.FinalWithBonusEffect();
            Camera.main.GetComponent<CameraController>().LevelOver();            
        }
        else
        {
            Debug.Log("Yenildiniz...");
        }

        UIController.instance.ShowEndGameUI(isSucceed, EarnedCrystalCount, Bonus);
        FindObjectOfType<PlayerController>().LevelOver();
    }

    public void LevelStart()
    {
        isLevelStarted = true;
        FindObjectOfType<PlayerController>().LevelStart();
    }

    public void EarnCrystal()
    {
        EarnedCrystalCount++;
    }
}
