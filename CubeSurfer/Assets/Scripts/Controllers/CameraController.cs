using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("During Game")]
    public Transform playerTransform;
    public float DistanceZ;
    [Header("Game End Animation")]
    [Tooltip("Angle/second")]
    public float RotateAnimationRate;
    private bool isGameEnd;    

    private void LateUpdate()
    {
        if (!isGameEnd)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z + DistanceZ);
        }
        else
        {
            //game over animations
            LevelOverAnimation();
        }
    }

    private void LevelOverAnimation()
    {
        transform.RotateAround(playerTransform.position, Vector3.up, -RotateAnimationRate * Time.deltaTime);

        Quaternion OriginalRot = transform.rotation;
        transform.LookAt(PlayerEffects.instance.transform);
        Quaternion NewRot = transform.rotation;
        transform.rotation = OriginalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, RotateAnimationRate * Time.deltaTime / 4f);
    }

    public void LevelOver()
    {
        isGameEnd = true;
    }    
}
