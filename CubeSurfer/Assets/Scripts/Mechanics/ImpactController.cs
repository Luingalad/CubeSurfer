using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactController : MonoBehaviour
{
    public ArrayController arrayController;
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (arrayController == null) return;

        if(other.CompareTag("RewardCube"))
        {
            other.isTrigger = false;
            other.GetComponent<Rigidbody>().isKinematic = false;
            arrayController.AddCube(other.transform);
        }

        else if(other.CompareTag("CubeArray"))
        {
            other.isTrigger = false;

            var children = other.GetComponentsInChildren<Rigidbody>();
            foreach(var rb in children)
            {
                rb.isKinematic = false;
                arrayController.AddCube(rb.transform);
            }

            Destroy(other.gameObject);
        }

        else if(other.CompareTag("ObstacleCube"))
        {
            if (Mathf.Abs(other.transform.position.y - transform.position.y) < 0.3f)
            {
                other.isTrigger = false;
                arrayController.RemoveCube(transform);
                arrayController = null;
            }
        }

        else if(other.CompareTag("Ladder"))
        {
            if (Mathf.Abs(other.transform.position.y - transform.position.y) < 0.3f)
            {
                other.isTrigger = false;
                arrayController.LadderCollision(transform);
                arrayController = null;
            }

            if(other.name.Equals("Collider"))
            {
                print(Mathf.Abs(other.transform.position.y - transform.position.y));
                print(other.transform.position);
            }
        }

        else if(other.CompareTag("HugeFinal"))
        {
            if(Mathf.Abs(other.transform.position.y - transform.position.y) < 0.3f)
            {
                other.enabled = false;
                arrayController.HugeFinal();
            }
        }

        else if(other.CompareTag("Reward"))
        {
            other.enabled = false;
            other.GetComponent<RewardCrystalController>().RewardGained();
            UIController.instance.SpawnCyrstalImage(other.transform);
            Destroy(other.gameObject);
        }
    }
}
