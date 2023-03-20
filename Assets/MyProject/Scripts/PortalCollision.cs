using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    // Attributs:
    private PlayerTeleport _pt;

    // Méthodes privées:
    private void Start()
    {
        _pt = GetComponent<PlayerTeleport>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            _pt.Teleport();
        }
    }
}
