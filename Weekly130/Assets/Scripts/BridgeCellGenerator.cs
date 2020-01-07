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
                this.tag = "TrackCell";                                 //标记为拖尾块
                Debug.Log("更改区块为拖尾块");
                Material mat = AssetDatabase.LoadAssetAtPath<Material>("Assets/Res/Materials/TrackMapCell.mat");
                Ground.GetComponent<MeshRenderer>().sharedMaterial = mat;
            }
        }
    }

}
