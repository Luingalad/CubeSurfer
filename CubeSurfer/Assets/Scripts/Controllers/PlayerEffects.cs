using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public ParticleSystem AddCubeParticle;
    public ParticleSystem FinalWithBonusParticle;

    #region Singleton

    public static PlayerEffects instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if( transform.position.y - collision.transform.position.y > .5f)
            {
                print("Grounded");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.y - collision.transform.position.y > .5f)
            {
                print("Flying");
            }
        }
    }

    public void AddCubeEffect()
    {
        AddCubeParticle.Play();
    }

    public void FinalWithBonusEffect()
    {
        FinalWithBonusParticle.Play();
    }
}
