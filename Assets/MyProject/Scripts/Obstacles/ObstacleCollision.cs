using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ObstacleCollision : MonoBehaviour
{
    // Attributs:
    private bool _playerCaught = false;

    private ObstacleMovement _obstacleMovement;
    private LevelManager _levelManager;

    [Header("References")]
    [SerializeField] private Material _playerCaughtMat;

    [Header("Type")]
    [SerializeField] private bool _movable;
    [SerializeField] private bool _isGuard;

    // Méthodes privées:
    private void Start()
    {
        _obstacleMovement = GetComponent<ObstacleMovement>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    // Gestion des collisions physiques.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_playerCaught)
            CaughtPlayer();
    }

    // Gestion des collisions d'entrées.
    private void OnTriggerEnter(Collider other)
    {
        // Le garde voit une copie.
        if (other.gameObject.tag == "Copy")
            _obstacleMovement.SetCanMove(false);

        // Le garde voit le joueur.
        if (other.gameObject.tag == "Player" && !_playerCaught)
            CaughtPlayer();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Copy" && !_playerCaught)
            _obstacleMovement.SetCanMove(true);
    }

    private void CaughtPlayer()
    {
        _playerCaught = true;

        if (!_movable)
            GetComponent<PlayerTeleport>().Teleport();
        else
            _obstacleMovement.SetCanMove(false);

        gameObject.GetComponentInChildren<MeshRenderer>().material = _playerCaughtMat;

        if(_isGuard)
            gameObject.GetComponentInChildren<Light>().color = Color.red;

        _levelManager.SubTime();
    }
}
