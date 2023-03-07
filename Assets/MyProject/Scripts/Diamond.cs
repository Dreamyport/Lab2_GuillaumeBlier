using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // M�thodes priv�es:
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject);
        }
    }
}
