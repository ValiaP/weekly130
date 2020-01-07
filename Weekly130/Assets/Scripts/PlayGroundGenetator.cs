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
                if (x<5 || z<5)
                {
                    Instantiate(GroundPlanePrefab, new Vector3(x, 1, z), Quaternion.identity); //阻止出生点产生障碍物
                }
                else
                {
                    Instantiate(GetPlanePrefab(), new Vector3(x, 1, z), Quaternion.identity);
                }
            }
        }
        GameObject wall00 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject wall01 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject wall02 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject wall03 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall00.transform.position = new Vector3(GroundLenght/2 - 0.5f, 2.5f, -1);
        wall00.transform.localScale = new Vector3(GroundLenght, 5, 1);
        wall01.transform.position = new Vector3(GroundLenght/2 - 0.5f, 2.5f, GroundLenght);
        wall01.transform.localScale = new Vector3(GroundLenght, 5, 1);
        wall02.transform.position = new Vector3(-1, 2.5f, GroundLenght/2 - 0.5f);
        wall02.transform.localScale = new Vector3(1, 5, GroundLenght + 2);
        wall03.transform.position = new Vector3(GroundLenght, 2.5f, GroundLenght/2 - 0.5f);
        wall03.transform.localScale = new Vector3(1, 5, GroundLenght + 2);                          //场景四边的墙面
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
