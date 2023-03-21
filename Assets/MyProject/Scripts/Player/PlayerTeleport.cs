using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _teleportObject;
    [SerializeField] private Transform _teleportLocation;

    // Méthodes publiques:
    public void Teleport() 
    {
        _teleportObject.transform.position = _teleportLocation.position;
    }
}
