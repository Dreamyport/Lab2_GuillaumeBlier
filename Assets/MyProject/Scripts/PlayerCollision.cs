using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Guard" || collision.gameObject.tag == "GuardBody") 
        {
            collision.gameObject.GetComponent<GuardPatrol>().SetCaughtSomeone(true);
            collision.gameObject.GetComponent<GuardPatrol>().CaughtSomeone();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Guard" || other.gameObject.tag == "GuardBody")
        {
            other.gameObject.GetComponent<GuardPatrol>().SetCaughtSomeone(true);
            other.gameObject.GetComponent<GuardPatrol>().CaughtSomeone();
        }
    }
}
