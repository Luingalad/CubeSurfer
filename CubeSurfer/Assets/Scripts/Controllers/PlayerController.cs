using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGameStart = false;

    public float MovementSpeed;

    private Vector3 _oldMousePosition;
    public float MouseSensitivity;

    void Update()
    {
        if(isGameStart)
        {            
            FixedMove();
            InputMove();
        }
        _oldMousePosition = Input.mousePosition;
    }

    private float DeltaMousePosition()
    {
        Vector3 delta = Input.mousePosition - _oldMousePosition;        
        return delta.x * MouseSensitivity;
    }

    private void CheckPosition()
    {
        if (transform.position.x > 2f)
        {
            transform.position = new Vector3(2f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -2f)
        {
            transform.position = new Vector3(-2f, transform.position.y, transform.position.z);
        }
    }

    private void InputMove()
    {
#if UNITY_EDITOR
        if(Input.GetAxis("Fire1") > .5f)
        {
            transform.Translate(Vector3.left * DeltaMousePosition());
            CheckPosition();
        }
#elif UNITY_ANDROID || UNITY_IOS
        if(Input.touchCount > 0)
        {
            float deltaTouchX = Input.touches[0].deltaPosition.x * MouseSensitivity;
            transform.Translate(Vector3.left * deltaTouchX);
            CheckPosition();
        }
#endif
    }

    private void FixedMove()
    {
        transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);
    }

    public void LevelStart()
    {
        isGameStart = true;
    }
    public void LevelOver()
    {
        isGameStart = false;
    }

}
