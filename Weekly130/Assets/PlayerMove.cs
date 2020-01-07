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
    static public float Hp=50000;
    public GameObject HpTitle;

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "NormalFloor")
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
            transform.position = new Vector3(0, 4, 0);
            Hp = 50000;
        }

        /*  UI显示 HP  */
        HpTitle.GetComponent<Text>().text = $"{Hp}";
    }



}

