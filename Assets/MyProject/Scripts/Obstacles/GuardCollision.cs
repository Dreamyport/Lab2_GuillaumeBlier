using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCollision : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private ObstacleMovement _obstacleMovement;
    private CatchingPlayer _catchingPlayer;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Start()
    {
        _obstacleMovement = GetComponent<ObstacleMovement>();
        _catchingPlayer = GetComponent<CatchingPlayer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Le joueur entre en collision avec le garde.
        if (collision.gameObject.tag == "Player" && !_catchingPlayer.GetPlayerCaught())
            GuardDeactivation();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Le garde voit une copie.
        if (other.gameObject.tag == "Copy")
            _obstacleMovement.SetCanMove(false);

        // Le garde voit le joueur.
        if (other.gameObject.tag == "Player" && !_catchingPlayer.GetPlayerCaught())
            GuardDeactivation();
    }

    private void OnTriggerExit(Collider other)
    {
        // Le garde ne voit plus la copie. Si le joueur quitte, rien ne se passe.
        if (other.gameObject.tag == "Copy" && !_catchingPlayer.GetPlayerCaught())
            _obstacleMovement.SetCanMove(true);
    }

    private void GuardDeactivation() 
    {
        // Désactivation du garde.
        _catchingPlayer.CaughtPlayer();
        _obstacleMovement.SetCanMove(false);
        gameObject.GetComponentInChildren<Light>().color = Color.red;
    }
}
