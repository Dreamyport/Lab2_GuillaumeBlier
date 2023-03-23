using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void OnTriggerEnter(Collider other) 
    {
        // On désactive les éléments lorsque la clé entre en contact avec la porte.
        if (other.gameObject.tag == "Key") 
        {
            transform.parent.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
