using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayController : MonoBehaviour
{
    public List<Transform> Array;
    public string PlayerTag;

    public Transform cubeParent;
    public Transform LostCubeParent;

    private int BonusMultiplier = 0;
    private bool isSucceed = false;

    public PlayerEffects playerEffects;

    void Start()
    { 
        foreach(var tr in Array)
        {
            ImpactController cont = tr.GetComponent<ImpactController>();
            if(cont != null)
            {
                cont.arrayController = this;
                tr.tag = PlayerTag;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCube(Transform cube)
    {
        foreach(var tr in Array)
        {
            tr.Translate(Vector3.up);
        }

        cube.tag = PlayerTag;
        cube.GetComponent<ImpactController>().arrayController = this;
        cube.parent = transform;
        cube.localPosition = Vector3.up;
        Array.Add(cube);

        if(PlayerEffects.instance != null) PlayerEffects.instance.AddCubeEffect();
    }

    public void RemoveCube(Transform cube)
    {
        RemovingCube(cube);
    }

    public void LadderCollision(Transform cube)
    {
        if (!isSucceed) isSucceed = true;
        RemovingCube(cube);
        BonusMultiplier++;

        Camera.main.GetComponent<CameraSmoothTranslate>().CameraSmoothMoveUp();
    }

    private void RemovingCube(Transform cube)
    {
        cube.parent = LostCubeParent;
        Array.Remove(cube);

        if (Array.Count < 2)
        {
            FindObjectOfType<LevelController>().LevelOver(BonusMultiplier, isSucceed);
        }
    }

    public void HugeFinal()
    {
        FindObjectOfType<LevelController>().LevelOver(BonusMultiplier, isSucceed);
    }


}
