using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            other.gameObject.GetComponentInParent<PlayerMovement>().DeleteCopy();
        }
    }
}
