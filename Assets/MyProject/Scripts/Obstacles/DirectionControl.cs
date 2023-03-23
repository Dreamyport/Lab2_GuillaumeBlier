using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionControl : MonoBehaviour
{
    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void OnTriggerEnter(Collider other) 
    {
        // Change la direction d'un obstacle ou d'un garde dans un mouvement de va-et-viens. 
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "GuardBody") 
            other.gameObject.GetComponentInParent<ObstacleMovement>().ChangeDirection();
    }
}
