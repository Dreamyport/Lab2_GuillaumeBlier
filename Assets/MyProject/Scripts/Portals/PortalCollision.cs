using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCollision : MonoBehaviour
{
    // Attributs:
    private PlayerTeleport _playerTeleport;
    private LevelManager _levelManager;

    // Méthodes privées:
    private void Start()
    {
        _playerTeleport = GetComponent<PlayerTeleport>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            if (this.gameObject.tag == "Portal")
            {
                _levelManager.LevelStatistics();

                // Récupération de l'index de la scène active.
                int indexScene = SceneManager.GetActiveScene().buildIndex;

                if (indexScene == 2)
                    _levelManager.GameOver();
                else
                    SceneManager.LoadScene(indexScene + 1);
            }
            else
            {
                _playerTeleport.Teleport();
            }
        }
    }
}
