using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeedNormal=10;
    public float MoveSpeedDead=1;
    Vector3 PlayerVector;
    public Transform North;
    public float Hp=2000;
    public float HpMax=2000;
    public GameObject HpTitle;
    public GameObject HpTitle2;
    public float MainHp=10000;

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "NormalFloor" || collider.tag == "TrackCell")
        {
            MoveSpeedNormal = 10;
            MoveSpeedDead = 1;

        }
        if (collider.tag == "DeadFloor")
        {
            MoveSpeedNormal = 1;
            MoveSpeedDead = 20;

        }
    }

    void Update()
    {
        /* 设置移动 */
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeedNormal* MoveSpeedDead);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * MoveSpeedNormal * MoveSpeedDead);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeedNormal * MoveSpeedDead);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * MoveSpeedNormal * MoveSpeedDead);
        }

        /* 保持朝向，临时 */
        transform.LookAt(North);

        /* 锁XYZ轴不动 */
        if (transform.localEulerAngles.x != 0 || transform.localEulerAngles.y != 0 || transform.localEulerAngles.z != 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        /* 移动扣除燃料 */

        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {

         
                Hp -= 1 * MoveSpeedNormal * MoveSpeedDead;
                Debug.Log(Hp);
          
        }

        /* 燃料用完，死亡 */
        if (Hp < 0)
        {
            Die();
        }

        /*  UI显示 HP  */
        HpTitle.GetComponent<Text>().text = $"{Hp}";
        //HpTitle2.GetComponent<Text>().text = $"{MainHp}";
        
    }

    public void Die()
    {
        //转换tag
        var cells = GameObject.FindGameObjectsWithTag("TrackCell");

        foreach(var cell in cells)
        {
            cell.GetComponent<BridgeCellGenerator>().Die();
        }

        Rebirth();
    }

    void Rebirth()
    {
        //
        transform.position = new Vector3(0, 1.6f, 0);
        Hp = HpMax;
        MainHp -= HpMax;
    }
    private void Start()
    {
        Hp = HpMax;
    }
}

