using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
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

    // Désactive l'objet et ajoute 1 au compteur du temps gagné.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            gameObject.SetActive(false);
            _levelManager.AddTime();
        }
    }
}
