using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCollision : MonoBehaviour
{
    // Attributs:
    private PlayerTeleport _playerTeleport;
    private LevelManager _levelManager;

    // M�thodes priv�es:
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

                // R�cup�ration de l'index de la sc�ne active.
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
