using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    public enum type
    {
        ending,
        hp,
        mainhp
    }

    public float AddAmount = 10;


    public type Type;


    public GameEnd GameEnd;

    public bool Eaten = false;


    private void OnTriggerEnter(Collider other)
    {
        if (Eaten)
            return;

        if (other.gameObject.tag == "Player")
        {
            switch (Type)
            {
                case type.ending:
                    GameEnd.End(true);
                    other.gameObject.GetComponent<PlayerMove>().WinSound();
                    break;
                case type.hp:
                    other.gameObject.GetComponent<PlayerMove>().Hp += AddAmount;
                    other.gameObject.GetComponent<PlayerMove>().PiaoZi(AddAmount);
                    Destroy(gameObject);
                    break;
                case type.mainhp:
                    other.gameObject.GetComponent<PlayerMove>().MainHp += AddAmount;
                    other.gameObject.GetComponent<PlayerMove>().PiaoZi(AddAmount);
                    Destroy(gameObject);
                    break;
            }
            other.gameObject.GetComponent<PlayerMove>().EatSound();
            Eaten = true;
        }
       

       
    }
}
