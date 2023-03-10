using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ObstacleCollision : MonoBehaviour
{
    // Attributs:
    private bool _playerCaught = false;

    private ObstacleMovement _om;

    [Header("References")]
    [SerializeField] private Material _playerCaughtMat;

    [Header("Type")]
    [SerializeField] private bool _isGuard;

    // Méthodes privées:
    private void Start()
    {
        _om = GetComponent<ObstacleMovement>();
    }

    // Gestion des collisions physiques.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            CaughtPlayer();
    }

    // Gestion des collisions d'entrées.
    private void OnTriggerEnter(Collider other)
    {
        // Le garde voit une copie.
        if (other.gameObject.tag == "Copy")
            _om.SetCanMove(false);

        // Le garde voit le joueur.
        if (other.gameObject.tag == "Player")
            CaughtPlayer();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Copy" && !_playerCaught)
            _om.SetCanMove(true);
    }

    private void CaughtPlayer()
    {
        _playerCaught = true;
        _om.SetCanMove(false);

        gameObject.GetComponentInChildren<MeshRenderer>().material = _playerCaughtMat;

        if(_isGuard)
            gameObject.GetComponentInChildren<Light>().color = Color.red;
    }
}
