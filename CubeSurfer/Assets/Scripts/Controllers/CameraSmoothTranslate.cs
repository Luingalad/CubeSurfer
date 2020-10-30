using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothTranslate : MonoBehaviour
{
    private bool isTranslating;

    public float TranslateDuration;
    private float _translateDuration;

    void Update()
    {
        if(isTranslating && _translateDuration < TranslateDuration)
        {
            transform.Translate(Vector3.up * Time.deltaTime / TranslateDuration);
            _translateDuration += Time.deltaTime;
        }
        else if(_translateDuration >= TranslateDuration)
        {
            isTranslating = false;
            _translateDuration = 0f;
        }
    }

    public void CameraSmoothMoveUp()
    {
        _translateDuration = 0;
        isTranslating = true;        
    }
}
