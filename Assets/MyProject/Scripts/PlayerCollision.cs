using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Guard") 
        {
            collision.gameObject.GetComponent<GuardPatrol>().SetCaughtSomeone(true);
            collision.gameObject.GetComponent<GuardPatrol>().CaughtSomeone();
        }
    }
}
