using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BridgeCellGenerator : MonoBehaviour
{

    public GameObject Ground;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "NormalCell")
            {
                Tracked();
            }
        }
    }

    public void Tracked()
    {
        this.tag = "TrackCell";                                 
        Debug.Log("更改区块为拖尾块");
        Material mat = Resources.Load<Material>("Materials/TrackMapCell");
        Ground.GetComponent<MeshRenderer>().sharedMaterial = mat;
    }
    public void Die()
    {
        gameObject.tag = "DeadFloor";

        Material mat = Resources.Load<Material>("Materials/DeadFloor");
        Ground.GetComponent<MeshRenderer>().sharedMaterial = mat;
    }
}
