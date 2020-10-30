using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCrystalController : MonoBehaviour
{
    public void RewardGained()
    {
        FindObjectOfType<LevelController>().EarnCrystal();
        transform.parent = GameObject.Find("UICanvas").transform;
    }

}
