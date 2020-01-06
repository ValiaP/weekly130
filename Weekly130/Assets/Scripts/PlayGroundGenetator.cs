using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGroundGenetator : MonoBehaviour
{
    public GameObject GroundPlanePrefab;    //普通地板
    public GameObject ObstaclePrefab;       //障碍物
    public int GroundLenght = 50;           //长度

    void Start()
    {
        for( var x = 0; x < GroundLenght; x++)
        {
            for(var z = 0; z <GroundLenght; z++)
            {
                Instantiate(GetPlanePrefab(), new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }

    private GameObject GetPlanePrefab()
    {
        int GroundChange = (int)Random.Range(0,10);
        if (GroundChange > 8)
        {
            return ObstaclePrefab;
        }
        else
        {
            return GroundPlanePrefab;
        }
    }

}
