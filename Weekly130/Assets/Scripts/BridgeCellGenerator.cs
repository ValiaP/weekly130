using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCellGenerator : MonoBehaviour
{
    public GameObject MyObj;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(MyObj.CompareTag("NormalCell"))
            {
                MyObj.tag = "TrackCell";
            }
        }
    }

}
