using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private CatchingPlayer _catchingPlayer;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Start()
    {
        _catchingPlayer = GetComponent<CatchingPlayer>();
    }

    // Gestion de la collision, si l'obstacle téléporte un objet.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _catchingPlayer.CaughtPlayer();
            GetComponent<ObjectTeleport>().Teleport();
        }
    }
}
