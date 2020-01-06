using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCellGenerator : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(this.CompareTag("NormalCell"))
            {
                this.tag = "TrackCell";                                 //标记为拖尾块
                Material[] materials = new Material[]
                {
                    Resources.Load("Res/Materials/TrackMapCell") as Material,
                };
                this.GetComponent<MeshRenderer>().materials = materials; //替换材质
            }
        }
    }

}
