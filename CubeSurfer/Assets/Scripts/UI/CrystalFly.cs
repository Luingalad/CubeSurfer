using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalFly : MonoBehaviour
{
    public float flyDuration;
    private float _currentFlyDuration = 0;

    private bool isFling;
    private Vector3 targetLoc;
    private Vector3 startLoc;

    void Start()
    {
        
    }

    void Update()
    {
        if(isFling && _currentFlyDuration < flyDuration)
        {
            transform.position += (targetLoc - startLoc) * _currentFlyDuration / flyDuration;
            _currentFlyDuration += Time.deltaTime;
        }
        else if(_currentFlyDuration > flyDuration)
        {
            isFling = false;
            GameController.instance.EarnCrystals();
            Destroy(gameObject);
        }
    }

    public void StartSpriteFly(Transform crystalLoc, Transform targetLoc)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(crystalLoc.position);
        transform.position = screenPos;
        startLoc = screenPos;

        this.targetLoc = targetLoc.position;
        isFling = true;
    }
}
