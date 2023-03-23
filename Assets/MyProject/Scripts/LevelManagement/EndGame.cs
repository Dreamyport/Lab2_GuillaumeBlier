using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private LevelManager _levelManager;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
       // À chaque niveau, on met à jour les statistiques du joueur et on change de scène.
        if (other.gameObject.tag == "Player")
        {
            _levelManager.LevelStatistics();

            int indexScene = SceneManager.GetActiveScene().buildIndex;

            // Si c'est le dernier niveau, on met fin à la partie.
            if (indexScene == 2)
                _levelManager.GameOver();
            else
                SceneManager.LoadScene(indexScene + 1);
        }
        
    }
}
