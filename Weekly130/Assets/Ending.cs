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
                    break;
                case type.hp:
                    other.gameObject.GetComponent<PlayerMove>().Hp += AddAmount;
                    Destroy(gameObject);
                    break;
                case type.mainhp:
                    other.gameObject.GetComponent<PlayerMove>().MainHp += AddAmount;
                    Destroy(gameObject);
                    break;
            }
            Eaten = true;
        }
       

       
    }
}
