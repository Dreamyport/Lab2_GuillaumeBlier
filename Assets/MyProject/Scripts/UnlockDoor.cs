using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.gameObject.tag == "Key") 
        {
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
        }
    }
}
