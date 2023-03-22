using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    /* ---------------------
     * Attributs:
     * ---------------------
     */
    private bool _playerHasKey = false;

    [Header("References")]
    [SerializeField] private Transform _inventory;

    /* ---------------------
     * Méthodes privées:
     * ---------------------
     */
    private void FixedUpdate()
    {
        if (_playerHasKey)
            FollowThePlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        // S'assurer que le joueur ne trigger pas la zone, quand la clé est dans l'inventaire.
        if (other.gameObject.tag == "Player" && !_playerHasKey)
            _playerHasKey = true;
    }

    // La clé suit le joueur, seulement si celui-ci la possède.
    private void FollowThePlayer() 
    {
        Transform keyTransform = GetComponent<Transform>();

        keyTransform.position = _inventory.position;
        keyTransform.rotation = _inventory.rotation;
    }
}
