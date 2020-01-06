using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    Vector3 PlayerVector;
    public Transform North;
    void Update()
    {
        /* 设置移动 */
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
        }

        /* 保持朝向，临时 */
        transform.LookAt(North);

        /* 锁XYZ轴不动 */
        if (transform.localEulerAngles.x != 0 || transform.localEulerAngles.y != 0 || transform.localEulerAngles.z != 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

   
    }
}

