using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private ObjectTeleport _player;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Start()
    {
        _player = GetComponent<ObjectTeleport>();
    }

    // Méthode qui appelle la fonction de téléportation.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            _player.Teleport();
        }
    }
}
