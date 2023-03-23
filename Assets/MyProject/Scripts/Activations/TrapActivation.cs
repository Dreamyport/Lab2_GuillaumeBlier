using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    [Header("References")]
    [SerializeField] private GameObject[] _traps;
    [SerializeField] private GameObject[] _blockades;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void OnTriggerEnter(Collider other)
    {
        // On active les pièges et les objets bloquants le joueur de sortir.
        if (other.gameObject.tag == "Player") 
        {
            foreach (GameObject trap in _traps)
                trap.SetActive(true);

            foreach (GameObject blockade in _blockades)
                blockade.SetActive(true);
        }
    }
}
