using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCellGenerator : MonoBehaviour
{

    public GameObject Ground;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("检测到进入");
            if(this.gameObject.tag == "NormalCell")
            {
                this.tag = "TrackCell";                                 //标记为拖尾块
                Debug.Log("更改区块为拖尾块");
                Material[] materials = new Material[]
                {
                    Resources.Load("Res/Materials/TrackMapCell") as Material,
                };
                Ground.GetComponent<MeshRenderer>().materials = materials; //替换材质
                Debug.Log("更改区块地板材质");
            }
        }
    }

}
